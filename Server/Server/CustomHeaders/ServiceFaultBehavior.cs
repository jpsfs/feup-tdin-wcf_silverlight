using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Configuration;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace Server.CustomHeaders
{
    public class ServiceFaultBehavior : BehaviorExtensionElement, IEndpointBehavior
    {
        public void ApplyDispatchBehavior(ServiceEndpoint endpoint,
                    EndpointDispatcher endpointDispatcher)
        {
            ServiceFaultMessageInspector inspector = new ServiceFaultMessageInspector();
            endpointDispatcher.DispatchRuntime.MessageInspectors.Add(inspector);
        }

        // The following methods are stubs and not relevant. 
        public void AddBindingParameters(ServiceEndpoint endpoint,
               BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint,
                    ClientRuntime clientRuntime)
        {
        }

        public void Validate(ServiceEndpoint endpoint)
        {
        }

        public override System.Type BehaviorType
        {
            get { return typeof(ServiceFaultBehavior); }
        }

        protected override object CreateBehavior()
        {
            return new ServiceFaultBehavior();
        }
    }
}
