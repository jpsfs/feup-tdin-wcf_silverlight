using System;
using System.ServiceModel.Channels;
using System.ServiceModel;
using System.ServiceModel.Dispatcher;

namespace ClientApplication.CustomHeaders
{
    public class ConsumerInspector : IClientMessageInspector 
    {

        #region IClientMessageInspector Members

        public object BeforeSendRequest(ref Message request, IClientChannel channel) {
            
            request.Headers.Add(
                MessageHeader.CreateHeader("CustomSession", "", WebContext.Current.User.Session)
            );

            request.Headers.Add(
                MessageHeader.CreateHeader("ClientID", "", WebContext.Current.User.ID)
            );

            request.Headers.Add(
                MessageHeader.CreateHeader("ClientRole", "", WebContext.Current.User.Role)
            );
            
            return null;            

        }

        public void AfterReceiveReply(ref Message reply, object correlationState) { }

        #endregion

    }
}
