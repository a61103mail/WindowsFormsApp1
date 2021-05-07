using Encoder.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        FOODEntities db = new FOODEntities();
        global::Encoder.Security.Encoder encode = new global::Encoder.Security.Encoder();
        EncoderType type = EncoderType.SHA1;
        
        public Form1()
        {
            InitializeComponent();
            this.TopMost = true;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            registered regis = new registered();            
            regis.Dock = DockStyle.Fill;
            regis.TopLevel = false;
            regis.TopMost = true;
            regis.FormBorderStyle = FormBorderStyle.None;
            this.panel3.Controls.Add(regis);
            this.panel2.Visible = false;
            regis.Show();

            //var registered = new registered();
            //registered.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {            
            ForgotPW forgotPW = new ForgotPW();
            forgotPW.Dock = DockStyle.Fill;
            forgotPW.TopLevel = false;
            forgotPW.TopMost = true;
            forgotPW.PWtextBox.Enabled = false;
            forgotPW.CKDPWtextBox.Enabled = false;
            forgotPW.ConfirmBtn.Enabled = false;
            forgotPW.FormBorderStyle = FormBorderStyle.None;
            this.panel3.Controls.Add(forgotPW);
            this.panel2.Visible = false;
            forgotPW.Show();

            //forgotPW.PWtextBox.Enabled = false;
            //forgotPW.CKDPWtextBox.Enabled = false;
            //forgotPW.ConfirmBtn.Enabled = false;
            //forgotPW.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string CusID = "";
            string CusPW = "";
            string EmpID = "";
            string EmpPW = "";
            string CusName = "";
            string EmpName = "";

            var CTMID = db.Customers.Where(n => n.Unicode == this.textBox1.Text).Select(n => new { n.Unicode, n.Password, n.Name });
            foreach (var item in CTMID)
            {
                CusID = item.Unicode;
                CusPW = item.Password;
                CusName = item.Name;
            }
            var EPYID = db.Employees.Where(n => n.Unicode == this.textBox1.Text).Select(n => new { n.Unicode, n.Password, n.Name });
            foreach (var item1 in EPYID)
            {
                EmpID = item1.Unicode;
                EmpPW = item1.Password;
                EmpName = item1.Name;
            }

            if (CustomerRadioButton.Checked == false && EMPRadioButton.Checked == false)
            {
                MessageBox.Show("請選擇登入身分別", "注意", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (CustomerRadioButton.Checked == true)
            {
                if (this.textBox1.Text == CusID && encode.Encrypt(type, this.textBox2.Text) == CusPW)
                {                    
                    MainForm main = new MainForm();
                    main.MainForm_NameLabel.Text = CusName + "，您好！";
                    main.Show();
                }
                else
                {
                    MessageBox.Show("輸入帳號密碼錯誤，請重新確認！", "警告！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (EMPRadioButton.Checked == true)
            {
                if (this.textBox1.Text == EmpID && encode.Encrypt(type, this.textBox2.Text) == EmpPW)
                {                    
                    MainForm main = new MainForm();
                    main.MainForm_NameLabel.Text = EmpName+"，您好！";
                    main.Show();
                }
                else
                {
                    MessageBox.Show("輸入帳號密碼錯誤，請重新確認！", "警告！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("錯誤！");
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            SetWindowRegion();
        }

        private void SetWindowRegion()
        {
            System.Drawing.Drawing2D.GraphicsPath formPath = new System.Drawing.Drawing2D.GraphicsPath();
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
            formPath = GetRoundedRectPath(rect, 50);//數字可以改框框圓角！
            this.Region = new Region(formPath);
        }

        private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            int diameter = radius;
            Rectangle arcRect = new Rectangle(rect.Location, new Size(diameter, diameter));
            GraphicsPath path = new GraphicsPath();

            // 左上角
            path.AddArc(arcRect, 180, 90);

            // 右上角
            arcRect.X = rect.Right - diameter;
            path.AddArc(arcRect, 270, 90);

            // 右下角
            arcRect.Y = rect.Bottom - diameter;
            path.AddArc(arcRect, 0, 90);

            // 左下角
            arcRect.X = rect.Left;
            path.AddArc(arcRect, 90, 90);
            path.CloseFigure();//閉合
            return path;
        }

        private Point mpoint = new Point();
        
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDownFunc(e);
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            MouseMoveFunc(e);
        }
        private void MouseDownFunc(MouseEventArgs e)
        {
            mpoint.X = e.X;
            mpoint.Y = e.Y;
        }
        private void MouseMoveFunc(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point myposition = MousePosition;
                myposition.Offset(-mpoint.X, -mpoint.Y);
                Location = myposition;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.CustomerRadioButton.Checked = true;
            this.textBox1.Text = "58888888";
            this.textBox2.Text = "5858";
        }


        private void panel3_ControlRemoved(object sender, ControlEventArgs e)
        {
            this.panel2.Visible = true;
        }
    }
}
