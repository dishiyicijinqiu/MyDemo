using SimpleCode.NamedPipeLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using WindowsFormsApplication1;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        Thread thread;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            thread = new Thread(new ThreadStart(Run));
            thread.IsBackground = true;
            thread.Start();
        }

        private void Run()
        {
            NamedPipeListenServer svr = new NamedPipeListenServer("test");
            svr.UserAdd += svr_UserAdd;
            svr.MsgReceived += svr_MsgReceived;
            svr.Start();
        }

        void svr_MsgReceived(object sender, MsgReceivedEventArgs e)
        {
            this.Invoke(new MethodInvoker(() =>
            {
                this.listBox1.Items.Add(string.Format("收到了{0}:{1}", e.UserName, e.Content));
            }));
        }

        void svr_UserAdd(object sender, UserAddEventArgs e)
        {
            this.Invoke(new MethodInvoker(() =>
            {
                this.listBox1.Items.Add(e.UserName);
            }));
        }
    }
}
namespace SimpleCode.NamedPipeLib
{
    public class UserAddEventArgs : EventArgs
    {
        public string UserName { get; private set; }
        public int HashCode { get; private set; }
        public UserAddEventArgs(string userName, int hashcode)
        {
            this.UserName = userName;
            this.HashCode = hashcode;
        }
    }
    public class MsgReceivedEventArgs : EventArgs
    {
        public string UserName { get; private set; }
        public string Content { get; private set; }
        public MsgReceivedEventArgs(string userName, string content)
        {
            this.UserName = userName;
            this.Content = content;
        }
    }
    public class NamedPipeListenServer
    {
        Dictionary<string, NamedPipeServerStream> users = new Dictionary<string, NamedPipeServerStream>();
        List<NamedPipeServerStream> _serverPool = new List<NamedPipeServerStream>();
        public event EventHandler<UserAddEventArgs> UserAdd;
        public event EventHandler<MsgReceivedEventArgs> MsgReceived;
        public static ManualResetEvent allDone = new ManualResetEvent(false);
        string _pipName = "test";
        public NamedPipeListenServer(string pipName)
        {
            _pipName = pipName;
        }

        /// <summary>
        /// 创建一个NamedPipeServerStream
        /// </summary>
        /// <returns></returns>
        protected NamedPipeServerStream CreateNamedPipeServerStream()
        {
            NamedPipeServerStream npss = new NamedPipeServerStream(_pipName, PipeDirection.InOut, 100, PipeTransmissionMode.Message, PipeOptions.Asynchronous);
            //NamedPipeServerStream npss = new NamedPipeServerStream(_pipName, PipeDirection.InOut, 10);
            lock (_serverPool)
            {
                _serverPool.Add(npss);
            }
            return npss;
        }

        /// <summary>
        /// 销毁
        /// </summary>
        /// <param name="npss"></param>
        protected void DistroyObject(NamedPipeServerStream npss)
        {
            npss.Close();
            lock (_serverPool)
            {
                if (_serverPool.Contains(npss))
                {
                    _serverPool.Remove(npss);
                }
            }
            Console.WriteLine("销毁一个NamedPipeServerStream " + npss.GetHashCode());
        }
        public void Start()
        {
            while (true)
            {
                allDone.Reset();
                NamedPipeServerStream pipeServer = CreateNamedPipeServerStream();
                AsyncCallback async = new AsyncCallback(EndWaitForConnection);
                pipeServer.BeginWaitForConnection(async, pipeServer);
                allDone.WaitOne();
            }
        }
        public void EndWaitForConnection(IAsyncResult ar)
        {
            allDone.Set();
            NamedPipeServerStream server = (NamedPipeServerStream)ar.AsyncState;
            server.EndWaitForConnection(ar);
            StreamReader sr = new StreamReader(server);
            string msg = sr.ReadLine();
            string username = server.GetImpersonationUserName();
            lock (users)
            {
                users.Add(username, server);
            }
            int hashcode = server.GetHashCode();
            if (UserAdd != null)
            {
                UserAdd(this, new UserAddEventArgs(username, server.GetHashCode()));
            }
            AsyncCallback async = new AsyncCallback(EndRead);
            StateObject state = new StateObject();
            state.WorkStream = server;
            state.UserName = username;
            server.BeginRead(state.Buffer, 0, state.Buffer.Length, async, state);
        }

        private void EndRead(IAsyncResult ar)
        {
            StateObject state = (StateObject)ar.AsyncState;
            var workstream = state.WorkStream;
            int len = workstream.EndRead(ar);
            string content = Encoding.Default.GetString(state.Buffer, 0, len);
            if (this.MsgReceived != null)
            {
                MsgReceived(this, new MsgReceivedEventArgs(state.UserName, content));
            }
            StateObject nextstate = new StateObject();
            nextstate.UserName = state.UserName;
            AsyncCallback async = new AsyncCallback(EndRead);
            workstream.BeginRead(state.Buffer, 0, state.Buffer.Length, async, state);
        }
        //public void Run()
        //{
        //    using (NamedPipeServerStream pipeServer = CreateNamedPipeServerStream())
        //    {
        //        pipeServer.WaitForConnection();
        //        Console.WriteLine("建立一个连接 " + pipeServer.GetHashCode());
        //        string username = pipeServer.GetImpersonationUserName();
        //        lock (users)
        //        {
        //            users.Add(username, pipeServer);
        //        }
        //        int hashcode = pipeServer.GetHashCode();
        //        if (UserAdd != null)
        //        {
        //            UserAdd(this, new UserAddEventArgs(pipeServer.GetImpersonationUserName(), pipeServer.GetHashCode()));
        //        }

        //        Action act = new Action(Run);
        //        act.BeginInvoke(null, null);

        //        try
        //        {
        //            bool isRun = true;
        //            while (isRun)
        //            {
        //                string str = null;
        //                StreamReader sr = new StreamReader(pipeServer);
        //                while (pipeServer.CanRead && (null != (str = sr.ReadLine())))
        //                {
        //                    ProcessMessage(str, pipeServer);

        //                    if (!pipeServer.IsConnected)
        //                    {
        //                        isRun = false;
        //                        break;
        //                    }
        //                }

        //                Thread.Sleep(50);
        //            }
        //        }
        //        // Catch the IOException that is raised if the pipe is broken
        //        // or disconnected.
        //        catch (IOException e)
        //        {
        //            Console.WriteLine("ERROR: {0}", e.Message);
        //        }
        //        finally
        //        {
        //            DistroyObject(pipeServer);
        //        }
        //    }

        //}

        /// <summary>
        /// 处理消息
        /// </summary>
        /// <param name="str"></param>
        /// <param name="pipeServer"></param>
        protected virtual void ProcessMessage(string str, NamedPipeServerStream pipeServer)
        {
            // Read user input and send that to the client process.
            using (StreamWriter sw = new StreamWriter(pipeServer))
            {
                sw.AutoFlush = true;
                sw.WriteLine("hello world " + str);
            }
        }

        /// <summary>
        /// 停止
        /// </summary>
        public void Stop()
        {
            for (int i = 0; i < _serverPool.Count; i++)
            {
                var item = _serverPool[i];

                DistroyObject(item);
            }
        }
    }
    public class StateObject
    {
        public string UserName { get; set; }
        public NamedPipeServerStream WorkStream { get; set; }
        private byte[] buffer = new byte[4096];
        public byte[] Buffer { get { return buffer; } set { buffer = value; } }
    }
}
