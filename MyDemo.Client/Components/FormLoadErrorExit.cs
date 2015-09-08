using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyDemo.Client
{
    [ToolboxItem(true)]
    [Description("窗体载入错误后退出。")]
    [ProvideProperty("EnableLoadErrorExit", typeof(Form))]
    public partial class FormLoadErrorExit : Component, IExtenderProvider
    {
        #region fileds
        private Dictionary<Form, FormLoadErrorExitPara> list = null;
        #endregion
        #region ctor
        public FormLoadErrorExit()
        {
            InitializeComponent();
            list = new Dictionary<Form, FormLoadErrorExitPara>();
        }

        public FormLoadErrorExit(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            list = new Dictionary<Form, FormLoadErrorExitPara>();
        }
        #endregion
        #region IExtenderProvider
        public bool CanExtend(object extendee)
        {
            return (extendee is Form);
        }
        #endregion
        #region methods
        private FormLoadErrorExitPara GetDefaultPara()
        {
            return new FormLoadErrorExitPara()
            {
                IsLoadError = false,
                EnableLoadError = false
            };
        }
        private FormLoadErrorExitPara defaultpara = null;
        public FormLoadErrorExitPara DefaultPara
        {
            get
            {
                if (defaultpara == null)
                    defaultpara = GetDefaultPara();
                return defaultpara;
            }
        }
        #endregion
        #region 组件属性实现
        [Category("错误处理")]
        [Description("窗体载入错误后是否退出。")]
        public bool GetEnableLoadErrorExit(Form form)
        {
            if (this.list.ContainsKey(form))
            {
                return list[form].EnableLoadError;
            }
            return DefaultPara.EnableLoadError;
        }
        public void SetEnableLoadErrorExit(Form form, bool enableloaderrorexit)
        {
            if (!this.list.ContainsKey(form))
            {
                var para = GetDefaultPara();
                this.list.Add(form, para);
            }
            this.list[form].EnableLoadError = enableloaderrorexit;
            Run(form);
        }

        private void Run(Form form)
        {
            if (!this.list.ContainsKey(form))
                return;
            var para = this.list[form];
            if (!para.EnableLoadError)
                return;
            form.Shown -= form_Shown;
            form.Shown += form_Shown;
        }
        void form_Shown(object sender, EventArgs e)
        {
            var form = sender as Form;
            if (list.ContainsKey(form))
            {
                var para = list[form];
                if (para.IsLoadError)
                {
                    form.Close();
                }
            }
        }
        #endregion

        public void LoadError(Form form)
        {
            foreach (KeyValuePair<Form, FormLoadErrorExitPara> kv in list)
            {
                if (form != kv.Key)
                    continue;
                if (!kv.Value.EnableLoadError)
                    continue;
                kv.Value.IsLoadError = true;
            }
        }
    }
    public class FormLoadErrorExitPara
    {
        public bool EnableLoadError { get; set; }
        public bool IsLoadError { get; set; }
    }
}
