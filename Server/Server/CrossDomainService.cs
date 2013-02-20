using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Xml;
using System.IO;

namespace Server
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CrossDomainService" in both code and config file together.
    public class CrossDomainService : ICrossDomainService
    {
        public System.ServiceModel.Channels.Message ProvidePolicyFile()
        {
            XmlReader reader = XmlReader.Create(@"ClientAccessPolicy.xml");
            System.ServiceModel.Channels.Message result = Message.CreateMessage(MessageVersion.None, "", reader);
            return result; 
        }
    }
}
