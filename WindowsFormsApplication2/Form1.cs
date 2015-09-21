using SimpleCode.NamedPipeLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        NamedPipeClient client = new NamedPipeClient(".", "test");
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //using (NamedPipeClient client = new NamedPipeClient(".", "test"))
            //{
            //    MessageBox.Show(client.Query("fff"));
            //    MessageBox.Show(client.Query("54353"));
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SendMessage(this.textBox1.Text);
        }
        public void SendMessage(string content)
        {
            client.Send(content);
        }
    }
}
namespace SimpleCode.NamedPipeLib
{
    public class NamedPipeClient : IDisposable
    {
        string _serverName;
        string _pipName;
        NamedPipeClientStream _pipeClient;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serverName">服务器地址</param>
        /// <param name="pipName">管道名称</param>
        public NamedPipeClient(string serverName, string pipName)
        {
            _serverName = serverName;
            _pipName = pipName;

            _pipeClient = new NamedPipeClientStream(serverName, pipName, PipeDirection.InOut);

        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public string Query(string request)
        {
            if (!_pipeClient.IsConnected)
            {
                _pipeClient.Connect(10000);
            }

            StreamWriter sw = new StreamWriter(_pipeClient);
            sw.WriteLine(request);
            sw.Flush();

            StreamReader sr = new StreamReader(_pipeClient);
            string temp;
            string returnVal = "";
            while ((temp = sr.ReadLine()) != null)
            {
                returnVal = temp;
                //nothing
            }
            return returnVal;
        }


        public void Send(string content)
        {
            if (!_pipeClient.IsConnected)
            {
                _pipeClient.Connect(10000);
            }

            StreamWriter sw = new StreamWriter(_pipeClient);
            sw.WriteLine(content);
            sw.Flush();
        }

        #region IDisposable 成员

        bool _disposed = false;
        public void Dispose()
        {
            if (!_disposed && _pipeClient != null)
            {
                _pipeClient.Dispose();
                _disposed = true;
            }
        }

        #endregion
    }
}
