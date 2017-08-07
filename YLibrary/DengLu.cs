﻿using System;
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
    public partial class DengLu : Form
    {
        public DengLu()
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
            if (textBox1.Text != "" && textBox2.Text != "" )
            {
                try
                {
                    string constr = "server=YTT-PC\\SQLEXPRESS;database=YLibrary;Integrated Security=SSPI";
                    SqlConnection conn = new SqlConnection(constr);
                    int shibie = 0;
                    if (radioButton2.Checked) shibie = 1;
                    conn.Open();
                    string sqlStr = "select Password from YUser where Uid= '" + textBox1.Text + "'and Ushibie='"+shibie+"'";
                    SqlDataAdapter da = new SqlDataAdapter(sqlStr,conn);
                    DataSet ds= new DataSet();
                    da.Fill(ds);
                    DataTable dt = ds.Tables[0];
                    if(dt.Rows.Count==0){
                        if(shibie==0)
                           MessageBox.Show("该用户未注册！");
                        else
                           MessageBox.Show("该管理员未注册！");

                    }
                    else{
                    string mima = dt.Rows[0]["Password"].ToString();

                    mima = mima.Trim();

                    if (mima.Equals(textBox2.Text.Trim()))
                    {
                        MessageBox.Show("登录成功!");
                        conn.Close();
                        if (shibie == 0)
                        {
                            YUser yuser = new YUser();
                            yuser.Show();
                            yuser.label2.Text = textBox1.Text;
                            guanbi = false;
                            this.Close();
                        }
                        else {
                            YGuanliy yguanliy = new YGuanliy();
                            yguanliy.Show();
                            yguanliy.uname = textBox1.Text;
                            guanbi = false;
                            this.Close();
                        }
                        }
                        else{
                              MessageBox.Show("密码错误!");
                            textBox1.Text = "";
                               textBox2.Text = "";
                        }
                    
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show("连接失败");
                }
            }
            else
            {
                MessageBox.Show("登录失败");
                textBox1.Text = "";
                textBox2.Text = "";

            }
           
        }

        private void DengLu_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (guanbi) Application.Exit();
        }
    }
}
