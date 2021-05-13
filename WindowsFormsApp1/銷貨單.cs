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
    public partial class 銷貨單 : Form
    {
        string OrderID;
        string StautsID;
        private List<Order> orders;
        private List<OrderDetail> orderDetails;
        private List<SalesDetail> salesDetails;       
        FOODEntities db = new FOODEntities();
        private bool rowEditing = false;
        public 銷貨單()
        {
            InitializeComponent();
        }
        private void 銷貨單_Load(object sender, EventArgs e)
        {
            var q = this.db.Orders.Select(n => n);
            orders = q.ToList();
            var q1 = this.db.OrderDetails.Select(n => n);
            orderDetails = q1.ToList();
            var q2 = this.db.SalesDetails.Select(n => n);
            salesDetails = q2.ToList();
            
        }
        private void Allclear()
        {
            foreach (Control con in this.splitContainer2.Panel2.Controls)
            {
                dataGridView1.Rows.Clear();

                if (con is TextBox)
                {
                    TextBox tb = con as TextBox;
                    tb.Text=string.Empty;
                }
            
            }
        }

        private void 新增轉單(object sender, EventArgs e)
        {
            Allclear();
            查詢子表 k = new 查詢子表();
            k.TopMost = true;
            DialogResult res = k.ShowDialog();
            if (res == DialogResult.OK)
            {
                OrderID = k.suppliername;
            }
            var q = this.orders.Where(n => n.OrderID.ToString() == OrderID).Select(n => new
            {
                odid = n.OrderID,
                cuname = n.Customer.Name,
                cuadd = n.Customer.Address,
                empname = n.Employee.Name,
                cucontar = n.Customer.ContactPerson,
                cucontarphone = n.Customer.ContactCellPhone,
                odadd = n.DeliveryAddress,
                           
            }) ;

            foreach (var p in q)
            {
              
                textBox3.Text = p.odid.ToString();
                textBox5.Text = p.empname;
                textBox8.Text = p.empname;
                textBox4.Text = p.cuname;
                textBox7.Text = p.cucontar;
                textBox9.Text = p.cucontarphone;
                textBox6.Text = p.odadd;
               
            }
            var q1 = this.orderDetails.Where(n => n.OrderID.ToString() == OrderID).Select(n => new
            {
                prcode = n.ProductCode,
                prname = n.Product.Name,
               unitprice= n.UnitPrice,
               qty= n.Qty,
               unit= n.Unit,
                commert=n.Commert
            });
            
            for (int i = 0; i<q1.ToList().Count;i++)
            {
                DataGridViewRow dr = this.dataGridView1.Rows[0].Clone() as DataGridViewRow;
                this.dataGridView1.Rows.Add(dr);
                this.dataGridView1[0, i].Value = q1.ToList()[i].prcode;
                this.dataGridView1[1, i].Value = q1.ToList()[i].prname;
                this.dataGridView1[2, i].Value = q1.ToList()[i].unitprice;
                this.dataGridView1[4, i].Value = q1.ToList()[i].unit;
                this.dataGridView1[6, i].Value = q1.ToList()[i].commert;
            }
            
        }
       

        private void 確定新增(object sender, EventArgs e)
        {
            DialogResult p = MessageBox.Show("確定新增銷貨單?", "提醒", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (p == DialogResult.OK)
            {
               
                var q = this.orderDetails.Where(n => n.OrderID.ToString() == OrderID).Select(n => n.OrderDetailID);

                foreach (DataGridViewRow dr in this.dataGridView1.Rows)
                {
                    SalesDetail sales = new SalesDetail();

                    sales.OrderID = int.Parse(this.textBox3.Text);
                    sales.OrderDetailID = q.ToList()[0];

                    if (dr.Cells[0].Value != null)
                    {
                        
                     sales.ProductCode = dr.Cells[0].Value.ToString();          sales.UnitPrice=decimal.Parse(dr.Cells[2].Value.ToString());
                        sales.unit= dr.Cells[4].Value.ToString();

                        this.db.SalesDetails.Add(sales);                       
                    }
                }
                short a = 2;
                Order q1 = this.db.Orders.Where(n => n.OrderID.ToString() == OrderID).Select(n => n).FirstOrDefault();
                
                q1.OrderStatus = a;
               
                this.db.SaveChanges();//新增OD回DB
                MessageBox.Show("新增成功", "提醒", MessageBoxButtons.OK);

            }
           
        }

        private void 銷貨單查詢(object sender, EventArgs e)
        {
            Allclear();
            銷貨單查詢表 k = new 銷貨單查詢表();
            k.TopMost = true;
            DialogResult res = k.ShowDialog();
            
            if (res == DialogResult.OK)
            {
                StautsID = k.suppliername;
                MessageBox.Show(StautsID);


                var q = from o in this.orders
                    from s in this.salesDetails                    
                    where o.OrderID == s.OrderID  && o.OrderID.ToString()== StautsID
                        select new
                    {
                        salesid = s.SalesDetailID,
                        odid = o.OrderID,
                        cname = o.Customer.Name,
                        oadd=o.Address,
                        empname=o.Employee.Name,
                        聯絡人=o.Customer.ContactPerson,
                        聯絡人電話=o.Customer.ContactCellPhone,
                        stauts=o.StatusList.StatusName
                    };
            foreach (var p in q)
            {
                textBox2.Text = p.salesid.ToString();
                textBox3.Text = p.odid.ToString();
                textBox5.Text = p.empname;
                textBox8.Text = p.empname;
                textBox4.Text = p.cname;
                textBox7.Text = p.聯絡人;
                textBox9.Text = p.聯絡人電話;
                textBox6.Text = p.oadd;
               
            }
           
            var q1 = this.orderDetails.Where(n => n.OrderID.ToString() == StautsID).Select(n => new
            {
                prcode = n.ProductCode,
                prname = n.Product.Name,
                unitprice = n.UnitPrice,
                qty = n.Qty,
                unit = n.Unit,
                commert = n.Commert
            });

            for (int i = 0; i < q1.ToList().Count; i++)
            {
                DataGridViewRow dr = this.dataGridView1.Rows[0].Clone() as DataGridViewRow;
                this.dataGridView1.Rows.Add(dr);
                this.dataGridView1[0, i].Value = q1.ToList()[i].prcode;
                this.dataGridView1[1, i].Value = q1.ToList()[i].prname;
                this.dataGridView1[2, i].Value = q1.ToList()[i].unitprice;
                this.dataGridView1[4, i].Value = q1.ToList()[i].unit;
                this.dataGridView1[6, i].Value = q1.ToList()[i].commert;
            }
        }
        }
        private void 修改(object sender, EventArgs e)
        {
        
            DialogResult p = MessageBox.Show("確定修改?", "提醒", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (p == DialogResult.OK)
            {
                

               
                //-----------------------------------------------------------------------
                var s = this.salesDetails.Where(n => n.OrderID.ToString() == this.textBox3.Text).Select(n => n);
                var psd = s.ToList();
                if ( s== null) return;

                var dr = this.dataGridView1.Rows;

                int row = 0;

                for (int i = 0; i < dr.Count; i++)
                {

                    if (i > psd.Count)
                    {
                        MessageBox.Show("這邊是修改不是新增", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }

                    else if (dr[i].Cells[0].Value != null)
                    {
                        psd[i].ProductCode = dr[i].Cells[0].Value.ToString();
                        psd[i].Qty = decimal.Parse(dr[i].Cells[3].Value.ToString());
                        psd[i].UnitPrice = decimal.Parse(dr[i].Cells[2].Value.ToString());
                        psd[i].unit = dr[i].Cells[4].Value.ToString();
                        if (dr[i].Cells[6].Value != null)
                        {
                            psd[i].Comment = dr[i].Cells[6].Value.ToString();
                        }
                        row = this.db.SaveChanges();//新增OD回DB
                    }
                }

                if (row != 0) MessageBox.Show("修改成功", "提醒", MessageBoxButtons.OK);
            }

            Allclear();


        }

        private void 通通刪除(object sender, EventArgs e)
        {
            
            if (this.textBox2.Text == "")
                return;
            else 
            {
                DialogResult p = MessageBox.Show("確定刪除?(資料不會復原)", "提醒", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                if (p == DialogResult.OK)
                {
                    var q = this.salesDetails.Where(n => n.OrderID.ToString() == StautsID).Select(n => n);
                    var a = q.ToList();
                    foreach (var n in a)
                    {
                        this.db.SalesDetails.Remove(n);
                    }
                    this.db.SaveChanges();
                    MessageBox.Show("刪除成功", "提醒", MessageBoxButtons.OK);
                }
                Allclear();
            }
        }

        private void splitContainer6_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }
    }

       
    }
