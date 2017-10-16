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

namespace BookManager
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        /*设置为子窗口*/
        public Form MdiParent { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Bname.Text.Trim() == "")
            {
                MessageBox.Show("请输入书名！");
            }
            else {
                string str = "server=localhost;database=BookManager;user=Lousen;password=1135497143";
                SqlConnection conn = new SqlConnection(str);    //创建连接数据库对象
                conn.Open(); //打开数据库连接

                string sql = "select * from Book where Bname like '%" + Bname.Text.Trim() + "%'";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataSet ds = new DataSet();

                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];   //DataGridView1为拖动到窗体的控件名称 

                conn.Close();   //关闭数据库连接

            }
        }
    }
}
