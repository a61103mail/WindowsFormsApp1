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
    public partial class 採購搜尋頁面 : Form
    {
        public 採購搜尋頁面()
        {
            InitializeComponent();
            this.button1.DialogResult = DialogResult.OK; 
            this.button2.DialogResult = DialogResult.Cancel;
            Suppliertodata();

        }
        FOODEntities db = new FOODEntities();
        public string suppliername;
        private void Suppliertodata()
        {
            if (this.textBox1.Text == "")
            {
                var q = from a in this.db.Customers
                        where a.CustomerRoleID == 1
                        select new { 供應商編號 = a.CustomerID, 供應商 = a.Name };
                this.dataGridView1.DataSource = q.ToList();
            }
            else if (this.textBox1.Text != "")
            {
                var q = from a in this.db.Customers
                        where (a.CustomerRoleID) == 1 && a.Name == this.textBox1.Text || (a.CustomerID).ToString() == this.textBox1.Text
                        select new { 供應商編號 = a.CustomerID, 供應商 = a.Name };
                this.dataGridView1.DataSource = q.ToList();
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;
            int x = dataGridView1.CurrentCell.ColumnIndex;
            if (x == 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewCheckBoxCell checkcell = (DataGridViewCheckBoxCell)dataGridView1.Rows[i].Cells[0];
                    checkcell.Value = false;
                }
                DataGridViewCheckBoxCell ifcheck = (DataGridViewCheckBoxCell)dataGridView1.Rows[e.RowIndex].Cells[0];
                ifcheck.Value = true;

                Boolean b = Convert.ToBoolean(ifcheck.Value);
                if (b)
                {
                    suppliername = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                }
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Suppliertodata();
        }
    }
}
