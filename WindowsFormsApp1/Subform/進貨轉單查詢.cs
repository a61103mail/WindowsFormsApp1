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
    public partial class 進貨轉單查詢 : Form
    {
        DateTime begDate = DateTime.Today.AddDays(-7);
        DateTime endDate = DateTime.Today;
        FOODEntities db = new FOODEntities();
        public int pur;
        public 進貨轉單查詢()
        {
            InitializeComponent();
            openthePurchConfirmed();
            this.button1.DialogResult = DialogResult.OK;
            this.button2.DialogResult = DialogResult.Cancel;
            
        }

        private void openthePurchConfirmed()
        {

            var q = (from p in db.Purchases.AsEnumerable()
                     where (p.PurchaseDate >= begDate && p.PurchaseDate <= endDate)  && p.PurchaseStatus == 1
                     select new
                     {
                         採購單編號 = p.PurchaseID,
                         採購日期 = p.PurchaseDate,
                         供應商編號 = p.SupplierID,
                         供應商 = p.Customer.Name
                     });
            this.dataGridView1.DataSource = q.ToList();
        }

        private void thePurchConfirmedforAll()
        {
            begDate = Convert.ToDateTime(this.dateTimePicker1.Value.ToShortDateString());
            endDate = this.dateTimePicker2.Value;

            var q = (from p in db.Purchases.AsEnumerable()
                     where (p.PurchaseDate >= begDate && p.PurchaseDate <= endDate)  && p.Customer.Name.Contains(textBox1.Text) && (from i in p.PurchaseDetails where i.PurchaseID == p.PurchaseID select i.Product.Name).FirstOrDefault().Contains(textBox2.Text) && p.PurchaseStatus == 1
                     select new
                     {
                         採購單編號 = p.PurchaseID,
                         採購日期 = p.PurchaseDate,
                         供應商編號 = p.SupplierID,
                         供應商 = p.Customer.Name
                     });
            this.dataGridView1.DataSource = q.ToList();
        }
        private void thePurchConfirmedfortext()
        {
            var q = (from p in db.Purchases.AsEnumerable()
                     where (from i in p.PurchaseDetails where i.PurchaseID == p.PurchaseID select i.Product.Name).FirstOrDefault().Contains(textBox2.Text) && p.Customer.Name.Contains(textBox1.Text) && p.PurchaseStatus == 1
                     select new
                     {
                         採購單編號 = p.PurchaseID,
                         採購日期 = p.PurchaseDate,
                         供應商編號 = p.SupplierID,
                         供應商 = p.Customer.Name
                     });
            this.check.Visible = true;
            this.dataGridView1.DataSource = q.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            thePurchConfirmedforAll();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            thePurchConfirmedforAll();
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            thePurchConfirmedforAll();
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
                    pur = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                }
            }
        }

       
    }
}
