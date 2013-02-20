using System;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Channels;

namespace Server.CustomHeaders
{
    public class LoginRequiredBehavior : Attribute, IOperationBehavior
    {
      public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
      {
        ConsumerInspector inspector = new ConsumerInspector();
        dispatchOperation.ParameterInspectors.Add(inspector);  
      }

      public void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation)
      { }

      public void AddBindingParameters(OperationDescription operationDescription, BindingParameterCollection bindingParameters)
      { }

      public void Validate(OperationDescription operationDescription)
      { }
    }
}
