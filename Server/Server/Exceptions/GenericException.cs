﻿using System;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Server.Exceptions
{
    [DataContract]
    public class GenericException
    {
        [DataMember]
        public string Message { get; set; }

    }
}
