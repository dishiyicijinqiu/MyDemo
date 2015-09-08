using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyDemo.Client.Components
{
    [ToolboxItem(true)]
    [Description("窗体载入错误后退出。")]
    [ProvideProperty("Enable", typeof(DataGridView))]
    [ProvideProperty("OddBackColor", typeof(DataGridView))]
    [ProvideProperty("EvenBackColor", typeof(DataGridView))]
    public partial class DataGridView_InterlacedColor : Component, IExtenderProvider
    {
        #region fileds
        private Dictionary<DataGridView, DataGridView_InterlacedColorPara> list = null;
        #endregion
        #region ctor
        public DataGridView_InterlacedColor()
        {
            InitializeComponent();
            list = new Dictionary<DataGridView, DataGridView_InterlacedColorPara>();
        }

        public DataGridView_InterlacedColor(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            list = new Dictionary<DataGridView, DataGridView_InterlacedColorPara>();
        }
        #endregion
        #region IExtenderProvider
        public bool CanExtend(object extendee)
        {
            return extendee is DataGridView;
        }
        #endregion
        #region methods
        private DataGridView_InterlacedColorPara GetDefaultPara()
        {
            return new DataGridView_InterlacedColorPara()
            {
                Enable = false,
                OddBackColor = Color.Bisque,
                EvenBackColor = Color.Beige,
            };
        }
        private DataGridView_InterlacedColorPara defaultpara = null;
        public DataGridView_InterlacedColorPara DefaultPara
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
        #region 是否使用隔行变色
        [Category("DataGridView样式")]
        [Description("是否使用隔行变色")]
        public bool GetEnable(DataGridView dgv)
        {
            if (this.list.ContainsKey(dgv))
            {
                return list[dgv].Enable;
            }
            return DefaultPara.Enable;
        }
        public void SetEnable(DataGridView dgv, bool enable)
        {
            if (!this.list.ContainsKey(dgv))
            {
                var para = GetDefaultPara();
                this.list.Add(dgv, para);
            }
            this.list[dgv].Enable = enable;
            Run(dgv);
        }
        #endregion
        #region 奇数行背景色
        [Category("DataGridView样式")]
        [Description("奇数行背景色")]
        public Color GetOddBackColor(DataGridView dgv)
        {
            if (this.list.ContainsKey(dgv))
            {
                return list[dgv].OddBackColor;
            }
            return DefaultPara.OddBackColor;
        }
        public void SetOddBackColor(DataGridView dgv, Color color)
        {
            if (!this.list.ContainsKey(dgv))
            {
                var para = GetDefaultPara();
                this.list.Add(dgv, para);
            }
            this.list[dgv].OddBackColor = color;
            Run(dgv);
        }
        #endregion
        #region 偶数行背景色
        [Category("DataGridView样式")]
        [Description("偶数行背景色")]
        public Color GetEvenBackColor(DataGridView dgv)
        {
            if (this.list.ContainsKey(dgv))
            {
                return list[dgv].EvenBackColor;
            }
            return DefaultPara.EvenBackColor;
        }
        public void SetEvenBackColor(DataGridView dgv, Color color)
        {
            if (!this.list.ContainsKey(dgv))
            {
                var para = GetDefaultPara();
                this.list.Add(dgv, para);
            }
            this.list[dgv].EvenBackColor = color;
            Run(dgv);
        }
        #endregion
        private void Run(DataGridView dgv)
        {
            if (!this.list.ContainsKey(dgv))
                return;
            var para = this.list[dgv];
            if (!para.Enable)
                return;
            dgv.RowsDefaultCellStyle.BackColor = para.OddBackColor;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = para.EvenBackColor;
        }
        #endregion

        
    }
    public class DataGridView_InterlacedColorPara
    {
        public bool Enable { get; set; }
        /// <summary>
        /// 奇数行背景色
        /// </summary>
        public Color OddBackColor { get; set; }
        /// <summary>
        /// 偶数行背景色
        /// </summary>
        public Color EvenBackColor { get; set; }
    }
}
