using System;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections;

namespace Server
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ServerOpsHttp : IServerOpsHttp
    {
        private static string connString = ConfigurationManager.ConnectionStrings["Server"].ToString();


        public string GetClients()
        {
            Console.WriteLine("Get Clients Called");
            return "Get Clients Called";
        }
    }
}
