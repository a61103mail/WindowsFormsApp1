
namespace WindowsFormsApp1
{
    partial class Form2
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            System.Windows.Forms.Label orderIDLabel;
            System.Windows.Forms.Label userNameLabel;
            System.Windows.Forms.Label orderDateLabel;
            System.Windows.Forms.Label modifiedDateLabel;
            System.Windows.Forms.Label customerIDLabel;
            System.Windows.Forms.Label employeeIDLabel;
            System.Windows.Forms.Label requiredDateLabel;
            System.Windows.Forms.Label commentLabel;
            System.Windows.Forms.Label statusLabel;
            System.Windows.Forms.Label addressLabel;
            System.Windows.Forms.Label employeeIDLabel1;
            System.Windows.Forms.Label orderIDLabel2;
            System.Windows.Forms.Label userNameLabel1;
            System.Windows.Forms.Label orderDateLabel1;
            System.Windows.Forms.Label modifiedDateLabel1;
            System.Windows.Forms.Label customerIDLabel1;
            System.Windows.Forms.Label employeeIDLabel2;
            System.Windows.Forms.Label requiredDateLabel1;
            System.Windows.Forms.Label commentLabel1;
            System.Windows.Forms.Label statusLabel1;
            System.Windows.Forms.Label addressLabel1;
            this.orderBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.orderBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.orderIDLabel1 = new System.Windows.Forms.Label();
            this.userNameTextBox = new System.Windows.Forms.TextBox();
            this.orderDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.modifiedDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.customerIDComboBox = new System.Windows.Forms.ComboBox();
            this.employeeIDComboBox = new System.Windows.Forms.ComboBox();
            this.requiredDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.commentTextBox = new System.Windows.Forms.TextBox();
            this.statusTextBox = new System.Windows.Forms.TextBox();
            this.addressTextBox = new System.Windows.Forms.TextBox();
            this.fKOrderDetailOrderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.orderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fOODDataSet = new WindowsFormsApp1.FOODDataSet();
            this.orderTableAdapter = new WindowsFormsApp1.FOODDataSetTableAdapters.OrderTableAdapter();
            this.tableAdapterManager = new WindowsFormsApp1.FOODDataSetTableAdapters.TableAdapterManager();
            this.orderDetailTableAdapter = new WindowsFormsApp1.FOODDataSetTableAdapters.OrderDetailTableAdapter();
            this.employeeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.employeeTableAdapter = new WindowsFormsApp1.FOODDataSetTableAdapters.EmployeeTableAdapter();
            this.orderBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.employeeIDComboBox1 = new System.Windows.Forms.ComboBox();
            this.orderIDLabel3 = new System.Windows.Forms.Label();
            this.userNameTextBox1 = new System.Windows.Forms.TextBox();
            this.orderDateDateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.modifiedDateDateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.customerIDComboBox1 = new System.Windows.Forms.ComboBox();
            this.employeeIDComboBox2 = new System.Windows.Forms.ComboBox();
            this.requiredDateDateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.commentTextBox1 = new System.Windows.Forms.TextBox();
            this.statusTextBox1 = new System.Windows.Forms.TextBox();
            this.addressTextBox1 = new System.Windows.Forms.TextBox();
            orderIDLabel = new System.Windows.Forms.Label();
            userNameLabel = new System.Windows.Forms.Label();
            orderDateLabel = new System.Windows.Forms.Label();
            modifiedDateLabel = new System.Windows.Forms.Label();
            customerIDLabel = new System.Windows.Forms.Label();
            employeeIDLabel = new System.Windows.Forms.Label();
            requiredDateLabel = new System.Windows.Forms.Label();
            commentLabel = new System.Windows.Forms.Label();
            statusLabel = new System.Windows.Forms.Label();
            addressLabel = new System.Windows.Forms.Label();
            employeeIDLabel1 = new System.Windows.Forms.Label();
            orderIDLabel2 = new System.Windows.Forms.Label();
            userNameLabel1 = new System.Windows.Forms.Label();
            orderDateLabel1 = new System.Windows.Forms.Label();
            modifiedDateLabel1 = new System.Windows.Forms.Label();
            customerIDLabel1 = new System.Windows.Forms.Label();
            employeeIDLabel2 = new System.Windows.Forms.Label();
            requiredDateLabel1 = new System.Windows.Forms.Label();
            commentLabel1 = new System.Windows.Forms.Label();
            statusLabel1 = new System.Windows.Forms.Label();
            addressLabel1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.orderBindingNavigator)).BeginInit();
            this.orderBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fKOrderDetailOrderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fOODDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // orderBindingNavigator
            // 
            this.orderBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.orderBindingNavigator.BindingSource = this.orderBindingSource;
            this.orderBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.orderBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.orderBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.orderBindingNavigatorSaveItem});
            this.orderBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.orderBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.orderBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.orderBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.orderBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.orderBindingNavigator.Name = "orderBindingNavigator";
            this.orderBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.orderBindingNavigator.Size = new System.Drawing.Size(1202, 25);
            this.orderBindingNavigator.TabIndex = 0;
            this.orderBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "移到最前面";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "移到上一個";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "位置";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "目前的位置";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(27, 22);
            this.bindingNavigatorCountItem.Text = "/{0}";
            this.bindingNavigatorCountItem.ToolTipText = "項目總數";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "移到下一個";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "移到最後面";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "加入新的";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "刪除";
            // 
            // orderBindingNavigatorSaveItem
            // 
            this.orderBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.orderBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("orderBindingNavigatorSaveItem.Image")));
            this.orderBindingNavigatorSaveItem.Name = "orderBindingNavigatorSaveItem";
            this.orderBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.orderBindingNavigatorSaveItem.Text = "儲存資料";
            this.orderBindingNavigatorSaveItem.Click += new System.EventHandler(this.orderBindingNavigatorSaveItem_Click_3);
            // 
            // orderIDLabel
            // 
            orderIDLabel.AutoSize = true;
            orderIDLabel.Location = new System.Drawing.Point(221, 51);
            orderIDLabel.Name = "orderIDLabel";
            orderIDLabel.Size = new System.Drawing.Size(50, 12);
            orderIDLabel.TabIndex = 1;
            orderIDLabel.Text = "Order ID:";
            // 
            // orderIDLabel1
            // 
            this.orderIDLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.orderBindingSource, "OrderID", true));
            this.orderIDLabel1.Location = new System.Drawing.Point(302, 51);
            this.orderIDLabel1.Name = "orderIDLabel1";
            this.orderIDLabel1.Size = new System.Drawing.Size(200, 23);
            this.orderIDLabel1.TabIndex = 2;
            this.orderIDLabel1.Text = "label1";
            // 
            // userNameLabel
            // 
            userNameLabel.AutoSize = true;
            userNameLabel.Location = new System.Drawing.Point(221, 80);
            userNameLabel.Name = "userNameLabel";
            userNameLabel.Size = new System.Drawing.Size(59, 12);
            userNameLabel.TabIndex = 3;
            userNameLabel.Text = "User Name:";
            // 
            // userNameTextBox
            // 
            this.userNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.orderBindingSource, "UserName", true));
            this.userNameTextBox.Location = new System.Drawing.Point(302, 77);
            this.userNameTextBox.Name = "userNameTextBox";
            this.userNameTextBox.Size = new System.Drawing.Size(200, 22);
            this.userNameTextBox.TabIndex = 4;
            this.userNameTextBox.Text = "  ";
            // 
            // orderDateLabel
            // 
            orderDateLabel.AutoSize = true;
            orderDateLabel.Location = new System.Drawing.Point(221, 109);
            orderDateLabel.Name = "orderDateLabel";
            orderDateLabel.Size = new System.Drawing.Size(59, 12);
            orderDateLabel.TabIndex = 5;
            orderDateLabel.Text = "Order Date:";
            // 
            // orderDateDateTimePicker
            // 
            this.orderDateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.orderBindingSource, "OrderDate", true));
            this.orderDateDateTimePicker.Location = new System.Drawing.Point(302, 105);
            this.orderDateDateTimePicker.Name = "orderDateDateTimePicker";
            this.orderDateDateTimePicker.Size = new System.Drawing.Size(200, 22);
            this.orderDateDateTimePicker.TabIndex = 6;
            // 
            // modifiedDateLabel
            // 
            modifiedDateLabel.AutoSize = true;
            modifiedDateLabel.Location = new System.Drawing.Point(221, 137);
            modifiedDateLabel.Name = "modifiedDateLabel";
            modifiedDateLabel.Size = new System.Drawing.Size(75, 12);
            modifiedDateLabel.TabIndex = 7;
            modifiedDateLabel.Text = "Modified Date:";
            // 
            // modifiedDateDateTimePicker
            // 
            this.modifiedDateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.orderBindingSource, "ModifiedDate", true));
            this.modifiedDateDateTimePicker.Location = new System.Drawing.Point(302, 133);
            this.modifiedDateDateTimePicker.Name = "modifiedDateDateTimePicker";
            this.modifiedDateDateTimePicker.Size = new System.Drawing.Size(200, 22);
            this.modifiedDateDateTimePicker.TabIndex = 8;
            // 
            // customerIDLabel
            // 
            customerIDLabel.AutoSize = true;
            customerIDLabel.Location = new System.Drawing.Point(221, 164);
            customerIDLabel.Name = "customerIDLabel";
            customerIDLabel.Size = new System.Drawing.Size(68, 12);
            customerIDLabel.TabIndex = 9;
            customerIDLabel.Text = "Customer ID:";
            // 
            // customerIDComboBox
            // 
            this.customerIDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.orderBindingSource, "CustomerID", true));
            this.customerIDComboBox.FormattingEnabled = true;
            this.customerIDComboBox.Location = new System.Drawing.Point(302, 161);
            this.customerIDComboBox.Name = "customerIDComboBox";
            this.customerIDComboBox.Size = new System.Drawing.Size(200, 20);
            this.customerIDComboBox.TabIndex = 10;
            // 
            // employeeIDLabel
            // 
            employeeIDLabel.AutoSize = true;
            employeeIDLabel.Location = new System.Drawing.Point(221, 190);
            employeeIDLabel.Name = "employeeIDLabel";
            employeeIDLabel.Size = new System.Drawing.Size(70, 12);
            employeeIDLabel.TabIndex = 11;
            employeeIDLabel.Text = "Employee ID:";
            // 
            // employeeIDComboBox
            // 
            this.employeeIDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.employeeBindingSource, "Name", true));
            this.employeeIDComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.employeeBindingSource, "EmployeeID", true));
            this.employeeIDComboBox.FormattingEnabled = true;
            this.employeeIDComboBox.Location = new System.Drawing.Point(302, 187);
            this.employeeIDComboBox.Name = "employeeIDComboBox";
            this.employeeIDComboBox.Size = new System.Drawing.Size(200, 20);
            this.employeeIDComboBox.TabIndex = 12;
            // 
            // requiredDateLabel
            // 
            requiredDateLabel.AutoSize = true;
            requiredDateLabel.Location = new System.Drawing.Point(221, 217);
            requiredDateLabel.Name = "requiredDateLabel";
            requiredDateLabel.Size = new System.Drawing.Size(75, 12);
            requiredDateLabel.TabIndex = 13;
            requiredDateLabel.Text = "Required Date:";
            // 
            // requiredDateDateTimePicker
            // 
            this.requiredDateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.orderBindingSource, "RequiredDate", true));
            this.requiredDateDateTimePicker.Location = new System.Drawing.Point(302, 213);
            this.requiredDateDateTimePicker.Name = "requiredDateDateTimePicker";
            this.requiredDateDateTimePicker.Size = new System.Drawing.Size(200, 22);
            this.requiredDateDateTimePicker.TabIndex = 14;
            // 
            // commentLabel
            // 
            commentLabel.AutoSize = true;
            commentLabel.Location = new System.Drawing.Point(221, 244);
            commentLabel.Name = "commentLabel";
            commentLabel.Size = new System.Drawing.Size(54, 12);
            commentLabel.TabIndex = 15;
            commentLabel.Text = "Comment:";
            // 
            // commentTextBox
            // 
            this.commentTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.orderBindingSource, "Comment", true));
            this.commentTextBox.Location = new System.Drawing.Point(302, 241);
            this.commentTextBox.Name = "commentTextBox";
            this.commentTextBox.Size = new System.Drawing.Size(200, 22);
            this.commentTextBox.TabIndex = 16;
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.Location = new System.Drawing.Point(221, 272);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new System.Drawing.Size(33, 12);
            statusLabel.TabIndex = 17;
            statusLabel.Text = "status:";
            // 
            // statusTextBox
            // 
            this.statusTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.orderBindingSource, "status", true));
            this.statusTextBox.Location = new System.Drawing.Point(302, 269);
            this.statusTextBox.Name = "statusTextBox";
            this.statusTextBox.Size = new System.Drawing.Size(200, 22);
            this.statusTextBox.TabIndex = 18;
            // 
            // addressLabel
            // 
            addressLabel.AutoSize = true;
            addressLabel.Location = new System.Drawing.Point(221, 300);
            addressLabel.Name = "addressLabel";
            addressLabel.Size = new System.Drawing.Size(45, 12);
            addressLabel.TabIndex = 19;
            addressLabel.Text = "Address:";
            // 
            // addressTextBox
            // 
            this.addressTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.orderBindingSource, "Address", true));
            this.addressTextBox.Location = new System.Drawing.Point(302, 297);
            this.addressTextBox.Name = "addressTextBox";
            this.addressTextBox.Size = new System.Drawing.Size(200, 22);
            this.addressTextBox.TabIndex = 20;
            // 
            // fKOrderDetailOrderBindingSource
            // 
            this.fKOrderDetailOrderBindingSource.DataMember = "FK_OrderDetail_Order";
            this.fKOrderDetailOrderBindingSource.DataSource = this.orderBindingSource;
            // 
            // orderBindingSource
            // 
            this.orderBindingSource.DataMember = "Order";
            this.orderBindingSource.DataSource = this.fOODDataSet;
            // 
            // fOODDataSet
            // 
            this.fOODDataSet.DataSetName = "FOODDataSet";
            this.fOODDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // orderTableAdapter
            // 
            this.orderTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CustomerTableAdapter = null;
            this.tableAdapterManager.EmployeeTableAdapter = null;
            this.tableAdapterManager.OrderDetailTableAdapter = this.orderDetailTableAdapter;
            this.tableAdapterManager.OrderTableAdapter = this.orderTableAdapter;
            this.tableAdapterManager.SalesDetailTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = WindowsFormsApp1.FOODDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // orderDetailTableAdapter
            // 
            this.orderDetailTableAdapter.ClearBeforeFill = true;
            // 
            // employeeBindingSource
            // 
            this.employeeBindingSource.DataMember = "Employee";
            this.employeeBindingSource.DataSource = this.fOODDataSet;
            // 
            // employeeTableAdapter
            // 
            this.employeeTableAdapter.ClearBeforeFill = true;
            // 
            // orderBindingSource1
            // 
            this.orderBindingSource1.DataMember = "FK_Order_Employee";
            this.orderBindingSource1.DataSource = this.employeeBindingSource;
            // 
            // employeeIDLabel1
            // 
            employeeIDLabel1.AutoSize = true;
            employeeIDLabel1.Location = new System.Drawing.Point(237, 355);
            employeeIDLabel1.Name = "employeeIDLabel1";
            employeeIDLabel1.Size = new System.Drawing.Size(70, 12);
            employeeIDLabel1.TabIndex = 21;
            employeeIDLabel1.Text = "Employee ID:";
            // 
            // employeeIDComboBox1
            // 
            this.employeeIDComboBox1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.orderBindingSource, "EmployeeID", true));
            this.employeeIDComboBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.employeeBindingSource, "Name", true));
            this.employeeIDComboBox1.FormattingEnabled = true;
            this.employeeIDComboBox1.Location = new System.Drawing.Point(313, 352);
            this.employeeIDComboBox1.Name = "employeeIDComboBox1";
            this.employeeIDComboBox1.Size = new System.Drawing.Size(121, 20);
            this.employeeIDComboBox1.TabIndex = 22;
            // 
            // orderIDLabel2
            // 
            orderIDLabel2.AutoSize = true;
            orderIDLabel2.Location = new System.Drawing.Point(620, 128);
            orderIDLabel2.Name = "orderIDLabel2";
            orderIDLabel2.Size = new System.Drawing.Size(50, 12);
            orderIDLabel2.TabIndex = 23;
            orderIDLabel2.Text = "Order ID:";
            // 
            // orderIDLabel3
            // 
            this.orderIDLabel3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.orderBindingSource, "OrderID", true));
            this.orderIDLabel3.Location = new System.Drawing.Point(701, 128);
            this.orderIDLabel3.Name = "orderIDLabel3";
            this.orderIDLabel3.Size = new System.Drawing.Size(200, 23);
            this.orderIDLabel3.TabIndex = 24;
            this.orderIDLabel3.Text = "label1";
            // 
            // userNameLabel1
            // 
            userNameLabel1.AutoSize = true;
            userNameLabel1.Location = new System.Drawing.Point(620, 157);
            userNameLabel1.Name = "userNameLabel1";
            userNameLabel1.Size = new System.Drawing.Size(59, 12);
            userNameLabel1.TabIndex = 25;
            userNameLabel1.Text = "User Name:";
            // 
            // userNameTextBox1
            // 
            this.userNameTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.orderBindingSource, "UserName", true));
            this.userNameTextBox1.Location = new System.Drawing.Point(701, 154);
            this.userNameTextBox1.Name = "userNameTextBox1";
            this.userNameTextBox1.Size = new System.Drawing.Size(200, 22);
            this.userNameTextBox1.TabIndex = 26;
            // 
            // orderDateLabel1
            // 
            orderDateLabel1.AutoSize = true;
            orderDateLabel1.Location = new System.Drawing.Point(620, 186);
            orderDateLabel1.Name = "orderDateLabel1";
            orderDateLabel1.Size = new System.Drawing.Size(59, 12);
            orderDateLabel1.TabIndex = 27;
            orderDateLabel1.Text = "Order Date:";
            // 
            // orderDateDateTimePicker1
            // 
            this.orderDateDateTimePicker1.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.orderBindingSource, "OrderDate", true));
            this.orderDateDateTimePicker1.Location = new System.Drawing.Point(701, 182);
            this.orderDateDateTimePicker1.Name = "orderDateDateTimePicker1";
            this.orderDateDateTimePicker1.Size = new System.Drawing.Size(200, 22);
            this.orderDateDateTimePicker1.TabIndex = 28;
            // 
            // modifiedDateLabel1
            // 
            modifiedDateLabel1.AutoSize = true;
            modifiedDateLabel1.Location = new System.Drawing.Point(620, 214);
            modifiedDateLabel1.Name = "modifiedDateLabel1";
            modifiedDateLabel1.Size = new System.Drawing.Size(75, 12);
            modifiedDateLabel1.TabIndex = 29;
            modifiedDateLabel1.Text = "Modified Date:";
            // 
            // modifiedDateDateTimePicker1
            // 
            this.modifiedDateDateTimePicker1.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.orderBindingSource, "ModifiedDate", true));
            this.modifiedDateDateTimePicker1.Location = new System.Drawing.Point(701, 210);
            this.modifiedDateDateTimePicker1.Name = "modifiedDateDateTimePicker1";
            this.modifiedDateDateTimePicker1.Size = new System.Drawing.Size(200, 22);
            this.modifiedDateDateTimePicker1.TabIndex = 30;
            // 
            // customerIDLabel1
            // 
            customerIDLabel1.AutoSize = true;
            customerIDLabel1.Location = new System.Drawing.Point(620, 241);
            customerIDLabel1.Name = "customerIDLabel1";
            customerIDLabel1.Size = new System.Drawing.Size(68, 12);
            customerIDLabel1.TabIndex = 31;
            customerIDLabel1.Text = "Customer ID:";
            // 
            // customerIDComboBox1
            // 
            this.customerIDComboBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.orderBindingSource, "CustomerID", true));
            this.customerIDComboBox1.FormattingEnabled = true;
            this.customerIDComboBox1.Location = new System.Drawing.Point(701, 238);
            this.customerIDComboBox1.Name = "customerIDComboBox1";
            this.customerIDComboBox1.Size = new System.Drawing.Size(200, 20);
            this.customerIDComboBox1.TabIndex = 32;
            // 
            // employeeIDLabel2
            // 
            employeeIDLabel2.AutoSize = true;
            employeeIDLabel2.Location = new System.Drawing.Point(620, 267);
            employeeIDLabel2.Name = "employeeIDLabel2";
            employeeIDLabel2.Size = new System.Drawing.Size(70, 12);
            employeeIDLabel2.TabIndex = 33;
            employeeIDLabel2.Text = "Employee ID:";
            // 
            // employeeIDComboBox2
            // 
            this.employeeIDComboBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.orderBindingSource, "EmployeeID", true));
            this.employeeIDComboBox2.FormattingEnabled = true;
            this.employeeIDComboBox2.Location = new System.Drawing.Point(701, 264);
            this.employeeIDComboBox2.Name = "employeeIDComboBox2";
            this.employeeIDComboBox2.Size = new System.Drawing.Size(200, 20);
            this.employeeIDComboBox2.TabIndex = 34;
            // 
            // requiredDateLabel1
            // 
            requiredDateLabel1.AutoSize = true;
            requiredDateLabel1.Location = new System.Drawing.Point(620, 294);
            requiredDateLabel1.Name = "requiredDateLabel1";
            requiredDateLabel1.Size = new System.Drawing.Size(75, 12);
            requiredDateLabel1.TabIndex = 35;
            requiredDateLabel1.Text = "Required Date:";
            // 
            // requiredDateDateTimePicker1
            // 
            this.requiredDateDateTimePicker1.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.orderBindingSource, "RequiredDate", true));
            this.requiredDateDateTimePicker1.Location = new System.Drawing.Point(701, 290);
            this.requiredDateDateTimePicker1.Name = "requiredDateDateTimePicker1";
            this.requiredDateDateTimePicker1.Size = new System.Drawing.Size(200, 22);
            this.requiredDateDateTimePicker1.TabIndex = 36;
            // 
            // commentLabel1
            // 
            commentLabel1.AutoSize = true;
            commentLabel1.Location = new System.Drawing.Point(620, 321);
            commentLabel1.Name = "commentLabel1";
            commentLabel1.Size = new System.Drawing.Size(54, 12);
            commentLabel1.TabIndex = 37;
            commentLabel1.Text = "Comment:";
            // 
            // commentTextBox1
            // 
            this.commentTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.orderBindingSource, "Comment", true));
            this.commentTextBox1.Location = new System.Drawing.Point(701, 318);
            this.commentTextBox1.Name = "commentTextBox1";
            this.commentTextBox1.Size = new System.Drawing.Size(200, 22);
            this.commentTextBox1.TabIndex = 38;
            // 
            // statusLabel1
            // 
            statusLabel1.AutoSize = true;
            statusLabel1.Location = new System.Drawing.Point(620, 349);
            statusLabel1.Name = "statusLabel1";
            statusLabel1.Size = new System.Drawing.Size(33, 12);
            statusLabel1.TabIndex = 39;
            statusLabel1.Text = "status:";
            // 
            // statusTextBox1
            // 
            this.statusTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.orderBindingSource, "status", true));
            this.statusTextBox1.Location = new System.Drawing.Point(701, 346);
            this.statusTextBox1.Name = "statusTextBox1";
            this.statusTextBox1.Size = new System.Drawing.Size(200, 22);
            this.statusTextBox1.TabIndex = 40;
            // 
            // addressLabel1
            // 
            addressLabel1.AutoSize = true;
            addressLabel1.Location = new System.Drawing.Point(620, 377);
            addressLabel1.Name = "addressLabel1";
            addressLabel1.Size = new System.Drawing.Size(45, 12);
            addressLabel1.TabIndex = 41;
            addressLabel1.Text = "Address:";
            // 
            // addressTextBox1
            // 
            this.addressTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.orderBindingSource, "Address", true));
            this.addressTextBox1.Location = new System.Drawing.Point(701, 374);
            this.addressTextBox1.Name = "addressTextBox1";
            this.addressTextBox1.Size = new System.Drawing.Size(200, 22);
            this.addressTextBox1.TabIndex = 42;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1202, 635);
            this.Controls.Add(orderIDLabel2);
            this.Controls.Add(this.orderIDLabel3);
            this.Controls.Add(userNameLabel1);
            this.Controls.Add(this.userNameTextBox1);
            this.Controls.Add(orderDateLabel1);
            this.Controls.Add(this.orderDateDateTimePicker1);
            this.Controls.Add(modifiedDateLabel1);
            this.Controls.Add(this.modifiedDateDateTimePicker1);
            this.Controls.Add(customerIDLabel1);
            this.Controls.Add(this.customerIDComboBox1);
            this.Controls.Add(employeeIDLabel2);
            this.Controls.Add(this.employeeIDComboBox2);
            this.Controls.Add(requiredDateLabel1);
            this.Controls.Add(this.requiredDateDateTimePicker1);
            this.Controls.Add(commentLabel1);
            this.Controls.Add(this.commentTextBox1);
            this.Controls.Add(statusLabel1);
            this.Controls.Add(this.statusTextBox1);
            this.Controls.Add(addressLabel1);
            this.Controls.Add(this.addressTextBox1);
            this.Controls.Add(employeeIDLabel1);
            this.Controls.Add(this.employeeIDComboBox1);
            this.Controls.Add(orderIDLabel);
            this.Controls.Add(this.orderIDLabel1);
            this.Controls.Add(userNameLabel);
            this.Controls.Add(this.userNameTextBox);
            this.Controls.Add(orderDateLabel);
            this.Controls.Add(this.orderDateDateTimePicker);
            this.Controls.Add(modifiedDateLabel);
            this.Controls.Add(this.modifiedDateDateTimePicker);
            this.Controls.Add(customerIDLabel);
            this.Controls.Add(this.customerIDComboBox);
            this.Controls.Add(employeeIDLabel);
            this.Controls.Add(this.employeeIDComboBox);
            this.Controls.Add(requiredDateLabel);
            this.Controls.Add(this.requiredDateDateTimePicker);
            this.Controls.Add(commentLabel);
            this.Controls.Add(this.commentTextBox);
            this.Controls.Add(statusLabel);
            this.Controls.Add(this.statusTextBox);
            this.Controls.Add(addressLabel);
            this.Controls.Add(this.addressTextBox);
            this.Controls.Add(this.orderBindingNavigator);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.orderBindingNavigator)).EndInit();
            this.orderBindingNavigator.ResumeLayout(false);
            this.orderBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fKOrderDetailOrderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fOODDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FOODDataSet fOODDataSet;
        private System.Windows.Forms.BindingSource orderBindingSource;
        private FOODDataSetTableAdapters.OrderTableAdapter orderTableAdapter;
        private FOODDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator orderBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton orderBindingNavigatorSaveItem;
        private System.Windows.Forms.Label orderIDLabel1;
        private System.Windows.Forms.TextBox userNameTextBox;
        private System.Windows.Forms.DateTimePicker orderDateDateTimePicker;
        private System.Windows.Forms.DateTimePicker modifiedDateDateTimePicker;
        private System.Windows.Forms.ComboBox customerIDComboBox;
        private System.Windows.Forms.ComboBox employeeIDComboBox;
        private System.Windows.Forms.DateTimePicker requiredDateDateTimePicker;
        private System.Windows.Forms.TextBox commentTextBox;
        private System.Windows.Forms.TextBox statusTextBox;
        private System.Windows.Forms.TextBox addressTextBox;
        private FOODDataSetTableAdapters.OrderDetailTableAdapter orderDetailTableAdapter;
        private System.Windows.Forms.BindingSource fKOrderDetailOrderBindingSource;
        private System.Windows.Forms.BindingSource employeeBindingSource;
        private FOODDataSetTableAdapters.EmployeeTableAdapter employeeTableAdapter;
        private System.Windows.Forms.BindingSource orderBindingSource1;
        private System.Windows.Forms.ComboBox employeeIDComboBox1;
        private System.Windows.Forms.Label orderIDLabel3;
        private System.Windows.Forms.TextBox userNameTextBox1;
        private System.Windows.Forms.DateTimePicker orderDateDateTimePicker1;
        private System.Windows.Forms.DateTimePicker modifiedDateDateTimePicker1;
        private System.Windows.Forms.ComboBox customerIDComboBox1;
        private System.Windows.Forms.ComboBox employeeIDComboBox2;
        private System.Windows.Forms.DateTimePicker requiredDateDateTimePicker1;
        private System.Windows.Forms.TextBox commentTextBox1;
        private System.Windows.Forms.TextBox statusTextBox1;
        private System.Windows.Forms.TextBox addressTextBox1;
    }
}