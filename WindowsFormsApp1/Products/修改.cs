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
    public partial class 修改 : Form
    {
        private FOODEntities FOODEntities = new FOODEntities();
        public int productID;
        private Product currentProduct;
        public 修改(int productID)
        {
            InitializeComponent();
            this.productID = productID;
        }

        private void 修改_Load(object sender, EventArgs e)
        {
            this.comboBox1.DataSource = (from s in this.FOODEntities.StatusLists
                                        where s.StatusID == 4 || s.StatusID == 5
                                        select s).ToList();
            
            this.comboBox1.DisplayMember = "StatusName";
            this.comboBox1.ValueMember = "StatusID";
            
            var q = (from p in this.FOODEntities.Products
                    where p.ProductID == this.productID
                    select p).FirstOrDefault();
            this.currentProduct = q;
            this.comboBox1.SelectedValue = this.currentProduct.ProductStatus;
            this.label2.Text = q.Name;
            this.comboBox1.SelectedIndexChanged += this.comboBox1_SelectedIndexChanged;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            DialogResult pp = MessageBox.Show("確定修改此項目?", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (pp == DialogResult.OK)
            {
                this.FOODEntities.SaveChanges();
                MessageBox.Show("修改成功");
            }
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.currentProduct.ProductStatus = (short)this.comboBox1.SelectedValue;
        }
    }
}
