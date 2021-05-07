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
        FOODEntities db = new FOODEntities();

        public 訂單表()
        {
            InitializeComponent();

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


        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox1.Text != "")
            {
                this.label16.Text = this.comboBox1.SelectedValue.ToString();


                var p = this.db.Customers.AsEnumerable().Where(n => n.Name == $"{this.comboBox1.Text}").Select(n => new { n.Unicode, n.Address, n.ContactPerson, n.ContactCellPhone });
                var res = p.ToList()[0];
                this.textBox6.Text = res.Unicode;
                this.textBox5.Text = res.Address;
                this.textBox2.Text = res.ContactPerson;
                this.textBox3.Text = res.ContactCellPhone;
            }
        }

      

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

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
            foreach (var p in q)
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
                if (e.ColumnIndex == 0)
                {
                    DataGridViewComboBoxCell cb = dataGridView1[0, e.RowIndex] as DataGridViewComboBoxCell;

                    string id = cb.Value.ToString();
                    var q = from p in this.db.Products
                            where p.ProductCode == id
                            select new { name = p.Name, unit = p.Unit };
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
                if (e.ColumnIndex == 3 || e.ColumnIndex == 2)
                {
                    if (this.dataGridView1[3, e.RowIndex].Value == null)
                        this.dataGridView1[5, e.RowIndex].Value = "";
                    else
                    {
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
        private bool rowEditing = false; //設一個flag來阻擋dataGridView1_CellValueChanged的連鎖反應
        private void button3_Click(object sender, EventArgs e)
        {
            allclear();

            //-------------------------------------
            if (rowEditing == true) return;  //如果row正在編輯中，就return掉這個function


            foreach (Control con in this.Controls)
            {
                con.Enabled = true;
                this.button2.Enabled = false;
                this.button4.Enabled = false;
                this.button6.Enabled = false;
                this.button7.Enabled = false;

            }



            var q = this.db.Customers.Select(n => new { ctname = n.Name, ctid = n.CustomerID });
            //要先將資料會datagridview不然ODD會抱錯


            this.comboBox1.DataSource = q.ToList();
            this.comboBox1.DisplayMember = "ctname";
            this.comboBox1.ValueMember = "ctid";



            var q1 = this.db.Employees.Select(n => new { empname = n.Name, empid = n.EmployeeID });
            //匯入理貨人員，客服人員

            this.comboBox5.DataSource = q1.ToList();
            this.comboBox5.DisplayMember = "empname";
            this.comboBox5.ValueMember = "empid";

            this.comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            this.ComboBox1_SelectedIndexChanged(this, EventArgs.Empty);

            this.comboBox5.SelectedIndexChanged += comboBox5_SelectedIndexChanged;
            this.comboBox5_SelectedIndexChanged(this,EventArgs.Empty);

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

        private void allclear()//關閉所有欄位 只有新增查詢是可以用  清除所有欄位內的資料
        {
            dataGridView1.Rows.Clear();
            foreach (Control con in this.Controls)
            {
                con.Enabled = false;
                this.button4.Enabled = true;
                this.button3.Enabled = true;
                if (con is ComboBox)
                {
                    ComboBox cob = con as ComboBox;
                    cob.SelectedIndex = -1;
                }
                else if (con is TextBox)
                {
                    TextBox tb = con as TextBox;
                    tb.Text = string.Empty;
                }
                else if (con is Label)
                {
                    this.label16.Text = string.Empty;
                    this.label17.Text = string.Empty;
                    this.label18.Text = string.Empty;
                    this.label19.Text = string.Empty;

                }


            }
        }

        string OrderID;
        private void button4_Click(object sender, EventArgs e)
        {
            allclear();



            //-------------------------------
            var q3 = this.db.Products.Select(n => new { pdid = n.ProductCode, pdna = n.ProductCode + "  " + n.Name });
            //要先將資料會datagridview不然ODD會抱錯


            this.ProductCode.DataSource = q3.ToList();
            this.ProductCode.DisplayMember = "pdna";
            this.ProductCode.ValueMember = "pdid";



            foreach (Control con in this.Controls)
            {
                con.Enabled = false;
                this.button2.Enabled = true;
                this.button5.Enabled = true;


            }

            查詢子表 k = new 查詢子表();
            DialogResult res = k.ShowDialog(); //開啟搜尋子表
            if (res == DialogResult.OK) //確認找尋的訂單編號
            {
                OrderID = k.suppliername;//迴船訂單編號
                Console.WriteLine(OrderID);
            }

            var q = from o in this.db.Orders
                    from c in this.db.Customers
                    where o.CustomerID == c.CustomerID && o.OrderID.ToString() == OrderID
                    select new
                    {
                        oid = o.OrderID,
                        cid = o.CustomerID,
                        cname = o.Customer.Name,
                        cunid = o.Customer.Unicode,
                        add = o.Address,
                        epid = o.Employee.EmployeeID,
                        epname = o.Employee.Name,
                        cadd = c.Address,
                        ccp = c.ContactPerson,
                        ccpp = c.ContactCellPhone

                    };//找頁面上所需要的資料

            foreach (var p in q)//將資料匯入個欄位
            {

                label18.Text = p.oid.ToString();
                //dateTimePicker1.Value = p.OrderDate.Value;
                comboBox1.Text = p.cname;
                label16.Text = p.cid.ToString();
                textBox6.Text = p.cunid;
                textBox5.Text = p.add;
                label19.Text = p.epid.ToString() == null ? "0" : p.epid.ToString();
                comboBox3.Text = p.epname;
                comboBox5.Text = p.epname;
                label17.Text = p.epid.ToString();
                textBox5.Text = p.cadd;
                textBox2.Text = p.ccp;
                textBox3.Text = p.ccpp;

            }
            找尋DATAGRIDVIEW資料(OrderID);//datagridview資料
        }

        private void 找尋DATAGRIDVIEW資料(string OrderID)
        {
            //找尋需要的資料欄位
            var q = this.db.OrderDetails.Where(n => n.OrderID.ToString() == OrderID).Select(n => new { prcode = n.ProductCode, prname = n.Product.Name, n.UnitPrice, n.Qty, n.Unit, n.Commert });
            

            for (int i = 0; i < q.ToList().Count; i++)//匯入資料欄
            {
                DataGridViewRow dr = this.dataGridView1.Rows[0].Clone() as DataGridViewRow;//做一個容器接變數
                this.dataGridView1.Rows.Add(dr);
                DataGridViewComboBoxCell dgc = (DataGridViewComboBoxCell)this.dataGridView1.Rows[i].Cells[0];
                //將資料匯入第一個combobox

                dgc.Value = q.ToList()[i].prcode;
                //this.dataGridView1[1,i].Value = q.ToList()[i].prname;
                this.dataGridView1[2, i].Value = q.ToList()[i].UnitPrice;
                this.dataGridView1[3, i].Value = q.ToList()[i].Qty;
                this.dataGridView1[6, i].Value = q.ToList()[i].Commert;
            }




        }

        private void button1_Click(object sender, EventArgs e)
        {

            {
                Order order = new Order(); //新增Order欄位

                order.OrderDate = this.dateTimePicker2.Value;
                order.RequiredDate = this.dateTimePicker1.Value;
                order.CustomerID = int.Parse(this.label16.Text);
                order.EmployeeID = int.Parse(this.label19.Text);
                order.Address = this.textBox4.Text;
                order.Comment = this.richTextBox1.Text;




                DialogResult p = MessageBox.Show("確定新增?", "提醒", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                if (p == DialogResult.OK)
                {
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
                    var qq = (from odd in this.db.OrderDetails
                              select odd);
                    foreach (var q in qq)
                    {
                        Console.WriteLine(q.OrderDetailID);
                    }
                    MessageBox.Show("新增成功", "提醒", MessageBoxButtons.OK);

                }
            }
            allclear();



        }



        private void button5_Click(object sender, EventArgs e)
        {
            allclear();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            foreach (Control con in this.Controls)
            {
                con.Enabled = true;
                this.button3.Enabled = false;
                this.button1.Enabled = false;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var od = (this.db.Orders.Select(n => n)).FirstOrDefault();
            DialogResult p = MessageBox.Show("確定修改?", "提醒", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (p == DialogResult.OK)
            {
                if (od == null) return;
               
                od.DeliveryAddress = this.textBox4.Text;
                //-----------------------------------------------------------------------
                var odd1 = this.db.OrderDetails.Where(n=>n.OrderID.ToString()==this.label18.Text).Select(n => n);
                var psd= odd1.ToList();
               
                var dr = this.dataGridView1.Rows;
                int row = 0;
                for (int i = 0; i < dr.Count; i++) {
                    MessageBox.Show(psd.Count.ToString());
                    if (i>=psd.Count)
                {
                    MessageBox.Show("這邊是修改不是新增", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }

              else  if (dr[i].Cells[0].Value != null)
                {
                    psd[i].ProductCode = dr[i].Cells[0].Value.ToString();
                    psd[i].Qty = decimal.Parse(dr[i].Cells[3].Value.ToString());
                    psd[i].UnitPrice = decimal.Parse(dr[i].Cells[2].Value.ToString());
                    psd[i].Unit = dr[i].Cells[4].Value.ToString();
                    if (dr[i].Cells[6].Value != null)
                    {
                        psd[i].Commert = dr[i].Cells[6].Value.ToString();
                    }
                }
            }   
                  row=  this.db.SaveChanges();//新增OD回DB
                if (row != 0) MessageBox.Show("修改成功", "提醒", MessageBoxButtons.OK);
            }

            allclear();
          

            }

        private void button7_Click(object sender, EventArgs e)
        {
            DialogResult p = MessageBox.Show("確定刪除?(資料不會復原)", "提醒", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (p == DialogResult.OK)
            {
                var od = this.db.Orders.AsEnumerable().Where(n => n.OrderID.ToString() == this.label18.Text).Select(n => n);

                var odd = this.db.OrderDetails.AsEnumerable().Where(n => n.OrderID.ToString() == this.label18.Text).Select(n => n);
                var oddd = odd.ToList();
                var od1 = od.ToList();
                if (oddd != null)
                {
                    foreach (var q in oddd)
                    {
                        this.db.OrderDetails.Remove(q);

                    }
                }
                foreach (var q in od1)
                {
                    this.db.Orders.Remove(q);
                }
                this.db.SaveChanges();
                MessageBox.Show("刪除成功", "提醒", MessageBoxButtons.OK);
            }
            allclear();
        }
    }
    }
    
    

