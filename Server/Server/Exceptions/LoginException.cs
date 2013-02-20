using System;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Server.Exceptions
{
    [DataContract]
    public class LoginException
    {
        [DataMember]
        public string LoginError { get; set; }
    }
}
