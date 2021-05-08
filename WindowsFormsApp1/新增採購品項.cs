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
    public partial class 新增採購品項 : Form
    {
        private int purchaseID;
        private FOODEntities db = new FOODEntities();
        private List<ProductCodeAndNamesAndPrice> productCodeAndNamesAndPrice = new List<ProductCodeAndNamesAndPrice>();
        private List<Product_LatestPrice> product_LatestPrices;
        private bool cmbSelecting = false;
        public string ProductCode;
        public string productName;
        public decimal Qty;
        public decimal UnitPirce;
        public string Unit;
        public decimal Total;
        public string Comment;
        public 新增採購品項(int purchaseID)
        {
            InitializeComponent();
            this.purchaseID = purchaseID;
            this.button1.DialogResult = DialogResult.OK;
            this.button2.DialogResult = DialogResult.Cancel;
        }

        private void 新增採購品項_Load(object sender, EventArgs e)
        {
            this.product_LatestPrices = (this.Owner as 採購表單).product_LatestPrices;
            this.txtPurchaseID.Text = this.purchaseID.ToString();
            this.productCodeAndNamesAndPrice = (from p in this.product_LatestPrices
                                                select new
                                                ProductCodeAndNamesAndPrice()
                                                {
                                                    ProductCode = p.ProductCode,
                                                    Name = p.Name,
                                                    UnitPrice = p.LatestUpperPrice.GetValueOrDefault(),
                                                    Unit = p.Unit

                                                }).ToList();

            this.cmbProductCode.DataSource = this.productCodeAndNamesAndPrice;
            this.cmbProductCode.DisplayMember = "ProductCode";
            this.cmbProductCode.ValueMember = "ProductCode";
            this.cmbProductCode.SelectedIndex = -1;
            this.cmbProductCode.SelectedIndexChanged += CmbProductCode_SelectedIndexChanged;
            this.numQty.ValueChanged += NumQty_ValueChanged;
            this.button1.Click += Button1_Click;
            this.button2.Click += Button2_Click;

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            ProductCodeAndNamesAndPrice selectedProduct = this.cmbProductCode.SelectedItem as ProductCodeAndNamesAndPrice;
            this.ProductCode = selectedProduct.ProductCode;
            this.productName = selectedProduct.Name;
            this.Qty = this.numQty.Value;
            this.UnitPirce = decimal.Parse(this.txtUnitPrice.Text);
            this.Unit = selectedProduct.Unit;
            this.Total = this.Qty * this.UnitPirce;
            this.Comment = this.txtComment.Text;
            this.Close();
        }

        private void NumQty_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                var total = this.numQty.Value * decimal.Parse(this.txtUnitPrice.Text);
                this.txtTotal.Text = total.ToString();
                
            }
            catch (Exception)
            {

            }
        }

        private void CmbProductCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbSelecting) return;
            this.cmbSelecting = true;
            dynamic selectedProdCode = this.cmbProductCode.SelectedItem;
            this.txtProductName.Text = selectedProdCode.Name;

            this.txtUnitPrice.Text = selectedProdCode.UnitPrice.ToString();
            this.NumQty_ValueChanged(this, EventArgs.Empty);

            this.cmbSelecting = false;
        }

        private void btnSearchProduct_Click(object sender, EventArgs e)
        {

            if (this.cmbSelecting) return;
            this.cmbSelecting = true;
            for (int i = 0; i < this.productCodeAndNamesAndPrice.Count; i++)
            {
                if (this.productCodeAndNamesAndPrice[i].Name == this.txtProductName.Text)
                {
                    this.cmbProductCode.SelectedIndex = i;
                    this.txtUnitPrice.Text = this.productCodeAndNamesAndPrice[i].UnitPrice.ToString();
                    break;
                }
            }
            this.NumQty_ValueChanged(this, EventArgs.Empty);
            this.cmbSelecting = false;
        }

        
    }

    class ProductCodeAndNamesAndPrice
    {
        public string ProductCode { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public string Unit { get; set; }
    }

}
