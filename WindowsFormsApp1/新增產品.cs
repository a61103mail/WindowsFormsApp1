using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Properties;

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
            Product newp = new Product();
            newp.Name = textBox1.Text;
            newp.ProductCode = textBox2.Text;
            newp.Unit = comboBox2.SelectedItem.ToString();
            newp.CategoryID = comboBox1.SelectedIndex+1;
            newp.CropCode = textBox3.Text;
            //insert
            DialogResult p = MessageBox.Show("確定新增?", "提醒", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (p == DialogResult.OK)
            {
                if(newp.Name=="" | newp.ProductCode=="" | newp.Unit=="" | newp.CropCode=="")
                {
                    MessageBox.Show("有*字號的項目必須填寫");
                }
                else
                {
                    this.FOODEntities.Products.Add(newp);
                    this.FOODEntities.SaveChanges();//新增product回DB
                }                  
                MessageBox.Show("新增成功");

            }



            }
        private FOODEntities FOODEntities = new FOODEntities();
        private void 新增產品_Load(object sender, EventArgs e)
        {
            var q = from o in this.FOODEntities.Categories
                    select o.Name;
            foreach(var s in q)
            {
                comboBox1.Items.Add(s);
            }
            var u = (from i in this.FOODEntities.Products
                    select i.Unit).Distinct();
            foreach(var k in u)
            {
                comboBox2.Items.Add(k);
            }
        }
    }
}
