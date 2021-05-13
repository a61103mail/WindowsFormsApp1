using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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
            this.button1.DialogResult = DialogResult.OK;
            this.button2.DialogResult = DialogResult.Cancel;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Product newp = new Product();
            Picture newpic = new Picture();
            try
            {
                if (newp.Name == "" | newp.ProductCode == "" | newp.Unit == "" | newp.CropCode == "")
                {
                    MessageBox.Show("有*字號的項目必須填寫");
                    return;
                }
                else
                {
                    newp.Name = textBox1.Text;
                    newp.ProductCode = textBox2.Text;
                    newp.Unit = comboBox2.SelectedItem.ToString();
                    newp.CategoryID = comboBox1.SelectedIndex + 1;
                    newp.CropCode = textBox3.Text;
                    if (txtPic.Text != null && File.Exists(this.txtPic.Text))
                    {
                        newpic.ProductCode = newp.ProductCode;
                        var png = Image.FromFile(this.txtPic.Text);
                        MemoryStream ms = new MemoryStream();
                        png.Save(ms,ImageFormat.Png);
                        byte[] bytes = ms.GetBuffer();
                        newpic.IMG = bytes;
                    }
                }                
                //insert
                DialogResult p = MessageBox.Show("確定新增?", "提醒", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                if (p == DialogResult.OK)
                {
                    this.FOODEntities.Products.Add(newp);
                    if (txtPic.Text != null && File.Exists(this.txtPic.Text)) this.FOODEntities.Pictures.Add(newpic);
                    this.FOODEntities.SaveChanges();//新增product回DB
                }
                else
                {
                    return;
                }
                MessageBox.Show("新增成功");
            }
            catch (Exception)
            {
                MessageBox.Show("輸入格式錯誤!");
            }
            this.Close();
            
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.picDialog1.Filter = @"Image Files|*PNG";
            var res = this.picDialog1.ShowDialog(this);
            if (res == DialogResult.OK)
            {
                this.txtPic.Text = this.picDialog1.FileName;
            }
            this.picDialog1.Dispose();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.txtPic.Text = null;
        }
    }
}
