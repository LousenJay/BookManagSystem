using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace BookManager_0
{
    class DBCon
    {
        /*定义连接数据库字符串*/
        static string str = "server=localhost;database=BookManager;user=Lousen;password=1135497143";
        
        /*增*/
        public static void addBookMessage()
        {
            Console.WriteLine("请输入添加书籍信息：");
            Console.WriteLine("编号：");
            String id = Console.ReadLine();
            Console.WriteLine("名称：");
            String name = Console.ReadLine();
            Console.WriteLine("作者：");
            String author = Console.ReadLine();
            Console.WriteLine("出版社：");
            String publish = Console.ReadLine();
            Console.WriteLine("价格：");
            String price = Console.ReadLine();

            string sql_2 = "select * from Book where BID='" + id + "'";  //查重

            string sql = "insert into Book(BID,BName,BAuthor,Bpublish,Bprice) values('" + id + "','" + name + "','" + author + "','" + publish + "','" + price + "')";  //SQL新增语句

            SqlConnection conn = new SqlConnection(str);    //创建连接数据库对象
            SqlCommand cmd = new SqlCommand(sql, conn);     //创建执行SQl命令对象
            SqlCommand cmd_2 = new SqlCommand(sql_2, conn);     //创建执行SQl命令对象
            conn.Open(); //打开数据库连接

            SqlDataReader reader = cmd_2.ExecuteReader(); //datareader对象提供只读单向数据的快速传递

            if (reader.Read())
            {
                Console.WriteLine("已存在编号！");
            }
            else {
                reader.Close();//一定要关闭reader对象
                int row = cmd.ExecuteNonQuery(); //执行SQL,返回一个整型变量,如果SQL是对数据库的记录进行操作,那么返回操作影响的记录条数   
                if (row > 0) //通过判断其返回值是否大于0来判断操作时候成功
                {
                    Console.WriteLine("添加成功！");
                }
                else
                {
                    Console.WriteLine("添加失败！");
                }
            }  
            conn.Close();   //关闭数据库连接
        }

        /*删*/
        public static void DeleteById()
        {
            Console.WriteLine("请输入你要删除书籍Id：");
            string BID = Console.ReadLine();
            string sql_2 = "select * from Book where BID='" + BID + "'";
            string sql = "delete Book where BID ="+BID;
            SqlConnection conn = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand(sql,conn);
            SqlCommand cmd_2 = new SqlCommand(sql_2, conn);
            conn.Open();

            SqlDataReader reader = cmd_2.ExecuteReader();
            if (reader.Read())
            {
                reader.Close();
                int row = cmd.ExecuteNonQuery();
                if (row > 0)
                {
                    Console.WriteLine("删除成功！");
                }
            }
            else {
                Console.WriteLine("不存在该编号！");
            }      
            conn.Close();         
        }

        /*改*/
        public static void UpdateMessage() 
        {
            Console.WriteLine("编号：");
            String BID = Console.ReadLine();
            Console.WriteLine("请输入要修改书籍的信息：");
            Console.WriteLine("名称：");
            String name = Console.ReadLine();
            Console.WriteLine("作者：");
            String author = Console.ReadLine();
            Console.WriteLine("出版社：");
            String publish = Console.ReadLine();
            Console.WriteLine("价格：");
            String price = Console.ReadLine();

            string sql = "update Book set Bname='" + name + "',Bauthor='" + author + "',Bpublish='" + publish + "',Bprice='" + price + "' where BID='" + BID + "'";
            string sql_2 = "select * from Book where BID='" + BID + "'";

            SqlConnection conn = new SqlConnection(str);
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
                    Console.WriteLine("修改成功！");
                }
                else
                {
                    Console.WriteLine("修改失败！");
                }
            }
            else {
                Console.WriteLine("不存在该编号！");
            }  
            conn.Close();
        }

        /*查*/
        public static DataTable SelectByName()
        {
            Console.WriteLine("请输入你要查询的书籍名字：");
            string name = Console.ReadLine();
            string sql = "select * from Book where Bname like '%" + name + "%'";
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable(); //创建空表
            sda.Fill(dt);  //填充空表
            conn.Close();
            showMessage(dt);
            return dt;

        }

 

        /*显示*/
        public static void showMessage(DataTable dt)
        {
            foreach (DataRow item in dt.Rows) 
            {
                Console.WriteLine("BID:" + item["BID"]);
                Console.WriteLine("Bname:" + item["Bname"]);
                Console.WriteLine("Bauthor:" + item["BAuthor"]);
                Console.WriteLine("Bpublish:" + item["Bpublish"]);
                Console.WriteLine("Bprice:" + item["Bprice"]);

            }
        }


    }
}
