using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace WindowsFormsApp1
{
    public partial class 採購表單 : Form
    {
        private FOODEntities db = new FOODEntities();
        private List<Purchase> purchases; //DB中的所有採購單
        private Purchase currentPurchase; //現在在表單上呈現的採購單
        private int currentIndex = 0; //這個欄位是指現在表單上顯示的是第幾筆採購單，預設為0
        private List<PurchaseDetailItem> detailItems = new List<PurchaseDetailItem>(); //這個欄位是用來裝目前所顯示的採購單的所有採購明細，包含被刪除的採購明細。PurchaseDetailItem是自定義的class，請見最末
        private List<int> selectedPurchaseID ; //這個欄位是要紀錄從採購單查詢頁面傳回來的（使用者勾選的）所有採購單ID，建議改成List<Purchase>的型態
        public List<Product_LatestPrice> product_LatestPrices; //先宣告這個欄位，等等要裝最新產品價格，目的是為了要加快採購單查詢頁面的讀取速度
        private BindingSource bs = new BindingSource(); //這個BindingSource是用來繫結表單上面的採購單號、供應商、統編等控制項
        private BindingSource viewBs = new BindingSource(); //這個BindingSource是用來繫結datagridview用的
        private SaveMode mode = SaveMode.EditPurchase; //用來區分新增模式或修改模式，對應在save中所需的不同流程
        private bool rowEditing = false; //這個布林值（flag）是用來阻擋datagridview在編輯的過程中一直觸發CellValidating事件

        public 採購表單()
        {

            InitializeComponent();
            this.purchases = this.db.Purchases.ToList();//先把所有採購單從資料庫中撈出來放到記憶體中，方便等等的操作
            //要注意！現在這個清單已經被固定在記憶體中了，因此如果有新增的採購單的話，要記得在db.SaveChange()之後重新撈一次！

            this.selectedPurchaseID = (from p in this.purchases
                                       select p.PurchaseID).ToList();//一開始使用者還沒進到採購單查詢頁面勾選要看的採購單有哪些，因此我先預設把所有採購單的ID都先放進這個list中，表示現在使用者可以從第一筆採購單一直下一筆下一筆到最後一筆採購單

            this.product_LatestPrices = this.db.Product_LatestPrice.ToList();//先把最新產品價格表撈出來放到記憶體中，任何需要查最新價格都用這個list查會快很多。在採購表單中基本上不會遇到最新產品價格更新的問題，因此不需要再重撈。

            this.Load += 採購表單_Load; //有些設定或綁定留到表單準備show出來的時候（Load事件發生）再做

        }
        private void 採購表單_Load(object sender, EventArgs e)
        {
            //綁定供應商、採購人員和理貨人員ComboBox的資料來源
            var emps = (from emp in this.db.Employees
                        select new
                        {
                            emp.Name,
                            emp.EmployeeID
                        }).ToList();
            this.cmbPurchaseEmp.DataSource = new BindingSource() {DataSource = emps };
            this.cmbPurchaseEmp.DisplayMember = "Name";
            this.cmbPurchaseEmp.ValueMember = "EmployeeID";
            this.cmbTallyEmp.DataSource = new BindingSource() { DataSource = emps };
            this.cmbTallyEmp.DisplayMember = "Name";
            this.cmbTallyEmp.ValueMember = "EmployeeID";

            this.cmbSupplier.DataSource = (from sup in this.db.Customers
                                           select sup).ToList();
            this.cmbSupplier.DisplayMember = "Name";
            this.cmbSupplier.ValueMember = "CustomerID";
            


            //找出資料庫中的第一筆採購單，藏在一個new PurchaseItem物件中
            this.currentPurchase = this.purchases[currentIndex];
            var purchaseItem = new PurchaseItem() { _p = this.currentPurchase };
            purchaseItem.SupplierName = purchaseItem._p.Customer.Name;
            purchaseItem.ContactPerson = purchaseItem._p.Customer.ContactPerson;
            purchaseItem.ContactCellPhone = purchaseItem._p.Customer.ContactCellPhone;
            purchaseItem.Unicode = purchaseItem._p.Customer.Unicode;
            purchaseItem.Address = purchaseItem._p.Customer.Address;
            purchaseItem.PurchaserEmp = (from emp in this.db.Employees
                                         where emp.EmployeeID == this.currentPurchase.PurchaserEmpID
                                         select emp.Name).FirstOrDefault();
            purchaseItem.TallyEmp = (from emp in this.db.Employees
                                     where emp.EmployeeID == this.currentPurchase.TallyEmpID
                                     select emp.Name).FirstOrDefault();
            

            //將this.bs的資料來源設定為上面那個PurchaseItem
            this.bs.DataSource = purchaseItem;


            //然後再綁定所有控制項（除了datagridview）的資料來源為this.bs，等等會用this.bs.ResetBindings()連動更新這些控制項的值（繫結）
            this.label4.DataBindings.Add(new Binding("Text", this.bs, "PurchaseID"));            
            this.dtpPurchase.DataBindings.Add(new Binding("Value", this.bs, "PurchaseDate"));            
            this.cmbSupplier.DataBindings.Add(new Binding("Text", this.bs, "SupplierName"));
            this.lblSupplierID.DataBindings.Add(new Binding("Text",this.bs, "SupplierID"));
            this.txtContact.DataBindings.Add(new Binding("Text", this.bs, "ContactPerson"));
            this.txtPhone.DataBindings.Add(new Binding("Text", this.bs, "ContactCellPhone"));
            this.txtUnicode.DataBindings.Add(new Binding("Text", this.bs, "Unicode"));
            this.txtSupplierAddr.DataBindings.Add(new Binding("Text", this.bs, "Address"));
            this.cmbPurchaseEmp.DataBindings.Add(new Binding("Text", this.bs, "PurchaserEmp"));
            this.lblPurchaserEmpID.DataBindings.Add(new Binding("Text", this.bs, "PurchaserEmpID"));
            this.cmbTallyEmp.DataBindings.Add(new Binding("Text", this.bs, "TallyEmp"));
            this.lblTallyEmpID.DataBindings.Add(new Binding("Text", this.bs, "TallyEmpID"));
            this.txtDeliveryAddr.DataBindings.Add(new Binding("Text", this.bs, "Deliveryaddress"));
            this.dtpDelivery.DataBindings.Add(new Binding("Value", this.bs, "RequiredDate"));
            this.txtComment.DataBindings.Add(new Binding("Text", this.bs, "Comment"));


            //綁定右上角listbox的資料來源為this.selectedPurchaseID，也就是採購單查詢頁面勾選的採購單的ID
            this.lbSelectedPurchase.DataSource = this.selectedPurchaseID;


            //一開始已經先找出了第一筆採購單（this.currentPurchase），用this.detailItems來記錄第一筆採購單的所有明細
            this.detailItems = (from pd in this.db.PurchaseDetails.AsEnumerable()
                              where pd.PurchaseID == this.currentPurchase.PurchaseID                              
                              select new PurchaseDetailItem()
                              {
                                  _pd = pd,
                                  項次 = 0, //這個是為了要製造出項次會1234的效果，說明起來有點麻煩，就略過囉！
                                  小計 = pd.Qty * pd.UnitPrice                                  
                              }).ToList();
            PurchaseDetailItem.serialNo = 0; //這個是為了要製造出項次會自動1234的效果，說明起來有點麻煩，就略過囉！

            //綁定dataGridView1的資料來源為this.viewBs，接著再綁定this.viewBs的資料來源為this.detailItems，但是因為之後會一直修改this.viewBs的資料來源，所以另外寫成一個function：reloadDataGridView（）
            this.dataGridView1.DataSource = this.viewBs;
            this.reloadDataGridView();


            this.dataGridView1.AllowUserToAddRows = false;  //把datagridview自動產生的最後一列空白列關掉
            this.dataGridView1.Columns["項次"].ReadOnly = true; //關閉項次欄位的編輯功能
            this.dataGridView1.Columns["料號"].ReadOnly = true; //關閉料號欄位的編輯功能
            this.dataGridView1.Columns["品名"].ReadOnly = true; //關閉品名欄位的編輯功能
            this.dataGridView1.Columns["單位"].ReadOnly = true; //關閉單位欄位的編輯功能
            this.dataGridView1.Columns["小計"].ReadOnly = true; //關閉小計欄位的編輯功能


            //綁定各控制項的事件
            this.btnAddPurchase.Click += this.addPurchase; //按下btnAddPurchase（新增）後即可生成新的採購單
            this.btnSearch.Click += this.searchPurchase;  //按下button3（搜尋）會開啟採購單查詢頁面
            this.btnCancel.Click += this.cancel; //按下btnCancel（取消）後會還原尚未儲存的任何修改
            this.button5.Click += this.previousPurchase; //按下button5（<）會跳到上一筆採購單，如果現在是第一筆，就不跳
            this.button6.Click += this.nextPurchase; //按下button6（>）會跳到下一筆採購單，如果現在是最後一筆，就不跳
            this.lbSelectedPurchase.Click += this.jumpPurchase;
            this.btnAddDetail.Click += this.addPurchaseDetail; //按下button11（新增品項）會開啟新增採購品項表單
            this.btnDelDetail.Click += this.delPurchaseDetail; //按下button12（刪除品項）會將在datagridview中選擇的項目標記為deleted，並從datagridview隱藏
            this.btnSave.Click += this.save; //把資料寫進DB，該新增的新增、該刪除的刪除、先新增又刪除的就不做任何處理、沒變動的資料也不做任何處理
            this.cmbSupplier.SelectedIndexChanged += ChangeSupplier;
            this.cmbPurchaseEmp.SelectedIndexChanged += ChangePurchaserEmp;
            this.cmbTallyEmp.SelectedIndexChanged += ChangeTallyEmp;
            this.dataGridView1.CellValidating += DataGridView1_CellValidating; //在datagridview中編輯格子中（cell）的內容後會觸發DataGridView1_CellValidating

            this.MouseClick += 採購表單_MouseClick;
        } //準備表單上的控制項、綁定各控制項的資料來源、載入第一筆訂單和明細、綁定控制項的事件
        private void reload()
        {

            //reload()要做的事情有：1.還原未儲存的變更、2.刷新表單上的採購單資訊（採購單號、供應商、統編等一大堆）、3.讀取現在這筆採購單的明細，並顯示在datagridview中。

            revertUnsavedChange();//1.還原未儲存的變更


            //2.刷新表單上的採購單資訊

            //2.1 如果有按上一筆或下一筆的話，this.currentIndex的值就會改變，應此需要更新現在要顯示在表單上的採購單（this.currentPurchase）
            this.currentPurchase = (from p in this.purchases
                                    where p.PurchaseID == this.selectedPurchaseID[currentIndex]
                                    select p).FirstOrDefault();


            //2.2 把現在要顯示的採購單藏在新的PurchaseItem物件
            var purchaseItem = new PurchaseItem() { _p = this.currentPurchase };
            purchaseItem.SupplierName = purchaseItem._p.Customer.Name;
            purchaseItem.ContactPerson = purchaseItem._p.Customer.ContactPerson;
            purchaseItem.ContactCellPhone = purchaseItem._p.Customer.ContactCellPhone;
            purchaseItem.Unicode = purchaseItem._p.Customer.Unicode;
            purchaseItem.Address = purchaseItem._p.Customer.Address;
            purchaseItem.PurchaserEmp = (from emp in this.db.Employees
                                         where emp.EmployeeID == this.currentPurchase.PurchaserEmpID
                                         select emp.Name).FirstOrDefault();
            purchaseItem.TallyEmp = (from emp in this.db.Employees
                                     where emp.EmployeeID == this.currentPurchase.TallyEmpID
                                     select emp.Name).FirstOrDefault();
            this.bs.DataSource = purchaseItem; //把this.bs的資料來源綁定為新的PurchaseItem物件


            ////////////////////關鍵！！雖然已經把this.bs的資料來源設定為新的要顯示的PurchaseItem物件了，但bindingsource的規矩就是要再呼叫這個方法來更新所有和bindingsource綁定的控制項
            this.bs.ResetBindings(false);


            //2.3 刷新右上角的listbox
            this.lbSelectedPurchase.SelectedIndex = currentIndex;

            //3.讀取現在這筆採購單的明細，儲存在this.detailItems中，並重新綁定this.viewBs的資料來源（reloadDataGridView）
            this.detailItems = (from pd in this.db.PurchaseDetails.AsEnumerable()
                                where pd.PurchaseID == this.currentPurchase.PurchaseID
                                select new PurchaseDetailItem()
                                {
                                    _pd = pd,
                                    項次 = 0,
                                    小計 = pd.Qty * pd.UnitPrice,
                                }).ToList();
            PurchaseDetailItem.serialNo = 0; 
            reloadDataGridView();
        } //刷新表單上的所有資訊（包含datagridview）
        private void reloadDataGridView()
        {
            //重新綁定this.viewBs的資料來源為this.detailItems當中處於新增、修改和未變動的採購明細（不包含要刪除的採購明細）
            this.viewBs.DataSource = (from item in this.detailItems
                                      where this.db.Entry(item._pd).State == EntityState.Added
                                      || this.db.Entry(item._pd).State == EntityState.Modified
                                      || this.db.Entry(item._pd).State == EntityState.Unchanged
                                      select item).ToList();
            this.viewBs.ResetBindings(false); //呼叫this.viewBs.ResetBindings來更新datagridview
        } //僅刷新datagridview上的資訊
        private void revertUnsavedChange()
        {
            //針對採購單的部分，如果是新增中的採購單未儲存，則將其狀態改為Detached；如果是修改中的採購單未儲存
            if (this.db.Entry(this.currentPurchase).State == EntityState.Added)
            {
                this.db.Entry(this.currentPurchase).State = EntityState.Detached;
            }
            else if (this.db.Entry(this.currentPurchase).State == EntityState.Modified)
            {
                this.db.Entry(this.currentPurchase).Reload();
            }

            //針對採購明細的部分，如果是新增中，則改為Detached；如果是修改中則用Reload()還原為原本的值；如果是原本有的明細被刪除但還沒按儲存的話，也用Reload()還原為未變動的狀態
            foreach (var item in this.detailItems)
            {
                if (this.db.Entry(item._pd).State == EntityState.Added)
                {
                    this.db.Entry(item._pd).State = EntityState.Detached;
                }
                else if (this.db.Entry(item._pd).State == EntityState.Modified)
                {
                    this.db.Entry(item._pd).Reload();
                }
                else if (this.db.Entry(item._pd).State == EntityState.Deleted)
                {
                    this.db.Entry(item._pd).Reload();
                }
            }
            this.btnAddPurchase.Enabled = true;
        } //還原未儲存之變更
        private void addPurchase(object sender, EventArgs e)
        {
            this.mode = SaveMode.AddPurchase;
            this.btnAddPurchase.Enabled = false;
            this.btnSearch.Enabled = false;
            
            var newPurchase = this.db.Set<Purchase>().Create();
            this.currentPurchase = newPurchase;
            var newPurchaseItem = new PurchaseItem();
            newPurchaseItem._p = newPurchase;
            newPurchaseItem.PurchaseDate = DateTime.Now;
            newPurchaseItem.SupplierID = 1;
            newPurchaseItem.PurchaserEmpID = 1;
            newPurchaseItem.RequiredDate = DateTime.Now;
            newPurchaseItem.TallyEmpID = 1;
            this.db.Set<Purchase>().Add(newPurchase);

            this.bs.DataSource = newPurchaseItem;
            
            this.bs.ResetBindings(false);
            this.detailItems = new List<PurchaseDetailItem>();

            this.reloadDataGridView();
        } //新增採購單，會進入新增採購單模式
        private void searchPurchase(object sender, EventArgs a)
        {
            var f = new 採購單查詢頁面();
            var res = f.ShowDialog(this); //叫出採購單查詢頁面。f.ShowDialog(this)的this有給沒給都沒關係，到了addPurchaseDetail裡面再說明給this有什麼好處。
            if (res == DialogResult.OK)
            {
                this.selectedPurchaseID = f.purchaseID; //在採購單查詢頁面中勾選的採購單ID會記錄在f.purchaseID這個欄位中，在這裡把f.purchaseID傳到現在這個「採購表單」的this.selectedPurchaseID欄位。右上角的listBox、和其他需要用PurchaseID做為查詢條件的linq語句都很需this.selectedPurchaseID這個欄位（list）。
                this.lbSelectedPurchase.DataSource = this.selectedPurchaseID;//重新指定右上角listBox的資料來源，強迫他更新一下
                this.currentIndex = 0;//因為使用者已經勾選了他想查詢的採購單，因此現在表單要從他所勾選的採購單的第一項看起，因此把currentIndex設為0，表示從第一個項目開始，下面reload()的定義就會看到currentIndex到底是什麼意思
                this.reload();
            }
            f.Dispose(); //這個有沒有都沒關係
        } //勾選要查詢或修改的採購單
        private void save(object sender, EventArgs e)
        {

            ////Validate data before write into DB.
            this.db.SaveChanges();
            if (this.mode == SaveMode.AddPurchase)
            {
                this.purchases = (from p in this.db.Purchases
                                  select p).ToList();
                this.selectedPurchaseID = (from p in this.purchases
                                           select p.PurchaseID).ToList();
                this.lbSelectedPurchase.DataSource = this.selectedPurchaseID;
                this.lbSelectedPurchase.SelectedIndex = this.selectedPurchaseID.Count - 1;
                this.currentIndex = this.selectedPurchaseID.Count - 1;
            }
            else
            {

            }
            this.mode = SaveMode.EditPurchase;
            this.btnAddPurchase.Enabled = true;
            this.btnSearch.Enabled = true;
            this.reload();
        } //儲存採購單和採購單明細。新增採購單和修改採購單有些微不同，因此用this.mode來區分
        private void cancel(object sender, EventArgs e)
        {
            this.btnAddPurchase.Enabled = true;
            this.btnSearch.Enabled = true;
            this.reload();
        } //取消所做之任何未儲存之新增或修改，並刷新表單
        private void previousPurchase(object sender, EventArgs e)
        {
            if (this.selectedPurchaseID.Count == 0) return;
            if (this.currentIndex >= 1)
            {
                this.currentIndex -= 1;
                this.reload();
            }
        } //上一筆採購單（<）
        private void nextPurchase(object sender, EventArgs e)
        {
            if (this.selectedPurchaseID.Count == 0) return;
            if (this.currentIndex < this.selectedPurchaseID.Count - 1)
            {
                this.currentIndex += 1;
                this.reload();
            }
        } //下一筆採購單（>）
        private void jumpPurchase(object sender, EventArgs e)
        {
            this.currentIndex = (sender as ListBox).SelectedIndex;
            this.reload();
        } //按listbox上的項目可以跳轉到該採購單
        private void ChangeSupplier(object sender, EventArgs e)
        {
            (this.bs.DataSource as PurchaseItem).SupplierID = (int)((sender as ComboBox).SelectedValue);
            (this.bs.DataSource as PurchaseItem).SupplierName = (sender as ComboBox).Text;
            (this.bs.DataSource as PurchaseItem).ContactPerson = ((sender as ComboBox).SelectedItem as Customer).ContactPerson;
            (this.bs.DataSource as PurchaseItem).ContactCellPhone = ((sender as ComboBox).SelectedItem as Customer).ContactCellPhone;
            (this.bs.DataSource as PurchaseItem).Address = ((sender as ComboBox).SelectedItem as Customer).Address;
            (this.bs.DataSource as PurchaseItem).Unicode = ((sender as ComboBox).SelectedItem as Customer).Unicode;

            this.bs.ResetBindings(false);
        } //選擇供應商後連帶改變供應商的其他資料（編號、聯絡人、電話、地址和統編）

        //////選擇採購人員和理貨人員連帶改變人員編號
        private void ChangePurchaserEmp(object sender, EventArgs e)
        {
            (this.bs.DataSource as PurchaseItem).PurchaserEmpID = (int)((sender as ComboBox).SelectedValue);
            (this.bs.DataSource as PurchaseItem).PurchaserEmp = (sender as ComboBox).Text;
            this.bs.ResetBindings(false);
        }
        private void ChangeTallyEmp(object sender, EventArgs e)
        {

            (this.bs.DataSource as PurchaseItem).TallyEmpID = (int)((sender as ComboBox).SelectedValue);
            (this.bs.DataSource as PurchaseItem).TallyEmp = (sender as ComboBox).Text;
            this.bs.ResetBindings(false);
        }
        //////

        private void addPurchaseDetail(object sender, EventArgs e)
        {
            var f = new 新增採購品項(this.selectedPurchaseID[currentIndex]);
            var res = f.ShowDialog(this);
            if (res == DialogResult.OK)
            {
                PurchaseDetailItem.serialNo = this.detailItems.Count;
                var addedItem = new PurchaseDetailItem();
                addedItem._pd = this.db.Set<PurchaseDetail>().Create();
                addedItem.PurchaseID = this.currentPurchase.PurchaseID;
                addedItem._pd.ProductCode = f.ProductCode;
                addedItem.數量 = f.Qty;
                addedItem.價格 = f.UnitPirce;
                addedItem._pd.Unit = f.Unit;
                addedItem.小計 = f.Total;
                addedItem.備註 = f.Comment;
                addedItem.項次 = 0;
                PurchaseDetailItem.serialNo = 0;
                this.db.PurchaseDetails.Add(addedItem._pd);
                this.detailItems.Add(addedItem);
                this.reloadDataGridView();
            }
            f.Dispose();
        } //新增品項並刷新datagridview，需要按儲存才會寫入DB
        private void delPurchaseDetail(object sender, EventArgs e)
        {
            var selectRowIndex = new List<int>();
            foreach (DataGridViewCell cell in this.dataGridView1.SelectedCells)
            {
                if (!selectRowIndex.Contains(cell.RowIndex))
                {
                    selectRowIndex.Add(cell.RowIndex);
                }
            }
            var items = this.viewBs.DataSource as List<PurchaseDetailItem>;
            foreach (int i in selectRowIndex)
            {
                if (this.db.Entry(items[i]._pd).State == EntityState.Added)
                {
                    this.db.Entry(items[i]._pd).State = EntityState.Detached;
                }
                else
                {
                    this.db.Entry(items[i]._pd).State = EntityState.Deleted;
                }
            }
            reloadDataGridView();
        } //刪除品項並刷新datagridview，需要按儲存才會寫入DB

        //////在datagridview上編輯數量和價格時，自動計算小計
        private void DataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (this.rowEditing) return;

            this.rowEditing = true;
            
            var selectedRow = this.dataGridView1.Rows[e.RowIndex];
            decimal price;
            decimal qty;
            if (e.ColumnIndex == 3)
            {
                if (!decimal.TryParse(e.FormattedValue.ToString(), out price))
                {
                    e.Cancel = true;
                    this.rowEditing = false;
                    return;
                }
                selectedRow.Cells[3].Value = (decimal.Parse(e.FormattedValue.ToString()));
                selectedRow.Cells[6].Value = (decimal.Parse(e.FormattedValue.ToString())) * (decimal.Parse(selectedRow.Cells[4].Value.ToString()));
                
            }
            else if (e.ColumnIndex == 4)
            {
                if (!decimal.TryParse(e.FormattedValue.ToString(), out qty))
                {
                    e.Cancel = true;
                    this.rowEditing = false;
                    return;
                }
                selectedRow.Cells[4].Value = (decimal.Parse(e.FormattedValue.ToString()));
                selectedRow.Cells[6].Value = (decimal.Parse(e.FormattedValue.ToString())) * (decimal.Parse(selectedRow.Cells[3].Value.ToString()));                
            }            
            this.rowEditing = false;
        }

        private void 採購表單_MouseClick(object sender, MouseEventArgs e)
        {

            var currentPurchase = (this.bs.DataSource as PurchaseItem)._p;
            Console.WriteLine("Purchase:");
            Console.WriteLine(currentPurchase.PurchaseID);
            Console.WriteLine(this.db.Entry(currentPurchase).State);
            Console.WriteLine("============");
            Console.WriteLine("Purchase Details:");
            foreach (var item in this.detailItems)
            {
                Console.WriteLine(item._purchaseDetailID);
                Console.WriteLine(this.db.Entry(item._pd).State);
            }
            Console.WriteLine("============");
        } //於主控台上顯示目前採購單的ID與Entity.State和其採購明細的ID與Entity.State
    }

    public class PurchaseItem
    {
        public Purchase _p;
        public int PurchaseID
        {
            get { return this._p.PurchaseID; }
            set { this._p.PurchaseID = value; }
        }
        public DateTime PurchaseDate
        {
            get { return this._p.PurchaseDate.GetValueOrDefault(); }
            set { this._p.PurchaseDate = value; }
        }
        public string SupplierName { get; set; }
        public int SupplierID
        {
            get { return this._p.SupplierID.GetValueOrDefault(); }
            set { this._p.SupplierID = value; }
        }
        public string ContactPerson { get; set; }
        public string ContactCellPhone { get; set; }
        public string Unicode { get; set; }
        public string Address { get; set; }
        public string PurchaserEmp { get; set; }
        public int PurchaserEmpID
        {
            get { return this._p.PurchaserEmpID.GetValueOrDefault(); }
            set { this._p.PurchaserEmpID = value; }

        }
        public string TallyEmp { get; set; }
        public int TallyEmpID 
        {
            get { return this._p.TallyEmpID.GetValueOrDefault(); }
            set { this._p.TallyEmpID = value; }
        }
        public string Deliveryaddress
        {
            get { return this._p.Deliveryaddress; }
            set { this._p.Deliveryaddress = value; }
        }
        public DateTime RequiredDate {
            get { return this._p.RequiredDate.GetValueOrDefault(); }
            set { this._p.RequiredDate = value; } 
        }
        public string Comment 
        {
            get { return this._p.Comment; }
            set { this._p.Comment = value; }
        }
    } //為了符合表單所要呈現出的資訊而自定義的class，內藏採購單的entity物件

    public class PurchaseDetailItem
    {
        public static int serialNo = 0;
        private int _項次 = 0;
        public PurchaseDetail _pd;

        internal int _purchaseDetailID
        {
            get { return this._pd.PurchaseDetailID; }
        }
        internal int PurchaseID
        {
            get { return this._pd.PurchaseID; }
            set { this._pd.PurchaseID = value; }
        }
        public int 項次
        {
            get { return this._項次; }
            set { this._項次 = PurchaseDetailItem.serialNo; }
        }
        public string 料號
        {
            get { return this._pd.ProductCode; }
            internal set { this._pd.ProductCode = value; }
        }
        public string 品名
        {
            get { return this._pd.Product.Name; }
        }
        public decimal 價格
        {
            get { return this._pd.UnitPrice; }
            set { this._pd.UnitPrice = value; }
        }
        public decimal 數量
        {
            get { return this._pd.Qty; }
            set { this._pd.Qty = value; }
        }
        public string 單位
        {
            get { return this._pd.Product.Unit; }
        }
        public decimal 小計 { get; set; }

        public string 備註
        {
            get { return this._pd.Comment; }
            set { this._pd.Comment = value; }
        }
        //public EntityState State = EntityState.Unchanged;
        public PurchaseDetailItem()
        {
            PurchaseDetailItem.serialNo += 1;
        }

    } //為了符合datagridview所要呈現出的資訊而自定義的class，內藏採購單明細的entity物件

    public enum SaveMode
    {
        EditPurchase = 0,
        AddPurchase = 1
    }  //用來區分現在是新增採購單或是修改修改採購單與明細
}
