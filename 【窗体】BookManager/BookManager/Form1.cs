using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookManager
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        /*添加子窗口2*/
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
        }
        /*添加子窗口3*/
        private void button2_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.Show();
        }
        /*添加子窗口4*/
        private void button3_Click(object sender, EventArgs e)
        {
            Form4 frm4= new Form4();
            frm4.Show();
        }
        /*添加子窗口5*/
        private void button4_Click(object sender, EventArgs e)
        {
            Form5 frm5 = new Form5();
            frm5.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
