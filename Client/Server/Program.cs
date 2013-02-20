using System;
using System.ServiceModel;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(Server.ServerOpsMsmq));
            host.Open();
            Console.WriteLine("Service Server Active. Press <Enter> to close.");
            Console.ReadLine();
            host.Close();
        }
    }
}
