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

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
         
                this.label16.Text = this.comboBox1.SelectedValue.ToString();
          
          
                var p = this.db.Customers.AsEnumerable().Where(n => n.Name == $"{this.comboBox1.Text}").Select(n => new { n.Unicode });
                var res = p.ToList()[0];
                this.textBox6.Text = res.Unicode;
           
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
                //CustomerID =int.Parse( $"{this.comboBox1}"),
                //EmployeeID =int.Parse($" {this.comboBox4}"),
                Address =this.textBox4.Text,
                Comment = this.richTextBox1.Text
            };
            
            this.db.Orders.Add(order);
            this.db.SaveChanges();
            MessageBox.Show("新增成功","",MessageBoxButtons.OK);


        }

        private void 訂單表_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'fOODDataSet.OrderDetail' 資料表。您可以視需要進行移動或移除。
            

            var q = this.db.Customers.Select(n=>new { ctname=n.Name , ctid=n.CustomerID });                    

            this.comboBox1.DataSource = q.ToList();
            this.comboBox1.DisplayMember = "ctname";
            this.comboBox1.ValueMember = "ctid";
            
            
            var q1 = this.db.Employees.Select(n => new { empname = n.Name, empid = n.EmployeeID });
                 
            this.comboBox5.DataSource = q1.ToList();
            this.comboBox5.DisplayMember = "empname";
            this.comboBox5.ValueMember = "empid";
           
            this.comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            this.comboBox1.SelectedIndex = 1;
            this.comboBox1.SelectedIndex = 0;

            this.comboBox5.SelectedIndexChanged += comboBox5_SelectedIndexChanged;
            this.comboBox5.SelectedIndex = 1;
            this.comboBox5.SelectedIndex = 0;

            //this.productEntryTableAdapter1.Fill(this.foodDataSet1.ProductEntry);
            //this.dataGridView1.DataSource = this.foodDataSet1.ProductEntry;

            var q3 = this.db.Products.Select(n => new { pdid = n.ProductID, pdna = n.Name  });

            
            this.productid.DataSource = q3.ToList();
            this.productid.DisplayMember = "pdid";
            this.productid.ValueMember = "pdid";

            this.productname.DataSource = q3.ToList();
            this.productname.DisplayMember = "pdna";
            this.productname.ValueMember = "pdid";

  



        }

        private void button2_Click(object sender, EventArgs e)
        {
            var order = (from p in this.db.Orders
                         where p.Comment.Contains("test")
                         select p).FirstOrDefault();
            if (order == null) return;
            this.db.SaveChanges();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox5.SelectedValue.GetType().ToString() != "System.Int32")
            {
                this.label17.Text = "無編號";
            }
            else
            {
                this.label17.Text = this.comboBox5.SelectedValue.ToString();
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var p = this.db.Products.AsEnumerable().Where(n => n.ProductID == int.Parse($"{this.productid.Items}")).Select(n => n.Name);
           
            this.productname.DataSource = p.ToList();
        }

       

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

        }

        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView1.IsCurrentCellDirty)
            {
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0) {
                DataGridViewComboBoxCell cb = dataGridView1[0, e.RowIndex] as DataGridViewComboBoxCell;
                
                    MessageBox.Show(cb.Value.ToString());
                }

            }
            catch
            {

            }

        }
    }
}
