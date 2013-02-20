using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Server.Serializables;

using Server.CustomHeaders;
namespace Server
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceHttp" in both code and config file together.
    [ServiceContract(SessionMode=SessionMode.Required)]
    //[ServiceContract]
    public interface IServiceTcp
    {
        
        [FaultContract(typeof(Server.Exceptions.LoginException))]
        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        string DoWork();

        #region ServiceTcp Authentication

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        bool Login(string username, string password);

        [FaultContract(typeof(Server.Exceptions.GenericException))]
        [OperationContract]
        void Register(string username, string name, string email, string password);

        [OperationContract]
        ClientInfo GetSession(string username);

        #endregion

        #region ServiceTcp BuyAndSell Orders

        [OperationContract]
        [LoginRequiredBehavior]
        void NewTransaction(TransactionType Type, double Quantity, string StockType);

        [OperationContract(Name="NewTransactionBalcon")]
        [LoginRequiredBehavior]
        void NewTransaction(string ClientEmail, TransactionType Type, double Quantity, string StockType);

        [FaultContract(typeof(Server.Exceptions.GenericException))]
        [FaultContract(typeof(Server.Exceptions.PermissionDeniedException))]
        [OperationContract]
        [LoginRequiredBehavior]
        void PerformTransaction(int id, double stockValue);

        [FaultContract(typeof(Server.Exceptions.GenericException))]
        [FaultContract(typeof(Server.Exceptions.PermissionDeniedException))]
        [OperationContract]
        [LoginRequiredBehavior]
        List<Transaction> ListTransaction();

        [OperationContract]
        [LoginRequiredBehavior]
        List<string> ListClientsEmail();

        #endregion
    }
}
