using System;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Server.Serializables
{
    [DataContract]
    public class Transaction
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        private int ClientID { get; set; }

        [DataMember]
        public string ClientName { get; set; }

        [DataMember]
        public double? Quantity { get; set; }

        [DataMember]
        public string StockType { get; set; }

        [DataMember]
        public DateTime Time { get; set; }
        
        [DataMember]
        public TransactionState State { get; set; }

        [DataMember]
        public TransactionType Type { get; set; }

        [DataMember]
        public double? StockValue { get; set; }

        [DataMember]
        public double? OperationValue { get; set; }
    }

    [DataContract]
    public enum TransactionState {
        [EnumMember(Value="To Perform")]
        ToPerform = 0,
        [EnumMember]
        Performed = 1
    }

    [DataContract]
    public enum TransactionType
    {
        [EnumMember]
        Buy = 0,
        [EnumMember]
        Sell = 1
    }
}
