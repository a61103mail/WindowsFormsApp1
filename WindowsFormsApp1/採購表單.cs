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
        private List<Purchase> purchases; //先宣告採購單清單，等等要預先把所有採購單存進來，加快表單的反應速度
        private int currentIndex = 0; //這個欄位是指現在表單上顯示的是第幾筆採購單，預設為0
        private List<GridViewItem> viewItems = new List<GridViewItem>(); //這個欄位是用來裝目前所顯示的採購單的所有採購明細，GridViewItem是自定義的class，請見最末
        private List<int> selectedPurchaseID ; //這個欄位是要紀錄從採購單查詢頁面傳回來的（使用者勾選的）所有採購單ID
        public List<Product_LatestPrice> product_LatestPrices; //先宣告這個欄位，等等要裝最新產品價格，目的是為了要加快產品價格的查詢和採購單查詢頁面的讀取速度
        private BindingSource bs = new BindingSource(); //這個BindingSource是用來繫結表單上面的採購單號、供應商、統編等控制項
        private BindingList<GridViewItem> viewItemBs = new BindingList<GridViewItem>(); //這個BindingSource是用來繫結datagridview用的
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

            //表單一開起來就要先顯示出第一筆採購單（也可以不要，看你想怎麼做）

            //先設定this.bs的資料來源為第一筆採購單和一些關連出來的資料（最前面已經把currentIndex設為0了）
            var 現在要顯示的採購單 = this.purchases[currentIndex];  //this.purchases[0]
            this.bs.DataSource = new //匿名型別物件(*)
            {
                現在要顯示的採購單.PurchaseID,  //屬性 PurchaseID
                現在要顯示的採購單.PurchaseDate, //屬性 PurchaseDate
                現在要顯示的採購單.Customer.Name, //屬性 Name
                現在要顯示的採購單.SupplierID, //...
                現在要顯示的採購單.Customer.ContactPerson, //...
                現在要顯示的採購單.Customer.ContactCellPhone,
                現在要顯示的採購單.Customer.Unicode,
                現在要顯示的採購單.Customer.Address,
                Purchaser = (from emp in this.db.Employees
                             where emp.EmployeeID == 現在要顯示的採購單.PurchaserEmpID
                             select emp.Name).FirstOrDefault(),  //屬性Purchaser
                現在要顯示的採購單.PurchaserEmpID, //屬性PurchaserEmpID
                TallyEmp = (from emp in this.db.Employees
                            where emp.EmployeeID == 現在要顯示的採購單.TallyEmpID
                            select emp.Name).FirstOrDefault(), //屬性TallyEmp
                現在要顯示的採購單.TallyEmpID,
                現在要顯示的採購單.Deliveryaddress,
                現在要顯示的採購單.RequiredDate,
                現在要顯示的採購單.Comment
            };

            //然後再綁定label4（要顯示採購單號的那個label）的Text屬性值等於bs的PurchaseID的值，等等在reload()裡面就會看到"綁定"到底是什麼意思
            this.label4.DataBindings.Add(new Binding("Text", this.bs, "PurchaseID"));
            //綁定dateTimePicker1（採購日期）的Value屬性值等於bs的PurchaseDate的值，等等在reload()裡面就會看到"綁定"到底是什麼意思...
            this.dateTimePicker1.DataBindings.Add(new Binding("Value", this.bs, "PurchaseDate"));
            //綁定this.textBox1（供應商名稱）的Text屬性值等於bs的Name的值，等等在reload()裡面就會看到"綁定"到底是什麼意思...
            this.textBox1.DataBindings.Add(new Binding("Text", this.bs, "Name"));
            this.label12.DataBindings.Add(new Binding("Text",this.bs, "SupplierID"));
            this.textBox3.DataBindings.Add(new Binding("Text", this.bs, "ContactPerson"));
            this.textBox4.DataBindings.Add(new Binding("Text", this.bs, "ContactCellPhone"));
            this.textBox2.DataBindings.Add(new Binding("Text", this.bs, "Unicode"));
            this.textBox5.DataBindings.Add(new Binding("Text", this.bs, "Address"));
            this.comboBox1.DataBindings.Add(new Binding("Text", this.bs, "Purchaser"));
            this.label18.DataBindings.Add(new Binding("Text", this.bs, "PurchaserEmpID"));
            this.comboBox2.DataBindings.Add(new Binding("Text", this.bs, "TallyEmp"));
            this.label19.DataBindings.Add(new Binding("Text", this.bs, "TallyEmpID"));
            this.textBox6.DataBindings.Add(new Binding("Text", this.bs, "Deliveryaddress"));
            this.dateTimePicker2.DataBindings.Add(new Binding("Value", this.bs, "RequiredDate"));
            this.richTextBox1.DataBindings.Add(new Binding("Text", this.bs, "Comment"));
            //思考一下，到底bs是什麼？
            //雖然bs仍然是一個BindingSource物件，但它其實代表了那個匿名型別物件(*)
            //那個個匿名型別物件裡面有的屬性包含了PurchaseID、PurchaseDate、Name......等一堆屬性
            //只要這個匿名型別物件的屬性值有變動，就可以利用BindingSource一口氣全部跟著連動改變，等等在reload()裡面就會看到要怎麼做了。


            //表單中的listBox1是我加上去的，可以看到說現在被圈選出來的採購單有哪幾筆。那因為現在是表單剛開起來的時候，因此我先預設圈選出所有採購單
            //DataSource是資料來源的意思，也就是說，這個listBox裡面的項目來自於this.selectedPurchaseID。在建構子當中我先預設把所有採購單的ID都放到了this.selectedPurchaseID中。
            this.listBox1.DataSource = this.selectedPurchaseID;

            //接下來，因為datagridview要顯示出的欄位有項次、料號、品名等8個欄位，和我們資料庫中PurchaseDetail的欄位不一致，因此我們要為了這個datagridview來定義一個class，如最末的GridViewItem，這樣等等用bindingsource才能抓到這些欄位並顯示在datagridview中
            //因為PurchaseDetail會頻繁的改動，因此就不要先撈進記憶體了
            //此外，因為要在表單一出現時就找出第一筆採購單，"並在datagridview中列出第一筆採購單的所有名細"，因此要先以第一筆採購單的PurchaseID來找出他的所有名細，並以GridViewItem的型別放進this.viewItems這個欄位（list）中
            this.viewItems = (from pd in this.db.PurchaseDetails.AsEnumerable()
                              where pd.PurchaseID == this.purchases[0].PurchaseID
                              //或 where pd.PurchaseID == this.purchases[currentIndex].PurchaseID //現在currentIndex還是0哦！
                              //或 where pd.PurchaseID == this.selectedPurchaseID[currentIndex] //現在currentIndex還是0哦！
                              //或 where pd.PurchaseID == this.selectedPurchaseID[0]
                              select new GridViewItem()
                              {
                                  _purchaseDetail = pd,
                                  _purchaseDetailID = pd.PurchaseDetailID,
                                  項次 = 0, //這個是為了要製造出項次會1234的效果，說明起來有點麻煩，就略過囉！
                                  價格 = pd.UnitPrice,
                                  數量 = pd.Qty,
                                  小計 = pd.Qty * pd.UnitPrice,
                                  備註 = pd.Comment                                  
                              }).ToList();
            GridViewItem.serialNo = 0; //這個是為了要製造出項次會自動1234的效果，說明起來有點麻煩，就略過囉！

            this.viewItemBs = new BindingList<GridViewItem>(this.viewItems.Where((item)=> {
                return (item.State != EntityState.Detached && item.State != EntityState.Deleted);
                }).ToList());            
            this.dataGridView1.DataSource = this.viewItemBs;            

            this.dataGridView1.AllowUserToAddRows = false;  //把datagridview自動產生的最後一列空白列關掉
            this.dataGridView1.Columns["項次"].ReadOnly = true; //關閉項次欄位的編輯功能
            this.dataGridView1.Columns["料號"].ReadOnly = true; //關閉料號欄位的編輯功能
            this.dataGridView1.Columns["品名"].ReadOnly = true; //關閉品名欄位的編輯功能
            this.dataGridView1.Columns["單位"].ReadOnly = true; //關閉單位欄位的編輯功能
            this.dataGridView1.Columns["小計"].ReadOnly = true; //關閉小計欄位的編輯功能

            this.button3.Click += this.searchPurchase;  //按下button3（搜尋）會開啟採購單查詢頁面
            this.button5.Click += this.previousPurchase; //按下button5（<）會跳到上一筆採購單，如果現在是第一筆，就不跳
            this.button6.Click += this.nextPurchase; //按下button6（>）會跳到下一筆採購單，如果現在是最後一筆，就不跳
            this.button11.Click += this.addPurchaseDetail; //按下button11（新增品項）會開啟新增採購品項表單
            this.button12.Click += this.delPurchaseDetail;
            this.button9.Click += this.saveEdit;
            this.button2.Click += Button2_Click;
            this.dataGridView1.CellValidating += DataGridView1_CellValidating; //在datagridview中編輯格子中（cell）的內容後會觸發DataGridView1_CellValidating

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            
        }

        private void searchPurchase(object sender, EventArgs a)
        {
            var f = new 採購單查詢頁面();
            var res = f.ShowDialog(this); //叫出採購單查詢頁面。f.ShowDialog(this)的this有給沒給都沒關係，到了addPurchaseDetail裡面再說明給this有什麼好處。
            if (res == DialogResult.OK)
            {
                this.selectedPurchaseID = f.purchaseID; //在採購單查詢頁面中勾選的採購單ID會記錄在f.purchaseID這個欄位中，在這裡把f.purchaseID傳到現在這個「採購表單」的this.selectedPurchaseID欄位。右上角的listBox、和其他需要用PurchaseID做為查詢條件的linq語句都很需this.selectedPurchaseID這個欄位（list）。
                this.listBox1.DataSource = this.selectedPurchaseID;//重新指定右上角listBox的資料來源，強迫他更新一下
                this.currentIndex = 0;//因為使用者已經勾選了他想查詢的採購單，因此現在表單要從他所勾選的採購單的第一項看起，因此把currentIndex設為0，表示從第一個項目開始，下面reload()的定義就會看到currentIndex到底是什麼意思
                this.reload();
            }
            f.Dispose(); //這個有沒有都沒關係
        }
        private void reload()
        {
            //reload()要做的事情有：1.刷新表單上的採購單資訊（採購單號、供應商、統編等一大堆）、2.刷新右上角的listbox、3.讀取現在這筆採購單的明細，並顯示在datagridview中。

            //1.刷新表單上的採購單資訊
            //原本在 採購表單_Load 中先設定了this.bs的資料來源為第一筆採購單和一些關連出來的資料
            //不過，在使用者於採購單查詢頁面勾選採購單並按確定後，要顯示的採購單應該會有所變動
            //那現在到底要顯示出哪筆採購單資訊呢？

            //如果是從上面的searchPurchase來呼叫到reload()的話，那要顯示的採購單資訊就會是使用者勾選出的採購單（this.selectedPurchaseID）的第一筆（在上面的searchPurchase已經把currentIndex歸0了！）
            //記不記得在建構子當中已經用this.purchases來存放了「所有的採購單」？
            //所以現在要做的事情是，找出「使用者勾選出的採購單」的第一筆（this.selectedPurchaseID[currentIndex]）到底是哪筆採購單
            //下面的linq語句就是在找「使用者勾選出的採購單」的第一筆（this.selectedPurchaseID[currentIndex]）到底是哪筆採購單

            //如果是從下面的previousPurchase或是nextPurchase來呼叫到reload()的話，則是要查詢當前的採購單的上一筆或下一筆採購單是誰，一樣是利用this.selectedPurchaseID[currentIndex]來當做查詢條件從this.purchases來找出我們接下來要顯示的採購單
            var 現在要顯示的採購單 = (from p in this.purchases
                             where p.PurchaseID == this.selectedPurchaseID[currentIndex]  //this.selectedPurchaseID[currentIndex]就是查詢條件
                             select p).FirstOrDefault();  //FirstOrDefault()是指說，如果這個linq有查詢到一個或一個以上的結果，那就只回傳第一個結果。如果這個linq沒有查到任何結果，那就回傳null（如果預期結果值是物件）或0（如果預期結果值是int）或空字串（如果預期結果值是string）...

            //在查到要顯示的採購單後，再次指定this.bs的資料來源為新的這個要顯示的採購單和關連出的資訊
            this.bs.DataSource = new //匿名型別物件(*)
            {
                現在要顯示的採購單.PurchaseID,
                現在要顯示的採購單.PurchaseDate,
                現在要顯示的採購單.Customer.Name,
                現在要顯示的採購單.SupplierID,
                現在要顯示的採購單.Customer.ContactPerson,
                現在要顯示的採購單.Customer.ContactCellPhone,
                現在要顯示的採購單.Customer.Unicode,
                現在要顯示的採購單.Customer.Address,
                Purchaser = (from emp in this.db.Employees
                             where emp.EmployeeID == 現在要顯示的採購單.PurchaserEmpID
                             select emp.Name).FirstOrDefault(),
                現在要顯示的採購單.PurchaserEmpID,
                TallyEmp = (from emp in this.db.Employees
                            where emp.EmployeeID == 現在要顯示的採購單.TallyEmpID
                            select emp.Name).FirstOrDefault(),
                現在要顯示的採購單.TallyEmpID,
                現在要顯示的採購單.Deliveryaddress,
                現在要顯示的採購單.RequiredDate,
                現在要顯示的採購單.Comment
            };


            ////////////////////關鍵！！雖然已經把this.bs的資料來源設定為新的要顯示的採購單（匿名型別物件）了，但bindingsource的規矩就是要再呼叫這個方法來更新所有和bindingsource綁定的控制項（this.label4、this.dateTimePicker1、this.textBox1 ... 等這一堆的控制項）
            this.bs.ResetBindings(false);


            //2.刷新右上角的listbox
            //不太重要，就不多做說明了
            this.listBox1.SelectedIndex = currentIndex;

            //3.讀取現在這筆採購單的明細，並顯示在datagridview中
            //等於是把 採購表單_Load 中
            this.viewItems = (from pd in this.db.PurchaseDetails.AsEnumerable()
                              where pd.PurchaseID == this.selectedPurchaseID[currentIndex]
                              select new GridViewItem()
                              {
                                  _purchaseDetail = pd,
                                  _purchaseDetailID = pd.PurchaseDetailID,                                  
                                  項次 = 0, //這個是為了要製造出項次會1234的效果，說明起來有點麻煩，就略過囉！
                                  價格 = pd.UnitPrice,
                                  數量 = pd.Qty,
                                  小計 = pd.Qty * pd.UnitPrice,
                                  備註 = pd.Comment
                              }).ToList();
            
            GridViewItem.serialNo = 0; //這個是為了要製造出項次會1234的效果，說明起來有點麻煩，就略過囉！            

            this.viewItemBs = new BindingList<GridViewItem>(this.viewItems.Where((item) =>
            {
                return (item.State != EntityState.Detached && item.State != EntityState.Deleted);
            }).ToList());
            this.viewItemBs.ResetBindings();
        }

        private void previousPurchase(object sender, EventArgs e)
        {
            if (this.selectedPurchaseID.Count == 0) return;
            if (this.currentIndex >= 1)
            {
                this.currentIndex -= 1;
                this.reload();
            }
        }

        private void nextPurchase(object sender, EventArgs e)
        {
            if (this.selectedPurchaseID.Count == 0) return;
            if (this.currentIndex < this.selectedPurchaseID.Count - 1)
            {
                this.currentIndex += 1;
                this.reload();
            }
        }
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
        private void addPurchaseDetail(object sender, EventArgs e)
        {
            var f = new 新增採購品項(this.selectedPurchaseID[currentIndex]);
            var res = f.ShowDialog(this);
            if (res == DialogResult.OK)
            {
                GridViewItem.serialNo = this.viewItems.Count;
                var addedItem = new GridViewItem();
                addedItem._purchaseDetail = this.db.Set<PurchaseDetail>().Create();
                addedItem._purchaseDetail.PurchaseID = this.selectedPurchaseID[currentIndex];
                addedItem._purchaseDetailID = -1;
                addedItem._purchaseDetail.ProductCode = f.ProductCode;
                addedItem._purchaseDetail.Qty = f.Qty;
                addedItem._purchaseDetail.UnitPrice = f.UnitPirce;
                addedItem._purchaseDetail.Unit = f.Unit;
                addedItem._purchaseDetail.Comment = f.Comment;
                addedItem.項次 = 0;
                addedItem.State = EntityState.Added;
                GridViewItem.serialNo = 0;
                this.db.PurchaseDetails.Attach(addedItem._purchaseDetail);
                this.viewItems.Add(addedItem);
                this.viewItemBs.Add(addedItem);
                this.viewItemBs.ResetBindings();
            }
            f.Dispose();
        }
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
            foreach (int i in selectRowIndex)
            {
                            
            }

            
        }

        private void saveEdit(object sender, EventArgs e)
        {
            this.db.SaveChanges();
        }
        
    }

    public class GridViewItem
    {
        public static int serialNo = 0;
        private int _項次 = 0;
        public int _purchaseDetailID = -1;
        public PurchaseDetail _purchaseDetail;

        internal int PurchaseID
        {
            get
            {
                return this._purchaseDetail.PurchaseID;
            }
        }
        public int 項次
        {
            get
            {
                return this._項次;
            }
            set
            {
                this._項次 = GridViewItem.serialNo;
            }
        }
        public string 料號 
        {
            get
            {
                return this._purchaseDetail.ProductCode;
            }
        }
        public string 品名
        {
            get
            {
                return this._purchaseDetail.Product.Name;
            }
        }
        public decimal 價格 
        {
            get
            {
                return this._purchaseDetail.UnitPrice;
            }
            set
            {
                this._purchaseDetail.UnitPrice = value;
            }
        }
        public decimal 數量 
        {
            get
            {
                return this._purchaseDetail.Qty;
            }
            set
            {
                this._purchaseDetail.Qty = value;
            }
        }
        public string 單位
        {
            get
            {
                return this._purchaseDetail.Product.Unit;
            }
        }
        public decimal 小計 { get; set; }
        public string 備註 
        {
            get
            {
                return this._purchaseDetail.Comment;
            }
            set
            {
                this._purchaseDetail.Comment = value;
            }
        }
        public EntityState State = EntityState.Unchanged;
        public GridViewItem()
        {
            GridViewItem.serialNo += 1;
        }
        
    }
}
