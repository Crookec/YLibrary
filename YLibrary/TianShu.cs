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
    public partial class TianShu : Form
    {
        public TianShu()
        {
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            YGuanliy yguanliy = new YGuanliy();
            yguanliy.Show();
            yguanliy.uname = uname;
            guanbi = false;
            this.Close();
        }

        private void TianShu_FormClosed(object sender, FormClosedEventArgs e)
        {

            if (guanbi) Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != ""&& textBox4.Text != "")
            {
                try
                {
                    string constr = "server=YTT-PC\\SQLEXPRESS;database=YLibrary;Integrated Security=SSPI";
                    
                    SqlConnection conn = new SqlConnection(constr);
                    conn.Open();
                    Decimal jiage=Convert.ToDecimal(textBox4.Text);
                       
                    string sqlStr = "insert into YBook values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','"+jiage +"',0)";
                   SqlCommand com = new SqlCommand(sqlStr, conn);
                    com.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("添加成功!");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";

                }
                catch (Exception err)
                {
                    MessageBox.Show("连接失败");
                }
            }
            else
            {
                MessageBox.Show("添加失败");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";

            }
        }
    }
}
