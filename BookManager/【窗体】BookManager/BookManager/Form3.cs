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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        /*设置为子窗口*/
        public Form MdiParent { get; set; }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (BID.Text.Trim() == "")
            {
                MessageBox.Show("请输入编号！");
            }
            else {

                string str = "server=localhost;database=BookManager;user=Lousen;password=1135497143";
                SqlConnection conn = new SqlConnection(str);
                string sql = "delete Book where BID =" + BID.Text.Trim();
                string sql_2 = "select * from Book where BID='" + BID.Text.Trim() + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlCommand cmd_2 = new SqlCommand(sql_2, conn);
                conn.Open();
                SqlDataReader reader = cmd_2.ExecuteReader();

                if (reader.Read())
                {
                    reader.Close();
                    int row = cmd.ExecuteNonQuery();
                    if (row > 0)
                    {
                        MessageBox.Show("删除成功！");
                    }

                }
                else {
                    MessageBox.Show("不存在该编号！");
                }             
                conn.Close();     
            }
               
        }
    }
}
