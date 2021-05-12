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
    public partial class 採購單查詢頁面 : Form
    {
        FOODEntities db = new FOODEntities();
        public List<int> purchaseID = new List<int>();
        DateTime begDate = DateTime.Today.AddDays(-7);
        DateTime endDate = DateTime.Today;

        public 採購單查詢頁面()
        {
            InitializeComponent();
            load7day();
            this.button1.DialogResult = DialogResult.OK;
            this.button2.DialogResult = DialogResult.Cancel;
        }

        private void load7day()
        {
            var q = (from p in db.Purchases.AsEnumerable()
                     where (p.PurchaseDate >= begDate && p.PurchaseDate <= endDate)

                     select new
                     {
                         採購單編號 = p.PurchaseID,
                         採購日期 = p.PurchaseDate,
                         供應商編號 = p.SupplierID,
                         供應商 = p.Customer.Name,
                         Total = (
                             from pd in p.PurchaseDetails
                             where pd.PurchaseID == p.PurchaseID
                             select pd).Sum((pdd) =>
                             {
                                 return pdd.UnitPrice * pdd.Qty;
                             })

                     });
            this.dataGridView1.DataSource = q.ToList();
        }
        private void loadPurchases()
        {
            var q = (from p in db.Purchases.AsEnumerable()
                         //from i in p.PurchaseDetails.AsEnumerable()
                     where /*i.Product.Name.Contains(textBox2.Text)*/(from i in p.PurchaseDetails where i.PurchaseID == p.PurchaseID select i.Product.Name).FirstOrDefault().Contains(textBox2.Text) && p.Customer.Name.Contains(textBox1.Text)
                     select new
                     {
                         採購單編號 = p.PurchaseID,
                         採購日期 = p.PurchaseDate,
                         供應商編號 = p.SupplierID,
                         供應商 = p.Customer.Name,
                         Total = (
                             from pd in p.PurchaseDetails
                             where pd.PurchaseID == p.PurchaseID
                             select pd).Sum((pdd) =>
                             {
                                 return pdd.UnitPrice * pdd.Qty;
                             })

                     });
            this.dataGridView1.DataSource = q.ToList();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            begDate = Convert.ToDateTime(this.dateTimePicker1.Value.ToShortDateString());
            endDate = this.dateTimePicker2.Value;

            var q = (from p in db.Purchases.AsEnumerable()
                     //from i in p.PurchaseDetails.AsEnumerable()
                     where (p.PurchaseDate >= begDate && p.PurchaseDate <= endDate) /*&& i.Product.Name.Contains(textBox2.Text)*/ && p.Customer.Name.Contains(textBox1.Text) && (from i in p.PurchaseDetails where i.PurchaseID == p.PurchaseID select i.Product.Name).FirstOrDefault().Contains(textBox2.Text)
                     select new
                     {
                         採購單編號 = p.PurchaseID,
                         採購日期 = p.PurchaseDate,
                         供應商編號 = p.SupplierID,
                         供應商 = p.Customer.Name,
                         Total = p.PurchaseDetails.Sum((pdd) =>
                             {
                                 return pdd.UnitPrice * pdd.Qty;
                             })
                     })/*.Distinct()*/;

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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            loadPurchases();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

            loadPurchases();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //foreach (DataGridViewRow dr in this.dataGridView1.Rows)
            //{
            //    DataGridViewCheckBoxCell dc = dr.Cells[0] as DataGridViewCheckBoxCell;
            //    if (Convert.ToBoolean(dc.Value))
            //    {
            //        purchaseID.Add(Convert.ToInt32(dr.Cells[1].Value.ToString()));
            //    }
            //}
            int x = dataGridView1.CurrentCell.ColumnIndex;
            if (x == 0)
            {
                DataGridViewCheckBoxCell ifcheck = (DataGridViewCheckBoxCell)dataGridView1.Rows[e.RowIndex].Cells[0];
                ifcheck.Value = true;

                Boolean b = Convert.ToBoolean(ifcheck.Value);
                if (b)
                {
                    //suppliername = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    purchaseID.Add(Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString()));
                }
            }
        }
    }
}
