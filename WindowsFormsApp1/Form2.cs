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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void orderBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.orderBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.fOODDataSet);

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'fOODDataSet.Order' 資料表。您可以視需要進行移動或移除。
            this.orderTableAdapter.Fill(this.fOODDataSet.Order);
            // TODO: 這行程式碼會將資料載入 'fOODDataSet.Order' 資料表。您可以視需要進行移動或移除。
            this.orderTableAdapter.Fill(this.fOODDataSet.Order);

        }

        private void orderBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.orderBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.fOODDataSet);

        }
    }
}
