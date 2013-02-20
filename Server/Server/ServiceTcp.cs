using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Security.Permissions;
using System.Security;
using Server.Exceptions;

using System.Security.Cryptography;
using System.Configuration;
using System.Data.SqlClient;
using Server.Serializables;

namespace Server
{

    public class ServiceTcp : IServiceTcp
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["Server"].ToString();
        private static StockService.ServiceMsmqClient stockClient = new StockService.ServiceMsmqClient();

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = false)]
        public string DoWork()
        {
            //Get Username
            //Console.WriteLine(OperationContext.Current.IncomingMessageHeaders.GetHeader<string>(0));
            
            //Get Password
            //Console.WriteLine(OperationContext.Current.IncomingMessageHeaders.GetHeader<string>(1));
            //return "Do Some Work";

            return "Work Done! -- Testing";
        }

        #region ServiceTcp Authentication

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public bool Login(string username, string password)
        {
            SHA256 seed = new SHA256Managed();
            byte[] passwordArray = Encoding.UTF8.GetBytes(password);
            passwordArray = seed.ComputeHash(passwordArray);

            string hashedPassword = Convert.ToBase64String(passwordArray);

            SqlConnection sqlConnection = new SqlConnection(connectionString);

            bool result = false;
            try
            {
                sqlConnection.Open();

                //Check if the user exists and password is correct
                SqlCommand sqlCommand = new SqlCommand("SELECT ID, Session FROM client WHERE username = @username AND password = @hashedPassword", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@username", username);
                sqlCommand.Parameters.AddWithValue("@hashedPassword", hashedPassword);

                int id = 0; int counter = 0;
                SqlDataReader sqlReader = sqlCommand.ExecuteReader();

                while (sqlReader.Read())
                {
                    counter++;

                    if (sqlReader["ID"] == DBNull.Value)
                    {
                        return false;
                    }
                    if (sqlReader["Session"] != DBNull.Value)
                    {
                        return true;
                    }
                    id = (int)sqlReader["ID"];
                    break;
                }

                if (counter == 0) return false;
               
                //Generate SessionID
                string sessionID = String.Format("{0}-{1}", username, DateTime.UtcNow.Ticks);
                sessionID = Convert.ToBase64String(seed.ComputeHash(Encoding.UTF8.GetBytes(sessionID)));

                //Update SessionID
                sqlCommand = new SqlCommand("UPDATE client SET session = @sessionID WHERE id = @id", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@sessionID", sessionID);
                sqlCommand.Parameters.AddWithValue("@id", id);

                sqlCommand.ExecuteNonQuery();

                result = true;
            }
            finally
            {
                sqlConnection.Close();
            }

            return result;
        }

        public void Register(string username, string name, string email, string password)
        {
            SHA256 seed = new SHA256Managed();
            
            byte[] passwordArray = Encoding.UTF8.GetBytes(password);
            passwordArray = seed.ComputeHash(passwordArray);

            string hashedPassword = Convert.ToBase64String(passwordArray);

            SqlConnection sqlConnection = new SqlConnection(connectionString);

            try
            {
                sqlConnection.Open();
                
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO client(username, name, email, password) VALUES(@username, @name, @email, @hashedPassword)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@username", username);
                sqlCommand.Parameters.AddWithValue("@name", name);
                sqlCommand.Parameters.AddWithValue("@email", email);
                sqlCommand.Parameters.AddWithValue("@hashedPassword", hashedPassword);

                int rows = sqlCommand.ExecuteNonQuery();

                if (rows != 1) throw new FaultException<GenericException>(
                                new GenericException(),
                                new FaultReason("Error Creating User"));
            }
            finally
            {
                sqlConnection.Close();
            }

        }

        public ClientInfo GetSession(string username)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            ClientInfo result = null;
            try
            {
                sqlConnection.Open();

                //Check if the user exists and password is correct
                SqlCommand sqlCommand = new SqlCommand("SELECT ID, session, Role FROM client WHERE username = @username", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@username", username);
                
                SqlDataReader sqlReader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.SingleRow);
                sqlReader.Read();
                
                result = new ClientInfo
                {
                    ID = (int)sqlReader["ID"],
                    SessionID = (string)sqlReader["session"],
                    Role = (ClientRole)Enum.ToObject(typeof(ClientRole), Convert.ToInt32((bool)sqlReader["Role"]))
                };
                sqlReader.Close();
            }
            finally
            {
                sqlConnection.Close();
            }

            return result;
        }

        #endregion

        #region ServiceTcp BuyAndSell Orders

        public void NewTransaction(TransactionType Type, double Quantity, string StockType)
        {
            int ClientID = GetCurrentClientID();
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            try
            {
                sqlConnection.Open();

                //Check if the user exists and password is correct
                SqlCommand sqlCommand = new SqlCommand(
                    @"INSERT INTO [Transaction] (ClientID, Quantity, StockType, Type)
                      OUTPUT INSERTED.ID
                      VALUES(@ClientID, @Quantity, @StockType, @Type)",
                    sqlConnection);

                sqlCommand.Parameters.AddWithValue("@ClientID", ClientID);
                sqlCommand.Parameters.AddWithValue("@Quantity", Quantity);
                sqlCommand.Parameters.AddWithValue("@StockType", StockType);
                sqlCommand.Parameters.AddWithValue("@Type", Type == TransactionType.Buy ? 0 : 1);

                int id = (int)sqlCommand.ExecuteScalar();
                NotifyStockService(id);
            }
            finally
            {
                sqlConnection.Close();
            }

        }

        public void NewTransaction(string ClientEmail, TransactionType Type, double Quantity, string StockType)
        {
            if (GetCurrentClientRole() != ClientRole.admin)
                throw new FaultException<PermissionDeniedException>(new PermissionDeniedException { Message = "You don't have the required permissions to do this operation" }, new FaultReason("Permission Denied"));
            

            SqlConnection sqlConnection = new SqlConnection(connectionString);

            try
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("SELECT ID FROM Client WHERE email = @ClientEmail", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@ClientEmail", ClientEmail);

                int ClientID = -1;
            
                object clientidobj = sqlCommand.ExecuteScalar();
                if (clientidobj == null)
                {
                    throw new FaultException<GenericException>(new GenericException { Message = "Email not Found" }, new FaultReason("Parameter Error"));
                }

                ClientID = (int)clientidobj;
                
                //Create the transaction
                sqlCommand = new SqlCommand(
                    @"INSERT INTO [Transaction] (ClientID, Quantity, StockType, Type)
                      OUTPUT INSERTED.ID
                      VALUES(@ClientID, @Quantity, @StockType, @Type)",
                    sqlConnection);

                sqlCommand.Parameters.AddWithValue("@ClientID", ClientID);
                sqlCommand.Parameters.AddWithValue("@Quantity", Quantity);
                sqlCommand.Parameters.AddWithValue("@StockType", StockType);
                sqlCommand.Parameters.AddWithValue("@Type", Type == TransactionType.Buy ? 0 : 1);
                
                int id = (int)sqlCommand.ExecuteScalar();

                NotifyStockService(id);
            }
            finally
            {
                sqlConnection.Close();
            }

        }

        public void PerformTransaction(int id, double stockValue)
        {
            if (GetCurrentClientRole() != ClientRole.admin)
                throw new FaultException<PermissionDeniedException>(new PermissionDeniedException { Message = "You don't have the required permissions to do this operation" }, new FaultReason("Permission Denied"));
            

            SqlConnection sqlConnection = new SqlConnection(connectionString);

            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT quantity FROM [Transaction] WHERE ID = @id", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@id", id);

                double quantity = (double)sqlCommand.ExecuteScalar();

                sqlCommand = new SqlCommand(
                    @"UPDATE [Transaction] SET
                        stockValue = @stockvalue,
                        operationValue = @operationvalue,
                        time = GETDATE(),
                        state =  @state WHERE ID = @id", sqlConnection);

                sqlCommand.Parameters.AddWithValue("@stockvalue", stockValue);
                sqlCommand.Parameters.AddWithValue("@operationvalue", stockValue * quantity);
                sqlCommand.Parameters.AddWithValue("@state", (int)TransactionState.Performed);
                sqlCommand.Parameters.AddWithValue("@id", id);

                sqlCommand.ExecuteNonQuery();

                sqlCommand = new SqlCommand(
                    @"SELECT email, name
                        FROM Client, [Transaction]
                        WHERE [Transaction].ID = @transactionid
                          AND [Transaction].ClientID = Client.ID
                    ", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@transactionid", id);

                SqlDataReader sqlReader = sqlCommand.ExecuteReader();
                sqlReader.Read();
                string emailClient = sqlReader["Email"] as string;
                string nameClient = sqlReader["Name"] as string;
                

                Shared.Mail.SendEmail(emailClient, nameClient, "[TDIN] Financial Institute - Transaction Change #" + id,
                    @"You Transaction with ID " + id + " has been performed, please check the system for more details.", false);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public List<Transaction> ListTransaction()
        {

            int ClientID = GetCurrentClientID();
            ClientRole clientRole = GetCurrentClientRole();

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            List<Transaction> result = new List<Transaction>();
            
            try
            {
                sqlConnection.Open();

                //Check if the user exists and password is correct

                string sqlQuery = 
                    @"SELECT [Transaction].ID, [Transaction].ClientID, [Transaction].Quantity, [Transaction].StockType, [Transaction].Time, [Transaction].State, [Transaction].StockValue, [Transaction].OperationValue, [Transaction].[Type], Client.Name as ClientName
                    FROM dbo.[Transaction], dbo.[Client]
                    WHERE [Transaction].ClientID = [Client].ID";

                if (clientRole != ClientRole.admin)
                {
                    sqlQuery += " AND [Transaction].ClientID = " + ClientID;
                }


                SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);

                SqlDataReader sqlReader = sqlCommand.ExecuteReader();
                while (sqlReader.Read())
                {
                    result.Add(new Transaction
                    {
                        ID = (int)sqlReader["ID"],
                        ClientName = (string)sqlReader["ClientName"],
                        StockType = (string)sqlReader["StockType"],
                        Quantity = sqlReader["Quantity"] as double?,
                        State = (TransactionState)Enum.ToObject(typeof(TransactionState), Convert.ToInt32((bool)sqlReader["State"])),
                        Time = (DateTime)sqlReader["Time"],
                        StockValue = sqlReader["StockValue"] as double?,
                        OperationValue = sqlReader["OperationValue"] as double?,
                        Type = (TransactionType)Enum.ToObject(typeof(TransactionType), Convert.ToInt32((bool)sqlReader["Type"]))
                    });
                }

            }
            finally
            {
                sqlConnection.Close();
            }

            return result;
        }

        public List<string> ListClientsEmail()
        {
            if (GetCurrentClientRole() != ClientRole.admin)
                throw new FaultException<PermissionDeniedException>(new PermissionDeniedException { Message = "You don't have the required permissions to do this operation" }, new FaultReason("Permission Denied"));

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            List<string> result = new List<string>();

            try
            {
                sqlConnection.Open();

                //Check if the user exists and password is correct

                string sqlQuery =
                    @"SELECT Email
                    FROM Client";


                SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                SqlDataReader sqlReader = sqlCommand.ExecuteReader();

                while (sqlReader.Read())
                {
                    result.Add((string)sqlReader["Email"]);
                }
            }
            finally
            {
                sqlConnection.Close();
            }

            return result;
        }
        #endregion

        #region ServiceTcp Utils

        private int GetCurrentClientID()
        {
            int ClientIDIndex = OperationContext.Current.IncomingMessageHeaders.FindHeader("ClientID", "");
            if (ClientIDIndex == -1) return -1;

            return OperationContext.Current.IncomingMessageHeaders.GetHeader<int>(ClientIDIndex);
        }

        private ClientRole GetCurrentClientRole()
        {
            int ClientRoleIndex = OperationContext.Current.IncomingMessageHeaders.FindHeader("ClientRole", "");
            if (ClientRoleIndex == -1) return ClientRole.user;

            int role = OperationContext.Current.IncomingMessageHeaders.GetHeader<int>(ClientRoleIndex);
            return (ClientRole)Enum.ToObject(typeof(ClientRole), role);
        }

        private Server.StockService.Transaction GetTransaction(int id)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            Server.StockService.Transaction result = null;
            try
            {
                sqlConnection.Open();

                //Check if the user exists and password is correct

                string sqlQuery =
                    @"SELECT [Transaction].ID, [Transaction].ClientID, [Transaction].Quantity, [Transaction].StockType, [Transaction].Time, [Transaction].State, [Transaction].StockValue, [Transaction].OperationValue, [Transaction].[Type], Client.Name as ClientName
                    FROM dbo.[Transaction], dbo.[Client]
                    WHERE [Transaction].ID = @transactionid AND [Transaction].ClientID = [Client].ID";

                SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@transactionid", id);

                SqlDataReader sqlReader = sqlCommand.ExecuteReader();
                while (sqlReader.Read())
                {
                    result = new Server.StockService.Transaction
                    {
                        ID = (int)sqlReader["ID"],
                        ClientName = (string)sqlReader["ClientName"],
                        StockType = (string)sqlReader["StockType"],
                        Quantity = sqlReader["Quantity"] as double?,
                        State = (Server.StockService.TransactionState)Enum.ToObject(typeof(TransactionState), Convert.ToInt32((bool)sqlReader["State"])),
                        Time = (DateTime)sqlReader["Time"],
                        StockValue = sqlReader["StockValue"] as double?,
                        OperationValue = sqlReader["OperationValue"] as double?,
                        Type = (Server.StockService.TransactionType)Enum.ToObject(typeof(TransactionType), Convert.ToInt32((bool)sqlReader["Type"]))
                    };
                }

            }
            finally
            {
                sqlConnection.Close();
            }

            return result;
        }

        internal void NotifyStockService(int id)
        {
            //Load Transaction
            Server.StockService.Transaction insertedTransaction = GetTransaction(id);
            stockClient.NewTransaction(insertedTransaction);
        }


        #endregion
       
    }

}
