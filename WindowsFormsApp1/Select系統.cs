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
                   Customer系統 CTMR = (Customer系統)this.Owner;
                   CTMR.IDTextBox_Client.Text= id;
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
