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
        public int thesupplerid;
        List<Purchase> purchaseList = new List<Purchase>(); 
        public 採購單查詢頁面()
        {
            
            InitializeComponent();
            this.button1.DialogResult = DialogResult.OK;
            this.button2.DialogResult = DialogResult.Cancel;
            this.dateTimePicker2.Value = DateTime.Today.AddDays(1);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime begTime = Convert.ToDateTime(this.dateTimePicker1.Value.ToShortDateString());
         

            var q = from p in db.Purchases.AsEnumerable()
                    where (p.PurchaseDate >= begTime && p.PurchaseDate <= this.dateTimePicker2.Value)
                    
                    select new {
                       訂單編號= p.PurchaseID,
                       訂單日期= p.PurchaseDate,
                        供應商編號 = p.SupplierID,
                        供應商 = p.Customer.Name,
                        Total = (
                            from pd in p.PurchaseDetails
                            where pd.PurchaseID == p.PurchaseID
                            select pd).Sum((pdd)=> {
                                return pdd.UnitPrice * pdd.Qty;
                            })
                    };
            this.dataGridView1.DataSource = q.ToList();
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
                    thesupplerid = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                }
            }
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
            var q = from p in db.Purchases.AsEnumerable()
                    where (p.Customer.Name.Contains(this.textBox1.Text))

                    select new
                    {
                        訂單編號 = p.PurchaseID,
                        訂單日期 = p.PurchaseDate,
                        供應商編號 = p.SupplierID,
                        供應商 = p.Customer.Name,
                        Total = (
                            from pd in p.PurchaseDetails
                            where pd.PurchaseID == p.PurchaseID
                            select pd).Sum((pdd) => {
                                return pdd.UnitPrice * pdd.Qty;
                            })
                    };
            this.dataGridView1.DataSource = q.ToList();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //var q1 = from pd in db.PurchaseDetails.AsEnumerable()
            //         where pd.ProductCode.Contains(
            //             (from p in db.PurchaseDetails.AsEnumerable()
            //              where p.Product.Name.Contains(textBox2.Text)
            //              select new { pid = p.ProductCode })
            //                );
           

            var q = from p in db.Purchases.AsEnumerable()
                    from i in p.PurchaseDetails.AsEnumerable()
                    where i.Product.Name.Contains(textBox2.Text)

                    select new
                    {
                        訂單編號 = p.PurchaseID,
                        訂單日期 = p.PurchaseDate,
                        供應商編號 = p.SupplierID,
                        供應商 = p.Customer.Name,
                        Total = (
                            from pd in p.PurchaseDetails
                            where pd.PurchaseID == p.PurchaseID
                            select pd).Sum((pdd) => {
                                return pdd.UnitPrice * pdd.Qty;
                            })
                    };
            this.dataGridView1.DataSource = q.ToList();
        }
    }
}
