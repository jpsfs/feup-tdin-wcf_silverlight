using System;
using System.Collections;
using System.ServiceModel;
using System.ServiceModel.Activation;

namespace Server
{
    [ServiceContract]
    public interface IServerOpsTcp
    {
        [OperationContract]
        string GetClients();
    }
}
