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
    
    public partial class ProductList : Form
    {
        private FOODEntities FOODEntities = new FOODEntities();
        public ProductList()
        {
            InitializeComponent();
            this.dataGridView1.AutoSize = true;
        }
        
        private void ProductList_Load(object sender, EventArgs e)
        {
            var q = from p in this.FOODEntities.Products
                    select new {p.ProductID, p.Name, Category=p.Category.Name, p.Unit  };
            this.dataGridView1.DataSource = q.ToList();
                    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            新增產品 f = new 新增產品();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var currentRowIndex = this.dataGridView1.SelectedCells[0].RowIndex;
           
        }
    }
}
