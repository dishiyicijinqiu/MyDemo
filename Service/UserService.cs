using Entity;
using FengSharp.OneCardAccess.Insfrastructures.Presenter;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;

namespace Service
{
    public class UserService : IUser
    {
        static List<UserInfo> Users = GetUsers();

        private static List<UserInfo> GetUsers()
        {
            List<UserInfo> result = new List<UserInfo>();
            result.Add(new UserInfo() { UserNo = "admin", UserName = "管理员", UserPassWord = "admin" });
            result.Add(new UserInfo() { UserNo = "guest", UserName = "来宾", UserPassWord = "guest" });
            return result;
        }

        public string GetAuthorizationTicket(string UserNo, string UserPassWord)
        {
            var user = Users.FirstOrDefault(t => t.UserNo == UserNo && t.UserPassWord == UserPassWord);
            if (user == null)
            {
                return null;
            }
            // 创建用户身份验证票,过期时间1分钟
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(user.UserNo, false, 1);
            // 加密用户身份验证票
            string encryptedTicket = FormsAuthentication.Encrypt(ticket);
            // 缓存身份验证票,过期时间10分钟
            FengSharp.Tool.MemoryCacheEx.GetCacheItem<string>(encryptedTicket, delegate() { return user.UserNo; }, TimeSpan.FromSeconds(10));
            return encryptedTicket;
        }


        public UserInfo FindUserByTicket(string ticket)
        {
            string userno = FormsAuthentication.Decrypt(ticket).Name;
            return this.FindUserByUserNo(userno);
        }
        private UserInfo FindUserByUserNo(string userno)
        {
            var user = Users.FirstOrDefault(t => t.UserNo == userno);
            return user;
        }

        public string SayHello(string UserName)
        {
            return string.Format("Hello:{0},{1}", UserName, DateTime.Now.ToString("HH:mm:ss fff"));
        }
    }
}
