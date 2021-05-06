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
            Order order = new Order(); //新增Order欄位

            order.OrderDate = this.dateTimePicker2.Value;
            order.RequiredDate = this.dateTimePicker1.Value;
            order.CustomerID = int.Parse(this.label16.Text);
            order.EmployeeID = int.Parse(this.label19.Text);
            order.Address = this.textBox4.Text;
            order.Comment = this.richTextBox1.Text;




        DialogResult p = MessageBox.Show("確定新增?","提醒", MessageBoxButtons.OKCancel,MessageBoxIcon.Exclamation);
            if (p == DialogResult.OK) {
                this.db.Orders.Add(order);                       
                this.db.SaveChanges();//新增Order回DB
                this.label18.Text = order.OrderID.ToString();//顯示出新增的流水號
                foreach (DataGridViewRow dr in this.dataGridView1.Rows)
                {
                    
                        OrderDetail od = new OrderDetail();//新增OD欄位

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
                this.db.SaveChanges();//新增OD回DB
                MessageBox.Show("新增成功", "提醒", MessageBoxButtons.OK);

            }
            
        }

        private void 訂單表_Load(object sender, EventArgs e)
        {
            foreach (Control con in this.Controls)
            {
                con.Enabled = false;
                this.button4.Enabled = true;
                this.button3.Enabled = true;          
            }

          
          
        }

      

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox5.SelectedValue.GetType().ToString() != "System.Int32")//柏翰寫的(如果用foreach就不用寫這邊)
            {
                this.label17.Text = "無編號";
            }
            else
            {
                this.label17.Text = this.comboBox5.SelectedValue.ToString();
            }
        }

      
        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            
            TextBox autoText = e.Control as TextBox; //建立dataGridView1與model的關聯
            if (autoText != null)
            {
                autoText.AutoCompleteMode = AutoCompleteMode.Suggest;
                autoText.AutoCompleteSource = AutoCompleteSource.CustomSource;
                AutoCompleteStringCollection DataCollection = new AutoCompleteStringCollection();
                addItems(DataCollection);
                autoText.AutoCompleteCustomSource = DataCollection;
            }
        }

        private void addItems(AutoCompleteStringCollection col) //提取資料給dataGridView1
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
            if (dataGridView1.IsCurrentCellDirty) //大家都不知道只有柏翰哥清楚
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

                    foreach (var p in q) //抓取後面搜尋的資料
                    {
                        this.dataGridView1[1, e.RowIndex].Value = p.name;
                        this.dataGridView1[4, e.RowIndex].Value = p.unit;
                        var s = q1.ToList();
                        if (s.Count != 0)
                        {
                            this.dataGridView1[2, e.RowIndex].Value = s[0].ToString();

                        }
                    }
                }
                if (e.ColumnIndex == 1)//搜尋關鍵字
                {
                    
                    var q = from p in db.Products
                            where p.Name == this.dataGridView1.CurrentCell.Value.ToString()
                            select p.ProductCode;

                    DataGridViewComboBoxCell cb = dataGridView1[0, e.RowIndex] as DataGridViewComboBoxCell;
                    cb.Value = q.ToList()[0];
                                    }
                if (e.ColumnIndex == 3 || e.ColumnIndex==2)
                {
                    if (this.dataGridView1[3, e.RowIndex].Value == null)
                        this.dataGridView1[5, e.RowIndex].Value = "";
                    else {
                    this.dataGridView1[5, e.RowIndex].Value = decimal.Parse(this.dataGridView1[2, e.RowIndex].Value.ToString()) * decimal.Parse(this.dataGridView1[3, e.RowIndex].Value.ToString());
                    }
                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            var q = this.db.Employees.AsEnumerable().Where(n => n.Name == $"{this.comboBox3.Text}").Select(n => n.EmployeeID);
            foreach (var p in q)
            {
                this.label19.Text = p.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (Control con in this.Controls)
            {
                con.Enabled = true;
                this.button2.Enabled = false;
                this.button4.Enabled = false;
            
            }



            var q = this.db.Customers.Select(n => new { ctname = n.Name, ctid = n.CustomerID });//匯入客戶


            this.comboBox1.DataSource = q.ToList();
            this.comboBox1.DisplayMember = "ctname";
            this.comboBox1.ValueMember = "ctid";


            var q1 = this.db.Employees.Select(n => new { empname = n.Name, empid = n.EmployeeID }); //匯入理貨人員，客服人員

            this.comboBox5.DataSource = q1.ToList();
            this.comboBox5.DisplayMember = "empname";
            this.comboBox5.ValueMember = "empid";

            this.comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            this.comboBox1.SelectedIndex = 1;
            this.comboBox1.SelectedIndex = 0;

            this.comboBox5.SelectedIndexChanged += comboBox5_SelectedIndexChanged;
            this.comboBox5.SelectedIndex = 1;
            this.comboBox5.SelectedIndex = 0;

            foreach (var p in q1)
            {
                this.comboBox3.Items.Add(p.empname);

            }


            var q3 = this.db.Products.Select(n => new { pdid = n.ProductCode, pdna = n.ProductCode + "  " + n.Name });
            //datagrirview匯入資料


            this.ProductCode.DataSource = q3.ToList();
            this.ProductCode.DisplayMember = "pdna";
            this.ProductCode.ValueMember = "pdid";



        }
        string suppliername;
        private void button4_Click(object sender, EventArgs e)
        {
            foreach (Control con in this.Controls)
            {
                con.Enabled = true;
                this.button3.Enabled = false;
                this.button4.Enabled = false;

            }

            查詢子表 k = new 查詢子表();
         DialogResult res=   k.ShowDialog();
            if (res == DialogResult.OK)
            {
                suppliername = k.suppliername;
            }
            var q = this.db.Orders.AsEnumerable().Where(n => n.OrderID.ToString() == k.suppliername).Select(n =>new { 
                cname=n.Customer.Name ,
                cid=n.CustomerID , 
                epid=n.EmployeeID, 
                epname=n.Employee.EmployeeID,
                add=n.Address,
            });
            foreach (var p in q)
            {
                this.comboBox1.Items.Add(p.cname);
                this.label16.Text = this.comboBox1.SelectedIndex.ToString();

            
            }
           
        }

        private void button5_Click(object sender, EventArgs e)
        {//關閉所有欄位 只有新增查詢是可以用得
            foreach (Control con in this.Controls)
            {
                con.Enabled = false;
                this.button4.Enabled = true;
                this.button3.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (Control con in this.Controls)
            {
                con.Enabled = true;                
                this.button3.Enabled = false;
            }
        }
    }
}
