using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Properties;

namespace WindowsFormsApp1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Employee系統 empFrm = new Employee系統()
            {
                Dock = DockStyle.Fill, TopLevel = false, TopMost = true
            };
            empFrm.FormBorderStyle = FormBorderStyle.None;
            this.panel1.Controls.Add(empFrm);
            empFrm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
           Client ClientFrm = new Client()
            {
                Dock = DockStyle.Fill,
                TopLevel = false,
                TopMost = true
            };
            ClientFrm.FormBorderStyle = FormBorderStyle.None;
            this.panel1.Controls.Add(ClientFrm);
            ClientFrm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
            


         
        }

        private void label1_Click(object sender, EventArgs e)
        {
            var label = new Form1();
            label.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            訂單表 訂單表 = new 訂單表()
            {
                Dock = DockStyle.Fill,
                TopLevel = false,
                TopMost = true
            };
            訂單表.FormBorderStyle = FormBorderStyle.None;
            this.panel1.Controls.Add(訂單表);
            訂單表.Show();
        }
    }
}
