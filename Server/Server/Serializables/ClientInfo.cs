using System;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Server.Serializables
{
    [DataContract]
    public class ClientInfo
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string SessionID { get; set; }

        [DataMember]
        public ClientRole Role { get; set; }
    }

    [DataContract]
    public enum ClientRole
    {
        [EnumMember]
        user = 0,
        [EnumMember]
        admin = 1
    }
}