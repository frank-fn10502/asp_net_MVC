//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Screen
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Screen()
        {
            this.MobileDevice = new HashSet<MobileDevice>();
        }
    
        public string Screen_ { get; set; }
        public string Resulation { get; set; }
        public string Reflash { get; set; }
        public string SRGB { get; set; }
        public string SType { get; set; }
        public string Size { get; set; }
        public string HDR { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MobileDevice> MobileDevice { get; set; }
    }
}