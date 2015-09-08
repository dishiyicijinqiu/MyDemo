using MyDemo.Client.Properties;
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
    [Description("按钮样式")]
    [ProvideProperty("Style", typeof(Button))]
    [ProvideProperty("UseDefaultText", typeof(Button))]
    [ProvideProperty("Enable", typeof(Button))]
    public partial class ButtonStyle : Component, IExtenderProvider
    {
        #region fileds
        private Dictionary<Button, ButtonStylePara> list = null;
        #endregion
        #region ctor
        public ButtonStyle()
        {
            InitializeComponent();
            list = new Dictionary<Button, ButtonStylePara>();
        }

        public ButtonStyle(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            list = new Dictionary<Button, ButtonStylePara>();
        }
        #endregion
        #region IExtenderProvider
        public bool CanExtend(object extendee)
        {
            return extendee is Button;
        }
        #endregion
        #region methods
        private ButtonStylePara GetDefaultPara()
        {
            return new ButtonStylePara()
            {
                ButtonStyleKind = ButtonStyleKind.AddWithSmallImage,
                Enable = false,
                UseDefaultText = true
            };
        }
        private ButtonStylePara defaultpara = null;
        public ButtonStylePara DefaultPara
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
        #region 按钮样式
        [Category("按钮样式")]
        [Description("按钮样式")]
        public ButtonStyleKind GetStyle(Button button)
        {
            if (this.list.ContainsKey(button))
            {
                return list[button].ButtonStyleKind;
            }
            return DefaultPara.ButtonStyleKind;
        }
        public void SetStyle(Button button, ButtonStyleKind buttonStyleKind)
        {
            if (!this.list.ContainsKey(button))
            {
                var para = GetDefaultPara();
                this.list.Add(button, para);
            }
            this.list[button].ButtonStyleKind = buttonStyleKind;
            Run(button);
        }
        #endregion
        #region 是否使用默认的文字
        [Category("按钮样式")]
        [Description("是否使用默认的文字")]
        public bool GetUseDefaultText(Button button)
        {
            if (this.list.ContainsKey(button))
            {
                return list[button].UseDefaultText;
            }
            return DefaultPara.UseDefaultText;
        }
        public void SetUseDefaultText(Button button, bool usedefaulttext)
        {
            if (!this.list.ContainsKey(button))
            {
                var para = GetDefaultPara();
                this.list.Add(button, para);
            }
            this.list[button].UseDefaultText = usedefaulttext;
            Run(button);
        }
        #endregion
        #region 是否应用按钮样式
        [Category("按钮样式")]
        [Description("是否应用按钮样式")]
        public bool GetEnable(Button button)
        {
            if (this.list.ContainsKey(button))
            {
                return list[button].Enable;
            }
            return DefaultPara.Enable;
        }
        public void SetEnable(Button button, bool enable)
        {
            if (!this.list.ContainsKey(button))
            {
                var para = GetDefaultPara();
                this.list.Add(button, para);
            }
            this.list[button].Enable = enable;
            Run(button);
        }
        #endregion
        #endregion

        private void Run(Button button)
        {
            if (!this.list.ContainsKey(button))
                return;
            var para = this.list[button];
            if (!para.Enable)
                return;
            button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            switch (para.ButtonStyleKind)
            {
                case ButtonStyleKind.AddWithLargeImage:
                case ButtonStyleKind.AddWithSmallImage:
                    button.Text = para.UseDefaultText ? Resources.btnAdd : button.Text;
                    break;
                case ButtonStyleKind.CopyAddWithLargeImage:
                case ButtonStyleKind.CopyAddWithSmallImage:
                    button.Text = para.UseDefaultText ? Resources.btnCopyAdd : button.Text;
                    break;
                case ButtonStyleKind.EditWithLargeImage:
                case ButtonStyleKind.EditWithSmallImage:
                    button.Text = para.UseDefaultText ? Resources.btnEdit : button.Text;
                    break;
                case ButtonStyleKind.DeleteWithLargeImage:
                case ButtonStyleKind.DeleteWithSmallImage:
                    button.Text = para.UseDefaultText ? Resources.btnDelete : button.Text;
                    break;
                case ButtonStyleKind.OKWithLargeImage:
                case ButtonStyleKind.OKWithSmallImage:
                    button.Text = para.UseDefaultText ? Resources.btnOK : button.Text;
                    break;
                case ButtonStyleKind.CancelWithLargeImage:
                case ButtonStyleKind.CancelWithSmallImage:
                    button.Text = para.UseDefaultText ? Resources.btnCancel : button.Text;
                    break;
                case ButtonStyleKind.SaveWithLargeImage:
                case ButtonStyleKind.SaveWithSmallImage:
                    button.Text = para.UseDefaultText ? Resources.btnSave : button.Text;
                    break;
                case ButtonStyleKind.CloseWithLargeImage:
                case ButtonStyleKind.CloseWithSmallImage:
                    button.Text = para.UseDefaultText ? Resources.btnClose : button.Text;
                    break;
                case ButtonStyleKind.KindWithLargeImage:
                case ButtonStyleKind.KindWithSmallImage:
                    button.Text = para.UseDefaultText ? Resources.btnKind : button.Text;
                    break;
                default:
                    throw new Exception(Resources.ErrorButtonStyle);
            }
            switch (para.ButtonStyleKind)
            {
                case ButtonStyleKind.AddWithLargeImage:
                    button.Image = Resources.add_32x32;
                    break;
                case ButtonStyleKind.AddWithSmallImage:
                    button.Image = Resources.add_16x16;
                    break;
                case ButtonStyleKind.CopyAddWithLargeImage:
                    button.Image = Resources.paste_32x32;
                    break;
                case ButtonStyleKind.CopyAddWithSmallImage:
                    button.Image = Resources.paste_16x16;
                    break;
                case ButtonStyleKind.EditWithLargeImage:
                    button.Image = Resources.edit_32x32;
                    break;
                case ButtonStyleKind.EditWithSmallImage:
                    button.Image = Resources.edit_16x16;
                    break;
                case ButtonStyleKind.DeleteWithLargeImage:
                    button.Image = Resources.delete_32x32;
                    break;
                case ButtonStyleKind.DeleteWithSmallImage:
                    button.Image = Resources.delete_16x16;
                    break;
                case ButtonStyleKind.OKWithLargeImage:
                    button.Image = Resources.apply_16x16;
                    break;
                case ButtonStyleKind.OKWithSmallImage:
                    button.Image = Resources.apply_16x16;
                    break;
                case ButtonStyleKind.CancelWithLargeImage:
                    button.Image = Resources.cancel_16x16;
                    break;
                case ButtonStyleKind.CancelWithSmallImage:
                    button.Image = Resources.cancel_16x16;
                    break;
                case ButtonStyleKind.SaveWithLargeImage:
                    button.Image = Resources.save_32x32;
                    break;
                case ButtonStyleKind.SaveWithSmallImage:
                    button.Image = Resources.save_16x16;
                    break;
                case ButtonStyleKind.CloseWithLargeImage:
                    button.Image = Resources.close_32x32;
                    break;
                case ButtonStyleKind.CloseWithSmallImage:
                    button.Image = Resources.close_16x16;
                    break;
                case ButtonStyleKind.KindWithLargeImage:
                    button.Image = Resources.cards_32x32;
                    break;
                case ButtonStyleKind.KindWithSmallImage:
                    button.Image = Resources.cards_16x16;
                    break;
                default:
                    throw new Exception("不正确的按钮类型");
            }
        }
    }
    public class ButtonStylePara
    {
        public ButtonStyleKind ButtonStyleKind { get; set; }
        public bool Enable { get; set; }
        public bool UseDefaultText { get; set; }
    }
    public enum ButtonStyleKind
    {
        AddWithLargeImage,
        AddWithSmallImage,
        CopyAddWithLargeImage,
        CopyAddWithSmallImage,
        EditWithLargeImage,
        EditWithSmallImage,
        DeleteWithLargeImage,
        DeleteWithSmallImage,
        OKWithLargeImage,
        OKWithSmallImage,
        CancelWithLargeImage,
        CancelWithSmallImage,
        SaveWithLargeImage,
        SaveWithSmallImage,
        CloseWithLargeImage,
        CloseWithSmallImage,
        KindWithLargeImage,
        KindWithSmallImage,
    }
}
