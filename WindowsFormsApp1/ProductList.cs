using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    
    public partial class ProductList : Form
    {
        private FOODEntities FOODEntities = new FOODEntities();
        public List<Product_LatestPrice> product_Latests = new List<Product_LatestPrice>();
        public ProductList()
        {
            InitializeComponent();
            this.dataGridView1.AutoSize = true;
            this.product_Latests = (from p in this.FOODEntities.Product_LatestPrice
                                    select p).ToList();
        }
        
        private void ProductList_Load(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = this.product_Latests;
            button3.Enabled = false;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            新增產品 f = new 新增產品();
            f.TopMost = true;
            var res = f.ShowDialog(this);
            if (res == DialogResult.OK)
            {
                this.button6_Click(this, EventArgs.Empty);
            }
            f.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //var currentRowIndex = this.dataGridView1.SelectedCells[0].RowIndex;
            var selectedItem = this.dataGridView1.SelectedRows[0].DataBoundItem as Product_LatestPrice;            
            修改 f = new 修改(selectedItem.ProductID);
            f.TopMost = true;
            f.ShowDialog(this);
            this.FOODEntities.Entry<Product_LatestPrice>(selectedItem).Reload();
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var selectedItem = this.dataGridView1.SelectedRows[0].DataBoundItem as Product_LatestPrice;
            var selectedIndex = this.product_Latests.IndexOf(selectedItem);
            詳細 f = new 詳細(selectedIndex);
            f.TopMost = true;
            f.ShowDialog(this);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            盤點 f = new 盤點();
            f.TopMost = true;
            f.Show();
        }



        private void button6_Click(object sender, EventArgs e)
        {
            var q = from p in this.FOODEntities.Product_LatestPrice
                    select p;
            this.dataGridView1.DataSource = q.ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //DialogResult pp = MessageBox.Show("確定刪除此項目?", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            //if (pp == DialogResult.OK)
            //{
            //    var selectedItem = this.dataGridView1.SelectedRows[0].DataBoundItem as Product_LatestPrice;

            //    var q1 = from p in this.FOODEntities.Pictures
            //             where p.ProductCode == selectedItem.ProductCode
            //             select p;
            //    var pics = q1.ToList();
            //    Picture pic = null;
            //    if (pics.Count != 0) pic = pics[0];

            //    var q = from i in this.FOODEntities.Products
            //            where i.ProductID == selectedItem.ProductID
            //            select i;
            //    var del = q.ToList();
            //    if (pic != null) this.FOODEntities.Pictures.Remove(pic);
            //    this.FOODEntities.Products.Remove(del[0]);
            //    this.FOODEntities.SaveChanges();
            //    this.button6_Click(this, EventArgs.Empty);
            //    MessageBox.Show("刪除成功");
            //}
        }

        private void button7_Click(object sender, EventArgs e)
        {
            現有庫存 f = new 現有庫存();
            f.TopMost=true;
            f.Show();
        }
    }
}
