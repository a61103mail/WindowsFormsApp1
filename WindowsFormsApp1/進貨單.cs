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
    public partial class 進貨單 : Form
    {
        FOODEntities db = new FOODEntities();
        int pid;
        public 進貨單()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            allclear();
            進貨轉單查詢 f = new 進貨轉單查詢();
            DialogResult res = f.ShowDialog();
            if (res == DialogResult.OK)
            {
                pid = f.pur;
            }
            f.Dispose();
            if (pid != 0)
            {
                thepurchasecfnew(pid);
            }
        }

        private void thepurchasecfnew(int pid)
        {
            var q = (from p in this.db.Purchases
                     where p.PurchaseID == pid
                     select new
                     {
                         purchaseid = p.PurchaseID,
                         purchaseemp = p.Employee.Name,
                         purchaseTally = p.Employee1.Name,
                         suppliername = p.Customer.Name,
                         suppliercp = p.Customer.ContactPerson,
                         supplierph = p.Customer.ContactCellPhone,
                         deliveryaddress = p.Deliveryaddress,
                         purchaseComment = p.Comment
                     }).FirstOrDefault();
            var q2 = (from pd in db.PurchaseDetails
                      where pd.PurchaseID == pid
                      select new
                      {
                          productCode = pd.ProductCode,
                          productName = pd.Product.Name,
                          price = pd.UnitPrice,
                          qty = pd.Qty,
                          unit = pd.Unit,
                      }).ToList();
            this.textBox3.Text = q.purchaseid.ToString();
            this.textBox6.Text = q.purchaseemp;
            this.textBox8.Text = q.purchaseTally;
            this.textBox4.Text = q.suppliername;
            this.textBox7.Text = q.suppliercp;
            this.textBox9.Text = q.supplierph;
            this.textBox5.Text = q.deliveryaddress;
            this.textBox1.Text = q.purchaseComment;
            for (int i = 0; i < q2.Count(); i++)
            {
                DataGridViewRow dr = this.dataGridView1.Rows[0].Clone() as DataGridViewRow;
                this.dataGridView1.Rows.Add(dr);
                this.dataGridView1[1, i].Value = q2[i].productCode;
                this.dataGridView1[2, i].Value = q2[i].productName;
                this.dataGridView1[3, i].Value = q2[i].price;
                this.dataGridView1[4, i].Value = q2[i].qty;
                this.dataGridView1[5, i].Value = q2[i].unit;
            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dataGridView1.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 3 || e.ColumnIndex == 4)
                {
                    if (this.dataGridView1[3, e.RowIndex].Value == null)
                        this.dataGridView1[6, e.RowIndex].Value = "";
                    else if (this.dataGridView1[4, e.RowIndex].Value == null)
                        this.dataGridView1[6, e.RowIndex].Value = "";
                    else if (this.dataGridView1[3, e.RowIndex].Value == null)
                        this.dataGridView1[6, e.RowIndex].Value = "";
                    else
                    {
                        this.dataGridView1[6, e.RowIndex].Value = decimal.Parse(this.dataGridView1[3, e.RowIndex].Value.ToString()) * decimal.Parse(this.dataGridView1[4, e.RowIndex].Value.ToString());
                    }

                }
                if (e.ColumnIndex == 4)
                {
                    var q = from pd in this.db.PurchaseDetails.AsEnumerable()
                            where pd.PurchaseID == int.Parse(this.textBox3.Text) && pd.ProductCode == this.dataGridView1[1, e.RowIndex].Value.ToString()
                            select pd.Qty;
                    var q1 = from pcf in this.db.PurchaseConfirmedDetails.AsEnumerable()
                             where pcf.PurchaseID == int.Parse(this.textBox3.Text) && pcf.ProductCode == this.dataGridView1[1, e.RowIndex].Value.ToString()
                             select pcf.Qty;
                    decimal a = 0;
                    decimal b = 0;
                    foreach (var n in q)
                    {
                        a += n;
                    }
                    foreach (var n in q1)
                    {
                        b += n;
                    }
                    decimal c = a - b;
                    if (this.dataGridView1[4, e.RowIndex].Value == null)
                    {
                        return;
                    }
                    else if (this.dataGridView1[8, e.RowIndex].Value != null)
                    {
                        return;
                    }
                    else if (decimal.Parse(this.dataGridView1[4, e.RowIndex].Value.ToString()) > c && this.dataGridView1[8, e.RowIndex].Value == null)
                    {
                        MessageBox.Show(this.dataGridView1[2, e.RowIndex].Value + " ,進貨數量不可大於採購數量。\n最大進貨數量為：" + c);
                    }
                }
            }
            catch
            {

            }
        }
        private void allclear()
        {
            dataGridView1.Rows.Clear();
            foreach (Control con in this.Controls)
            {
                if (con is TextBox)
                {
                    TextBox tb = con as TextBox;
                    tb.Text = string.Empty;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PurchaseConfirmedDetail pucf = new PurchaseConfirmedDetail();
            var q = (from pu in this.db.Purchases
                     where pu.PurchaseID == pid
                     select pu).FirstOrDefault();

            DialogResult p = MessageBox.Show("確定新增?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (p == DialogResult.OK)
            {

                foreach (DataGridViewRow dr in this.dataGridView1.Rows)
                {
                    if (dr.Cells[1].Value != null)
                    {
                        q.PurchaseStatus = 2;
                        pucf.PurchaseID = int.Parse(this.textBox3.Text);
                        pucf.Comment = this.textBox1.Text;
                        pucf.ProductCode = dr.Cells[1].Value.ToString();
                        pucf.Qty = decimal.Parse(dr.Cells[4].Value.ToString());
                        pucf.UnitPrice = decimal.Parse(dr.Cells[3].Value.ToString());
                        pucf.Unit = dr.Cells[5].Value.ToString();
                        if (dr.Cells[8].Value != null)
                        {
                            pucf.Comment = dr.Cells[7].Value.ToString();
                        }
                        this.db.PurchaseConfirmedDetails.Add(pucf);
                        pucf.ComfirmedDate = this.dateTimePicker1.Value;
                    }
                }
            }
            this.db.SaveChanges();
            MessageBox.Show("新增成功", "", MessageBoxButtons.OK);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            allclear();
            進貨單查詢表 f = new 進貨單查詢表();
            DialogResult res = f.ShowDialog();
            if (res == DialogResult.OK)
            {
                pid = f.purd;
            }
            f.Dispose();
            if (pid != 0)
            {
                thepurchasecfsearch(pid);
            }
        }

        private void thepurchasecfsearch(int pid)
        {
            var q = (from p in this.db.Purchases
                     where p.PurchaseID == pid
                     select new
                     {
                         purchaseid = p.PurchaseID,
                         purchaseemp = p.Employee.Name,
                         purchaseTally = p.Employee1.Name,
                         suppliername = p.Customer.Name,
                         suppliercp = p.Customer.ContactPerson,
                         supplierph = p.Customer.ContactCellPhone,
                         deliveryaddress = p.Deliveryaddress,
                         purchaseComment = p.Comment
                     }).FirstOrDefault();
            var q2 = (from pd in db.PurchaseConfirmedDetails
                      where pd.PurchaseID == pid
                      select new
                      {
                          productCode = pd.ProductCode,
                          productName = pd.Product.Name,
                          price = pd.UnitPrice,
                          qty = pd.Qty,
                          unit = pd.Unit,
                          comm = pd.Comment,
                          pcpdid = pd.PurchaseComfirmedDetailID
                      }).ToList();
            this.textBox3.Text = q.purchaseid.ToString();
            this.textBox6.Text = q.purchaseemp;
            this.textBox8.Text = q.purchaseTally;
            this.textBox4.Text = q.suppliername;
            this.textBox7.Text = q.suppliercp;
            this.textBox9.Text = q.supplierph;
            this.textBox5.Text = q.deliveryaddress;
            this.textBox1.Text = q.purchaseComment;
            for (int i = 0; i < q2.Count(); i++)
            {
                DataGridViewRow dr = this.dataGridView1.Rows[0].Clone() as DataGridViewRow;
                this.dataGridView1.Rows.Add(dr);
                this.dataGridView1[8, i].Value = q2[i].pcpdid;
                this.dataGridView1[1, i].Value = q2[i].productCode;
                this.dataGridView1[2, i].Value = q2[i].productName;
                this.dataGridView1[3, i].Value = q2[i].price;
                this.dataGridView1[4, i].Value = q2[i].qty;
                this.dataGridView1[5, i].Value = q2[i].unit;
                this.dataGridView1[7, i].Value = q2[i].comm;
                
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            var q1 = from pd in this.db.PurchaseConfirmedDetails
                     where (pd.PurchaseID).ToString() == this.textBox3.Text
                     select pd;
            var pds = q1.ToList();
            List<int> myIntLists = new List<int>();
            List<int> myIntLists2 = new List<int>();
            
                DialogResult s = MessageBox.Show("確定修改?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

                if (s == DialogResult.OK)
                {
                    var dr = this.dataGridView1.Rows;
                    for (int j = 0; j < pds.Count; j++)
                    {
                        for (int i = 0; i < dr.Count - 1; i++)
                        {
                            if (dr[i].Cells["pcdid"].Value != null)
                            {
                                if (pds[j].PurchaseComfirmedDetailID == int.Parse(dr[i].Cells["pcdid"].Value.ToString()))
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
                    
                    MessageBox.Show("修改成功", "", MessageBoxButtons.OK);
                }
            
        }
    }
}
