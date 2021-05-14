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
        private bool rowEditing = false; //設一個flag來阻擋dataGridView1_CellValueChanged的連鎖反應  伯夷
        public 訂單表()
        {
            InitializeComponent();
            // 有些地方可以考慮把需要重複用到的資料表先轉成List放在變數裡，可以大幅加快表單的載入和反應速度  伯夷
        }

        private void 訂單表_Load(object sender, EventArgs e)  //依照發生順序放前面會比較直觀 伯夷
        {
            foreach (Control con in this.Controls)
            {
                con.Enabled = false;
            }
            this.button3.Enabled = true;
            this.button4.Enabled = true;
            this.dataGridView1.CellValueChanged += this.dataGridView1_CellValueChanged;
        }

        private void button3_Click(object sender, EventArgs e)  //依照發生順序放前面會比較直觀 伯夷
        {
            foreach (Control con in this.Controls)
            {
                con.Enabled = true;
                this.button2.Enabled = false;
                this.button4.Enabled = false;
                this.button6.Enabled = false; 
                this.button7.Enabled = false;
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
            this.ComboBox1_SelectedIndexChanged(this, EventArgs.Empty);  //這樣可以少觸發一次(原本先選1會觸發一次，選0又會再觸發一次)  伯夷

            this.comboBox5.SelectedIndexChanged += comboBox5_SelectedIndexChanged;
            this.comboBox5.SelectedIndex = 1;
            this.comboBox5.SelectedIndex = 0;

            foreach (var p in q1)
            {
                this.comboBox3.Items.Add(p.empname); //這裡不用DataSource？不用DataSource的話要記得清理comboBox3(comboBox3.clear())哦！ 伯夷 
            }

            var q3 = this.db.Products.Select(n => new { pdid = n.ProductCode, pdna = n.ProductCode + "  " + n.Name });
            //datagrirview匯入資料

            this.ProductCode.DataSource = q3.ToList();
            this.ProductCode.DisplayMember = "pdna";
            this.ProductCode.ValueMember = "pdid";

        }


        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox1.Text != "")
            {
                this.label16.Text = this.comboBox1.SelectedValue.ToString();
                var p = this.db.Customers.AsEnumerable().Where(n => n.Name == $"{this.comboBox1.Text}").Select(n => n); //不用new啦！ 伯夷
                var res = p.ToList()[0];
                //this.textBox6.Text = res.Unicode;  伯夷
                this.textBox6.Text = res.Unicode.ToString();
                this.textBox2.Text = res.ContactPerson;
                this.textBox3.Text = res.ContactCellPhone;
                this.textBox5.Text = res.Address;
                
            }
        }

        FOODEntities db = new FOODEntities();//建議移到建構子的上面 伯夷


        private void button1_Click(object sender, EventArgs e)
        {
            string status = "1";
            Order order = new Order(); //新增Order欄位

            order.OrderDate = this.dateTimePicker2.Value;
            order.RequiredDate = this.dateTimePicker1.Value;
            order.CustomerID = int.Parse(this.label16.Text);
            order.EmployeeID = int.Parse(this.label19.Text);
            order.Address = this.textBox4.Text;
            order.Comment = this.richTextBox1.Text;
            order.OrderStatus =short.Parse(status);

          

            DialogResult p = MessageBox.Show("確定新增?", "提醒", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (p == DialogResult.OK)
            {
                this.db.Orders.Add(order);

                this.db.Entry(order).State = System.Data.Entity.EntityState.Added; //柏頤的神奇方法
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
                        this.db.Entry(od).State = System.Data.Entity.EntityState.Added;
                    }
                }

               
                this.db.SaveChanges();//新增OD回DB
                MessageBox.Show("新增成功", "提醒", MessageBoxButtons.OK);

            }
            allclear();
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
            //////////多處修改   伯夷


            if (rowEditing == true) return;  //如果row正在編輯中，就return掉這個function  伯夷

          
            //try  //可以不需要try catch了，但是還是建議把try catch包回去以防萬一  伯夷
            //{
            if (e.ColumnIndex == 0 && rowEditing == false)
            {
                this.rowEditing = true;  //表示cell正在編輯中  伯夷
                DataGridViewComboBoxCell cb = dataGridView1[0, e.RowIndex] as DataGridViewComboBoxCell;

                //就這裡的用途，建議抓取this.db.Product_LatestPrice檢視表就好  伯夷
                string id = cb.Value.ToString();
                var q = from p in this.db.Products
                        where p.ProductCode == id
                        select new { name = p.Name, unit = p.Unit };
                var q1 = this.db.Product_LatestPrice.Where(n => n.ProductCode == id).Select(n => n.LatestUpperPrice);


                // 這裡應該不需要foreach吧？伯夷
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
            if (e.ColumnIndex == 1 && rowEditing == false)//搜尋關鍵字
            {

                this.rowEditing = true; //表示cell正在編輯中  伯夷


                //DataGridView的cell如果裡面沒東西的話，Value會是null
                //null進到linq就會報錯  伯夷
                if (this.dataGridView1.CurrentCell.Value == null)
                {
                    this.dataGridView1[0, e.RowIndex].Value = null;
                    this.dataGridView1[2, e.RowIndex].Value = null;
                    this.dataGridView1[3, e.RowIndex].Value = null;
                    this.dataGridView1[4, e.RowIndex].Value = null;
                    this.dataGridView1[5, e.RowIndex].Value = null;
                    this.rowEditing = false;
                    return;
                }

                var q = from p in this.db.Product_LatestPrice
                        where p.Name == this.dataGridView1.CurrentCell.Value.ToString()
                        select p;

                DataGridViewComboBoxCell cb = dataGridView1[0, e.RowIndex] as DataGridViewComboBoxCell;

                var found = q.ToList();// 先將產品名稱的查尋結果轉成list，如果found.Count不是0，表示有查詢到產品，才會進行下面的步驟  伯夷

                if (found.Count != 0)
                {
                    // 自動帶上ProductCode  伯夷
                    cb.Value = found[0].ProductCode;
                    // 自動帶上價格  伯夷
                    this.dataGridView1[2, e.RowIndex].Value = found[0].LatestUpperPrice.GetValueOrDefault().ToString();
                    // 自動帶上單位  伯夷
                    this.dataGridView1[4, e.RowIndex].Value = found[0].Unit;
                }

            }
            if ((e.ColumnIndex == 3 || e.ColumnIndex == 2) && rowEditing == false)
            {
                this.rowEditing = true; //表示cell正在編輯中  伯夷

                //要確定所選的產品有價格，然後有輸入數量才自動計算小計  伯夷
                if (this.dataGridView1[2, e.RowIndex].Value.ToString() == "" || this.dataGridView1[3, e.RowIndex].Value == null)
                    this.dataGridView1[5, e.RowIndex].Value = "";
                else
                {
                    this.dataGridView1[5, e.RowIndex].Value = decimal.Parse(this.dataGridView1[2, e.RowIndex].Value.ToString()) * decimal.Parse(this.dataGridView1[3, e.RowIndex].Value.ToString());
                }

            }
            this.rowEditing = false;  //表示cell已經編輯完成  伯夷
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}  //可以不需要try catch了，但是還是建議把try catch包回去以防萬一  伯夷

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox3.Text != "")
            {

                var q = this.db.Employees.AsEnumerable().Where(n => n.Name == $"{this.comboBox3.Text}").Select(n => n.EmployeeID);
                foreach (var p in q)
                {
                    this.label19.Text = p.ToString();
                }
            }
        }


        string OrderID;
        private void button4_Click(object sender, EventArgs e)
        {

            var q3 = this.db.Products.Select(n => new { pdid = n.ProductCode, pdna = n.ProductCode + "  " + n.Name });
            //datagrirview匯入資料


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
            k.TopMost = true;
            DialogResult res = k.ShowDialog();
            
            if (res == DialogResult.OK)
            {
                OrderID = k.suppliername;
                


                var q = from o in this.db.Orders
                        from od in this.db.OrderDetails
                        where o.OrderID == od.OrderID && o.OrderID.ToString() == OrderID
                        select new
                        {
                            oid = o.OrderID,
                            cid = o.CustomerID,
                            cname = o.Customer.Name,
                            cunid = o.Customer.Unicode,
                            add = o.Address,
                            epid = o.Employee.EmployeeID,
                            epname = o.Employee.Name,
                            pcode = od.ProductCode,
                            qty = od.Qty,
                            unp = od.UnitPrice,
                            status = o.StatusList.StatusName
                        };



                foreach (var p in q)
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
                    label20.Text = p.status;


                }
                找尋DATAGRIDVIEW資料(OrderID);

            }

        }

        private void 找尋DATAGRIDVIEW資料(string OrderID)
        {

            //////////要不要考慮一下在button4_Click(object sender, EventArgs e)先撈一次OrderDetails等著用？
            //////////因為只有button4_Click會呼叫這個方法，所以可以共用相同的OrderDetails清單
            ///////// 伯夷
            var q = this.db.OrderDetails.Where(n => n.OrderID.ToString() == OrderID).Select(n => new { prcode = n.ProductCode, prname = n.Product.Name, n.UnitPrice, n.Qty, n.Unit, n.Commert });

            for (int i = 0; i < q.ToList().Count; i++)
            {
                DataGridViewRow dr = this.dataGridView1.Rows[0].Clone() as DataGridViewRow;
                this.dataGridView1.Rows.Add(dr);
                DataGridViewComboBoxCell dgc = (DataGridViewComboBoxCell)this.dataGridView1.Rows[i].Cells[0];

                dgc.Value = q.ToList()[i].prcode;
                this.dataGridView1[1, i].Value = q.ToList()[i].prname;
                this.dataGridView1[2, i].Value = q.ToList()[i].UnitPrice;
                this.dataGridView1[3, i].Value = q.ToList()[i].Qty;
                this.dataGridView1[4, i].Value = q.ToList()[i].Unit;
                this.dataGridView1[6, i].Value = q.ToList()[i].Commert;
            }



        }

      
        private void button5_Click(object sender, EventArgs e)
        {//關閉所有欄位 只有新增查詢是可以用  清除所有欄位內的資料


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
                  
                if (dr[i].Cells[0].Value != null)
                    {
                        if (i > psd.Count && i < psd.Count) {
                            psd[i].ProductCode = dr[i].Cells[0].Value.ToString();
                            psd[i].Qty = decimal.Parse(dr[i].Cells[3].Value.ToString());
                            psd[i].UnitPrice = decimal.Parse(dr[i].Cells[2].Value.ToString());
                            psd[i].Unit = dr[i].Cells[4].Value.ToString();
                            if (dr[i].Cells[6].Value != null)
                            {
                                psd[i].Commert = dr[i].Cells[6].Value.ToString();
                            }
                            row = this.db.SaveChanges();//新增OD回DB
                        }
                    }

                    if (i > psd.Count || i < psd.Count)
                    {
                        MessageBox.Show("這邊是修改不是新增", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                }   
                  
                if (row != 0) MessageBox.Show("修改成功", "提醒", MessageBoxButtons.OK);
            }

            allclear();
          

            }

        private void allclear()
        {
            foreach (Control con in this.Controls)
            {
                dataGridView1.Rows.Clear();  /////dataGridView忘了清哦！ 伯夷

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
                    this.label20.Text = string.Empty;

                }




            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string a = "3";
            DialogResult p = MessageBox.Show("確定刪除?(資料不會復原)", "提醒", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (p == DialogResult.OK)
            {
                var od = (this.db.Orders.Where(n => n.OrderID.ToString() == OrderID).Select(n => n)).ToList();
              
                od[0].OrderStatus = short.Parse(a);



                this.db.SaveChanges();
                MessageBox.Show("刪除成功", "提醒", MessageBoxButtons.OK);
            }
            allclear();
        }

       
    }
}
