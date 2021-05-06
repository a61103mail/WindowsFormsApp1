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
        private List<Label> labels = new List<Label>();
        private int selectedIndex = 0;
        private BindingSource bindingSource = new BindingSource();
        private List<Product_LatestPrice> product_Latests;
        public 詳細(int selectedIndex)
        {
            InitializeComponent();
            this.selectedIndex = selectedIndex;
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
            this.product_Latests = (this.Owner as ProductList).product_Latests;
            this.reload();
            PropertyInfo[] props = this.bindingSource.DataSource.GetType().GetProperties();
            for (int i = 2; i < props.Length; i++)
            {
                this.labels[i - 2].DataBindings.Add("Text", this.bindingSource, props[i].Name);
            }
            this.label1.DataBindings.Add("Text", this.bindingSource, "Name");
            this.pictureBox1.DataBindings.Add("Image", this.bindingSource, "image");
        }

        private void reload()
        {
            var selectedProduct = this.product_Latests[this.selectedIndex];
            var selectedDetail = new
            {
                image = getImage(selectedProduct.ProductCode),
                Name = selectedProduct.Name,
                ProductID = selectedProduct.ProductID,
                ProductCode = selectedProduct.ProductCode,
                CropCode = selectedProduct.CropCode,
                Unit = selectedProduct.Unit,
                Category = selectedProduct.Category,
                SupplierID = selectedProduct.SupplierID,
                LatestUpperPrice = selectedProduct.LatestUpperPrice,
                DailyTrend = selectedProduct.DailyTrend,
                LatestMarket = selectedProduct.LatestMarket,
                LatestTransDate = selectedProduct.TransDate.GetValueOrDefault().ToShortDateString()
            };
            this.bindingSource.DataSource = selectedDetail;

        }

        private Image getImage(string productCode)
        {
            Image img = null;
            var pics = (from pic in FOODEntities.Pictures
                        where pic.ProductCode == productCode
                        select pic.IMG).ToList();
            if (pics.Count != 0)
            {
                MemoryStream ms = new MemoryStream(pics[0]);
                img = Image.FromStream(ms);
            }
            return img;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.selectedIndex <= 0) return;
            else this.selectedIndex -= 1;
            reload();
            this.bindingSource.ResetBindings(false);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.selectedIndex >= this.product_Latests.Count - 1) return;
            else this.selectedIndex += 1;
            reload();
            this.bindingSource.ResetBindings(false);
        }
    }
}
