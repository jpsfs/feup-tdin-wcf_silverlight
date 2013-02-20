using System;
using System.ServiceModel.Channels;
using System.ServiceModel;
using System.ServiceModel.Dispatcher;

namespace StockService.CustomHeaders
{
    public class ConsumerInspector : IClientMessageInspector
    {

        #region IClientMessageInspector Members

        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {

            request.Headers.Add(
                MessageHeader.CreateHeader("CustomSession", "", Program.userInfo.SessionID)
            );

            request.Headers.Add(
                MessageHeader.CreateHeader("ClientID", "", Program.userInfo.ID)
            );

            request.Headers.Add(
                MessageHeader.CreateHeader("ClientRole", "", ((int)Program.userInfo.Role).ToString())
            );

            return null;

        }

        public void AfterReceiveReply(ref Message reply, object correlationState) { }

        #endregion

    }
}
