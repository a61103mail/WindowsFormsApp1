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
    public partial class 現有庫存 : Form
    {
        public 現有庫存()
        {
            InitializeComponent();
        }
        private FOODEntities FOODEntities = new FOODEntities();
        private void 現有庫存_Load(object sender, EventArgs e)
        {
            var q = from i in this.FOODEntities.Inventories
                    join j in this.FOODEntities.Products on i.ProductCode equals j.ProductCode
                    select new { i.InventoryID,i.ProductCode,產品名稱=j.Name,數量=i.Qty,單位=j.Unit,上次盤點日期=i.Date};
            dataGridView1.DataSource = q.ToList();
        }
    }
}
