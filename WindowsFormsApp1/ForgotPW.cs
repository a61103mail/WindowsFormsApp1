using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class ForgotPW : Form
    {
        public ForgotPW()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //帳密資料庫的建置
            if(this.textBox1.Text=="" && this.textBox2.Text == "")
            {
                MessageBox.Show("你的密碼為XXXXX");
                this.Dispose();
                //var login = new Form1();
                //login.Show();

            }
            else
            {
                MessageBox.Show("輸入不符，請重新確認！");
            }
        }
    }
}
