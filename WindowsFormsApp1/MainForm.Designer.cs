﻿
namespace WindowsFormsApp1
{
    partial class MainForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.splitContainer_EMP = new System.Windows.Forms.SplitContainer();
            this.lbl_EMP = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.splitContainer_CUMR = new System.Windows.Forms.SplitContainer();
            this.lbl_CUMR = new System.Windows.Forms.Label();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.button8 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.MainForm_NameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_EMP)).BeginInit();
            this.splitContainer_EMP.Panel1.SuspendLayout();
            this.splitContainer_EMP.Panel2.SuspendLayout();
            this.splitContainer_EMP.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_CUMR)).BeginInit();
            this.splitContainer_CUMR.Panel1.SuspendLayout();
            this.splitContainer_CUMR.Panel2.SuspendLayout();
            this.splitContainer_CUMR.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("標楷體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 50);
            this.label1.TabIndex = 2;
            this.label1.Text = "主選單";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1729, 905);
            this.panel1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Font = new System.Drawing.Font("標楷體", 14F);
            this.button1.Location = new System.Drawing.Point(1, 1);
            this.button1.Margin = new System.Windows.Forms.Padding(1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(185, 50);
            this.button1.TabIndex = 0;
            this.button1.Text = "人事管理系統";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.flowLayoutPanel2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.button3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1920, 960);
            this.splitContainer1.SplitterDistance = 187;
            this.splitContainer1.TabIndex = 3;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.splitContainer_EMP);
            this.flowLayoutPanel2.Controls.Add(this.splitContainer_CUMR);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 50);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.flowLayoutPanel2.Size = new System.Drawing.Size(187, 866);
            this.flowLayoutPanel2.TabIndex = 10;
            // 
            // splitContainer_EMP
            // 
            this.splitContainer_EMP.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer_EMP.IsSplitterFixed = true;
            this.splitContainer_EMP.Location = new System.Drawing.Point(0, 5);
            this.splitContainer_EMP.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer_EMP.Name = "splitContainer_EMP";
            this.splitContainer_EMP.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer_EMP.Panel1
            // 
            this.splitContainer_EMP.Panel1.Controls.Add(this.lbl_EMP);
            // 
            // splitContainer_EMP.Panel2
            // 
            this.splitContainer_EMP.Panel2.Controls.Add(this.flowLayoutPanel1);
            this.splitContainer_EMP.Size = new System.Drawing.Size(187, 470);
            this.splitContainer_EMP.SplitterDistance = 51;
            this.splitContainer_EMP.TabIndex = 3;
            // 
            // lbl_EMP
            // 
            this.lbl_EMP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_EMP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_EMP.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_EMP.Font = new System.Drawing.Font("標楷體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbl_EMP.Location = new System.Drawing.Point(0, 0);
            this.lbl_EMP.Name = "lbl_EMP";
            this.lbl_EMP.Size = new System.Drawing.Size(187, 50);
            this.lbl_EMP.TabIndex = 3;
            this.lbl_EMP.Text = "員工系統";
            this.lbl_EMP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_EMP.Click += new System.EventHandler(this.lbl_EMP_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.button1);
            this.flowLayoutPanel1.Controls.Add(this.button2);
            this.flowLayoutPanel1.Controls.Add(this.button4);
            this.flowLayoutPanel1.Controls.Add(this.button5);
            this.flowLayoutPanel1.Controls.Add(this.button9);
            this.flowLayoutPanel1.Controls.Add(this.button6);
            this.flowLayoutPanel1.Controls.Add(this.button7);
            this.flowLayoutPanel1.Controls.Add(this.button10);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(187, 415);
            this.flowLayoutPanel1.TabIndex = 12;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Font = new System.Drawing.Font("標楷體", 14F);
            this.button2.Location = new System.Drawing.Point(1, 53);
            this.button2.Margin = new System.Windows.Forms.Padding(1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(185, 50);
            this.button2.TabIndex = 3;
            this.button2.Text = "客戶管理系統";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Font = new System.Drawing.Font("標楷體", 14F);
            this.button4.Location = new System.Drawing.Point(1, 105);
            this.button4.Margin = new System.Windows.Forms.Padding(1);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(185, 50);
            this.button4.TabIndex = 5;
            this.button4.Text = "採購管理系統";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.Font = new System.Drawing.Font("標楷體", 14F);
            this.button5.Location = new System.Drawing.Point(1, 157);
            this.button5.Margin = new System.Windows.Forms.Padding(1);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(185, 50);
            this.button5.TabIndex = 6;
            this.button5.Text = "訂單管理系統";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button9
            // 
            this.button9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button9.Font = new System.Drawing.Font("標楷體", 14F);
            this.button9.Location = new System.Drawing.Point(1, 209);
            this.button9.Margin = new System.Windows.Forms.Padding(1);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(185, 50);
            this.button9.TabIndex = 9;
            this.button9.Text = "銷單管理系統";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button6.Font = new System.Drawing.Font("標楷體", 14F);
            this.button6.Location = new System.Drawing.Point(1, 261);
            this.button6.Margin = new System.Windows.Forms.Padding(1);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(185, 50);
            this.button6.TabIndex = 7;
            this.button6.Text = "進貨管理系統";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button7.Font = new System.Drawing.Font("標楷體", 14F);
            this.button7.Location = new System.Drawing.Point(1, 313);
            this.button7.Margin = new System.Windows.Forms.Padding(1);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(185, 50);
            this.button7.TabIndex = 8;
            this.button7.Text = "盤點系統";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button10
            // 
            this.button10.Font = new System.Drawing.Font("標楷體", 14F);
            this.button10.Location = new System.Drawing.Point(1, 365);
            this.button10.Margin = new System.Windows.Forms.Padding(1);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(185, 50);
            this.button10.TabIndex = 9;
            this.button10.Text = "產品系統";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // splitContainer_CUMR
            // 
            this.splitContainer_CUMR.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer_CUMR.IsSplitterFixed = true;
            this.splitContainer_CUMR.Location = new System.Drawing.Point(0, 475);
            this.splitContainer_CUMR.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer_CUMR.Name = "splitContainer_CUMR";
            this.splitContainer_CUMR.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer_CUMR.Panel1
            // 
            this.splitContainer_CUMR.Panel1.Controls.Add(this.lbl_CUMR);
            // 
            // splitContainer_CUMR.Panel2
            // 
            this.splitContainer_CUMR.Panel2.Controls.Add(this.flowLayoutPanel3);
            this.splitContainer_CUMR.Size = new System.Drawing.Size(187, 370);
            this.splitContainer_CUMR.SplitterDistance = 51;
            this.splitContainer_CUMR.TabIndex = 11;
            // 
            // lbl_CUMR
            // 
            this.lbl_CUMR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_CUMR.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_CUMR.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_CUMR.Font = new System.Drawing.Font("標楷體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbl_CUMR.Location = new System.Drawing.Point(0, 0);
            this.lbl_CUMR.Name = "lbl_CUMR";
            this.lbl_CUMR.Size = new System.Drawing.Size(187, 50);
            this.lbl_CUMR.TabIndex = 3;
            this.lbl_CUMR.Text = "客戶系統";
            this.lbl_CUMR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_CUMR.Click += new System.EventHandler(this.lbl_CUMR_Click);
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.button8);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(187, 315);
            this.flowLayoutPanel3.TabIndex = 12;
            // 
            // button8
            // 
            this.button8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button8.Font = new System.Drawing.Font("標楷體", 14F);
            this.button8.Location = new System.Drawing.Point(1, 1);
            this.button8.Margin = new System.Windows.Forms.Padding(1);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(185, 50);
            this.button8.TabIndex = 9;
            this.button8.Text = "分析系統";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button3.Font = new System.Drawing.Font("標楷體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button3.Location = new System.Drawing.Point(0, 916);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(187, 44);
            this.button3.TabIndex = 9;
            this.button3.Text = "離開";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.MainForm_NameLabel);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.panel1);
            this.splitContainer2.Size = new System.Drawing.Size(1729, 960);
            this.splitContainer2.SplitterDistance = 51;
            this.splitContainer2.TabIndex = 2;
            // 
            // MainForm_NameLabel
            // 
            this.MainForm_NameLabel.AutoSize = true;
            this.MainForm_NameLabel.Font = new System.Drawing.Font("標楷體", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.MainForm_NameLabel.Location = new System.Drawing.Point(3, 10);
            this.MainForm_NameLabel.Name = "MainForm_NameLabel";
            this.MainForm_NameLabel.Size = new System.Drawing.Size(0, 27);
            this.MainForm_NameLabel.TabIndex = 0;
            this.MainForm_NameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 960);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "食材通";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.splitContainer_EMP.Panel1.ResumeLayout(false);
            this.splitContainer_EMP.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_EMP)).EndInit();
            this.splitContainer_EMP.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.splitContainer_CUMR.Panel1.ResumeLayout(false);
            this.splitContainer_CUMR.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_CUMR)).EndInit();
            this.splitContainer_CUMR.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        internal System.Windows.Forms.Button button5;
        internal System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.SplitContainer splitContainer2;
        internal System.Windows.Forms.Label MainForm_NameLabel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.SplitContainer splitContainer_EMP;
        internal System.Windows.Forms.Label lbl_EMP;
        private System.Windows.Forms.SplitContainer splitContainer_CUMR;
        internal System.Windows.Forms.Label lbl_CUMR;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Button button8;
        internal System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
    }
}