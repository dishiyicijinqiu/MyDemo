using Entity;
using FengSharp.OneCardAccess.Common;
using FengSharp.OneCardAccess.Insfrastructures.BusinessEntity;
using MyDemo.Client.Properties;
using System;
using System.Windows.Forms;
using Service.Interface;

namespace MyDemo.Client
{
    public partial class UserLoginForm : Form
    {
        private IUser _Service = ServiceProxyFactory.Create<IUser>("UserService");
        public UserLoginForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string userno = this.textBox1.Text;
                string password = this.textBox2.Text;
                if (string.IsNullOrWhiteSpace(userno))
                {
                    MessageBox.Show("用户名不可为空");
                    this.textBox1.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("密码不可为空");
                    this.textBox2.Focus();
                    return;
                }
                Login(userno, password);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                string content = ex.Message;
                if (ex is System.ServiceModel.EndpointNotFoundException)
                    content = Resources.WCFExceptionType_EndpointNotFoundException;
                else if (ex is System.ServiceModel.ProtocolException)
                    content = Resources.WCFExceptionType_ProtocolException;
                else
                    content = ex.Message;
                MessageBox.Show(content, "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Login(string userNo, string userPassword)
        {
            AuthIdentity authidentity = new AuthIdentity(userNo, userPassword);
            AuthPrincipal authprincipal = new AuthPrincipal(authidentity);
            System.Threading.Thread.CurrentPrincipal = authprincipal;
            GetAuthorizationTicket();
        }
        private void GetAuthorizationTicket()
        {
            try
            {
                AuthPrincipal authprincipal = System.Threading.Thread.CurrentPrincipal as AuthPrincipal;
                AuthIdentity authidentity = authprincipal.Identity as AuthIdentity;
                authprincipal.Ticket = _Service.GetAuthorizationTicket(authidentity.UserNo, authidentity.PassWord);
                if (string.IsNullOrWhiteSpace(authprincipal.Ticket))
                {
                    throw new BusinessException("验证失败");
                }
                UserInfo newUser = _Service.FindUserByTicket((System.Threading.Thread.CurrentPrincipal as AuthPrincipal).Ticket);
                authidentity = new AuthIdentity(newUser.UserNo, newUser.UserName, authidentity.PassWord);
                System.Threading.Thread.CurrentPrincipal = new AuthPrincipal(authidentity) { Ticket = authprincipal.Ticket };
            }
            catch (Exception ex)
            {
                System.Threading.Thread.CurrentPrincipal = null;
                throw ex;
            }
        }
    }
}
