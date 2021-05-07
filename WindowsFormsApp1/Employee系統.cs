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
    public partial class Employee系統 : Form
    {
        public Employee系統()
        {
            InitializeComponent();
            
        }
        internal void SelectEMP(int ID) 
        {
            var EMPID = ENT.db.Employees.Where(n=>n.EmployeeID==ID).Select(n =>new {  n.EmployeeID , n.Name, n.DOB,n.Address,n.Phone,n.Cellphone,n.DOE,n.Unicode ,n.Email}) ;
            var EMP業務 = from OD in ENT.db.Orders
                        where OD.EmployeeID==ID
                        select new 
                        {
                            ODID = OD.OrderID,
                            OD日期 = OD.OrderDate,
                            客戶 = OD.Customer.Name,
                            地址 = OD.Address,
                            截止 = OD.RequiredDate,
                            最後修改 = OD.ModifiedDate,
                            狀態 = OD.status
                        };
            
            this.dataGridView_order.DataSource =EMP業務.ToList();
            foreach (var item in EMPID)
            {
                this.NameTextBox_Employee.Text = item.Name;
                this.UnicodeTextBox_Employee.Text = item.Unicode;
                this.DOBTextBox_Employee.Text = item.DOB.ToShortDateString();
                this.CellPhoneTextBox_Employee.Text = item.Cellphone;
                this.PhoneTextBox_Employee.Text = item.Phone;
                this.AddressTextBox_Employee.Text = item.Address;
                this.DOETextBox_Employee.Text = item.DOE.ToShortDateString();
                this.EmailTextBox_Employee.Text = item.Email;
            }
        }
        internal void SelectODD(int ID) 
        {
            var EMPOD = from OD in ENT.db.Orders
                        from ODD in OD.OrderDetails
                        from PD in ENT.db.Products
                        where OD.OrderID == ID && PD.ProductCode == ODD.ProductCode
                        select new
                        {
                            ODID = OD.OrderID,
                            ODDID = ODD.OrderDetailID,
                            OD日期 = OD.OrderDate,
                            產品 = PD.Name,
                            數量 = ODD.Qty,
                            售價 = ODD.UnitPrice,
                            客戶 = OD.Customer.Name,
                            統一編號 = OD.Customer.Unicode,
                            客戶電話 = OD.Customer.Phone,
                            客戶傳真 = OD.Customer.FAX,
                            客戶負責人 = OD.Customer.ContactPerson,
                            負責人電話 = OD.Customer.ContactCellPhone,
                            負責人Email = OD.Customer.Email,
                            地址 = OD.Address,
                            負責人 = OD.Employee.Name,
                            截止 = OD.RequiredDate,
                            最後修改 = OD.ModifiedDate,
                            狀態 = OD.status
                        };
            foreach (var item in EMPOD)
            {
                this.c11.Text = item.客戶;
                this.c21.Text = item.地址;
                this.c31.Text = item.統一編號;
                this.c41.Text = item.客戶電話;
                this.c51.Text = item.客戶傳真;
                this.c61.Text = item.客戶負責人;
                this.c71.Text = item.客戶電話;
                this.c81.Text = item.負責人Email;

                
            }
            this.dataGridView_ODD.DataSource = EMPOD.Select(n=>new { n.ODID,n.OD日期,n.產品,n.數量,n.售價}).ToList();

        }
        
        private void dataGridView_order_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var ID = this.dataGridView_order.CurrentRow.Cells["ODID"].Value.ToString();
            SelectODD(int.Parse(ID));
            this.tabControl1.SelectedTab = XXX;
        }

        private void EmployeeIDtextBox_Employee_TextChanged(object sender, EventArgs e)
        {
            var ID = ENT.db.Employees.Where(n => n.EmployeeID.ToString() == EmployeeIDtextBox_Employee.Text).Select(n => new { n.EmployeeID }).ToList();
            foreach (var item in ID)
            {
                SelectEMP(item.EmployeeID);
            }
        }
        private void btn_search_Click(object sender, EventArgs e)
        {
            Select系統 s = new Select系統();
            s.EMPbtn.Checked = true;
            s.TopMost = true;
            s.Panel查詢.Enabled = false;
            s.Owner = this;//重要的一步，主要是使Form2的Owner指針指向Form1  
            s.AddEMPtextboxsource();
            s.ShowDialog();
        }

        private void btn_modify_Click(object sender, EventArgs e)
        {           
                        
            try
            {
                var emp = (from i in ENT.db.Employees
                           where i.EmployeeID.ToString() == this.EmployeeIDtextBox_Employee.Text
                           select i).FirstOrDefault();
                emp.Unicode = this.UnicodeTextBox_Employee.Text;
                emp.Name = this.NameTextBox_Employee.Text;
                emp.DOB = DateTime.Parse(this.DOBTextBox_Employee.Text);
                emp.Address = this.AddressTextBox_Employee.Text;
                emp.Phone = this.PhoneTextBox_Employee.Text;
                emp.Cellphone = this.CellPhoneTextBox_Employee.Text;
                emp.Email = this.EmailTextBox_Employee.Text;
                emp.DOE = DateTime.Parse(this.DOETextBox_Employee.Text);
                emp.Password = emp.Password;
                ENT.db.SaveChanges();
            }
            catch (Exception ex)
            {
            }
        }

        private void btn_creat_Click(object sender, EventArgs e)
        {
            CURDpanel.Enabled = false;
            Savepanel.Visible = true;
            PWDpanel.Visible = true;
            //btn_search.Enabled = false;
            //btn_modify.Enabled = false;
            //btn_delete.Enabled = false;
            //btn_creat.Enabled = false;
            //btn_save.Visible = true;
            //=====清除TEXT============
            NameTextBox_Employee.Text = null;
            UnicodeTextBox_Employee.Text = null;
            DOBTextBox_Employee.Text = null;
            CellPhoneTextBox_Employee.Text = null;
            PhoneTextBox_Employee.Text = null;
            DOETextBox_Employee.Text = null;
            EmailTextBox_Employee.Text = null;
            AddressTextBox_Employee.Text = null;
            PasswordtextBox_Employee.Text = null;
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            CURDpanel.Enabled = true;
            Savepanel.Visible = false;
            PWDpanel.Visible = false;
            try
            {
                Employee emp = new Employee();
                emp.Name = this.NameTextBox_Employee.Text;
                emp.DOB = DateTime.Parse(this.DOBTextBox_Employee.Text);
                emp.Address = this.AddressTextBox_Employee.Text;
                emp.Phone = this.PhoneTextBox_Employee.Text;
                emp.Cellphone = this.CellPhoneTextBox_Employee.Text;
                emp.DOE = DateTime.Parse(this.DOETextBox_Employee.Text);
                emp.Unicode = this.UnicodeTextBox_Employee.Text;
                emp.Password = this.PasswordtextBox_Employee.Text;
                emp.Email = this.EmailTextBox_Employee.Text;
                ENT.db.Employees.Add(emp);
                ENT.db.SaveChanges();
                EmployeeIDtextBox_Employee.Text = emp.EmployeeID.ToString();
            }
            catch (Exception)
            {
            }
             
        }
        private void btn_delete_Click(object sender, EventArgs e)
        {
            var result_once = MessageBox.Show("確定要刪除嗎!?", "注意！", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result_once == System.Windows.Forms.DialogResult.OK)
            {
                var result_twice = MessageBox.Show("真的要刪除!?", "注意！", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (result_twice == System.Windows.Forms.DialogResult.OK)
                {
                    var result_three = MessageBox.Show("刪除就沒有囉!?", "注意！", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (result_three == System.Windows.Forms.DialogResult.OK)
                    {
                        var emp = (from i in ENT.db.Employees
                                    where i.EmployeeID.ToString() == this.EmployeeIDtextBox_Employee.Text
                                    select i).FirstOrDefault();
                        ENT.db.Employees.Remove(emp);
                        ENT.db.SaveChanges();
                        MessageBox.Show("刪除成功，無法挽回!", "注意！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            CURDpanel.Enabled = true;
            Savepanel.Visible = false;
            PWDpanel.Visible = false;

        }
    }
}
