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
    public partial class 盤點 : Form
    {
        public List<Product> Products = new List<Product>();
        public 盤點()
        {
            InitializeComponent();
        }
        private FOODEntities FOODEntities = new FOODEntities();
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var q = from i in this.FOODEntities.Products
                    where i.ProductID.ToString().Contains(textBox1.Text)
                    select new  displayItem{ ProductId=i.ProductID,ProductCode=i.ProductCode,Name=i.Name,Unit=i.Unit };
            this.dataGridView1.DataSource = q.ToList();
        }

        private void 盤點_Load(object sender, EventArgs e)
        {
            var q = from i in FOODEntities.Products
                    select new displayItem{ ProductId = i.ProductID, ProductCode = i.ProductCode, Name = i.Name, Unit = i.Unit };
            this.dataGridView1.DataSource = q.ToList();
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Inventory newI = new Inventory();
            if(textBox2.Text=="")
                MessageBox.Show("請輸入數量");
            else
            {

                var selectedItem = this.dataGridView1.SelectedRows[0].DataBoundItem as displayItem;
                //newI.InventoryID = selectedItem.ProductId;
                newI.ProductCode = selectedItem.ProductCode;
                newI.Qty = Convert.ToDecimal(textBox2.Text);
                newI.Date = DateTime.Now;

                DialogResult p = MessageBox.Show("確定新增?", "提醒", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                if (p == DialogResult.OK)
                {
                    this.FOODEntities.Inventories.Add(newI);
                    this.FOODEntities.SaveChanges();//新增product回DB
                    MessageBox.Show("新增成功");
                    textBox2.Text = "";
                }
                else
                {
                    MessageBox.Show("something wrong");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult p = MessageBox.Show("確定刪除?", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (p == DialogResult.OK)
            {
                var de = from h in FOODEntities.Inventories
                         select h;
                foreach (var a in de)
                {
                    FOODEntities.Inventories.Remove(a);
                }
                FOODEntities.SaveChanges();
                MessageBox.Show("刪除成功");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            現有庫存 f = new 現有庫存();
            f.Show();
        }
    }

    public class displayItem
    {
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
    }

}
