using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YLibrary
{
    public partial class MyMessage : Form
    {
        public MyMessage()
        {
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (shibie == 0)
            {
                YUser yuser = new YUser();
                yuser.Show();
                yuser.label2.Text = label2.Text;
                guanbi = false;
                this.Close();
            }
            else {
                YGuanliy yguanliy = new YGuanliy();
                yguanliy.Show();
                yguanliy.uname = label2.Text;
                guanbi = false;
                this.Close();
            }
        }

        private void MyMessage_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (guanbi) Application.Exit();
        }
    }
}
