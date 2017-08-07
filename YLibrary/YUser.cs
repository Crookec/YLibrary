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
    public partial class YUser : Form
    {
        public YUser()
        {
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             string constr = "server=YTT-PC\\SQLEXPRESS;database=YLibrary;Integrated Security=SSPI";
                    SqlConnection conn = new SqlConnection(constr);
                    conn.Open();
                    string sqlStr = "select Password,Uphone from YUser where Uid= '" + label2.Text + "'";
                    SqlDataAdapter da = new SqlDataAdapter(sqlStr,conn);
                    DataSet ds= new DataSet();
                    da.Fill(ds);
                    DataTable dt = ds.Tables[0];
                 
                    
                    string mima = dt.Rows[0]["Password"].ToString();
                    mima = mima.Trim();  
                    string phone = dt.Rows[0]["Uphone"].ToString();
                    phone = phone.Trim();  

            MyMessage ms = new MyMessage();
            ms.Show();
            ms.label2.Text = label2.Text;
            ms.label4.Text = mima;
            ms.label6.Text = phone;
            guanbi = false;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string constr = "server=YTT-PC\\SQLEXPRESS;database=YLibrary;Integrated Security=SSPI";
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            // string sqlStr = "select YBook.Bid,BName,BAuthor,BPrice,BZhuangt from YBook";
            string sqlStr = " select  Jid,YBook.Bid,BName,JTime,HTime from YBook,YJieS "
               +"where YJieS.Uid='"+label2.Text+"' and YJieS.Bid=YBook.Bid";
            SqlDataAdapter da = new SqlDataAdapter(sqlStr, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            JieShuJL jie = new JieShuJL();
            jie.dataGridView1.DataSource = dt;
            jie.uname = label2.Text;
            jie.Show();
            conn.Close();
            guanbi = false;
            this.Close();

          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string constr = "server=YTT-PC\\SQLEXPRESS;database=YLibrary;Integrated Security=SSPI";
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
           // string sqlStr = "select Bid,BName,BAuthor,BPrice,BZhuangt from YBook";
           string sqlStr = " select  Bid,BName,BAuthor,BPrice,"
             +"case BZhuangt when '1' then '已借出' "
             +"when '0' then '未借出' "
             +"end as 'BZT'  from YBook ";
            SqlDataAdapter da = new SqlDataAdapter(sqlStr, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            TushuMess shu = new TushuMess();
            shu.dataGridView1.Columns[5].HeaderText = "借此书";
            shu.dataGridView1.DataSource = dt; 
            shu.uname = label2.Text;
                shu.Show();
               guanbi = false;
            this.Close();
        }

        private void YUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (guanbi) Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DengLu dengl = new DengLu();
            dengl.Show();
            guanbi = false;
            this.Close();
        }
    }
}
