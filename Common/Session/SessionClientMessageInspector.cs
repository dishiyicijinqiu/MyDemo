using FengSharp.OneCardAccess.Insfrastructures.BusinessEntity;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Threading;

namespace FengSharp.OneCardAccess.Insfrastructures.Presenter
{
    internal class SessionClientMessageInspector : IClientMessageInspector
    {
        private SessionMessageHeaderInfo messageheaderinfo;
        public SessionClientMessageInspector(SessionMessageHeaderInfo messageheaderinfo)
        {
            this.messageheaderinfo = messageheaderinfo;
        }

        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            var tickid = (Thread.CurrentPrincipal as AuthPrincipal).Ticket;
            if (tickid != null)
            {
                request.Headers.Add(MessageHeader.CreateHeader(this.messageheaderinfo.TicketName,
                    this.messageheaderinfo.Namespace, tickid));
            }
            return null;
        }

        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
        }
    }
}
