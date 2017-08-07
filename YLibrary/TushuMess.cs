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
    public partial class TushuMess : Form
    {
        public TushuMess()
        {
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (shibie == 0)
            {
                YUser yuser = new YUser();
                yuser.label2.Text = uname;
                yuser.Show();
                guanbi = false;
                this.Close();
            }
            else {
                YGuanliy yguanli = new YGuanliy();
                yguanli.uname = uname;
                yguanli.Show();
                guanbi = false;
                this.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "操作")
            {
                //占击按钮操作
              //  MessageBox.Show(e.RowIndex.ToString() + "行的按钮被点击了。");  0
                string id = dataGridView1.Rows[e.RowIndex].Cells["书号"].Value.ToString();
                string zhuangt = dataGridView1.Rows[e.RowIndex].Cells["状态"].Value.ToString();
                DateTime time = DateTime.Now;
                if (zhuangt == "已借出")
                {
                    if(shibie==0)
                    MessageBox.Show("该书已被借走!");
                    else
                        MessageBox.Show("该书被借走,无法删除!");
                }
                else {
                    if (shibie == 0)
                    {
                        string constr = "server=YTT-PC\\SQLEXPRESS;database=YLibrary;Integrated Security=SSPI";
                        SqlConnection conn = new SqlConnection(constr);
                        conn.Open();
                        string sqlStr = "insert into YJieS(Uid,Bid,JTime) values ('" + uname + "','" + id + "','" + time + "')";
                        //  string sqlStr = "insert into YJieShu values(" + uname
                        //      + "," + id + "," + time + ")";
                        SqlCommand com = new SqlCommand(sqlStr, conn);
                        com.ExecuteNonQuery();

                        sqlStr = "update YBook set BZhuangt=1 where Bid='" + id + "'";
                        //  string sqlStr = "insert into YJieShu values(" + uname
                        //      + "," + id + "," + time + ")";
                        com = new SqlCommand(sqlStr, conn);
                        com.ExecuteNonQuery();
                        conn.Close();
                        fresh();
                        MessageBox.Show("借书成功!");
                    }
                    else {
                        string constr = "server=YTT-PC\\SQLEXPRESS;database=YLibrary;Integrated Security=SSPI";
                        SqlConnection conn = new SqlConnection(constr);
                        conn.Open();
                        string sqlStr = "delete YBook where Bid='"+id+"'";
                        //  string sqlStr = "insert into YJieShu values(" + uname
                        //      + "," + id + "," + time + ")";
                        SqlCommand com = new SqlCommand(sqlStr, conn);
                        com.ExecuteNonQuery();
                        conn.Close();
                        fresh();
                        MessageBox.Show("删书成功!");
                    }
                }
                
                   
            }

        }

        private void fresh() {
            string constr = "server=YTT-PC\\SQLEXPRESS;database=YLibrary;Integrated Security=SSPI";
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            // string sqlStr = "select Bid,BName,BAuthor,BPrice,BZhuangt from YBook";
            string sqlStr = " select  Bid,BName,BAuthor,BPrice,"
              + "case BZhuangt when '1' then '已借出' "
              + "when '0' then '未借出' "
              + "end as 'BZT'  from YBook ";
            SqlDataAdapter da = new SqlDataAdapter(sqlStr, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string constr = "server=YTT-PC\\SQLEXPRESS;database=YLibrary;Integrated Security=SSPI";
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            // string sqlStr = "select Bid,BName,BAuthor,BPrice,BZhuangt from YBook";
            string sqlStr = " select  Bid,BName,BAuthor,BPrice,"
              + "case BZhuangt when '1' then '已借出' "
              + "when '0' then '未借出' "
              + "end as 'BZT'  from YBook where BName= '" + textBox1.Text + "'";
            SqlDataAdapter da = new SqlDataAdapter(sqlStr, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("未找到该书！");
            }
            else { 
               dataGridView1.DataSource = dt;
            conn.Close();
            }
         
        }

        private void TushuMess_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (guanbi) Application.Exit();
        }
    }
}
