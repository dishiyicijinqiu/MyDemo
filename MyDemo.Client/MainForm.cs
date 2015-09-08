using FengSharp.OneCardAccess.Common;
using FengSharp.OneCardAccess.Insfrastructures.BusinessEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Service.Interface;

namespace MyDemo.Client
{
    public partial class MainForm : Form
    {
        private IUser _Service = ServiceProxyFactory.Create<IUser>("UserService");
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;
                UserLoginForm loginForm = new UserLoginForm();
                var result = loginForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    this.Visible = true;
                    AuthPrincipal authprincipal = System.Threading.Thread.CurrentPrincipal as AuthPrincipal;
                    AuthIdentity authidentity = authprincipal.Identity as AuthIdentity;
                    this.Text = string.Format("欢迎你：{0}", authidentity.UserName);
                    this.dataGridView1.DataSource = this.GetData();
                }
                else
                {
                    // 退出程序
                    throw new ExitException();
                }
            }
            catch (ExitException ex)
            {
                ex.Show();
                Application.Exit();
            }
        }

        private DataTable GetData()
        {
            DataTable dt = new DataTable();
            for (int i = 0; i < 5; i++)
            {
                dt.Columns.Add(string.Format("col{0}", i));
            }
            for (int j = 0; j < 20; j++)
            {
                DataRow dr = dt.NewRow();
                for (int i = 0; i < 5; i++)
                {
                    dr[string.Format("col{0}", i)] = string.Format("col{0}row{1}value", i, j);
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new FormLoadTest1().ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new FormLoadTest2().ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                AuthPrincipal authprincipal = System.Threading.Thread.CurrentPrincipal as AuthPrincipal;
                AuthIdentity authidentity = authprincipal.Identity as AuthIdentity;
                this.textBox1.Text = _Service.SayHello(authidentity.UserName);
            }
            catch (Exception ex)
            {
                if (ex is System.ServiceModel.FaultException<System.ServiceModel.ExceptionDetail>)
                {
                    if (((System.ServiceModel.FaultException<System.ServiceModel.ExceptionDetail>)(ex)).Detail.Type
                        == typeof(FengSharp.OneCardAccess.Common.TimeOutException).FullName)
                    {
                        MessageBox.Show(Properties.Resources.LoginTimeOut);
                        Application.Restart();
                    }
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.label5.Text = DateTime.Now.ToString("HH:mm:ss");
        }
    }
    /// <summary>
    /// 自定义异常类,用来处理退出程序异常
    /// </summary>
    public class ExitException : ApplicationException
    {
        private String m_msg;
        public ExitException()
        { }
        public ExitException(String msg)
        {
            m_msg = msg;
        }
        public void Show()
        {
            if (m_msg != null && m_msg.Trim().Length > 0)
            {
                MessageBox.Show(m_msg, "发生异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
