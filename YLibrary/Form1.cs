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
    public partial class Form1 : Form
    {
        public Form1()
        {
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           ZhuCe zhuce = new ZhuCe();
           zhuce.Show();
           guanbi = false;
           this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DengLu denglu = new DengLu();
            denglu.Show();

            guanbi = false;
            this.Close();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(guanbi) Application.Exit();
        }
    }
}
