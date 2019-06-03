using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVC.Models.ViewModels
{
    public class ProductBlockViewModel
    {
        public IEnumerable<MobileDevice> MobileDevice { get; set; }
        public IEnumerable<LapTop> LapTop { get; set; }
        public IEnumerable<GPU> GPU { get; set; }
    }
}