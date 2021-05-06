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
            this.UnicodeTextBox__Client.AutoCompleteCustomSource = source_Unicode;
            this.UnicodeTextBox__Client.AutoCompleteMode =
                                  AutoCompleteMode.Suggest;
            this.UnicodeTextBox__Client.AutoCompleteSource =
                                  AutoCompleteSource.CustomSource;
            //-
            this.PhoneTextBox_Client.AutoCompleteCustomSource = source_Phone;
            this.PhoneTextBox_Client.AutoCompleteMode =
                                  AutoCompleteMode.Suggest;
            this.PhoneTextBox_Client.AutoCompleteSource =
                                  AutoCompleteSource.CustomSource;
            //-
            this.ContactPersonTextBox__Client.AutoCompleteCustomSource = source_ContactPerson;
            this.ContactPersonTextBox__Client.AutoCompleteMode =
                                  AutoCompleteMode.Suggest;
            this.ContactPersonTextBox__Client.AutoCompleteSource =
                                  AutoCompleteSource.CustomSource;
            //-
            this.ContactCellPhoneTextBox__Client.AutoCompleteCustomSource = source_ContactCellPhone;
            this.ContactCellPhoneTextBox__Client.AutoCompleteMode =
                                  AutoCompleteMode.Suggest;
            this.ContactCellPhoneTextBox__Client.AutoCompleteSource =
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
            var CTMR = from c in db.Customers
                       from e in db.Employees
                       where c.CustomerID == ID
                       select new { c.CustomerID,c.CustomerRoleID,c.Name,c.Unicode,c.Address,c.SalesID,c.Phone,c.FAX,c.ContactPerson,c.ContactCellPhone,c.Email,c.DoB,EMPName=e.Name,e.Cellphone} ;
            //var CTMR = this.db.Customers.Where(n => n.CustomerID == ID).Select(n => n);
            foreach (var item in CTMR)
            {
                DoBTimePicker.Value = item.DoB.Value;
                IDTextBox_Client.Text = item.CustomerID.ToString();
                FaxTextBox__Client.Text = item.FAX;
                NameTextBox_Client.Text = item.Name;
                PhoneTextBox_Client.Text = item.Phone;
                EmailTextBox__Client.Text = item.Email;
                UnicodeTextBox__Client.Text = item.Unicode;
                AddressTextBox__Client.Text = item.Address;
                SalesIDTextBox__Client.Text = item.SalesID.ToString();
                ContactPersonTextBox__Client.Text = item.ContactPerson;
                ContactCellPhoneTextBox__Client.Text = item.ContactCellPhone;
                CustomerRoleTextBox_Client.Text = item.CustomerRoleID.ToString();
                EmployeeTextBox__Client.Text = item.EMPName;
                EmployeeTELTextBox__Client.Text = item.Cellphone;
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
        private void button3_Click(object sender, EventArgs e)
        {
            Select系統 s = new Select系統();
            s.CTMRbtn.Checked = true;
            s.Panel查詢.Enabled = false;
            s.Owner = this;//重要的一步，主要是使Form2的Owner指針指向Form1  
            s.ShowDialog();
        }

        private void btn_modify_Click(object sender, EventArgs e)
        {
            var ctmr = (from i in db.Customers
                        where i.CustomerID.ToString() == this.IDTextBox_Client.Text
                        select i).FirstOrDefault();
            ctmr.CustomerRoleID =int.Parse(this.CustomerRoleTextBox_Client.Text);
            ctmr.Name = this.NameTextBox_Client.Text;
            ctmr.Unicode = this.UnicodeTextBox__Client.Text;
            ctmr.Address = this.AddressTextBox__Client.Text;
            ctmr.SalesID = int.Parse(this.SalesIDTextBox__Client.Text);
            ctmr.Phone = this.PhoneTextBox_Client.Text;
            ctmr.FAX = this.FaxTextBox__Client.Text;
            ctmr.ContactPerson = this.ContactPersonTextBox__Client.Text;
            ctmr.ContactCellPhone = this.ContactCellPhoneTextBox__Client.Text;
            ctmr.Email = this.EmailTextBox__Client.Text;
            ctmr.DoB = this.DoBTimePicker.Value;
            ctmr.Password = ctmr.Password;
            db.SaveChanges();
        }
    }
}
