using System;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Channels;

namespace StockService.CustomHeaders
{
    public class ConsumerEndpointBehavior : IEndpointBehavior
    {
        #region IEndpointBehavior Members

        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            clientRuntime.MessageInspectors.Add(new ConsumerInspector());
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {

        }

        public void Validate(ServiceEndpoint endpoint)
        {

        }
        #endregion
    }
}
