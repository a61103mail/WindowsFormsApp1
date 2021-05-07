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
        public 採購表單()
        {
            
            InitializeComponent();
            addnews();
            addItemsCustomerName();
            
        }
        FOODEntities db = new FOODEntities();
        string suppliername;
        private void addnews()
        {
            var q = from e in this.db.Employees
                    select new { empna = e.Name, empid = e.EmployeeID };

            this.comboBox2.DataSource = q.ToList();
            this.comboBox2.DisplayMember = "empna";
            this.comboBox2.ValueMember = "empid";

            //foreach (var n in q)
            //{
            //    this.comboBox2.Items.Add(n.empna);
            //}



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
                PurchaseDate = this.dateTimePicker1.Value,
                SupplierID = int.Parse(this.label12.Text),
                //PurchaserEmpID = int.Parse(this.label18.Text),
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
                    //DataGridViewComboBoxCell cb = dataGridView1[0, e.RowIndex] as DataGridViewComboBoxCell;
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

                    //DataGridViewComboBoxCell cb = dataGridView1[0, e.RowIndex] as DataGridViewComboBoxCell;
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
            DialogResult res = fk.ShowDialog();
            if (res == DialogResult.OK)
            {
                pL.Clear();
                foreach(int i in fk.purchaseID)
                {
                    pL.Add(i);
                }
                
                DisplayOrderFields(pL,indexTracker);
            }
        }

        private void DisplayOrderFields(List<int> purchaseID,int tracker)
        {
            var q = from p in db.Purchases.AsEnumerable()
                    where p.PurchaseID == purchaseID[tracker]
                    select new { pid =p.PurchaseID,spid = p.SupplierID,spname =p.Customer.Name, spcp = p.Customer.ContactPerson, spph = p.Customer.Phone, spun = p.Customer.Unicode, spads = p.Customer.Address ,purchaseDate = p.PurchaseDate, RequiredDate = p.RequiredDate, DeliveryAddress = p.Deliveryaddress,TallyID = p.TallyEmpID };
            q = q.ToList();
            textBox1.Text = q.FirstOrDefault().spname;
            textBox2.Text = q.FirstOrDefault().spun;
            label12.Text = q.FirstOrDefault().spid.ToString();
            label4.Text = q.FirstOrDefault().pid.ToString();
            textBox3.Text = q.FirstOrDefault().spcp;
            textBox4.Text = q.FirstOrDefault().spph;
            textBox5.Text = q.FirstOrDefault().spads;
            dateTimePicker1.Value = q.FirstOrDefault().purchaseDate.Value;
            dateTimePicker2.Value = q.FirstOrDefault().RequiredDate.Value;
            textBox6.Text = q.FirstOrDefault().DeliveryAddress;
            label19.Text = q.FirstOrDefault().TallyID.ToString();
            comboBox2.SelectedValue = q.FirstOrDefault().TallyID;

            DisplayOrderDetails(q.FirstOrDefault().pid);



        }

        private void DisplayOrderDetails(int pid)
        {
            this.dataGridView1.Rows.Clear();
            var q = from pd in db.PurchaseDetails
                    where pd.PurchaseID == pid
                    select new
                    {
                        pdid = pd.PurchaseID,
                        productCode = pd.ProductCode,
                        productName = pd.Product.Name,
                        price = pd.UnitPrice,
                        qty = pd.Qty,
                        unit = pd.Unit,
                        Total = pd.Qty * pd.UnitPrice,
                        comment = pd.Comment

                    };

            for (int i = 0; i < q.Count(); i++)
            {
                DataGridViewRow dr = this.dataGridView1.Rows[0].Clone() as DataGridViewRow;
                this.dataGridView1.Rows.Add(dr);
                DataGridViewComboBoxCell cb = (DataGridViewComboBoxCell)dataGridView1.Rows[i].Cells[1];
                cb.Value = q.ToList()[i].productCode;
                this.dataGridView1[1, i].Value = q.ToList()[i].productCode;
                this.dataGridView1[2, i].Value = q.ToList()[i].productName;
                this.dataGridView1[3, i].Value = q.ToList()[i].price;
                this.dataGridView1[4, i].Value = q.ToList()[i].qty;
                this.dataGridView1[5, i].Value = q.ToList()[i].unit;
                this.dataGridView1[6, i].Value = q.ToList()[i].Total;
                this.dataGridView1[7, i].Value = q.ToList()[i].comment;
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

        private void 採購表單_Load(object sender, EventArgs e)
        {

        }

        private void label19_TextChanged(object sender, EventArgs e)
        {
            //var q = from emp in this.db.Employees
            //        where emp.EmployeeID == int.Parse(this.label19.Text)
            //        select new { empID = emp.Unicode };
            //this.comboBox2.Text = q.ToList().ToString();
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
            int rows = 0;
            

            DialogResult s = MessageBox.Show("確定修改?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            
            if (s == DialogResult.OK)
            {
                if (q == null) return;
                
                q.PurchaseDate = this.dateTimePicker1.Value;
                q.SupplierID = int.Parse(this.label12.Text);
                //q.PurchaserEmpID = int.Parse(this.label18.Text);
                q.Deliveryaddress = this.textBox6.Text;
                q.Comment = this.richTextBox1.Text;
                q.RequiredDate = this.dateTimePicker2.Value;
                q.TallyEmpID = int.Parse(this.label19.Text);
                
                this.db.SaveChanges();

                var dr = this.dataGridView1.Rows;
                for (int i = 0; i < dr.Count; i++)
                {
                    if (i > pds.Count)
                    {
                        MessageBox.Show("gg", "", MessageBoxButtons.OK);
                        break;
                    }
                    if (dr[i].Cells[1].Value != null)
                    {
                        pds[i].ProductCode = dr[i].Cells[1].Value.ToString();
                        pds[i].Qty = decimal.Parse(dr[i].Cells[4].Value.ToString());
                        pds[i].UnitPrice = decimal.Parse(dr[i].Cells[3].Value.ToString());
                        pds[i].Unit = dr[i].Cells[5].Value.ToString();
                        if (dr[i].Cells[7].Value != null)
                        {
                            pds[i].Comment = dr[i].Cells[7].Value.ToString();
                        }
                    }
                    
                     
                    
                }
                rows = this.db.SaveChanges();
                if (rows != 0) MessageBox.Show("修改成功", "", MessageBoxButtons.OK);
            }
            
        }

        private void dataGridView1_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            //var q1 = (from pd in this.db.PurchaseDetails
            //          where (pd.PurchaseID).ToString() == this.label4.Text
            //          select pd).FirstOrDefault();

            //if (q1.ProductCode == this.dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString())
            //{
            //    q1.ProductCode = this.dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            //    q1.Qty = decimal.Parse(this.dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
            //    q1.UnitPrice = decimal.Parse(this.dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
            //    q1.Unit = this.dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            //    if (this.dataGridView1.Rows[e.RowIndex].Cells[7].Value != null)
            //    {
            //        q1.Comment = this.dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            //    }
            //    this.db.SaveChanges();
            //}
            
        }
    }
}
