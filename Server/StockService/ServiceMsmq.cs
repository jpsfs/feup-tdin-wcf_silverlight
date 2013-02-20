using System;
using System.Configuration;
using System.Data.SqlClient;
using System.ServiceModel;
using System.Collections.Generic;

namespace StockService
{
    public class ServiceMsmq : IServiceMsmq
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["StockService"].ToString();

        public void doWork(string todo)
        {
            System.Windows.Forms.MessageBox.Show(todo);
        }


        public void NewTransaction(Server.Transaction transaction)
        {
            //Check if the current user exists in the database
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            try
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand(
                    @"INSERT INTO
                        [Transaction](ID, ClientID, ClientName, Quantity, StockType, Time, State, Type)
                        VALUES(@id, @clientid, @clientname, @quantity, @stocktype, @time, @state, @type)", sqlConnection
                    );

                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@id", transaction.ID));
                parameters.Add(new SqlParameter("@clientid", transaction.ClientID));
                parameters.Add(new SqlParameter("@clientname", transaction.ClientName));
                parameters.Add(new SqlParameter("@quantity", transaction.Quantity));
                parameters.Add(new SqlParameter("@stocktype", transaction.StockType));
                parameters.Add(new SqlParameter("@time", transaction.Time));
                parameters.Add(new SqlParameter("@state", transaction.State));
                parameters.Add(new SqlParameter("@type", transaction.Type));
                sqlCommand.Parameters.AddRange(parameters.ToArray());
                sqlCommand.ExecuteNonQuery();

                if(Main.main != null)
                    Main.main.UpdateList();

            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
