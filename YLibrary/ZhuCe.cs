using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace YLibrary
{

    public partial class ZhuCe : Form
    {
        public ZhuCe()
        {
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            guanbi = false;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                try
                {
                    string constr = "server=YTT-PC\\SQLEXPRESS;database=YLibrary;Integrated Security=SSPI";
                    int shibie = 0;
                    if (radioButton2.Checked) shibie = 1;
                    SqlConnection conn = new SqlConnection(constr);
                    conn.Open();
                    string sqlStr = "insert into YUser values("+textBox1.Text
                        +","+textBox2.Text+","+textBox3.Text+","+shibie+")";
                    SqlCommand com = new SqlCommand(sqlStr, conn);
                    com.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("注册成功!");
                    YUser yuser = new YUser();
                    yuser.Show();
                    yuser.label2.Text = textBox1.Text;
                    guanbi = false;
                    this.Close();
                }
                catch (Exception err)
                {
                    MessageBox.Show("连接失败");
                }
            }
            else {
                MessageBox.Show("注册失败");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";

            }
        }

        private void ZhuCe_Load(object sender, EventArgs e)
        {

        }

        private void ZhuCe_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (guanbi) Application.Exit();
        }
    }
}
