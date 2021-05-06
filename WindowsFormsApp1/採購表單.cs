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
        public 採購表單()
        {
            
            InitializeComponent();
            addnews();
            addItemsCustomerName();
            
        }
        FOODEntities db = new FOODEntities();
        string suppliername;
        int sup;
        private void addnews()
        {
            var q = from e in this.db.Employees
                    select new { empna = e.Name, empid = e.EmployeeID };
            foreach (var n in q)
            {
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

        private void 採購表單_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            採購單查詢頁面 fk = new 採購單查詢頁面();
            DialogResult res = fk.ShowDialog();
            if (res == DialogResult.OK)
            {
                sup = fk.thesupplerid;
            }
            this.label4.Text = sup.ToString();
            
            var q = from s in this.db.Purchases
                    where s.SupplierID == sup
                    select s;
        }
    }
}
