using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MyDemo.Client
{
    [ToolboxItem(true)]
    [Description("行号。")]
    [ProvideProperty("Enable", typeof(DataGridView))]
    [ProvideProperty("FormatString", typeof(DataGridView))]
    public partial class DataGridView_ShowLine : Component, IExtenderProvider
    {
        #region fileds
        private Dictionary<DataGridView, DataGridView_ShowLinePara> list = null;
        #endregion
        #region ctor
        public DataGridView_ShowLine()
        {
            list = new Dictionary<DataGridView, DataGridView_ShowLinePara>();
        }

        public DataGridView_ShowLine(IContainer container)
        {
            container.Add(this);
            list = new Dictionary<DataGridView, DataGridView_ShowLinePara>();
        }
        #endregion
        #region IExtenderProvider
        public bool CanExtend(object extendee)
        {
            return (extendee is DataGridView);
        }
        #endregion
        #region methods
        private DataGridView_ShowLinePara GetDefaultPara()
        {
            return new DataGridView_ShowLinePara()
            {
                Enable = false,
                FormatString = "{0}"
            };
        }
        private DataGridView_ShowLinePara defaultpara = null;
        public DataGridView_ShowLinePara DefaultPara
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
        #region 是否显示行号
        [Category("DataGridView样式")]
        [Description("是否显示行号")]
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

        #region 行号格式化字符串
        [Category("DataGridView样式")]
        [Description("行号格式化字符串")]
        public string GetFormatString(DataGridView dgv)
        {
            if (this.list.ContainsKey(dgv))
            {
                return list[dgv].FormatString;
            }
            return DefaultPara.FormatString;
        }
        public void SetFormatString(DataGridView dgv, string formatstring)
        {
            if (!this.list.ContainsKey(dgv))
            {
                var para = GetDefaultPara();
                this.list.Add(dgv, para);
            }
            this.list[dgv].FormatString = formatstring;
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
            dgv.RowPostPaint -= dataGridView1_RowPostPaint;
            dgv.RowPostPaint += dataGridView1_RowPostPaint;
        }
        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (!this.list.ContainsKey(dgv))
                return;
            var para = this.list[dgv];
            string text = string.Format(para.FormatString, e.RowIndex + 1);
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, dgv.RowHeadersWidth - 4, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, text, dgv.RowHeadersDefaultCellStyle.Font, rectangle,
                dgv.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }
        #endregion
    }
    public class DataGridView_ShowLinePara
    {
        public bool Enable { get; set; }
        public string FormatString { get; set; }
    }
}
