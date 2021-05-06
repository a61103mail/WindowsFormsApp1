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
        public string thesupplerid;
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
            //MessageBox.Show(this.dateTimePicker1.Value.ToString()); 
            //var q = from p in db.PurchaseDetails

            //        where (p.Purchase.PurchaseDate >= begTime && p.Purchase.PurchaseDate <= this.dateTimePicker2.Value)
            //        //group p by p.PurchaseID into g
            //        select new
            //        {
            //            PurchaseID = p.Purchase.PurchaseID,
            //            Date = p.Purchase.PurchaseDate,
            //            SupplerID = p.Purchase.SupplierID,
            //            Suppler = p.Purchase.Customer.Name,
            //            Total = p.UnitPrice*p.Qty,
            //        }; /*Sum(n => n.price * n.QTY)*/
            //var R = q.GroupBy(n => n.PurchaseID).Select(n=>new { n.Key,S=n.Sum(w => w.price * w.QTY) });
            //var T = from t in q
            //        from r in R
            //        select new { t.PurchaseID, t.Date, t.SupplerID, t.Suppler, r.S };

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
                    thesupplerid = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
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
    }
}
