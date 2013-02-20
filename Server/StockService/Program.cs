using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using System.ServiceModel;

namespace StockService
{
    static class Program
    {
        public static Server.ServiceTcpClient client;
        public static Server.ClientInfo userInfo = new Server.ClientInfo { SessionID = "", ID = 0, Role = Server.ClientRole.user};

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                client = new Server.ServiceTcpClient();
                client.Endpoint.Behaviors.Add(new CustomHeaders.ConsumerEndpointBehavior());

                bool validLogin = client.Login("admin", "qaz!\"#WSX");
                userInfo = client.GetSession("admin");

                ServiceHost host = new ServiceHost(typeof(StockService.ServiceMsmq));
                host.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not connect to server");
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }
}
