namespace MyDemo.Client
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonStyle1 = new MyDemo.Client.ButtonStyle(this.components);
            this.dataGridView_ShowLine1 = new MyDemo.Client.DataGridView_ShowLine(this.components);
            this.dataGridView_InterlacedColor1 = new MyDemo.Client.Components.DataGridView_InterlacedColor(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(22, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(685, 85);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "buttonstyle效果";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(471, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "点击上面按钮在右侧属性栏，找到分类“按钮样式”，选择对应的属性，来配置按钮的样式";
            // 
            // button2
            // 
            this.buttonStyle1.SetEnable(this.button2, true);
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(153, 19);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 36);
            this.buttonStyle1.SetStyle(this.button2, MyDemo.Client.ButtonStyleKind.EditWithSmallImage);
            this.button2.TabIndex = 1;
            this.button2.Text = "编辑";
            this.buttonStyle1.SetUseDefaultText(this.button2, true);
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.buttonStyle1.SetEnable(this.button4, true);
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(380, 19);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(88, 36);
            this.buttonStyle1.SetStyle(this.button4, MyDemo.Client.ButtonStyleKind.CancelWithSmallImage);
            this.button4.TabIndex = 3;
            this.button4.Text = "取消";
            this.buttonStyle1.SetUseDefaultText(this.button4, true);
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.buttonStyle1.SetEnable(this.button3, true);
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(279, 19);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(88, 36);
            this.buttonStyle1.SetStyle(this.button3, MyDemo.Client.ButtonStyleKind.OKWithLargeImage);
            this.button3.TabIndex = 2;
            this.button3.Text = "确定";
            this.buttonStyle1.SetUseDefaultText(this.button3, true);
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.buttonStyle1.SetEnable(this.button1, true);
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(44, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 36);
            this.buttonStyle1.SetStyle(this.button1, MyDemo.Client.ButtonStyleKind.AddWithSmallImage);
            this.button1.TabIndex = 0;
            this.button1.Text = "新增";
            this.buttonStyle1.SetUseDefaultText(this.button1, true);
            this.button1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.button6);
            this.groupBox2.Controls.Add(this.button5);
            this.groupBox2.Location = new System.Drawing.Point(22, 103);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(658, 96);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "FormLoadErrorExit效果";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(435, 39);
            this.label2.TabIndex = 5;
            this.label2.Text = "有时候当窗体载入失败时，需要退出\r\n通过使用FormLoadErrorExit，只需要在窗体载入加载业务数据的方法catch中加一句 \r\nthis.formLoa" +
    "dErrorExit1.LoadError();就可实现窗体载入失败退出的效果";
            // 
            // button6
            // 
            this.buttonStyle1.SetEnable(this.button6, false);
            this.button6.Location = new System.Drawing.Point(548, 51);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(93, 36);
            this.buttonStyle1.SetStyle(this.button6, MyDemo.Client.ButtonStyleKind.AddWithSmallImage);
            this.button6.TabIndex = 1;
            this.button6.Text = "使用";
            this.buttonStyle1.SetUseDefaultText(this.button6, true);
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.buttonStyle1.SetEnable(this.button5, false);
            this.button5.Location = new System.Drawing.Point(548, 9);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(93, 36);
            this.buttonStyle1.SetStyle(this.button5, MyDemo.Client.ButtonStyleKind.AddWithSmallImage);
            this.button5.TabIndex = 0;
            this.button5.Text = "未使用";
            this.buttonStyle1.SetUseDefaultText(this.button5, true);
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Controls.Add(this.button7);
            this.groupBox3.Location = new System.Drawing.Point(12, 481);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(668, 96);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Session效果";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(422, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "label5";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(395, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "调用wcf方法，session设置10秒失效，10秒再调用就会出现登录超时的错误";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(132, 28);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(257, 20);
            this.textBox1.TabIndex = 1;
            // 
            // button7
            // 
            this.buttonStyle1.SetEnable(this.button7, false);
            this.button7.Location = new System.Drawing.Point(17, 19);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(109, 36);
            this.buttonStyle1.SetStyle(this.button7, MyDemo.Client.ButtonStyleKind.AddWithSmallImage);
            this.button7.TabIndex = 0;
            this.button7.Text = "UserSayHello";
            this.buttonStyle1.SetUseDefaultText(this.button7, true);
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.dataGridView1);
            this.groupBox4.Location = new System.Drawing.Point(22, 205);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(685, 270);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "（设计模式）组合模式演示";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(53, 228);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(475, 39);
            this.label4.TabIndex = 6;
            this.label4.Text = "通过配置dataGridView_ShowLine和dataGridView_InterlacedColor来实现dataGridView1\r\n的显示行号和隔行变" +
    "色的样式，使用组合模式可灵活运用，可通过属性是否使用显示行号\r\n，是否使用隔行变色，或者同时使用或者都不使用。而用继承则需要多个实现";
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Beige;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView_InterlacedColor1.SetEnable(this.dataGridView1, true);
            this.dataGridView_ShowLine1.SetEnable(this.dataGridView1, true);
            this.dataGridView_InterlacedColor1.SetEvenBackColor(this.dataGridView1, System.Drawing.Color.Beige);
            this.dataGridView_ShowLine1.SetFormatString(this.dataGridView1, "第{0}行");
            this.dataGridView1.Location = new System.Drawing.Point(3, 16);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView_InterlacedColor1.SetOddBackColor(this.dataGridView1, System.Drawing.Color.Bisque);
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 60;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Bisque;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Size = new System.Drawing.Size(679, 206);
            this.dataGridView1.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 589);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private ButtonStyle buttonStyle1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private DataGridView_ShowLine dataGridView_ShowLine1;
        private System.Windows.Forms.Label label4;
        private Components.DataGridView_InterlacedColor dataGridView_InterlacedColor1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Timer timer1;
    }
}