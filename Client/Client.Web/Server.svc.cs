using System;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;

namespace Client.Web
{
    [ServiceContract(Namespace = "")]
    [SilverlightFaultBehavior]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Server
    {
        [OperationContract(IsOneWay=true)]
        public void DoWork()
        {
            // Add your operation implementation here
            return;
        }

        /*
        [OperationContract(IsOneWay=true)]
        public string GetClients()
        {
            // Add your operation implementation here

            return "Clients Work!";
        }*/

        // Add more operations here and mark them with [OperationContract]
    }
}
