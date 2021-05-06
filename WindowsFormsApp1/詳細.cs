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
        public 詳細(int selectIndex)
        {
            InitializeComponent();
            this.productID = selectIndex;
        }

        private void 詳細_Load(object sender, EventArgs e)
        {
            var q = from p in FOODEntities.Product_LatestPrice.AsEnumerable()
                    where p.ProductID == this.productID
                    select new
                    {
                        image = (
                            from pic in FOODEntities.Pictures
                            where pic.ProductCode == p.ProductCode
                            select pic.IMG
                        ).ToList()[0],
                        p.Name,
                        p.ProductID,
                        p.ProductCode,
                        p.CropCode,
                        p.Unit,
                        p.Category,
                        p.SupplierID,
                        p.LatestUpperPrice,
                        p.DailyTrend,
                        p.LatestMarket,
                        p.TransDate
                    };
            var selectedProduct = q.ToList()[0];
            byte[] bytes = selectedProduct.image;
            label1.Text = selectedProduct.Name;
            MemoryStream ms = new MemoryStream(bytes);
            this.pictureBox1.Image = Image.FromStream(ms);
            PropertyInfo[] props = selectedProduct.GetType().GetProperties();
            for (int i = 2; i < props.Length; i++) 
            {
                var label = new Label();
                label.Font = new Font("標楷體", 14, FontStyle.Bold);
                if (props[i].GetValue(selectedProduct) != null) 
                {

                    if (i == props.Length - 1)
                    {
                        var trand = selectedProduct.TransDate;
                        label.Text = $"000000009";
                    }
                    else
                    {
                        label.Text = props[i].GetValue(selectedProduct).ToString();
                    }                    
                    this.tableLayoutPanel1.Controls.Add(label, 1, i - 2);
                    
                    
                }
            }

        }


    }
}
