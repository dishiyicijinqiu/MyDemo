using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;

namespace FengSharp.OneCardAccess.Insfrastructures.BusinessEntity
{
    public class AuthPrincipal : IPrincipal
    {
        public string Ticket = null;

        public IIdentity Identity
        {
            get;
            private set;
        }

        public bool IsInRole(string role)
        {
            throw new Exception("未实现");
        }
        public AuthPrincipal(IIdentity iidentity)
        {
            this.Identity = iidentity;
        }
    }
    public class AuthIdentity : IIdentity
    {

        public string AuthenticationType
        {
            get { throw new Exception("未实现"); }
        }

        public bool IsAuthenticated
        {
            get { throw new Exception("未实现"); }
        }
        public AuthIdentity(string userno, string password)
        {
            this.UserNo = userno;
            this.PassWord = password;
        }
        public AuthIdentity(string userno, string username, string password)
        {
            this.UserNo = userno;
            this.UserName = username;
            this.PassWord = password;
        }
        public string UserNo { get; private set; }
        public string UserName { get; private set; }
        public string PassWord { get; private set; }
        public string Name
        {
            get { throw new Exception("未实现"); }
        }
    }
}
