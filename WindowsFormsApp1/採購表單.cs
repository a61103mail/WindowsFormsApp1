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
    public partial class 採購表單 : Form
    {
        private BindingSource bs = new BindingSource();
        private BindingSource dataGridBs = new BindingSource();
        private FOODEntities db = new FOODEntities();
        private List<Purchase> purchases;
        private List<GridViewItem> viewItems;
        private int currentIndex = 0;
        private List<int> selectedPurchaseID = new List<int>();
        private bool rowEditing = false;

        public 採購表單()
        {

            InitializeComponent();
            this.purchases = (from p in this.db.Purchases
                              select p).ToList();
            this.Load += 採購表單_Load;

        }

        private void 採購表單_Load(object sender, EventArgs e)
        {
            this.bs.DataSource = purchases[currentIndex];
            
            this.label4.DataBindings.Add(new Binding("Text", this.bs, "PurchaseID"));
            this.viewItems = (from pd in this.db.PurchaseDetails.AsEnumerable()
                                          where pd.PurchaseID == purchases[currentIndex].PurchaseID
                                          select new GridViewItem()
                                          {
                                              項次 = 0,
                                              料號 = pd.ProductCode,
                                              品名 = pd.Product.Name,
                                              價格 = (from lp in this.db.Product_LatestPrice
                                                    where lp.ProductCode == pd.ProductCode
                                                    select lp.LatestUpperPrice).FirstOrDefault().GetValueOrDefault(),
                                              數量 = pd.Qty,
                                              單位 = pd.Unit,
                                              小計 = pd.Qty * pd.UnitPrice,
                                              備註 = pd.Comment
                                          }).ToList();
            this.dataGridBs.DataSource = viewItems;
            GridViewItem.serialNo = 0;
            this.dataGridView1.DataSource = this.dataGridBs;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Columns["項次"].ReadOnly = true;
            this.dataGridView1.Columns["料號"].ReadOnly = true;
            this.dataGridView1.Columns["品名"].ReadOnly = true;
            this.dataGridView1.Columns["單位"].ReadOnly = true;
            this.dataGridView1.Columns["小計"].ReadOnly = true;
            this.dataGridView1.Columns["備註"].ReadOnly = true;
            this.button3.Click += this.searchPurchase;
            this.button5.Click += this.previousPurchase;
            this.button6.Click += this.nextPurchase;
            this.button11.Click += this.addPurchaseDetail;
            this.dataGridView1.CellValidating += DataGridView1_CellValidating;

        }

        private void addPurchaseDetail(object sender, EventArgs e)
        {
            var f = new 新增採購品項(this.selectedPurchaseID[currentIndex]);
            var res = f.ShowDialog(this);
            if (res == DialogResult.OK)
            {
                var addedItem = new GridViewItem();
                addedItem.項次 = 0;
                addedItem.料號 = f.ProductCode;
                addedItem.品名 = f.ProductName;
                addedItem.價格 = f.UnitPirce;
                addedItem.數量 = f.Qty;
                addedItem.單位 = (from p in this.db.Products
                                where p.ProductCode == f.ProductCode
                                select p.Unit).FirstOrDefault();
                addedItem.小計 = f.Total;
                addedItem.備註 = f.Comment;

                (this.dataGridBs.DataSource as List<GridViewItem>).Add(addedItem);
                this.tempReload();
            }
            f.Dispose();            
        }

        private void DataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (this.rowEditing) return;

            this.rowEditing = true;
            
            var selectedRow = this.dataGridView1.Rows[e.RowIndex];
            decimal price;
            decimal qty;
            if (e.ColumnIndex == 3)
            {
                if (!decimal.TryParse(e.FormattedValue.ToString(), out price))
                {
                    e.Cancel = true;
                    this.rowEditing = false;
                    return;
                }
                selectedRow.Cells[3].Value = (decimal.Parse(e.FormattedValue.ToString()));
                selectedRow.Cells[6].Value = (decimal.Parse(e.FormattedValue.ToString())) * (decimal.Parse(selectedRow.Cells[4].Value.ToString()));
                
            }
            else if (e.ColumnIndex == 4)
            {
                if (!decimal.TryParse(e.FormattedValue.ToString(), out qty))
                {
                    e.Cancel = true;
                    this.rowEditing = false;
                    return;
                }
                selectedRow.Cells[4].Value = (decimal.Parse(e.FormattedValue.ToString()));
                selectedRow.Cells[6].Value = (decimal.Parse(e.FormattedValue.ToString())) * (decimal.Parse(selectedRow.Cells[3].Value.ToString()));
                
            }
            
            this.rowEditing = false;
        }

        private void previousPurchase(object sender, EventArgs e)
        {
            if (this.selectedPurchaseID.Count == 0) return;
            if (this.currentIndex >= 1)
            {
                this.currentIndex -= 1;
                this.reload();
            }
        }

        private void nextPurchase(object sender, EventArgs e)
        {
            if (this.selectedPurchaseID.Count == 0) return;
            if (this.currentIndex < this.selectedPurchaseID.Count - 1)
            {
                this.currentIndex += 1;
                this.reload();
            }
        }

        private void reload()
        {
            this.bs.DataSource = from p in this.purchases
                                 where p.PurchaseID == this.selectedPurchaseID[currentIndex]
                                 select p;
            this.bs.ResetBindings(false);
            this.listBox1.SelectedIndex = currentIndex;
            this.viewItems = (from pd in this.db.PurchaseDetails.AsEnumerable()
                              where pd.PurchaseID == this.selectedPurchaseID[currentIndex]
                              select new GridViewItem()
                              {
                                  項次 = 0,
                                  料號 = pd.ProductCode,
                                  品名 = pd.Product.Name,
                                  價格 = (from lp in this.db.Product_LatestPrice
                                        where lp.ProductCode == pd.ProductCode
                                        select lp.LatestUpperPrice).FirstOrDefault().GetValueOrDefault(),
                                  數量 = pd.Qty,
                                  單位 = pd.Unit,
                                  小計 = pd.Qty * pd.UnitPrice,
                                  備註 = pd.Comment
                              }).ToList();
            this.dataGridBs.DataSource = viewItems;
            GridViewItem.serialNo = 0;
            this.dataGridView1.DataSource = this.dataGridBs;
            this.dataGridBs.ResetBindings(false);
        }

        private void tempReload()
        {
            this.bs.DataSource = from p in this.purchases
                                 where p.PurchaseID == this.selectedPurchaseID[currentIndex]
                                 select p;
            this.bs.ResetBindings(false);
            this.listBox1.SelectedIndex = currentIndex;
            this.dataGridBs.DataSource = (from pd in this.viewItems
                                          select pd).ToList();
            GridViewItem.serialNo = 0;
            this.dataGridView1.DataSource = this.dataGridBs;
            this.dataGridBs.ResetBindings(false);
        }

        private void searchPurchase(object sender, EventArgs a)
        {
            var f = new 採購單查詢頁面();
            var res = f.ShowDialog(this);
            if (res == DialogResult.OK)
            {
                this.selectedPurchaseID = f.purchaseID;
                this.listBox1.Items.Clear();
                foreach (int id in this.selectedPurchaseID)
                {
                    this.listBox1.Items.Add(id);
                }
                this.reload();
            }            
            f.Dispose();
        }
    }

    public class GridViewItem
    {
        public static int serialNo = 0;
        private int _項次 = 0;
        public int 項次
        {
            get
            {
                return this._項次;
            }
            set
            {
                this._項次 = GridViewItem.serialNo;
            }
        }
        public string 料號 { get; set; }
        public string 品名 { get; set; }
        public decimal 價格 { get; set; }
        public decimal 數量 { get; set; }
        public string 單位 { get; set; }
        public decimal 小計 { get; set; }
        public string 備註 { get; set; }

        public GridViewItem()
        {
            GridViewItem.serialNo += 1;
        }

    }
}
