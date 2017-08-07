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
    public partial class YGuanliy : Form
    {
        public YGuanliy()
        {
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string constr = "server=YTT-PC\\SQLEXPRESS;database=YLibrary;Integrated Security=SSPI";
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();
            string sqlStr = "select Password,Uphone from YUser where Uid= '" + uname + "'";
            SqlDataAdapter da = new SqlDataAdapter(sqlStr, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];


            string mima = dt.Rows[0]["Password"].ToString();
            mima = mima.Trim();
            string phone = dt.Rows[0]["Uphone"].ToString();
            phone = phone.Trim();

            MyMessage ms = new MyMessage();
            ms.Show();
            ms.label2.Text = uname;
            ms.label4.Text = mima;
            ms.label6.Text = phone;
            ms.shibie = 1;
            guanbi = false;
            this.Close();
        }

        private void YGuanliy_FormClosed(object sender, FormClosedEventArgs e)
        {

            if (guanbi) Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TianShu ts = new TianShu();
            ts.Show();
            ts.uname = uname;
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
              + "case BZhuangt when '1' then '已借出' "
              + "when '0' then '未借出' "
              + "end as 'BZT'  from YBook ";
            SqlDataAdapter da = new SqlDataAdapter(sqlStr, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            TushuMess shu = new TushuMess();
            shu.dataGridView1.Columns[5].HeaderText = "删除此书";
            shu.dataGridView1.DataSource = dt;
            shu.uname = uname;
            shu.shibie = 1;
            shu.Show();
            guanbi = false;
            this.Close();
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
