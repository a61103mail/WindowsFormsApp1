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
        
        public Customer系統()
        {
            InitializeComponent();
        }
        internal void SelectCTMR(int ID)
        {
            var CTMR = from c in ENT.db.Customers
                       from e in ENT.db.Employees
                       from o in ENT.db.Orders
                       where c.CustomerID == ID &&c.SalesID==e.EmployeeID &&o.CustomerID==c.CustomerID
                       select new { c.CustomerID,c.CustomerRoleID,c.Name,c.Unicode,c.Address,c.SalesID,c.Phone,c.FAX,
                       c.ContactPerson,c.ContactCellPhone,c.Email,c.DoB,EMPName=e.Name,e.Cellphone,
                           o.OrderID,o.OrderDate,o.RequiredDate,訂單地址=o.Address,o.StatusList.StatusName,o.EmployeeID} ;
            
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
                EmployeeTextBox__Client.Text = item.EMPName;
                EmployeeTELTextBox__Client.Text = item.Cellphone;
                CustomerRoleTextBox_Client.Text = item.CustomerRoleID.ToString();
                ContactPersonTextBox__Client.Text = item.ContactPerson;
                ContactCellPhoneTextBox__Client.Text = item.ContactCellPhone; 
            }
            this.dataGridView_order.DataSource = CTMR.Select(s=>new {ODID=s.OrderID,s.OrderDate,s.RequiredDate,s.訂單地址,s.EmployeeID,s.StatusName }).ToList();
        }
        private void IDTextBox_Client_TextChanged(object sender, EventArgs e)
        {
            var ID = ENT.db.Customers.Where(n => n.CustomerID.ToString() == IDTextBox_Client.Text).Select(n => new { n.CustomerID });
            foreach (var item in ID)
            {
                SelectCTMR(item.CustomerID);
            }

        }
        private void btn_search_Click(object sender, EventArgs e)
        {
            Select系統 s = new Select系統();
            s.CTMRbtn.Checked = true;
            s.TopMost = true;
            s.Panel查詢.Enabled = false;
            s.Owner = this;//重要的一步，主要是使Form2的Owner指針指向Form1  
            s.AddCTMRtextboxsource();  //Select系統  裡的方法
            s.ShowDialog();
        }
        private void btn_modify_Click(object sender, EventArgs e)
        {
            try
            {
                var ctmr = (from i in ENT.db.Customers
                            where i.CustomerID.ToString() == this.IDTextBox_Client.Text
                            select i).FirstOrDefault();
                ctmr.CustomerRoleID = int.Parse(this.CustomerRoleTextBox_Client.Text);
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
                //ctmr.Password = ctmr.Password;
                ENT.db.Entry(ctmr).State = System.Data.Entity.EntityState.Modified;
                
            }
            catch (Exception )
            {
            }
        }

        private void btn_creat_Click(object sender, EventArgs e)
        {
            registered registered = new registered();
            registered.Owner = this;
            registered.TopMost = true;
            registered.ShowDialog();
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
                        var ctmr = (from i in ENT.db.Customers
                                    where i.CustomerID.ToString() == this.IDTextBox_Client.Text
                                    select i).FirstOrDefault();
                        //ENT.db.Customers.Remove(ctmr);
                        ENT.db.Entry(ctmr).State = System.Data.Entity.EntityState.Deleted;
                        MessageBox.Show("刪除成功，無法挽回!", "注意！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            ENT.db.SaveChanges();
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
                            狀態 = OD.StatusList.StatusName
                        };
            
            this.dataGridView_orderdetail.DataSource = EMPOD.Select(n => new { n.ODID, n.OD日期, n.產品, n.數量, n.售價 }).ToList();

        }
        private void dataGridView_order_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var ID = this.dataGridView_order.CurrentRow.Cells["ODID"].Value.ToString();
            SelectODD(int.Parse(ID));
            this.tabControl1.SelectedTab = XXX;
        }
    }
}
