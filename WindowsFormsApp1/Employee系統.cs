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
            AddData();
            
        }
        FOODEntities db = new FOODEntities();
        internal void AddData() 
        { 
        var EMPID = this.db.Employees.Select(n => new { empname = n.Name, empid = n.EmployeeID });
            this.IDcomboBox_Employee.DataSource = EMPID.ToList();
            this.IDcomboBox_Employee.DisplayMember = "empid";
            this.IDcomboBox_Employee.ValueMember = "empid";
        }
        internal void SelectEMP(int ID) 
        {
            var EMPID = this.db.Employees.Where(n=>n.EmployeeID==ID).Select(n =>new {  n.EmployeeID , n.Name, n.DOB,n.Address,n.Phone,n.Cellphone,n.DOE,n.Unicode}) ;
            var EMP業務 = from OD in db.Orders
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
                this.nameTextBox_Employee.Text = item.Name;
                this.PersonIDTextBox_Employee.Text = item.Unicode;
                this.BirthTextBox_Employee.Text = item.DOB.ToShortDateString();
                this.TELTextBox_Employee.Text = item.Cellphone;
                this.TEL2TextBox_Employee.Text = item.Phone;
                this.AddTextBox_Employee.Text = item.Address;
                this.InTextBox_Employee.Text = item.DOE.ToShortDateString();
            }
        }
        internal void SelectODD(int ID) 
        {
            var EMPOD = from OD in db.Orders
                        from ODD in OD.OrderDetails
                        from PD in db.Products
                        where OD.OrderID == ID && PD.ProductID == ODD.ProductID
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
        private void IDcomboBox_Employee_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(this.IDcomboBox_Employee.DisplayMember==""))
            {
                var ID = int.Parse(this.IDcomboBox_Employee.SelectedValue.ToString());
                SelectEMP(ID);
            }
            
        }

        

        private void dataGridView_order_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var ID = this.dataGridView_order.CurrentRow.Cells["ODID"].Value.ToString();
            SelectODD(int.Parse(ID));
            this.tabControl1.SelectedTab = XXX;
        }

        
    }
}
