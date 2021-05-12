using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Encoder.Security;

namespace WindowsFormsApp1
{
    public partial class registered : Form
    {
        FOODEntities db = new FOODEntities(); //database
        global::Encoder.Security.Encoder encode = new global::Encoder.Security.Encoder(); //密碼
        EncoderType type = EncoderType.SHA1;
        public registered()
        {
            InitializeComponent();
            this.TransparencyKey = this.BackColor;
            
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
            companyPanel.Enabled = false;
            personalPanel.Enabled = false;
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
            companyPanel.Enabled = false;
            personalPanel.Enabled = true;
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
            companyPanel.Enabled = true;
            personalPanel.Enabled = false;
            checkBox1.Enabled = true;
            CorrectButton.Enabled = true;
        }

        private void BackButton_Click(object sender, EventArgs e)
        {            
            this.Dispose();
        }

        string id = "";
        int Esum = 0;
        int Nsum = 0;
        int count = 0;
        private void CorrectButton_Click(object sender, EventArgs e)
        {
            Customer cus = new Customer();
            Employee emp = new Employee();
            
            //客戶權限編號--
            //    CustomrtRoleID=1：個人
            //    CustomrtRoleID = 2：企業
            if (PersonRadioButton_register.Checked == true)
            {
                var x = CheckID();
                if (x=="Fine"|| x=="NO")
                {
                    return;
                }
                
                cus.CustomerRoleID = 1;
                cus.Unicode = id;
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
                    MessageBox.Show("輸入密碼不同，請重新確認", "注意！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    AccountTextBox_register.Clear();
                    PWTextBox_register.Clear();
                    CorrectPWTextBox_register.Clear();
                    return;
                }

            }
            else if (CompanyRadioButton_register.Checked == true)
            {
                cus.CustomerRoleID = 2;                
                cus.Unicode = AccountTextBox_register.Text;
                cus.Email = EmailTextBox_register.Text;
                cus.Phone = TELTextBox_register.Text;
                cus.Name = CompanyNameTextBox_register.Text;
                cus.FAX = FaxTextBox_register.Text;
                cus.ContactPerson = ContactNameTextBox_register.Text;
                cus.ContactCellPhone = ContactTELTextBox_register.Text;
                cus.Address = CompanyAddTextBox_register.Text;
                cus.DoB = DateTime.Now;
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
            
            cus.SalesID = 1;
            db.Customers.Add(cus);
            try
            {
                db.SaveChanges();                
                 var result = MessageBox.Show("帳號註冊成功！", "成功！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    Customer系統 CTMR = (Customer系統)this.Owner;
                    CTMR.IDTextBox_Client.Text = cus.CustomerID.ToString();
                    this.Close();
                }
            }
            catch (Exception )
            {
               
            }           
        }


        private string CheckID()
        {
            id = AccountTextBox_register.Text.ToUpper();
            if (Regex.IsMatch(id, @"^[A-Z]{1}[1-2]{1}[0-9]{8}$"))
            {
                string[] country = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "J", "K", "L", "M", "N", "P", "Q", "R", "S", "T", "U", "V", "X", "Y", "W", "Z", "I", "O" };
                for (int index = 0; index < country.Length; index++)
                {
                    if (id.Substring(0, 1) == country[index])
                    {
                        index += 10;//A是從10開始編碼,每個英文的碼都跟index差異10,先加回來
                        Esum = (((index % 10) * 9) + (index / 10));
                        //英文轉成的數字, 個位數(把數字/10取餘數)乘９再加上十位數
                        //加上十位數(數字/10,因為是int,後面會直接捨去)
                        break;
                    }
                }
                for (int i = 1; i < 9; i++)
                {//從第二個數字開始跑,每個數字*相對應權重
                    Nsum += (Convert.ToInt32(id[i].ToString())) * (9 - i);
                }
                count = 10 - ((Esum + Nsum) % 10);//把上述的總和加起來,取餘數後,10-該餘數為檢查碼,要等於最後一個數字
                if (count == Convert.ToInt32(id[9].ToString()))//判斷計算總和是不是等於檢查碼
                {                    
                    return "OK";
                }
                else
                {
                    MessageBox.Show( "身分證字號不存在"); return "NO";
                }
            }
            else
            {
                MessageBox.Show( "身分證格式錯誤");
                return "NO";
            }
            
        }
    }
}

