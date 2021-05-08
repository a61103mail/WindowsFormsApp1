
namespace WindowsFormsApp1
{
    partial class 採購表單
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUnicode = new System.Windows.Forms.TextBox();
            this.txtContact = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSupplierAddr = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDeliveryAddr = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dtpDelivery = new System.Windows.Forms.DateTimePicker();
            this.lblSupplierID = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.RichTextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblPurchaserEmpID = new System.Windows.Forms.Label();
            this.lblTallyEmpID = new System.Windows.Forms.Label();
            this.cmbPurchaseEmp = new System.Windows.Forms.ComboBox();
            this.cmbTallyEmp = new System.Windows.Forms.ComboBox();
            this.dtpPurchase = new System.Windows.Forms.DateTimePicker();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.cmbSupplier = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(13, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "供應商：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(13, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "採購單號：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(275, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "供應商編號：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(99, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "                     ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(13, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "統    編：";
            // 
            // txtUnicode
            // 
            this.txtUnicode.Location = new System.Drawing.Point(93, 175);
            this.txtUnicode.Name = "txtUnicode";
            this.txtUnicode.ReadOnly = true;
            this.txtUnicode.Size = new System.Drawing.Size(164, 22);
            this.txtUnicode.TabIndex = 7;
            // 
            // txtContact
            // 
            this.txtContact.Location = new System.Drawing.Point(528, 138);
            this.txtContact.Name = "txtContact";
            this.txtContact.ReadOnly = true;
            this.txtContact.Size = new System.Drawing.Size(123, 22);
            this.txtContact.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(456, 142);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 15);
            this.label6.TabIndex = 8;
            this.label6.Text = "聯絡人：";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(751, 138);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.ReadOnly = true;
            this.txtPhone.Size = new System.Drawing.Size(164, 22);
            this.txtPhone.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.Location = new System.Drawing.Point(673, 142);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 15);
            this.label7.TabIndex = 10;
            this.label7.Text = "聯絡電話：";
            // 
            // txtSupplierAddr
            // 
            this.txtSupplierAddr.Location = new System.Drawing.Point(375, 175);
            this.txtSupplierAddr.Name = "txtSupplierAddr";
            this.txtSupplierAddr.ReadOnly = true;
            this.txtSupplierAddr.Size = new System.Drawing.Size(361, 22);
            this.txtSupplierAddr.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.Location = new System.Drawing.Point(275, 179);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 15);
            this.label8.TabIndex = 12;
            this.label8.Text = "供應商地址：";
            // 
            // txtDeliveryAddr
            // 
            this.txtDeliveryAddr.Location = new System.Drawing.Point(93, 289);
            this.txtDeliveryAddr.Name = "txtDeliveryAddr";
            this.txtDeliveryAddr.Size = new System.Drawing.Size(361, 22);
            this.txtDeliveryAddr.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label9.Location = new System.Drawing.Point(12, 296);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 15);
            this.label9.TabIndex = 14;
            this.label9.Text = "送貨地址：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label10.Location = new System.Drawing.Point(208, 106);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 15);
            this.label10.TabIndex = 16;
            this.label10.Text = "採購日期：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label11.Location = new System.Drawing.Point(13, 335);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 15);
            this.label11.TabIndex = 17;
            this.label11.Text = "交貨日期：";
            // 
            // dtpDelivery
            // 
            this.dtpDelivery.Location = new System.Drawing.Point(93, 330);
            this.dtpDelivery.Name = "dtpDelivery";
            this.dtpDelivery.Size = new System.Drawing.Size(176, 22);
            this.dtpDelivery.TabIndex = 19;
            // 
            // lblSupplierID
            // 
            this.lblSupplierID.AutoSize = true;
            this.lblSupplierID.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblSupplierID.Location = new System.Drawing.Point(372, 141);
            this.lblSupplierID.Name = "lblSupplierID";
            this.lblSupplierID.Size = new System.Drawing.Size(83, 15);
            this.lblSupplierID.TabIndex = 20;
            this.lblSupplierID.Text = "                   ";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label13.Location = new System.Drawing.Point(12, 216);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(82, 15);
            this.label13.TabIndex = 21;
            this.label13.Text = "採購人員：";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label14.Location = new System.Drawing.Point(227, 216);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(112, 15);
            this.label14.TabIndex = 22;
            this.label14.Text = "採購人員編號：";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label15.Location = new System.Drawing.Point(227, 256);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(112, 15);
            this.label15.TabIndex = 26;
            this.label15.Text = "理貨人員編號：";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label16.Location = new System.Drawing.Point(12, 256);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(82, 15);
            this.label16.TabIndex = 25;
            this.label16.Text = "理貨人員：";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label17.Location = new System.Drawing.Point(506, 215);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(52, 15);
            this.label17.TabIndex = 29;
            this.label17.Text = "備註：";
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(564, 214);
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(378, 138);
            this.txtComment.TabIndex = 30;
            this.txtComment.Text = "";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(18, 369);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(946, 262);
            this.dataGridView1.TabIndex = 31;
            // 
            // lblPurchaserEmpID
            // 
            this.lblPurchaserEmpID.AutoSize = true;
            this.lblPurchaserEmpID.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblPurchaserEmpID.Location = new System.Drawing.Point(341, 215);
            this.lblPurchaserEmpID.Name = "lblPurchaserEmpID";
            this.lblPurchaserEmpID.Size = new System.Drawing.Size(75, 15);
            this.lblPurchaserEmpID.TabIndex = 32;
            this.lblPurchaserEmpID.Text = "                 ";
            // 
            // lblTallyEmpID
            // 
            this.lblTallyEmpID.AutoSize = true;
            this.lblTallyEmpID.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblTallyEmpID.Location = new System.Drawing.Point(342, 255);
            this.lblTallyEmpID.Name = "lblTallyEmpID";
            this.lblTallyEmpID.Size = new System.Drawing.Size(91, 15);
            this.lblTallyEmpID.TabIndex = 33;
            this.lblTallyEmpID.Text = "                     ";
            // 
            // cmbPurchaseEmp
            // 
            this.cmbPurchaseEmp.FormattingEnabled = true;
            this.cmbPurchaseEmp.Location = new System.Drawing.Point(93, 214);
            this.cmbPurchaseEmp.Name = "cmbPurchaseEmp";
            this.cmbPurchaseEmp.Size = new System.Drawing.Size(121, 20);
            this.cmbPurchaseEmp.TabIndex = 34;
            // 
            // cmbTallyEmp
            // 
            this.cmbTallyEmp.FormattingEnabled = true;
            this.cmbTallyEmp.Location = new System.Drawing.Point(93, 252);
            this.cmbTallyEmp.Name = "cmbTallyEmp";
            this.cmbTallyEmp.Size = new System.Drawing.Size(121, 20);
            this.cmbTallyEmp.TabIndex = 35;
            // 
            // dtpPurchase
            // 
            this.dtpPurchase.Location = new System.Drawing.Point(293, 102);
            this.dtpPurchase.Name = "dtpPurchase";
            this.dtpPurchase.Size = new System.Drawing.Size(176, 22);
            this.dtpPurchase.TabIndex = 37;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button3.Location = new System.Drawing.Point(89, 10);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(65, 31);
            this.button3.TabIndex = 38;
            this.button3.Text = "搜尋";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.Info;
            this.button4.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button4.Location = new System.Drawing.Point(366, 51);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(42, 31);
            this.button4.TabIndex = 39;
            this.button4.Text = "<<";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.SystemColors.Info;
            this.button5.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button5.Location = new System.Drawing.Point(413, 51);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(63, 31);
            this.button5.TabIndex = 40;
            this.button5.Text = "<";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.SystemColors.Info;
            this.button6.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button6.Location = new System.Drawing.Point(481, 51);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(63, 31);
            this.button6.TabIndex = 41;
            this.button6.Text = ">";
            this.button6.UseVisualStyleBackColor = false;
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.SystemColors.Info;
            this.button7.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button7.Location = new System.Drawing.Point(549, 51);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(42, 31);
            this.button7.TabIndex = 42;
            this.button7.Text = ">>";
            this.button7.UseVisualStyleBackColor = false;
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button8.Location = new System.Drawing.Point(14, 10);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(65, 31);
            this.button8.TabIndex = 43;
            this.button8.Text = "新增";
            this.button8.UseVisualStyleBackColor = false;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(15, 52);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(65, 31);
            this.button9.TabIndex = 44;
            this.button9.Text = "儲存";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            this.button10.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.red;
            this.button10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button10.Location = new System.Drawing.Point(89, 52);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(65, 31);
            this.button10.TabIndex = 45;
            this.button10.Text = "刪除此單";
            this.button10.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.搜尋圖示;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(234, 137);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 25);
            this.button1.TabIndex = 1;
            this.button1.Text = "`";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(638, 17);
            this.listBox1.Margin = new System.Windows.Forms.Padding(2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(153, 88);
            this.listBox1.TabIndex = 46;
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(284, 329);
            this.button11.Margin = new System.Windows.Forms.Padding(2);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(74, 22);
            this.button11.TabIndex = 47;
            this.button11.Text = "新增品項";
            this.button11.UseVisualStyleBackColor = true;
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(367, 329);
            this.button12.Margin = new System.Windows.Forms.Padding(2);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(65, 21);
            this.button12.TabIndex = 48;
            this.button12.Text = "刪除品項";
            this.button12.UseVisualStyleBackColor = true;
            // 
            // cmbSupplier
            // 
            this.cmbSupplier.FormattingEnabled = true;
            this.cmbSupplier.Location = new System.Drawing.Point(93, 138);
            this.cmbSupplier.Name = "cmbSupplier";
            this.cmbSupplier.Size = new System.Drawing.Size(121, 20);
            this.cmbSupplier.TabIndex = 49;
            // 
            // 採購表單
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(977, 644);
            this.Controls.Add(this.cmbSupplier);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.dtpPurchase);
            this.Controls.Add(this.cmbTallyEmp);
            this.Controls.Add(this.cmbPurchaseEmp);
            this.Controls.Add(this.lblTallyEmpID);
            this.Controls.Add(this.lblPurchaserEmpID);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lblSupplierID);
            this.Controls.Add(this.dtpDelivery);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtDeliveryAddr);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtSupplierAddr);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtContact);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtUnicode);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "採購表單";
            this.Text = "採購表單";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUnicode;
        private System.Windows.Forms.TextBox txtContact;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSupplierAddr;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDeliveryAddr;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtpDelivery;
        private System.Windows.Forms.Label lblSupplierID;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.RichTextBox txtComment;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblPurchaserEmpID;
        private System.Windows.Forms.Label lblTallyEmpID;
        private System.Windows.Forms.ComboBox cmbPurchaseEmp;
        private System.Windows.Forms.ComboBox cmbTallyEmp;
        private System.Windows.Forms.DateTimePicker dtpPurchase;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.ComboBox cmbSupplier;
    }
}

