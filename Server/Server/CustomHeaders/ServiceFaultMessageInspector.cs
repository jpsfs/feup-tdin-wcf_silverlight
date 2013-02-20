using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Configuration;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace Server.CustomHeaders
{
    public class ServiceFaultMessageInspector : IDispatchMessageInspector
    {
        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            if (reply.IsFault)
            {
                HttpResponseMessageProperty property = new HttpResponseMessageProperty();
                // Here the response code is changed to 200.
                property.StatusCode = System.Net.HttpStatusCode.OK;

                reply.Properties[HttpResponseMessageProperty.Name] = property;
            }
        }

        public object AfterReceiveRequest(ref Message request,
        IClientChannel channel, InstanceContext instanceContext)
        {
            // Do nothing to the incoming message.
            return null;
        }
    }
}
