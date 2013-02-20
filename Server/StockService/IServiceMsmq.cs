using System;
using System.ServiceModel;

namespace StockService
{
    [ServiceContract]
    public interface IServiceMsmq
    {
        [OperationContract(IsOneWay=true)]
        void doWork(string todo);

        [OperationContract(IsOneWay=true)]
        void NewTransaction(Server.Transaction transaction);
    }
}
