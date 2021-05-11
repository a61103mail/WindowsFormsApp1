//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace WindowsFormsApp1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Purchase
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Purchase()
        {
            this.PurchaseConfirmedDetails = new HashSet<PurchaseConfirmedDetail>();
            this.PurchaseDetails = new HashSet<PurchaseDetail>();
        }
    
        public int PurchaseID { get; set; }
        public Nullable<System.DateTime> PurchaseDate { get; set; }
        public Nullable<int> SupplierID { get; set; }
        public Nullable<int> PurchaserEmpID { get; set; }
        public string Deliveryaddress { get; set; }
        public string Comment { get; set; }
        public Nullable<short> PurchaseStatus { get; set; }
        public Nullable<System.DateTime> RequiredDate { get; set; }
        public Nullable<int> TallyEmpID { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Employee Employee1 { get; set; }
        public virtual StatusList StatusList { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseConfirmedDetail> PurchaseConfirmedDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseDetail> PurchaseDetails { get; set; }
    }
}
