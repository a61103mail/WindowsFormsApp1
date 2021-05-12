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
    public partial class 進貨單查詢表 : Form
    {
        DateTime begDate = DateTime.Today.AddDays(-7);
        DateTime endDate = DateTime.Today;
        FOODEntities db = new FOODEntities();
        public int purd;
        public 進貨單查詢表()
        {
            InitializeComponent();
            openthePurchConfirmed();
            this.button1.DialogResult = DialogResult.OK;
            this.button2.DialogResult = DialogResult.Cancel;
        }
        private void openthePurchConfirmed()
        {

            var q = (from p in db.PurchaseConfirmedDetails.AsEnumerable()
                     select new
                     {
                         採購單編號 = p.PurchaseID,
                         進貨日期 = p.ComfirmedDate,
                         產品編號 = p.ProductCode,
                         產品名稱 = p.Product.Name
                     });
            this.dataGridView1.DataSource = q.ToList();
        }
        private void thePurchConfirmed()
        {
            begDate = Convert.ToDateTime(this.dateTimePicker1.Value.ToShortDateString());
            endDate = this.dateTimePicker2.Value;
            var q = (from p in db.PurchaseConfirmedDetails.AsEnumerable()
                     where p.ComfirmedDate >= begDate && p.ComfirmedDate <= endDate && p.Product.Name.Contains(this.textBox1.Text)
                     select new
                     {
                         採購單編號 = p.PurchaseID,
                         進貨日期 = p.ComfirmedDate,
                         產品編號 = p.ProductCode,
                         產品名稱 = p.Product.Name
                     });
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
                    purd = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != null)
            {
                var q = (from p in db.PurchaseConfirmedDetails.AsEnumerable()
                         where p.PurchaseID == int.Parse(this.textBox2.Text)
                         select new
                         {
                             採購單編號 = p.PurchaseID,
                             進貨日期 = p.ComfirmedDate,
                             產品編號 = p.ProductCode,
                             產品名稱 = p.Product.Name
                         });
                this.dataGridView1.DataSource = q.ToList();
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            thePurchConfirmed();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            thePurchConfirmed();
        }
    }
}
