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
    
    public partial class LapTop
    {
        public string MD_ { get; set; }
        public string CDPlayer { get; set; }
        public string Adapter { get; set; }
        public string Port { get; set; }
        public string Webcam { get; set; }
        public string CpuName { get; set; }
        public string CPUManuName { get; set; }
        public string InPort { get; set; }
    
        public virtual MobileDevice MobileDevice { get; set; }
        public virtual x86CPU x86CPU { get; set; }
    }
}
