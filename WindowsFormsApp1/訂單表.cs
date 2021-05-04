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
      

        private void button1_Click(object sender, EventArgs e)
        {
            Order order = new Order
            {
                OrderDate = this.dateTimePicker2.Value,
                RequiredDate = this.dateTimePicker1.Value,
                CustomerID = int.Parse(this.label16.Text),
                //EmployeeID = int.Parse(this.comboBox4.Text),
                Address = this.textBox4.Text,
                Comment = this.richTextBox1.Text
            };
           

        DialogResult p = MessageBox.Show("確定新增?","提醒", MessageBoxButtons.OKCancel,MessageBoxIcon.Exclamation);
            if (p == DialogResult.OK) {
                this.db.Orders.Add(order);
                //this.db.OrderDetails.Add(od);               
                this.db.SaveChanges();
                this.label18.Text = order.OrderID.ToString();//顯示出新增的流水號
                foreach (DataGridViewRow dr in this.dataGridView1.Rows)
                {
                    //if (dr.Cells[0].Value.ToString()!="")
                   
                        //MessageBox.Show(dr.Cells[0].Value.ToString());
                        OrderDetail od = new OrderDetail();

                        if (dr.Cells[0].Value != null)
                    { 
                        od.ProductCode = dr.Cells[0].Value.ToString();
                        od.OrderID = order.OrderID;
                        od.Qty = decimal.Parse(dr.Cells[3].Value.ToString());
                        od.UnitPrice = decimal.Parse(dr.Cells[2].Value.ToString());
                        od.Unit = dr.Cells[4].Value.ToString();
                        if (dr.Cells[6].Value != null)
                        {
                            od.Commert = dr.Cells[6].Value.ToString();
                        }

                    
                        this.db.OrderDetails.Add(od);
                      
                    }
                }
                this.db.SaveChanges();
                MessageBox.Show("新增成功", "提醒", MessageBoxButtons.OK);

            }
            
        }

        private void 訂單表_Load(object sender, EventArgs e)
        {
            
            

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

            var q3 = this.db.Products.Select(n => new { pdid = n.ProductCode, pdna = n.ProductCode +"  "+ n.Name    });


            this.ProductCode.DataSource = q3.ToList();
            this.ProductCode.DisplayMember = "pdna";
            this.ProductCode.ValueMember = "pdid";







        }

        private void button2_Click(object sender, EventArgs e)
        {
            var order = (from p in this.db.Orders
                         where p.Comment.Contains("test")
                         select p).FirstOrDefault();
           
            DialogResult p1 = MessageBox.Show("確定新增?", "提醒", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (p1 == DialogResult.OK)
            {
                if (order == null) return;
                var orderdetailld = (this.db.OrderDetails.Where(n => n.Commert.Contains("test")).Select(n => n)).FirstOrDefault();
                if (orderdetailld == null) return;
                this.db.SaveChanges();
            }

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
            
           
          
        }

       

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            
            TextBox autoText = e.Control as TextBox;
            if (autoText != null)
            {
                autoText.AutoCompleteMode = AutoCompleteMode.Suggest;
                autoText.AutoCompleteSource = AutoCompleteSource.CustomSource;
                AutoCompleteStringCollection DataCollection = new AutoCompleteStringCollection();
                addItems(DataCollection);
                autoText.AutoCompleteCustomSource = DataCollection;
            }
        }

        private void addItems(AutoCompleteStringCollection col)
        {
            var q = from p in db.Products
                    select p.Name;
            foreach(var p in q)
            {
                col.Add(p.ToString());
            }
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

                    string id = cb.Value.ToString();
                    var q = from p in this.db.Products
                            where p.ProductCode == id
                            select new {name= p.Name ,unit= p.Unit};
                    var q1 = this.db.Product_LatestPrice.Where(n => n.ProductCode == id).Select(n => n.LatestUpperPrice);
                    
                    foreach (var p in q)
                    {
                        this.dataGridView1[1, e.RowIndex].Value =p.name;
                        this.dataGridView1[4, e.RowIndex].Value = p.unit;
                        this.dataGridView1[2, e.RowIndex].Value = q1.ToList()[0].ToString();
                    }

                }
                if (e.ColumnIndex == 1)
                {
                    
                    var q = from p in db.Products
                            where p.Name == this.dataGridView1.CurrentCell.Value.ToString()
                            select p.ProductCode;

                    DataGridViewComboBoxCell cb = dataGridView1[0, e.RowIndex] as DataGridViewComboBoxCell;
                    cb.Value = q.ToList()[0];
                                    }
                if (e.ColumnIndex == 3)
                {
                    this.dataGridView1[5, e.RowIndex].Value = decimal.Parse(this.dataGridView1[2, e.RowIndex].Value.ToString()) * decimal.Parse(this.dataGridView1[3, e.RowIndex].Value.ToString());
                 
                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }

        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
