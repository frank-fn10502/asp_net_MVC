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
    
    public partial class LapTopGpu
    {
        public string MD_ { get; set; }
        public string Gpu_ { get; set; }
        public int GpuNum { get; set; }
    
        public virtual GPU GPU { get; set; }
        public virtual MobileDevice MobileDevice { get; set; }
    }
}
