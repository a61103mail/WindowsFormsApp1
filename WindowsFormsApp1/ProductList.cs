﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    
    public partial class ProductList : Form
    {
        private FOODEntities FOODEntities = new FOODEntities();
        public ProductList()
        {
            InitializeComponent();
            this.dataGridView1.AutoSize = true;
        }
        
        private void ProductList_Load(object sender, EventArgs e)
        {
            var q = from p in this.FOODEntities.Products
                    select new {p.ProductID, p.Name, Category = p.Category.Name, p.Unit  };
            this.dataGridView1.DataSource = q.ToList();

            SqlConnection conn = new SqlConnection("Data Source=fooddb.database.windows.net;Initial Catalog=FOOD;Persist Security Info=True;User ID=msit130;Password=xxxyyy1!");
            try
            {
                using (conn)
                {
                    var command = conn.CreateCommand();
                    command.CommandText = "Select * from LatestPrice";
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataSet ds = new DataSet();
                    Console.WriteLine(adapter.Fill(ds));

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
                    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            新增產品 f = new 新增產品();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var currentRowIndex = this.dataGridView1.SelectedCells[0].RowIndex;
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            詳細 f = new 詳細();
            f.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            盤點 f = new 盤點();
            f.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
