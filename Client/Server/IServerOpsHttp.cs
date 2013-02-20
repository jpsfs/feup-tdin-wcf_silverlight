using System;
using System.Collections;
using System.ServiceModel;
using System.ServiceModel.Activation;

namespace Server
{
    [ServiceContract]
    public interface IServerOpsHttp
    {
        [OperationContract]
        string GetClients();
    }
}
