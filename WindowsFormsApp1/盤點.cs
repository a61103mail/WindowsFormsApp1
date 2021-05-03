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
        public 盤點()
        {
            InitializeComponent();
        }
        private FOODEntities FOODEntities = new FOODEntities();
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var q = from i in this.FOODEntities.Products
                    where i.ProductID.ToString().Contains(textBox1.Text)
                    select new { i.ProductID,i.Name,i.Pictures,i.CropCode};
            this.dataGridView1.DataSource = q.ToList();
        }

        private void 盤點_Load(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = FOODEntities;
        }
    }
}
