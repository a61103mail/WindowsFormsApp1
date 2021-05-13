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
    public partial class 銷貨單查詢表 : Form
    {
        FOODEntities db = new FOODEntities();
        public string suppliername;

        public 銷貨單查詢表()
        {
            InitializeComponent();
            this.button1.DialogResult = DialogResult.OK;
            this.button2.DialogResult = DialogResult.Cancel;
            Suppliertodata();
        }

        private void Suppliertodata()
        {
            if (this.textBox1.Text == "")
            {
               
                var q = from n in this.db.SalesDetails
                        where n.Order.OrderStatus == 1
                        select new
                        {
                            訂單編號 = n.OrderID,
                            產品=n.Product.Name,
                            訂貨日期 = n.Order.OrderDate

                        };
                this.dataGridView1.DataSource = q.ToList();
            }
            else if (this.textBox1.Text != "")
            {
               
                var q = from n in this.db.SalesDetails.AsEnumerable()
                       where n.OrderID.ToString()
                        == $"{this.textBox1.Text}" || n.Product.Name== $"{this.textBox1.Text}"
                        select new
                        {
                            
                            訂單編號 = n.OrderID,
                            產品 = n.Product.Name,
                            訂貨日期 = n.Order.OrderDate

                        };
                this.dataGridView1.DataSource = q.ToList();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;
            int x = dataGridView1.CurrentCell.ColumnIndex;
            if (x == 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewCheckBoxCell checkcell = (DataGridViewCheckBoxCell)dataGridView1.Rows[i].Cells[0];
                    checkcell.Value = false;
                }
                DataGridViewCheckBoxCell ifcheck = (DataGridViewCheckBoxCell)dataGridView1.Rows[e.RowIndex].Cells[0];
                ifcheck.Value = true;

                Boolean b = Convert.ToBoolean(ifcheck.Value);
                if (b)
                {
                    if (dataGridView1.Rows[e.RowIndex].Cells[2] != null)
                    {
                        suppliername = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    }
                    if (dataGridView1.Rows[e.RowIndex].Cells[1] != null)
                    {
                        suppliername = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    }
                }
            }
        }

        private void 銷貨單查詢表_Load(object sender, EventArgs e)
        {

        }
    }
    
}
