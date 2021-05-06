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
    public partial class Customer系統 : Form
    {
        FOODEntities db = new FOODEntities();
        public Customer系統()
        {
            InitializeComponent();
            Addtextboxsource();
        }
        internal void Addtextboxsource()
        {
            var source_NAME = new AutoCompleteStringCollection();
            var source_Unicode = new AutoCompleteStringCollection();
            var source_Phone = new AutoCompleteStringCollection();
            var source_ContactPerson = new AutoCompleteStringCollection();
            var source_ContactCellPhone = new AutoCompleteStringCollection();
            var source_FAX = new AutoCompleteStringCollection();
            var EMP = db.Customers.Select(n => new { n.Name, n.Unicode,n.Phone,n.ContactPerson,n.ContactCellPhone,n.FAX }).ToList();
            foreach (var item in EMP)
            {
                source_NAME.Add(item.Name);
                source_Unicode.Add(item.Unicode);
                source_Phone.Add(item.Phone);
                source_ContactPerson.Add(item.ContactPerson);
                source_ContactCellPhone.Add(item.ContactCellPhone);
                source_FAX.Add(item.FAX);
            }
            //=========================讓TEXTBOX 可以有相近字顯示
            this.NameTextBox_Client.AutoCompleteCustomSource = source_NAME;
            this.NameTextBox_Client.AutoCompleteMode =
                                  AutoCompleteMode.Suggest;
            this.NameTextBox_Client.AutoCompleteSource =
                                  AutoCompleteSource.CustomSource;
            //-
            this.CompanyIDTextBox__Client.AutoCompleteCustomSource = source_Unicode;
            this.CompanyIDTextBox__Client.AutoCompleteMode =
                                  AutoCompleteMode.Suggest;
            this.CompanyIDTextBox__Client.AutoCompleteSource =
                                  AutoCompleteSource.CustomSource;
            //-
            this.TELTextBox_Client.AutoCompleteCustomSource = source_Phone;
            this.TELTextBox_Client.AutoCompleteMode =
                                  AutoCompleteMode.Suggest;
            this.TELTextBox_Client.AutoCompleteSource =
                                  AutoCompleteSource.CustomSource;
            //-
            this.ContactNameTextBox__Client.AutoCompleteCustomSource = source_ContactPerson;
            this.ContactNameTextBox__Client.AutoCompleteMode =
                                  AutoCompleteMode.Suggest;
            this.ContactNameTextBox__Client.AutoCompleteSource =
                                  AutoCompleteSource.CustomSource;
            //-
            this.ContactTELTextBox__Client.AutoCompleteCustomSource = source_ContactCellPhone;
            this.ContactTELTextBox__Client.AutoCompleteMode =
                                  AutoCompleteMode.Suggest;
            this.ContactTELTextBox__Client.AutoCompleteSource =
                                  AutoCompleteSource.CustomSource;
            //-
            this.FaxTextBox__Client.AutoCompleteCustomSource = source_FAX;
            this.FaxTextBox__Client.AutoCompleteMode =
                                  AutoCompleteMode.Suggest;
            this.FaxTextBox__Client.AutoCompleteSource =
                                  AutoCompleteSource.CustomSource;
        }
        internal void SelectCTMR(int ID)
        {
            var CTMR = this.db.Customers.Where(n => n.CustomerID == ID).Select(n => new { n.CustomerID, n.Unicode, n.Name, n.FAX, n.Address, n.Phone, n.Email, n.DoB ,n.ContactPerson,n.ContactCellPhone });
            foreach (var item in CTMR)
            {
                IDTextBox_Client.Text = item.CustomerID.ToString();
                NameTextBox_Client.Text = item.Name;
                TELTextBox_Client.Text = item.Phone;
                CompanyIDTextBox__Client.Text = item.Unicode;
                ContactNameTextBox__Client.Text = item.ContactPerson;
                ContactTELTextBox__Client.Text = item.ContactCellPhone;
                FaxTextBox__Client.Text = item.FAX;
                birthTextBox__Client.Text = item.DoB.Value.ToShortDateString();
                EmailTextBox__Client.Text = item.Email;
                AddTextBox__Client.Text = item.Address;

            }
        }
        
        private void IDTextBox_Client_TextChanged(object sender, EventArgs e)
        {
            var ID = this.db.Customers.Where(n => n.CustomerID.ToString() == IDTextBox_Client.Text).Select(n => new { n.CustomerID });
            foreach (var item in ID)
            {
                SelectCTMR(item.CustomerID);
            }
        }

        private void NameTextBox_Client_TextChanged(object sender, EventArgs e)
        {
            var ID = db.Customers.Where(n => n.Name == NameTextBox_Client.Text).Select(n => new { n.CustomerID });
            if (ID.Count()>1)
            {
                MessageBox.Show("有多筆資料!請用ID或Unicode查詢!");
            }
            else
            {
                foreach (var item in ID)
                {
                    SelectCTMR(item.CustomerID);
                }
            }
            
        }
            

        private void TELTextBox_Client_TextChanged(object sender, EventArgs e)
        {
            var ID = db.Customers.Where(n => n.Phone == TELTextBox_Client.Text).Select(n => new { n.CustomerID });
            if (ID.Count() > 1)
            {
                MessageBox.Show("有多筆資料!請用ID或Unicode查詢!");
            }
            else
            {
                foreach (var item in ID)
                {
                    SelectCTMR(item.CustomerID);
                }
            }
            
        }

        private void CompanyIDTextBox__Client_TextChanged(object sender, EventArgs e)
        {
            var ID = db.Customers.Where(n => n.Unicode == CompanyIDTextBox__Client.Text).Select(n => new { n.CustomerID });
            if (ID.Count() > 1)
            {
                MessageBox.Show("有多筆資料!請用ID或Unicode查詢!");
            }
            else
            {
                foreach (var item in ID)
                {
                    SelectCTMR(item.CustomerID);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Select系統 s = new Select系統();
            s.CTMRbtn.Checked = true;
            s.Owner = this;//重要的一步，主要是使Form2的Owner指針指向Form1  
            s.ShowDialog();
        }
    }
}
