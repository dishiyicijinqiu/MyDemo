using System;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace FengSharp.OneCardAccess.Insfrastructures.Presenter
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class SessionAttribute : Attribute, IContractBehavior, IOperationBehavior
    {
        private SessionMessageHeaderInfo messageHeaderInfo;
        public const string DefaultNamespace = "http://www.fengsharp.com/session";
        public const string DefaultTicketName = "TicketName";
        public string Namespace { get; set; }
        public string TicketName { get; set; }
        public SessionAttribute()
        {
            messageHeaderInfo = new SessionMessageHeaderInfo
            {
                Namespace = DefaultNamespace,
                TicketName = DefaultTicketName,
            };
        }

        #region IContractBehavior
        public void AddBindingParameters(ContractDescription contractDescription, ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyClientBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            clientRuntime.MessageInspectors.Add(new SessionClientMessageInspector(messageHeaderInfo));
        }

        public void ApplyDispatchBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, DispatchRuntime dispatchRuntime)
        {
            foreach (DispatchOperation operation in dispatchRuntime.Operations)
            {
                operation.CallContextInitializers.Add(new SessionCallContextInitializer(messageHeaderInfo));
            }
        }

        public void Validate(ContractDescription contractDescription, ServiceEndpoint endpoint)
        {
            //throw new NotImplementedException();
        }
        #endregion
        #region IOperationBehavior
        public void AddBindingParameters(OperationDescription operationDescription, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation)
        {
            clientOperation.Parent.MessageInspectors.Add(new SessionClientMessageInspector(messageHeaderInfo));
        }

        public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
        {
            dispatchOperation.CallContextInitializers.Add(new SessionCallContextInitializer(messageHeaderInfo));
        }

        public void Validate(OperationDescription operationDescription)
        {
        }
        #endregion
    }
}
