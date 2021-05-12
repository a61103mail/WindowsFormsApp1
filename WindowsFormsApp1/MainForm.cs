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
        FOODEntities db = new FOODEntities();
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
           Customer系統 ClientFrm = new Customer系統()
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
            Form1 form = (Form1)this.Owner;
            form.Visible = true;
            form.BackColor = Color.Black;
            this.Close();
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

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 form = (Form1)this.Owner;
            form.Visible = true;
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void lbl_EMP_Click(object sender, EventArgs e)
        {
            lbl_meau_Click("lbl_EMP");

        }

        private void lbl_CUMR_Click(object sender, EventArgs e)
        {
            lbl_meau_Click("lbl_CUMR");
        }
        private void lbl_meau_Click(string str)
        {
            switch (str)
            {
                case "lbl_EMP":
                    if (this.splitContainer_EMP.Panel2Collapsed == true)
                    {
                        this.splitContainer_EMP.Panel2Collapsed = false;
                        this.splitContainer_EMP.Height = 370;
                    }
                    else
                    {
                        this.splitContainer_EMP.Panel2Collapsed = true;
                        this.splitContainer_EMP.Height = 50;
                    }
                    break;

                case "lbl_CUMR":
                    if (this.splitContainer_CUMR.Panel2Collapsed == true)
                    {
                        this.splitContainer_CUMR.Panel2Collapsed = false;
                        this.splitContainer_CUMR.Height = 370;
                    }
                    else
                    {
                        this.splitContainer_CUMR.Panel2Collapsed = true;
                        this.splitContainer_CUMR.Height = 50;
                    }
                    break;

                default:
                    if (this.splitContainer_CUMR.Panel2Collapsed == true)
                    {
                        this.splitContainer_CUMR.Panel2Collapsed = false;
                        this.splitContainer_CUMR.Height = 370;
                        this.splitContainer_EMP.Panel2Collapsed = false;
                        this.splitContainer_EMP.Height = 370;
                    }
                    else
                    {
                        this.splitContainer_CUMR.Panel2Collapsed = true;
                        this.splitContainer_CUMR.Height = 50;
                        this.splitContainer_EMP.Panel2Collapsed = true;
                        this.splitContainer_EMP.Height = 50;
                    }
                    break;
            }
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lbl_meau_Click("Load");
        }
    }
}
