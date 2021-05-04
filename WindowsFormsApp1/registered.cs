using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Encoder.Security;

namespace WindowsFormsApp1
{
    public partial class registered : Form
    {
        FOODEntities db = new FOODEntities();
        global::Encoder.Security.Encoder encode = new global::Encoder.Security.Encoder();
        public registered()
        {
            InitializeComponent();
        }
        private void registered_Load(object sender, EventArgs e)
        {
            //選擇類別
            PersonRadioButton_register.Checked = false;
            CompanyRadioButton_register.Checked = false;
            //資料填入
            AccountTextBox_register.Enabled = false;
            PWTextBox_register.Enabled = false;
            CorrectPWTextBox_register.Enabled = false;
            EmailTextBox_register.Enabled = false;
            TELTextBox_register.Enabled = false;
            AddTextBox_register.Enabled = false;
            panel1.Enabled = false;
            panel2.Enabled = false;
            checkBox1.Enabled = false;
            CorrectButton.Enabled = false;
        }
        private void PersonRadioButton_register_CheckedChanged(object sender, EventArgs e)
        {            
            AccountTextBox_register.Enabled = true;
            PWTextBox_register.Enabled = true;
            CorrectPWTextBox_register.Enabled = true;
            EmailTextBox_register.Enabled = true;
            TELTextBox_register.Enabled = true;
            AddTextBox_register.Enabled = true;
            panel1.Enabled = false;
            panel2.Enabled = true;
            checkBox1.Enabled = true;
            CorrectButton.Enabled = true;

        }

        private void CompanyRadioButton_register_CheckedChanged(object sender, EventArgs e)
        {
            AccountTextBox_register.Enabled = true;
            PWTextBox_register.Enabled = true;
            CorrectPWTextBox_register.Enabled = true;
            EmailTextBox_register.Enabled = true;
            TELTextBox_register.Enabled = true;
            AddTextBox_register.Enabled = true;
            panel1.Enabled = true;
            panel2.Enabled = false;
            checkBox1.Enabled = true;
            CorrectButton.Enabled = true;
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        
        private void CorrectButton_Click(object sender, EventArgs e)
        {
            Customer cus = new Customer();
            EncoderType type = EncoderType.SHA1;

            if (PersonRadioButton_register.Checked == true)
            {
                cus.Unicode = AccountTextBox_register.Text;
                cus.Email = EmailTextBox_register.Text;
                cus.Phone = TELTextBox_register.Text;
                cus.Name = NameTextBox_register.Text;
                cus.DoB = dateTimePicker1.Value;
                cus.Address = AddTextBox_register.Text;
                cus.FAX = FaxTextBox_register.Text;
                cus.ContactPerson = ContactNameTextBox_register.Text;
                cus.ContactCellPhone = ContactTELTextBox_register.Text;
                if (PWTextBox_register.Text == CorrectPWTextBox_register.Text)
                {
                    cus.Password = encode.Encrypt(type, this.PWTextBox_register.Text); 
                }
                else
                {
                    MessageBox.Show("輸入密碼不同，請重新確認","注意！",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    AccountTextBox_register.Clear();
                    PWTextBox_register.Clear();
                    CorrectPWTextBox_register.Clear();
                    return;
                }

            }
            else if (CompanyRadioButton_register.Checked == true)
            {
                cus.Unicode = AccountTextBox_register.Text;
                cus.Email = EmailTextBox_register.Text;
                cus.Phone = TELTextBox_register.Text;
                cus.Name = CompanyNameTextBox_register.Text;
                cus.FAX = FaxTextBox_register.Text;
                cus.ContactPerson = ContactNameTextBox_register.Text;
                cus.ContactCellPhone = ContactTELTextBox_register.Text;
                cus.Address = CompanyAddTextBox_register.Text;
                cus.DoB = dateTimePicker1.Value;
                if (PWTextBox_register.Text == CorrectPWTextBox_register.Text)
                {
                    cus.Password = encode.Encrypt(type, this.PWTextBox_register.Text);
                }
                else
                {
                    MessageBox.Show("輸入密碼不同，請重新確認", "注意！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    AccountTextBox_register.Clear();
                    PWTextBox_register.Clear();
                    CorrectPWTextBox_register.Clear();
                    return;
                }
            }
            else
            {
                MessageBox.Show("請勾選申請類別！");
            }

            //Customer的 PWD屬性 = encode.Encrypt(type, this.PWTextBox_register.Text);
            cus.CustomerRoleID = 1;
            cus.SalesID = 1;
            db.Customers.Add(cus);
            try
            {
                db.SaveChanges();                
                 var result = MessageBox.Show("帳號註冊成功！", "注意！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (result == System.Windows.Forms.DialogResult.OK)
                {                    
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
           
        }
    }
}
