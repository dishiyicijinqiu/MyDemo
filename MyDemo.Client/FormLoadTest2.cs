using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyDemo.Client
{
    public partial class FormLoadTest2 : Form
    {
        public FormLoadTest2()
        {
            InitializeComponent();
        }

        private void FormLoadTest1_Load(object sender, EventArgs e)
        {
            try
            {
                throw new Exception("yoo ,man, error");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.formLoadErrorExit1.LoadError(this);
            }
        }
    }
}
