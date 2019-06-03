using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVC.Models.ViewModels
{
    public class MoblieDeviceBrowsingViewModel : ProductBlockViewModel
    {
        public static String[] ulTitleStr  = new String[] 
                                            {"廠商" ,"價格" ,"中央處理器(Cpu)" ,"顯示卡(Gpu)" 
                                            ,"記憶體(Ram)" ,"固態硬碟(SSD)" ,"傳統硬碟(HDD)：2.5吋"};

        public static String[] SQLSelector  = new String[] 
                                            {"MobileDevice.ManuName = " ,"SMD.SMDPrice = " ,"LapTop.CpuName = " ,"GPU.GPUName = " 
                                            ,"MobileDevice.Ram = " ,"Storage.Storage# = " ,"Storage.Storage# = "};

        public int pageProductNum   = 12;

        public IEnumerable<Manufacture> ManufactureSelector { get; set; }
        //價錢(用輸入去查詢)
        public IEnumerable<x86CPU> X86CPUSelector    { get; set; }
        public IEnumerable<GPU> GPUSelector    { get; set; }
        public IEnumerable<String> RamSelector { get; set; }
        public IEnumerable<Storage> SSDSelector { get; set; }
        public IEnumerable<Storage> HDDSelector { get; set; }
    }
}