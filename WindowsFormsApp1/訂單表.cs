using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Properties
{
    public partial class 訂單表 : Form
    {
        public 訂單表()
        {
            InitializeComponent();
        }
        FOODEntities db = new FOODEntities();
        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Order order = new Order
            {
                OrderDate = this.dateTimePicker2.Value,
                RequiredDate =this.dateTimePicker1.Value,
                //CustomerID = Int32.Parse($"{this.comboBox1}")/*,*/
                //EmployeeID = int.Parse($"{this.comboBox4}"),
                Address =this.textBox4.Text,
                Comment = this.richTextBox1.Text
            };
            this.db.Orders.Add(order);
            this.db.SaveChanges();
            MessageBox.Show("新增成功");

        }

        private void 訂單表_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var order = (from p in this.db.Orders
                         where p.Comment.Contains("test")
                         select p).FirstOrDefault();
            if (order == null) return;
            this.db.SaveChanges();
        }
    }
}
