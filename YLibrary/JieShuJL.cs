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
    public partial class JieShuJL : Form
    {
        public JieShuJL()
        {
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            InitializeComponent();
        }
       

        private void fresh() {
            string constr = "server=YTT-PC\\SQLEXPRESS;database=YLibrary;Integrated Security=SSPI";
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            // string sqlStr = "select YBook.Bid,BName,BAuthor,BPrice,BZhuangt from YBook";
            string sqlStr = " select  Jid,YBook.Bid,BName,JTime,HTime from YBook,YJieS "
               + "where YJieS.Uid='" + uname + "' and YJieS.Bid=YBook.Bid";
            SqlDataAdapter da = new SqlDataAdapter(sqlStr, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
           dataGridView1.DataSource = dt;
            conn.Close();
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            YUser yuser = new YUser();
            yuser.label2.Text = uname;
            yuser.Show();
            guanbi = false;
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "操作")
            {
                //占击按钮操作
             //   MessageBox.Show(e.RowIndex.ToString() + "行的按钮被点击了。");
                string id = dataGridView1.Rows[e.RowIndex].Cells["借书号"].Value.ToString();
                string sid = dataGridView1.Rows[e.RowIndex].Cells["书号"].Value.ToString();
                string huanTime = dataGridView1.Rows[e.RowIndex].Cells["还书时间"].Value.ToString();
                huanTime = huanTime.Trim();
                DateTime time = DateTime.Now;
                if (huanTime != "")
                {
                    MessageBox.Show("该书已被归还!");
                }
                else
                {
                    string constr = "server=YTT-PC\\SQLEXPRESS;database=YLibrary;Integrated Security=SSPI";
                    SqlConnection conn = new SqlConnection(constr);
                    conn.Open();
                    //  string sqlStr = "insert into YJieS(Uid,Bid,JTime) values ('" + uname + "','" + id + "','" + time + "')";
                    //  string sqlStr = "insert into YJieShu values(" + uname
                    //      + "," + id + "," + time + ")";
                    string sqlStr = "update YJieS set HTime='" + time + "' where Jid='" + id + "' ";
                    SqlCommand com = new SqlCommand(sqlStr, conn);
                    com.ExecuteNonQuery();

                    sqlStr = "update YBook set BZhuangt=0 where Bid='" + sid + "'";
                    //  string sqlStr = "insert into YJieShu values(" + uname
                    //      + "," + id + "," + time + ")";
                    com = new SqlCommand(sqlStr, conn);
                    com.ExecuteNonQuery();
                    conn.Close();
                    fresh();
                    MessageBox.Show("还书成功!");
                }


            }
        }

        private void JieShuJL_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (guanbi) Application.Exit();
        }
    }
}
