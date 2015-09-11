using FengSharp.OneCardAccess.Insfrastructures.Presenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace Service.Interface
{
    //[ServiceContract]
    [ServiceContract(CallbackContract = typeof(ICallback))]
    public interface IUser
    {
        [OperationContract]
        string GetAuthorizationTicket(string UserNo, string UserPassWord);
        [OperationContract]
        Entity.UserInfo FindUserByTicket(string ticket);
        [Session]
        [OperationContract]
        string SayHello(string UserName);

        [OperationContract(IsOneWay = true)]
        void Add(double x, double y);
    }
}
