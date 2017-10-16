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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        /*设置为子窗口*/
        public Form MdiParent { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            if (BID.Text.Trim() == "")
            {
                MessageBox.Show("请输入编号！");
            }
            else {

                string str = "server=localhost;database=BookManager;user=Lousen;password=1135497143";
                SqlConnection conn = new SqlConnection(str);    //创建连接数据库对象
                conn.Open(); //打开数据库连接
                string sql = "update Book set Bname='" + Bname.Text.Trim() + "',Bauthor='" + Bauthor.Text.Trim() + "',Bpublish='" + Bpublish.Text.Trim() + "',Bprice='" + Bprice.Text.Trim() + "'where BID='" + BID.Text.Trim() + "' ";  //SQL新增语句
                string sql_2 = "select * from Book where BID='" + BID.Text.Trim() + "'";  //查重
                SqlCommand cmd_2 = new SqlCommand(sql_2, conn);     //创建执行SQl命令对象
                SqlCommand cmd = new SqlCommand(sql, conn);     //创建执行SQl命令对象
                SqlDataReader reader = cmd_2.ExecuteReader(); //datareader对象提供只读单向数据的快速传递
                if (reader.Read())
                {
                    reader.Close();
                    int row = cmd.ExecuteNonQuery();    //通过判断其返回值是否大于0来判断操作时候成功
                    if (row > 0)
                    {
                        MessageBox.Show("修改成功！");
                    }
                }
                else {
                    MessageBox.Show("不存在该编号！");
                }

                
                conn.Close();   //关闭数据库连接
            }
            
        }
    }
}
