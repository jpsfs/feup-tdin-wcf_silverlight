using System;
using System.ServiceModel.Channels;
using System.ServiceModel;
using System.ServiceModel.Dispatcher;
using Server.Exceptions;

using System.Configuration;
using System.Data.SqlClient;

namespace Server.CustomHeaders
{
    public class ConsumerInspector : IParameterInspector 
    {

        #region IClientMessageInspector Members



        public void AfterCall(string operationName, object[] outputs, object returnValue, object correlationState)
        {
            //Do Nothing
        }



        public object BeforeCall(string operationName, object[] inputs)
        {
            
            int index = OperationContext.Current.IncomingMessageHeaders.FindHeader("CustomSession", "");
            string session = OperationContext.Current.IncomingMessageHeaders.GetHeader<string>(index);

            int indexC = OperationContext.Current.IncomingMessageHeaders.FindHeader("ClientID", "");
            string id = OperationContext.Current.IncomingMessageHeaders.GetHeader<string>(indexC);

            int indexR = OperationContext.Current.IncomingMessageHeaders.FindHeader("ClientRole", "");
            string role = OperationContext.Current.IncomingMessageHeaders.GetHeader<string>(indexR);
            

            string connectionString = ConfigurationManager.ConnectionStrings["Server"].ToString();
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            try
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("SELECT ID FROM Client WHERE ID = @id AND Role = @role AND Session = @session", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@id", id);
                sqlCommand.Parameters.AddWithValue("@role", role);
                sqlCommand.Parameters.AddWithValue("@session", session);

                var nid = sqlCommand.ExecuteScalar();
                if (nid == null)
                {
                    throw new FaultException<LoginException>(
                       new LoginException { LoginError = "Error While Login" },
                   new FaultReason("Login Failed"));
                }
            }
            catch (Exception e)
            {
                throw new FaultException<LoginException>(
                       new LoginException { LoginError = e.Message },
                   new FaultReason("Login Failed"));
            }
            finally
            {
                sqlConnection.Close();
            }

            return null;

        }

        #endregion

    }
}
