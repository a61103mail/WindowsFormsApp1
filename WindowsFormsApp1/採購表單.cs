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
    public partial class 採購表單 : Form
    {
        private BindingSource bs = new BindingSource();
        FOODEntities db = new FOODEntities();
        string suppliername;
        public 採購表單()
        {
            
            InitializeComponent();
            controlbutton();
            addnews();
            addItemsCustomerName();
            
        }

        private void controlbutton()
        {
            foreach (Control con in this.Controls)
            {
                con.Enabled = false;
                this.button8.Enabled = true;
                this.button3.Enabled = true;
            }
        }

        
        private void addnews()
        {
            var q = from e in this.db.Employees
                    select new { empna = e.Name, empid = e.EmployeeID };

            foreach (var n in q)
            {
                this.comboBox1.Items.Add(n.empna);
                this.comboBox2.Items.Add(n.empna);
            }

            var q2 = from p in this.db.Products
                     select new { pcd = p.ProductCode};
            this.productid.DataSource = q2.ToList();
            this.productid.DisplayMember = "pcd";
            this.productid.ValueMember = "pcd";

        }

        private void addItemsCustomerName()
        {
            AutoCompleteStringCollection DataCollection = new AutoCompleteStringCollection();
            var q = from a in this.db.Customers
                    where a.CustomerRoleID == 1
                    select a.Name;
            foreach (var p in q)
            {
                DataCollection.Add(p.ToString());
            }
            this.textBox1.AutoCompleteCustomSource = DataCollection;
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            採購搜尋頁面 f = new 採購搜尋頁面();
            DialogResult res = f.ShowDialog();
            if (res == DialogResult.OK)
            {
                suppliername = f.suppliername;
            }
            this.textBox1.Text = suppliername;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var q = from c in this.db.Customers
                    where c.Name == this.textBox1.Text && c.CustomerRoleID == 1
                    select new { spid = c.CustomerID, spcp = c.ContactPerson, spph = c.Phone, spun = c.Unicode, spads = c.Address };
            foreach (var n in q)
            {
                this.label12.Text = n.spid.ToString();
                this.textBox3.Text = n.spcp.ToString();
                this.textBox4.Text = n.spph.ToString();
                this.textBox2.Text = n.spun.ToString();
                this.textBox5.Text = n.spads.ToString();
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var q = from em in this.db.Employees
                    where em.Name == this.comboBox1.Text
                    select em.EmployeeID;

            this.label18.Text = q.FirstOrDefault().ToString();
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var q = from em in this.db.Employees
                    where em.Name == this.comboBox2.Text
                    select em.EmployeeID;

            this.label19.Text = q.FirstOrDefault().ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Purchase pchs = new Purchase
            {
                //status = 1,
                PurchaseDate = this.dateTimePicker1.Value,
                SupplierID = int.Parse(this.label12.Text),
                PurchaserEmpID = int.Parse(this.label18.Text),
                TallyEmpID = int.Parse(this.label19.Text),
                Deliveryaddress = this.textBox6.Text,
                RequiredDate = this.dateTimePicker2.Value,
                Comment = this.richTextBox1.Text
            };
            
            DialogResult p = MessageBox.Show("確定新增?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (p == DialogResult.OK)
            {
                this.db.Purchases.Add(pchs);
                this.db.SaveChanges();
                this.label4.Text = pchs.PurchaseID.ToString();
                
            }
            
            foreach (DataGridViewRow dr in this.dataGridView1.Rows)
            {
                PurchaseDetail pchsdtl = new PurchaseDetail();

                if (dr.Cells[1].Value != null)
                {
                    pchsdtl.ProductCode = dr.Cells[1].Value.ToString();
                    pchsdtl.PurchaseID = pchs.PurchaseID;
                    pchsdtl.Qty = decimal.Parse(dr.Cells[4].Value.ToString());
                    pchsdtl.UnitPrice = decimal.Parse(dr.Cells[3].Value.ToString());
                    pchsdtl.Unit = dr.Cells[5].Value.ToString();
                    if (dr.Cells[7].Value != null)
                    {
                        pchsdtl.Comment = dr.Cells[7].Value.ToString();
                    }
                    this.db.PurchaseDetails.Add(pchsdtl);
                }
            }
            this.db.SaveChanges();
            MessageBox.Show("新增成功", "", MessageBoxButtons.OK);
            allclear();
            this.comboBox1.SelectedIndex = 0;
            this.comboBox2.SelectedIndex = 0;
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            string text = dataGridView1.Columns[2].HeaderText;
            if (text.Equals("品名"))
                {
                TextBox autoText = e.Control as TextBox;
                if (autoText != null)
                {
                    autoText.AutoCompleteMode = AutoCompleteMode.Suggest;
                    autoText.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    AutoCompleteStringCollection DataCollection = new AutoCompleteStringCollection();
                    addItemsproductName(DataCollection);
                    autoText.AutoCompleteCustomSource = DataCollection;
                }
            }
        }
        private void addItemsproductName(AutoCompleteStringCollection col)
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
            if (dataGridView1.IsCurrentCellDirty)
            {
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex.Equals(1))
                {
                    DataGridViewComboBoxCell cb = (DataGridViewComboBoxCell)dataGridView1.Rows[e.RowIndex].Cells[1];
                    string id = cb.Value.ToString();
                    var q = from p in this.db.Products
                            where p.ProductCode == id
                            select new { pna = p.Name, punit = p.Unit };
                    var q1 = from p1 in this.db.Product_LatestPrice
                             where p1.ProductCode == id
                             select new { price = p1.LatestUpperPrice };
                    foreach (var n in q)
                    {
                        this.dataGridView1[2, e.RowIndex].Value = n.pna;
                        this.dataGridView1[5, e.RowIndex].Value = n.punit;
                    }
                    foreach (var n in q1)
                    {
                        this.dataGridView1[3, e.RowIndex].Value = n.price.ToString();
                    }

                }
                if (e.ColumnIndex.Equals(2))
                {
                    var q = from p in db.Products
                            where p.Name == this.dataGridView1.CurrentCell.Value.ToString()
                            select new {pcd = p.ProductCode, punit = p.Unit };
                    var q1 = from p1 in this.db.Product_LatestPrice
                             where p1.Name == this.dataGridView1.CurrentCell.Value.ToString()
                             select new { price = p1.LatestUpperPrice };

                    DataGridViewComboBoxCell cb = (DataGridViewComboBoxCell)dataGridView1.Rows[e.RowIndex].Cells[1];
                    cb.Value = q.ToList()[0];
                    foreach (var n in q)
                    {
                        cb.Value = n.pcd;
                        this.dataGridView1[5, e.RowIndex].Value = n.punit;
                    }
                    foreach (var n in q1)
                    {
                        this.dataGridView1[3, e.RowIndex].Value = n.price.ToString();
                    } 
                }
                if (e.ColumnIndex == 4 || e.ColumnIndex == 3)
                {
                    if (this.dataGridView1[4, e.RowIndex].Value == null)
                        this.dataGridView1[6, e.RowIndex].Value = "";
                    else
                    {
                        this.dataGridView1[6, e.RowIndex].Value = decimal.Parse(this.dataGridView1[3, e.RowIndex].Value.ToString()) * decimal.Parse(this.dataGridView1[4, e.RowIndex].Value.ToString());
                    }
                }
            }
            catch
            {

            }
        }
        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
                this.dataGridView1.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }
        
        int indexTracker = 0;
        List<int> pL=new List<int>();
        private void button3_Click(object sender, EventArgs e)
        {
            採購單查詢頁面 fk = new 採購單查詢頁面();
            DialogResult res = fk.ShowDialog(this);
            foreach (Control con in this.Controls)
            {
                con.Enabled = true;
                this.button2.Enabled = false;
                this.button2.BackColor = Color.WhiteSmoke;
                this.button4.BackColor = Color.DarkGray;
                this.button5.BackColor = Color.DarkGray;
                this.button6.BackColor = Color.DarkGray;
                this.button7.BackColor = Color.DarkGray;
                this.button9.BackColor = Color.DarkGray;
                this.button10.BackColor = Color.Tomato;
            }
            pL.Clear();
            indexTracker = 0;
            if (res == DialogResult.OK)
            {
                pL = fk.purchaseID;
                if(pL.Count!=0)
                DisplayOrderFields(pL, indexTracker);
            }
            fk.Dispose();
        }
        int thestartus;
        private void DisplayOrderFields(List<int> purchaseID,int tracker)
        {
            allclear();
            var q = (from p in db.Purchases.AsEnumerable()
                     where p.PurchaseID == purchaseID[tracker]
                     select new { pid = p.PurchaseID, spid = p.SupplierID, spname = p.Customer.Name, spcp = p.Customer.ContactPerson, spph = p.Customer.Phone, spun = p.Customer.Unicode, spads = p.Customer.Address, purchaseDate = p.PurchaseDate, RequiredDate = p.RequiredDate, DeliveryAddress = p.Deliveryaddress, TallyID = p.TallyEmpID,puempID=p.PurchaserEmpID ,sta = p.PurchaseStatus}).FirstOrDefault();
            var q2 = (from pd in db.PurchaseDetails
                      where pd.PurchaseID == q.pid
                      select new
                      {
                          pdid = pd.PurchaseID,
                          productCode = pd.ProductCode,
                          productName = pd.Product.Name,
                          price = pd.UnitPrice,
                          qty = pd.Qty,
                          unit = pd.Unit,
                          Total = pd.Qty * pd.UnitPrice,
                          comment = pd.Comment,
                          pudt = pd.PurchaseDetailID
                      }).ToList();
            var q3 = (from emp in this.db.Employees
                     where emp.EmployeeID == q.TallyID
                     select emp.Name).FirstOrDefault();
            var q4 = (from emp in this.db.Employees
                      where emp.EmployeeID == q.puempID
                      select emp.Name).FirstOrDefault();
            this.textBox1.Text = q.spname;
            this.textBox2.Text = q.spun;
            this.label12.Text = q.spid.ToString();
            this.label4.Text = q.pid.ToString();
            this.textBox3.Text = q.spcp;
            this.textBox4.Text = q.spph;
            this.textBox5.Text = q.spads;
            this.dateTimePicker1.Value = q.purchaseDate.Value;
            this.dateTimePicker2.Value = q.RequiredDate.Value;
            this.textBox6.Text = q.DeliveryAddress;
            this.comboBox2.Text = q3.ToString();
            this.comboBox1.Text = q4.ToString();
            thestartus = int.Parse(q.sta.ToString());
            theStartusText(thestartus);

            for (int i = 0; i < q2.Count(); i++)
            {
                DataGridViewRow dr = this.dataGridView1.Rows[0].Clone() as DataGridViewRow;
                this.dataGridView1.Rows.Add(dr);
                this.dataGridView1[1, i].Value = q2[i].productCode;
                this.dataGridView1[2, i].Value = q2[i].productName;
                this.dataGridView1[3, i].Value = q2[i].price;
                this.dataGridView1[4, i].Value = q2[i].qty;
                this.dataGridView1[5, i].Value = q2[i].unit;
                this.dataGridView1[7, i].Value = q2[i].comment;
                this.dataGridView1[8, i].Value = q2[i].pudt;
            }

        }

        private void theStartusText(int thestartus)
        {
            switch (thestartus)
            {
                case 1:
                    this.label20.Text = "未銷單";
                    this.label20.ForeColor = Color.Black;
                    break;
                case 2:
                    this.label20.Text = "已銷單";
                    this.label20.ForeColor = Color.ForestGreen;
                    break;
                case 3:
                    this.label20.Text = "已作廢";
                    this.label20.ForeColor = Color.Red;
                    break;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            indexTracker += 1;
            if (indexTracker < pL.Count)
            {
                DisplayOrderFields(pL, indexTracker);
            }
            else
            {
                indexTracker = pL.Count-1;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            indexTracker += -1;
            if (indexTracker >= 0)
            {
                DisplayOrderFields(pL, indexTracker);
            }
            else
            {
                indexTracker = 0;
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            indexTracker = pL.Count - 1;
            DisplayOrderFields(pL, indexTracker);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            indexTracker = 0;
            DisplayOrderFields(pL, indexTracker);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var q = (from p in this.db.Purchases
                    where (p.PurchaseID).ToString() == this.label4.Text //??????????????????
                    select p).FirstOrDefault();
            var q1 = from pd in this.db.PurchaseDetails
                      where (pd.PurchaseID).ToString() == this.label4.Text
                      select pd;
            var pds = q1.ToList();
            //int rows = 0;
            List<int> myIntLists = new List<int>();
            List<int> myIntLists2 = new List<int>();
            if (this.label20.Text == "已作廢")
            {
                MessageBox.Show("作廢單無法進行修改");
            }
            else
            {
                DialogResult s = MessageBox.Show("確定修改?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

                if (s == DialogResult.OK)
                {
                    if (q == null) return;

                    q.PurchaseDate = this.dateTimePicker1.Value;
                    q.SupplierID = int.Parse(this.label12.Text);
                    q.PurchaserEmpID = int.Parse(this.label18.Text);
                    q.Deliveryaddress = this.textBox6.Text;
                    q.Comment = this.richTextBox1.Text;
                    q.RequiredDate = this.dateTimePicker2.Value;
                    q.TallyEmpID = int.Parse(this.label19.Text);

                    this.db.SaveChanges();

                    var dr = this.dataGridView1.Rows;
                    for (int i = 0; i < dr.Count - 1; i++)
                    {
                        if (dr[i].Cells["pudt"].Value == null)
                        {
                            PurchaseDetail pcdt = new PurchaseDetail();
                            pcdt.PurchaseID = int.Parse(this.label4.Text);
                            pcdt.ProductCode = dr[i].Cells[1].Value.ToString();
                            pcdt.Qty = decimal.Parse(dr[i].Cells[4].Value.ToString());
                            pcdt.UnitPrice = decimal.Parse(dr[i].Cells[3].Value.ToString());
                            pcdt.Unit = dr[i].Cells[5].Value.ToString();
                            if (dr[i].Cells[7].Value != null)
                            {
                                pcdt.Comment = dr[i].Cells[7].Value.ToString();
                            }
                            this.db.PurchaseDetails.Add(pcdt);
                        }
                    }
                    this.db.SaveChanges();
                    for (int j = 0; j < pds.Count; j++)
                    {
                        for (int i = 0; i < dr.Count - 1; i++)
                        {

                            if (dr[i].Cells["pudt"].Value != null)
                            {
                                myIntLists.Add(int.Parse(dr[i].Cells["pudt"].Value.ToString()));
                                if (pds[j].PurchaseDetailID == int.Parse(dr[i].Cells["pudt"].Value.ToString()))
                                {
                                    pds[j].ProductCode = dr[i].Cells[1].Value.ToString();
                                    pds[j].Qty = decimal.Parse(dr[i].Cells[4].Value.ToString());
                                    pds[j].UnitPrice = decimal.Parse(dr[i].Cells[3].Value.ToString());
                                    pds[j].Unit = dr[i].Cells[5].Value.ToString();
                                    if (dr[i].Cells[7].Value != null)
                                    {
                                        pds[j].Comment = dr[i].Cells[7].Value.ToString();
                                    }
                                }
                            }
                        }
                    }
                    this.db.SaveChanges();
                    foreach (var n in pds)
                    {
                        myIntLists2.Add(int.Parse(n.PurchaseDetailID.ToString()));
                    }
                    var diffArr = myIntLists2.Where(c => !myIntLists.Contains(c)).ToArray();
                    for (int i = 0; i < diffArr.Length; i++)
                    {
                        int z = int.Parse(diffArr[i].ToString());
                        var q3 = from pd in this.db.PurchaseDetails
                                 where pd.PurchaseDetailID == z
                                 select pd;
                        var a = q3.ToList();
                        foreach (var d in a)
                        {
                            this.db.PurchaseDetails.Remove(d);
                        }
                        this.db.SaveChanges();
                    }
                    MessageBox.Show("修改成功", "", MessageBoxButtons.OK);
                }
            }
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            foreach (Control con in this.Controls)
            {
                con.Enabled = true;
                this.button2.BackColor = Color.DarkGray;
                this.button4.BackColor = Color.WhiteSmoke;
                this.button5.BackColor = Color.WhiteSmoke;
                this.button6.BackColor = Color.WhiteSmoke;
                this.button7.BackColor = Color.WhiteSmoke;
                this.button9.BackColor = Color.WhiteSmoke;
                this.button10.BackColor = Color.WhiteSmoke;
                this.button4.Enabled = false;
                this.button5.Enabled = false;
                this.button6.Enabled = false;
                this.button7.Enabled = false;
                this.button9.Enabled = false;
                this.button10.Enabled = false;
            }

            allclear();
            this.comboBox1.SelectedIndex = 0;
            this.comboBox2.SelectedIndex = 0;
        }
        private void allclear()
        {
            dataGridView1.Rows.Clear();
            foreach (Control con in this.Controls)
            {
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
                    this.label4.Text = string.Empty;
                    this.label12.Text = string.Empty;
                    this.label18.Text = string.Empty;
                    this.label19.Text = string.Empty;
                    this.label20.Text = "      ";
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string a = "3";
            if (label4.Text == "     ") return;
            else { 
            DialogResult s = MessageBox.Show("確定刪除整筆採購單?", "提醒", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                if (s == DialogResult.OK)
                {
                    if (this.label4.Text != null)
                    {
                        var q = (from p in this.db.Purchases
                                where (p.PurchaseID).ToString() == this.label4.Text
                                select p).ToList();
                        q[0].PurchaseStatus = short.Parse(a);
                        this.db.SaveChanges();
                        //var q1 = from pd in this.db.PurchaseDetails
                        //         where (pd.PurchaseID).ToString() == this.label4.Text
                        //         select pd;
                        //var a = q1.ToList();
                        //foreach (var n in a)
                        //{
                        //    this.db.PurchaseDetails.Remove(n);
                        //}

                        //var q = from p in this.db.Purchases
                        //        where (p.PurchaseID).ToString() == this.label4.Text
                        //        select p;
                        //var b = q.ToList();
                        //foreach (var x in b)
                        //{
                        //    this.db.Purchases.Remove(x);
                        //}

                        //this.db.SaveChanges();
                    }
                    MessageBox.Show("刪除成功", "", MessageBoxButtons.OK);
                    foreach (Control con in this.Controls)
                    {
                        con.Enabled = false;
                        this.button2.BackColor = Color.WhiteSmoke;
                        this.button4.BackColor = Color.WhiteSmoke;
                        this.button5.BackColor = Color.WhiteSmoke;
                        this.button6.BackColor = Color.WhiteSmoke;
                        this.button7.BackColor = Color.WhiteSmoke;
                        this.button9.BackColor = Color.WhiteSmoke;
                        this.button10.BackColor = Color.WhiteSmoke;
                        this.button3.Enabled = true;
                        this.button8.Enabled = true;
                    }
                    allclear();
                }
                
            }
        }
    }
}
