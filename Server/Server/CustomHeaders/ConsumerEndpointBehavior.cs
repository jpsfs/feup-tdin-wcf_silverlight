using System;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Channels;

namespace Server.CustomHeaders
{
    public class ConsumerEndpointBehavior : IEndpointBehavior
    {
 
        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
        }
 
        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            foreach (ClientOperation operation in clientRuntime.Operations)
            {
                operation.ParameterInspectors.Add(new ConsumerInspector());
            }
        }
 
        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            foreach (DispatchOperation operation in endpointDispatcher.DispatchRuntime.Operations)
            {
                operation.ParameterInspectors.Add(new ConsumerInspector());
            }
        }
 
        public void Validate(ServiceEndpoint endpoint)
        {
        }

    }
}
