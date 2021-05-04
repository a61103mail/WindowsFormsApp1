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
            panel1.Enabled = true;
            panel2.Enabled = false;
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
            panel1.Enabled = false;
            panel2.Enabled = true;
            checkBox1.Enabled = true;
            CorrectButton.Enabled = true;
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void CorrectButton_Click(object sender, EventArgs e)
        {
            EncoderType type = EncoderType.SHA256;
            //Customer的 PWD屬性 = encode.Encrypt(type, this.PWTextBox_register.Text);
        }

        //要將輸入的資訊加到資料庫
    }
}
