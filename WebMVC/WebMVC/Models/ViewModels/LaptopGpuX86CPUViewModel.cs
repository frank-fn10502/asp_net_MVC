using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVC.Models.ViewModels
{
    public class LaptopGpuX86CPUViewModel : ProductBlockViewModel
    {
        public IEnumerable<Manufacture>  Manufacture  { get; set; }
    }
}