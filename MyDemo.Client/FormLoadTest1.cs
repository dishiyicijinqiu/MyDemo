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
    public partial class FormLoadTest1 : Form
    {
        bool isloadderror = false;
        public FormLoadTest1()
        {
            InitializeComponent();
        }

        private void FormLoadTest2_Load(object sender, EventArgs e)
        {
            try
            {
                throw new Exception("yoo ,man, error");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                isloadderror = true;
            }
        }

        private void FormLoadTest2_Shown(object sender, EventArgs e)
        {
            if (isloadderror)
                this.Close();
        }
    }
}
