using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class 分析 : UserControl
    {
        private FOODEntities db;
        private List<ProductItem> products = new List<ProductItem>();
        private Product_LatestPrice currentProduct;
        public event EventHandler DoneLoading;
        public 分析()
        {
            InitializeComponent();
            if (this.db == null)
            {
                this.db = new FOODEntities();
            }
            
            this.Load += 分析_Load;
            this.DoneLoading += onDoneLoading;
        }

        private void onDoneLoading(object sender, EventArgs e)
        {
            this.chart1.DataSource = this.products;
            this.chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            this.chart1.Series[1].XValueMember = "交易日期";
            this.chart1.Series[1].YValueMembers = "當日價格";
            this.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            this.chart1.Series[0].XValueMember = "交易日期";
            this.chart1.Series[0].YValueMembers = "交易量";
            decimal maxPrice = (from p in this.products
                                select p.當日價格).Max();
            this.lblMax.Text = $"{maxPrice:C}";
            decimal minPrice = (from p in this.products
                                select p.當日價格).Min();
            this.lblMin.Text = $"{minPrice:C}";
            decimal avgPrice = (from p in this.products
                                select p.當日價格).Average();
            this.lblAvg.Text = $"{avgPrice:C}";
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = this.products;
            this.btnChooseProduct.Enabled = true;
        }

        public 分析(FOODEntities db)
        {
            InitializeComponent();
            this.db = db;
            
        }
        private void 分析_Load(object sender, EventArgs e)
        {
            this.btnChooseProduct.Click += BtnChooseProduct_Click;
        }

        private void BtnChooseProduct_Click(object sender, EventArgs e)
        {
            var f = new FrmChooseProduct(this.db);
            this.currentProduct = f.ShowProductChooser();
            if (this.currentProduct == null) return;
            else this.reload();
        }

        private void reload()
        {
            this.lblName.Text = this.currentProduct.Name;
            this.lblLatestPrice.Text = $"{this.currentProduct.LatestUpperPrice:C}";
            if (this.currentProduct.DailyTrend == null)
            {
                this.lblTrend.Text = "無資料";
            }
            else
            {
                this.lblTrend.Text = $"{this.currentProduct.DailyTrend}";
            }
            Task.Run(this.loading);
            this.btnChooseProduct.Enabled = false;
        }

        async private void loading()
        {
            var q = (from p in this.db.Product_WeeklyPrice
                     where p.ProductCode == this.currentProduct.ProductCode
                     select p);
            this.products.Clear();
            foreach (var p in q)
            {
                var item = new ProductItem();
                item.產品名稱 = p.Name;
                item.產品類型 = p.Category;
                item.當日價格 = p.Upper_Price.GetValueOrDefault();
                item.交易市場 = p.MarketName;
                item.交易日期 = $"{p.TransDate.GetValueOrDefault():MM/dd}";
                item.交易量 = p.Trans_Quantity.GetValueOrDefault();
                this.products.Add(item);
            }
            this.Invoke(this.DoneLoading);
        }

    }

    public class ProductItem
    {
        public string 產品名稱 { get; set; }
        public string 產品類型 { get; set; }
        public decimal 當日價格 { get; set; }
        public string 交易市場 { get; set; }
        public string 交易日期 { get; set; }
        public decimal 交易量 { get; set; }
    }
}
