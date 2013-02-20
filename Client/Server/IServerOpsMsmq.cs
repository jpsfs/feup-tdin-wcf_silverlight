using System;
using System.Collections;
using System.ServiceModel;

namespace Server
{
    [ServiceContract]
    public interface IServerOpsMsmq
    {
        [OperationContract(IsOneWay=true)]
        void GetClients();
    }
}
