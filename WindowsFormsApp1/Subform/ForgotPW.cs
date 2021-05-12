using Encoder.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class ForgotPW : Form
    {
        FOODEntities db = new FOODEntities();
        global::Encoder.Security.Encoder encode = new global::Encoder.Security.Encoder(); //密碼
        EncoderType type = EncoderType.SHA1;
        public ForgotPW()
        {
            InitializeComponent();
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void ConfirmBtn_Click(object sender, EventArgs e)
        {
            string CusID = "";            
            string CusEmail = "";
            var CUSTOMER = db.Customers.Where(n => n.Unicode == this.AccounttextBox.Text).Select(n => new { n.Unicode, n.Email });
            foreach (var item in CUSTOMER)
            {
                CusID = item.Unicode;                
                CusEmail = item.Email;
            }

            if(this.AccounttextBox.Text == CusID && this.EmailtextBox.Text == CusEmail && this.PWtextBox.Text == this.CKDPWtextBox.Text)
            {
                var ckid = db.Customers.Where(m => m.Unicode == this.AccounttextBox.Text && m.Email == this.EmailtextBox.Text).Select(m =>m).FirstOrDefault();
                ckid.Password = encode.Encrypt(type, this.PWtextBox.Text);
                db.SaveChanges();
                MessageBox.Show("密碼更新成功","成功",MessageBoxButtons.OK, MessageBoxIcon.None);
                this.Dispose();
            }            
            else if (this.AccounttextBox.Text == CusID && this.EmailtextBox.Text == CusEmail && this.PWtextBox.Text != this.CKDPWtextBox.Text)
            {
                MessageBox.Show("密碼不相同請重新確認","注意",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("錯誤！請重新確認輸入資訊");
            }

            /****Email信件  (待研究)****
               System.Net.Mail.SmtpClient MySmtp = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);
                //MySmtp.Credentials = new System.Net.NetworkCredential("Account", "password");

                MySmtp.EnableSsl = true;
                MailMessage mail = new MailMessage();

                mail.From = new MailAddress("smtp.gmail.com", "系統信件");
                mail.To.Add("pengjiun.lin@gmail.com");
                mail.Priority = MailPriority.Normal;
                mail.Subject = "食材通密碼通知信，請盡速更新您的密碼，謝謝！";
                mail.Body = $"您的密碼為{CusPW}，收到信後請盡速更新您的密碼";

                MySmtp.Send(mail);

                this.Dispose();
            */
        }

        private void CheckBtn_Click(object sender, EventArgs e)
        {
            string CusID = "";
            string CusPW = "";
            string CusEmail = "";
            var CUSTOMER = db.Customers.Where(n => n.Unicode == this.AccounttextBox.Text).Select(n => new { n.Unicode, n.Password, n.Email });
            foreach (var item in CUSTOMER)
            {
                CusID = item.Unicode;
                CusPW = item.Password;
                CusEmail = item.Email;
            }

            //帳密資料庫的建置
            if (this.AccounttextBox.Text == CusID && this.EmailtextBox.Text == CusEmail)
            {
                MessageBox.Show("驗證成功，請立即變更新的密碼", "成功", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.ConfirmBtn.Enabled = true;
                this.CKDPWtextBox.Enabled = true;
                this.PWtextBox.Enabled = true;
                this.CheckBtn.Enabled = false;
            }
            else
            {
                MessageBox.Show("輸入帳號或信箱不符，請重新確認！");
            }
        }
    }
}
