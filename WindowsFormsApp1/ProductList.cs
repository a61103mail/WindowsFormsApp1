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
        public ProductList()
        {
            InitializeComponent();
            this.dataGridView1.AutoSize = true;
        }
        
        private void ProductList_Load(object sender, EventArgs e)
        {
            var q = from p in this.FOODEntities.Product_LatestPrice
                    select p;
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

        private void button4_Click(object sender, EventArgs e)
        {
            var selectedIndex = int.Parse(this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            詳細 f = new 詳細(selectedIndex);
            f.Show(this);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            盤點 f = new 盤點();
            f.Show();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            var q = from p in this.FOODEntities.Product_LatestPrice
                    select p;
            this.dataGridView1.DataSource = q.ToList();
        }
    }
}
