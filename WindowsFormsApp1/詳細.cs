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
        public 詳細(int selectIndex)
        {
            InitializeComponent();
            this.productID = selectIndex;
            this.products = FOODEntities.Product_LatestPrice.ToList();
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
                var label = new Label();
                label.Dock = DockStyle.Fill;
                label.Font = new Font("標楷體", 14, FontStyle.Bold);
                if (props[i].GetValue(selectedProduct) != null) 
                {
                    label.Text = props[i].GetValue(selectedProduct).ToString();
                    this.tableLayoutPanel1.Controls.Add(label, 1, i - 2);
                    if (i == 9)
                    {
                        if (decimal.Parse(props[i].GetValue(selectedProduct).ToString()) >= 2.0M) label.BackColor = Color.Red;
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
                }
            }
            Console.WriteLine(this.productIndex);
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

        }
    }
}
