using Encoder.Security;
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
    
    public partial class Form1 : Form
    {
        FOODEntities db = new FOODEntities();
        global::Encoder.Security.Encoder encode = new global::Encoder.Security.Encoder();
        EncoderType type = EncoderType.SHA1;
        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var registered = new registered();
            registered.Show();
        }       

        private void button3_Click(object sender, EventArgs e)
        {
            ForgotPW forgotPW = new ForgotPW();
            forgotPW.PWtextBox.Enabled = false;
            forgotPW.CKDPWtextBox.Enabled = false;
            forgotPW.ConfirmBtn.Enabled = false;
            forgotPW.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string CusID = "";
            string CusPW = "";
            string EmpID = "";
            string EmpPW = "";

            var CTMID = db.Customers.Where(n=>n.Unicode==this.textBox1.Text).Select(n => new { n.Unicode, n.Password }) ;            
            foreach (var item in CTMID)
            {                
                CusID = item.Unicode;
                CusPW = item.Password;
            }
            var EPYID = db.Employees.Where(n => n.Unicode == this.textBox1.Text).Select(n => new { n.Unicode, n.Password });
            foreach (var item1 in EPYID)
            {              
                EmpID = item1.Unicode;
                EmpPW = item1.Password;
            }            

            if(CustomerRadioButton.Checked == false && EMPRadioButton.Checked == false)
            {
                MessageBox.Show("請選擇登入身分別","注意",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else if (CustomerRadioButton.Checked == true)
            {                
                if (this.textBox1.Text == CusID && encode.Encrypt(type, this.textBox2.Text)== CusPW)
                {
                    var main = new MainForm();
                    main.Show();
                }
                else
                {
                    MessageBox.Show("輸入帳號密碼錯誤，請重新確認！", "警告！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (EMPRadioButton.Checked == true)
            {
                if (this.textBox1.Text == EmpID && encode.Encrypt(type, this.textBox2.Text) == EmpPW)
                {
                    var main = new MainForm();
                    main.Show();
                }
                else
                {
                    MessageBox.Show("輸入帳號密碼錯誤，請重新確認！", "警告！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("錯誤！");
            }
        }
    }
}
