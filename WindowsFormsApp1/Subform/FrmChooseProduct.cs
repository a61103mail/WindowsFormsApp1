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
    public partial class FrmChooseProduct : Form
    {
        private FOODEntities db;
        private Product_LatestPrice product;
        public FrmChooseProduct(FOODEntities db)
        {
            InitializeComponent();
            this.db = db;
            this.Load += FrmChooseProduct_Load;
            this.listBox1.Click += ListBox1_Click;
            
        }

        private void ListBox1_Click(object sender, EventArgs e)
        {
            this.product = listBox1.SelectedItem as Product_LatestPrice;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ListBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void FrmChooseProduct_Load(object sender, EventArgs e)
        {
            this.listBox1.DataSource = (from p in this.db.Product_LatestPrice
                                       select p).ToList();
            this.listBox1.DisplayMember = "Name";
        }

        public Product_LatestPrice ShowProductChooser()
        {
            var res = this.ShowDialog();
            if (res == DialogResult.Cancel) return null;
            else 
            {
                return this.product;
            }
        }
    }
}
