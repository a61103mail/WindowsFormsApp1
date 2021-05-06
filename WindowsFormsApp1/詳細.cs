using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class 詳細 : Form
    {
        private FOODEntities FOODEntities = new FOODEntities();
        private int productID;
        private int productIndex = 0;
        private List<Product_LatestPrice> products;
        private List<Label> labels = new List<Label>();
        public 詳細(int selectedID)
        {
            InitializeComponent();
            this.productID = selectedID;
            this.products = FOODEntities.Product_LatestPrice.ToList();
            for (int i = 0; i < 10; i++)
            {
                var lbl = new Label();
                labels.Add(lbl);
                lbl.Dock = DockStyle.Fill;
                lbl.Font = new Font("標楷體", 14, FontStyle.Bold);
                this.tableLayoutPanel1.Controls.Add(lbl,1,i);
            }
        }

        private void 詳細_Load(object sender, EventArgs e)
        {
            var q = from p in products
                    where p.ProductID == this.productID
                    select new
                    {
                        image = getImage(p.ProductCode),
                        p.Name,
                        ProductID = getProductID(p.ProductID),
                        p.ProductCode,
                        p.CropCode,
                        p.Unit,
                        p.Category,
                        p.SupplierID,
                        p.LatestUpperPrice,
                        p.DailyTrend,
                        p.LatestMarket,
                        LatestTransDate = p.TransDate.GetValueOrDefault().ToShortDateString()
                    };
            var selectedProduct = q.ToList()[0];
            byte[] bytes = selectedProduct.image;
            label1.Text = selectedProduct.Name;
            if (bytes != null)
            {
                MemoryStream ms = new MemoryStream(bytes);
                this.pictureBox1.Image = Image.FromStream(ms);
            }
            else
            {
                this.pictureBox1.Image = null;
            }

            PropertyInfo[] props = selectedProduct.GetType().GetProperties();
            for (int i = 2; i < props.Length; i++) 
            {
                if (props[i].GetValue(selectedProduct) != null) 
                {
                    labels[i-2].Text = props[i].GetValue(selectedProduct).ToString();
                    if (i == 9)
                    {
                        if (decimal.Parse(props[i].GetValue(selectedProduct).ToString()) >= 2.0M) labels[i-2].BackColor = Color.Red;
                        else labels[i - 2].BackColor = Control.DefaultBackColor;
                    }
                }
            }

        }

        private int getProductID(int productID)
        {
            for (int i = 0; i < this.products.Count; i++)
            {
                if (this.products[i].ProductID == productID)
                {
                    this.productIndex = i;
                    this.productID = this.products[i].ProductID;
                }
            }
            return productID;
        }

        private byte[] getImage(string productCode)
        {
            var pics = (from pic in FOODEntities.Pictures
                           where pic.ProductCode == productCode
                           select pic.IMG).ToList();
            if (pics.Count == 0) return null;
            else return pics[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.productIndex <= 0) return;
            else this.productIndex -= 1;
            this.productID = this.products[this.productIndex].ProductID;
            this.詳細_Load(this, EventArgs.Empty);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.productIndex >= this.products.Count -1 ) return;
            else this.productIndex += 1;
            this.productID = this.products[this.productIndex].ProductID;
            this.詳細_Load(this, EventArgs.Empty);
        }
    }
}
