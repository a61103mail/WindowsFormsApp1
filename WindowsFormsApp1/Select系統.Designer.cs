
namespace WindowsFormsApp1
{
    partial class Select系統
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CTMRbtn = new System.Windows.Forms.RadioButton();
            this.EMPbtn = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.selectbtn = new System.Windows.Forms.Button();
            this.phonetextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.unicodetextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nametextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.IDTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.listView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // CTMRbtn
            // 
            this.CTMRbtn.AutoSize = true;
            this.CTMRbtn.Location = new System.Drawing.Point(3, 3);
            this.CTMRbtn.Name = "CTMRbtn";
            this.CTMRbtn.Size = new System.Drawing.Size(71, 16);
            this.CTMRbtn.TabIndex = 0;
            this.CTMRbtn.Text = "客戶查詢";
            this.CTMRbtn.UseVisualStyleBackColor = true;
            // 
            // EMPbtn
            // 
            this.EMPbtn.AutoSize = true;
            this.EMPbtn.Location = new System.Drawing.Point(94, 3);
            this.EMPbtn.Name = "EMPbtn";
            this.EMPbtn.Size = new System.Drawing.Size(71, 16);
            this.EMPbtn.TabIndex = 1;
            this.EMPbtn.Text = "員工查詢";
            this.EMPbtn.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.selectbtn);
            this.panel1.Controls.Add(this.phonetextBox);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.unicodetextBox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.nametextBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.IDTextBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(12, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(550, 161);
            this.panel1.TabIndex = 2;
            // 
            // selectbtn
            // 
            this.selectbtn.Location = new System.Drawing.Point(365, 20);
            this.selectbtn.Name = "selectbtn";
            this.selectbtn.Size = new System.Drawing.Size(166, 126);
            this.selectbtn.TabIndex = 11;
            this.selectbtn.Text = "查詢";
            this.selectbtn.UseVisualStyleBackColor = true;
            this.selectbtn.Click += new System.EventHandler(this.selectbtn_Click);
            // 
            // phonetextBox
            // 
            this.phonetextBox.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.phonetextBox.Location = new System.Drawing.Point(106, 119);
            this.phonetextBox.Name = "phonetextBox";
            this.phonetextBox.Size = new System.Drawing.Size(160, 27);
            this.phonetextBox.TabIndex = 10;
            this.phonetextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Select系統_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(20, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "電話";
            // 
            // unicodetextBox
            // 
            this.unicodetextBox.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.unicodetextBox.Location = new System.Drawing.Point(106, 86);
            this.unicodetextBox.Name = "unicodetextBox";
            this.unicodetextBox.Size = new System.Drawing.Size(160, 27);
            this.unicodetextBox.TabIndex = 8;
            this.unicodetextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Select系統_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(20, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Unicode";
            // 
            // nametextBox
            // 
            this.nametextBox.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.nametextBox.Location = new System.Drawing.Point(106, 53);
            this.nametextBox.Name = "nametextBox";
            this.nametextBox.Size = new System.Drawing.Size(160, 27);
            this.nametextBox.TabIndex = 6;
            this.nametextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Select系統_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(20, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "名稱";
            // 
            // IDTextBox
            // 
            this.IDTextBox.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.IDTextBox.Location = new System.Drawing.Point(106, 20);
            this.IDTextBox.Name = "IDTextBox";
            this.IDTextBox.Size = new System.Drawing.Size(160, 27);
            this.IDTextBox.TabIndex = 4;
            this.IDTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Select系統_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(20, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "編號";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.CTMRbtn);
            this.panel2.Controls.Add(this.EMPbtn);
            this.panel2.Location = new System.Drawing.Point(186, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(180, 21);
            this.panel2.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.listView);
            this.panel3.Location = new System.Drawing.Point(13, 212);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(549, 437);
            this.panel3.TabIndex = 4;
            // 
            // listView
            // 
            this.listView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.HideSelection = false;
            this.listView.HotTracking = true;
            this.listView.HoverSelection = true;
            this.listView.Location = new System.Drawing.Point(0, 0);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(549, 437);
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView_MouseClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "名稱";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "ID";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "unicode";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 120;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "電話";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 120;
            // 
            // Select系統
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 656);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Select系統";
            this.Text = "Select系統";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Select系統_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.RadioButton CTMRbtn;
        internal System.Windows.Forms.RadioButton EMPbtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button selectbtn;
        private System.Windows.Forms.TextBox phonetextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox unicodetextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox nametextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox IDTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
    }
}