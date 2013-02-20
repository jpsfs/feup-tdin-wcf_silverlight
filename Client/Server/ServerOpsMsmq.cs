using System;
using System.ServiceModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections;

namespace Server
{
    public class ServerOpsMsmq : IServerOpsMsmq
    {
        private static string connString = ConfigurationManager.ConnectionStrings["Server"].ToString();

        public void GetClients()
        {
            Console.WriteLine("Get Clients Called");
        }
    }
}
