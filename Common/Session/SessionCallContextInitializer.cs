using FengSharp.OneCardAccess.Common;
using System.Data;
using System.Data.Common;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace FengSharp.OneCardAccess.Insfrastructures.Presenter
{
    internal class SessionCallContextInitializer : ICallContextInitializer
    {
        private SessionMessageHeaderInfo messageHeaderInfo;
        public SessionCallContextInitializer(SessionMessageHeaderInfo messageHeaderInfo)
        {
            this.messageHeaderInfo = messageHeaderInfo;
        }
        public void AfterInvoke(object correlationState)
        {
        }

        public object BeforeInvoke(InstanceContext instanceContext, IClientChannel channel, Message message)
        {
            if (message.Headers.FindHeader(messageHeaderInfo.TicketName, messageHeaderInfo.Namespace) > -1)
            {
                var ticket = message.Headers.GetHeader<string>(messageHeaderInfo.TicketName, messageHeaderInfo.Namespace);
                var UserNo = FengSharp.Tool.MemoryCacheEx.GetCache<string>(ticket);
                if (string.IsNullOrEmpty(UserNo))
                {
                    throw new TimeOutException();
                }
                return true;
            }
            else
            {
                throw new BusinessException("无效的票据");
            }
        }
    }
}
