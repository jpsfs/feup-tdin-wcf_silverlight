using System;
using System.IO;
using System.ServiceModel;
using System.Web;
using System.IdentityModel.Selectors;
using System.Security;
using System.IdentityModel.Tokens;
using Server.CustomHeaders;

using System.ServiceModel.Description;
namespace Server
{
    class Program
    {

        static void Main(string[] args)
        {
            ServiceHost servicehttpTcp = new ServiceHost(typeof(ServiceTcp));
            ServiceHost crossDomainserviceHost = new ServiceHost(typeof(CrossDomainService));

            foreach (ServiceEndpoint endpoint in servicehttpTcp.Description.Endpoints)
            {
                if (endpoint.Name == "metadata") continue;

                //endpoint.Behaviors.Add(new ConsumerEndpointBehavior());
                endpoint.Behaviors.Add(new ServiceFaultBehavior());
            } 

            servicehttpTcp.Open();
            crossDomainserviceHost.Open();

            //StockService.ServiceMsmqClient stockClient = new StockService.ServiceMsmqClient();
            //stockClient.doWork("work to do");
            
            Console.WriteLine("Service is Running on port: 4504\nPress Any Key to Exit...");
            Console.ReadLine();

            crossDomainserviceHost.Close();
            servicehttpTcp.Close();
         
        }

    }

}
