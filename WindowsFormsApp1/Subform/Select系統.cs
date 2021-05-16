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
    public partial class Select系統 : Form
    {
        
        public Select系統()
        {
            InitializeComponent();
        }
        internal void AddCTMRtextboxsource()
        {
            var source_ID = new AutoCompleteStringCollection();
            var source_NAME = new AutoCompleteStringCollection();
            var source_Unicode = new AutoCompleteStringCollection();
            var source_Phone = new AutoCompleteStringCollection();
            var EMP = ENT.db.Customers.Select(n => new { n.CustomerID,n.Name, n.Unicode, n.Phone}).ToList();
            foreach (var item in EMP)
            {
                source_ID.Add(item.CustomerID.ToString());
                source_NAME.Add(item.Name);
                source_Unicode.Add(item.Unicode);
                source_Phone.Add(item.Phone);
            }
            //=========================讓TEXTBOX 可以有相近字顯示
            this.IDTextBox.AutoCompleteCustomSource = source_ID;
            this.IDTextBox.AutoCompleteMode =
                                  AutoCompleteMode.Suggest;
            this.IDTextBox.AutoCompleteSource =
                                  AutoCompleteSource.CustomSource;
            this.nametextBox.AutoCompleteCustomSource = source_NAME;
            this.nametextBox.AutoCompleteMode =
                                  AutoCompleteMode.Suggest;
            this.nametextBox.AutoCompleteSource =
                                  AutoCompleteSource.CustomSource;
            this.unicodetextBox.AutoCompleteCustomSource = source_Unicode;
            this.unicodetextBox.AutoCompleteMode =
                                  AutoCompleteMode.Suggest;
            this.unicodetextBox.AutoCompleteSource =
                                  AutoCompleteSource.CustomSource;
            this.phonetextBox.AutoCompleteCustomSource = source_Phone;
            this.phonetextBox.AutoCompleteMode =
                                  AutoCompleteMode.Suggest;
            this.phonetextBox.AutoCompleteSource =
                                  AutoCompleteSource.CustomSource;
        }
        internal void AddEMPtextboxsource()
        {
            var source_ID = new AutoCompleteStringCollection();
            var source_NAME = new AutoCompleteStringCollection();
            var source_Unicode = new AutoCompleteStringCollection();
            var source_Phone = new AutoCompleteStringCollection();
            var EMP = ENT.db.Employees.Select(n => new { n.EmployeeID, n.Name, n.Unicode, n.Phone }).ToList();
            foreach (var item in EMP)
            {
                source_ID.Add(item.EmployeeID.ToString());
                source_NAME.Add(item.Name);
                source_Unicode.Add(item.Unicode);
                source_Phone.Add(item.Phone);
            }
            //=========================讓TEXTBOX 可以有相近字顯示
            this.IDTextBox.AutoCompleteCustomSource = source_ID;
            this.IDTextBox.AutoCompleteMode =
                                  AutoCompleteMode.Suggest;
            this.IDTextBox.AutoCompleteSource =
                                  AutoCompleteSource.CustomSource;
            this.nametextBox.AutoCompleteCustomSource = source_NAME;
            this.nametextBox.AutoCompleteMode =
                                  AutoCompleteMode.Suggest;
            this.nametextBox.AutoCompleteSource =
                                  AutoCompleteSource.CustomSource;
            this.unicodetextBox.AutoCompleteCustomSource = source_Unicode;
            this.unicodetextBox.AutoCompleteMode =
                                  AutoCompleteMode.Suggest;
            this.unicodetextBox.AutoCompleteSource =
                                  AutoCompleteSource.CustomSource;
            this.phonetextBox.AutoCompleteCustomSource = source_Phone;
            this.phonetextBox.AutoCompleteMode =
                                  AutoCompleteMode.Suggest;
            this.phonetextBox.AutoCompleteSource =
                                  AutoCompleteSource.CustomSource;
        }
        private void selectbtn_Click(object sender, EventArgs e)
        {
            selectfunc();
        }

        private void selectfunc()
        {
            this.listView.Items.Clear();
            var r = 0;
            if (CTMRbtn.Checked == true)
            {
                var CTMR = ENT.db.Customers.Where(n =>
                       n.CustomerID.ToString() == IDTextBox.Text ||
                       n.Name == nametextBox.Text ||
                       n.Unicode == unicodetextBox.Text ||
                       n.Phone == phonetextBox.Text
                       ).Select(n => new { n.Name, n.CustomerID, n.Unicode, n.Phone });
                foreach (var item in CTMR)
                {
                    this.listView.Items.Add(item.Name, r);
                    this.listView.Items[r].SubItems.Add(item.CustomerID.ToString());
                    this.listView.Items[r].SubItems.Add(item.Unicode);
                    this.listView.Items[r].SubItems.Add(item.Phone);
                    r++;
                }
            }
            else if (EMPbtn.Checked == true)
            {
                var EMP = ENT.db.Employees.Where(n =>
                   n.EmployeeID.ToString() == IDTextBox.Text ||
                   n.Name == nametextBox.Text ||
                   n.Unicode == unicodetextBox.Text ||
                   n.Phone == phonetextBox.Text
                   ).Select(n => new { n.Name, n.EmployeeID, n.Unicode, n.Phone });
                foreach (var item in EMP)
                {
                    this.listView.Items.Add(item.Name, r);
                    this.listView.Items[r].SubItems.Add(item.EmployeeID.ToString());
                    this.listView.Items[r].SubItems.Add(item.Unicode);
                    this.listView.Items[r].SubItems.Add(item.Phone);
                    r++;
                }
            }
            else
            {
                MessageBox.Show("先勾!");
            }

        }

        private void listView_MouseClick(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < listView.Items.Count; i++)
            {
                var rectangle = listView.GetItemRect(i);
                if (rectangle.Contains(e.Location))
                {
                   var id = listView.Items[i].SubItems[1].Text;
                    if (CTMRbtn.Checked == true)
                    {
                        Customer系統 CTMR = (Customer系統)this.Owner;
                        CTMR.IDTextBox_Client.Text = id;
                        CTMR.btn_modify.Enabled = true;
                        CTMR.btn_delete.Enabled = true;
                        CTMR.lblstatus.Text = "查詢中!";
                    }
                    else if (EMPbtn.Checked == true)
                    {
                        Employee系統 EMP = (Employee系統)this.Owner;
                        EMP.EmployeeIDtextBox_Employee.Text = id;
                        EMP.btn_modify.Enabled = true;
                        EMP.btn_delete.Enabled = true;
                    }
                    
                   this.Close();
                   return;
                }
            }
        }

        private void Select系統_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                selectfunc();
            }
        }
    }
}
