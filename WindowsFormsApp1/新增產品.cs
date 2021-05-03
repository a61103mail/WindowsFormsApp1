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
    public partial class 新增產品 : Form
    {
        public 新增產品()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Name = textBox1.Text;
            string Unit = textBox2.Text;
            int CategoryId = comboBox1.SelectedIndex;
            string CropCode = textBox3.Text;
            string CustomerID = textBox4.Text;


        }
        private FOODEntities FOODEntities = new FOODEntities();
        private void 新增產品_Load(object sender, EventArgs e)
        {
            var q = (from o in this.FOODEntities.Categories
                     select o.CategoryID).Distinct();
            foreach (int s in q)
            {
                comboBox1.Items.Add(s);
            }
        }
    }
}
