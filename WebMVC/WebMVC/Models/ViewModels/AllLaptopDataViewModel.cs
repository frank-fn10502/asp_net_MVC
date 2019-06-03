using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVC.Models.ViewModels
{
    public class AllLaptopDataViewModel
    {
        private DetailStr detailStr;
        
        public MobileDevice MobileDevice { get; set; }
        public LapTop LapTop { get; set; }
        public x86CPU x86CPU { get; set; }
        public GPU GPU { get; set; }
        public IEnumerable<Storage> Storage { get; set; }
        public Screen Screen { get; set; }
        public Manufacture  Manufacture  { get; set; }

        public IEnumerable<MobileDeviceCC> MobileDeviceCC { get; set; }
        public IEnumerable<MobileDeviceColor> MobileDeviceColor { get; set; }
        public IEnumerable<MobileDeviceMutimedia> MobileDeviceMutimedia { get; set; }
        public IEnumerable<MobileDeviceOther> MobileDeviceOther { get; set; }
        public IEnumerable<MobileDeviceReview> MobileDeviceReview { get; set; }

        public IEnumerable<SMD> SMD { get; set; }

        public void setDetail()
        {
           detailStr = new DetailStr(this);
        }
        public DetailStr getDetail()
        {
            return detailStr;
        }
        public class DetailStr
        {
            public int simpleDetailItemNum;
            public String[] simpleDetailStr;
            private String[] simpleDetailTitle = { "處理器(CPU)" ,"顯示卡(GPU)" ,"記憶體(RAM)" ,"硬碟" 
                                                 , "光碟機" ,"作業系統" ,"保固" ,"電池" ,"螢幕" ,"尺寸" ,"重量" };

            public int fullDetailItemNum;
            public String[] fullDetailStr;
            public String[] fullDetailTitle = { "處理器(CPU)" ,"顯示卡(GPU)" ,"記憶體(RAM)" ,"硬碟" 
                                              , "光碟機" ,"作業系統" ,"保固" ,"電池" 
                                              , "變壓器" ,"螢幕" ,"尺寸" ,"重量" 
                                              , "連接埠", "視訊鏡頭" ,"擴充插槽" ,"通訊介面" ,"顏色" ,"多媒體" ,"其他"};
            public DetailStr(AllLaptopDataViewModel laptopData)
            {
                simpleDetailItemNum = simpleDetailTitle.Length;
                setSimpleDetailStr(laptopData);

                fullDetailItemNum = fullDetailTitle.Length;
                setFullDetailStr(laptopData);
            }
            private void setSimpleDetailStr(AllLaptopDataViewModel laptopData)
            {
                simpleDetailStr = new String[simpleDetailItemNum];
                simpleDetailStr[0] = simpleDetailTitle[0] + ": " + laptopData.LapTop.CpuName;
                simpleDetailStr[1] = simpleDetailTitle[1] + ": " + laptopData.GPU.GPUName + " | " + laptopData.GPU.MemoryConfig;
                simpleDetailStr[2] = simpleDetailTitle[2] + ": " + laptopData.MobileDevice.Ram;
                for(int i = 0 ; i < laptopData.Storage.Count() ; i++ )
                {
                    simpleDetailStr[3] += simpleDetailTitle[3] + ": " + laptopData.Storage.ToArray()[i].StorageType  + " | " + laptopData.Storage.ToArray()[i].StorageCapacity  + " | " + laptopData.Storage.ToArray()[i].StoragePort
                                     + "<br/>";
                }
                simpleDetailStr[4] = simpleDetailTitle[4] + ": " + ((laptopData.LapTop.CDPlayer == "no") ? "無" : "有");
                simpleDetailStr[5] = simpleDetailTitle[5] + ": " + laptopData.MobileDevice.OS;
                simpleDetailStr[6] = simpleDetailTitle[6] + ": " + laptopData.MobileDevice.Warranty;
                simpleDetailStr[7] = simpleDetailTitle[7] + ": " + laptopData.MobileDevice.Battery;
                simpleDetailStr[8] = simpleDetailTitle[8] + ": " + laptopData.Screen.Resulation  + " | " + laptopData.Screen.Reflash  + " | " + 
                                                                   laptopData.Screen.SType  + " | " + laptopData.Screen.Size  + " | " + "HDR: " + ((laptopData.Screen.HDR == "no") ? "無" : "有");
                simpleDetailStr[9] = simpleDetailTitle[9] + ": " + laptopData.MobileDevice.Size;
                simpleDetailStr[10]= simpleDetailTitle[10]+ ": " + laptopData.MobileDevice.Weight;
            }
            private void setFullDetailStr(AllLaptopDataViewModel laptopData)
            {
                fullDetailStr = new String[fullDetailItemNum];
                fullDetailStr[0] = laptopData.x86CPU.ManuName + " " + laptopData.x86CPU.CpuName + " (" + laptopData.x86CPU.CAndT + ") | Cache: " 
                                 + laptopData.x86CPU.Cache + " | " + laptopData.x86CPU.BaseClock + " ~ " + laptopData.x86CPU.TurboClock + " | "
                                 + laptopData.x86CPU.TDP   + " | " + laptopData.x86CPU.Graphics;
                fullDetailStr[1] = laptopData.GPU.ManuName + " " + laptopData.GPU.GPUName + " (" + laptopData.GPU.Cores + ") |  "
                                 + laptopData.GPU.BaseClock + " ~ " + laptopData.GPU.BoostClock + " | " 
                                 + laptopData.GPU.MemoryConfig + " | " + laptopData.GPU.PowerDraw;
                fullDetailStr[2] = laptopData.MobileDevice.Ram;

                for(int i = 0 ; i < laptopData.Storage.Count() ; i++ )
                {
                    fullDetailStr[3] += laptopData.Storage.ToArray()[i].StorageType  + " | " + laptopData.Storage.ToArray()[i].StorageCapacity  + " | " + laptopData.Storage.ToArray()[i].StoragePort
                                     + "<br/>";
                }
                fullDetailStr[4] = ((laptopData.LapTop.CDPlayer == "no") ? "無" : "有");
                fullDetailStr[5] = laptopData.MobileDevice.OS;
                fullDetailStr[6] = laptopData.MobileDevice.Warranty;
                fullDetailStr[7] = laptopData.MobileDevice.Battery;
                fullDetailStr[8] = laptopData.LapTop.Adapter;
                fullDetailStr[9] = laptopData.Screen.Resulation  + " | " + laptopData.Screen.Reflash  + " | " + 
                                   laptopData.Screen.SType  + " | " + laptopData.Screen.Size  + " | " + "HDR: " + ((laptopData.Screen.HDR == "no") ? "無" : "有");
                fullDetailStr[10]= laptopData.MobileDevice.Size;
                fullDetailStr[11]= laptopData.MobileDevice.Weight;
                   
                fullDetailStr[12]= laptopData.LapTop.Port;
                fullDetailStr[13]= laptopData.LapTop.Webcam;

                String[] temp = laptopData.LapTop.InPort.Split(',');
                fullDetailStr[14] = "可用:<br/>";
                for(int i = 0 ; i < temp.Length ; i++ )
                {
                    fullDetailStr[14] += temp[i] + "<br/>";
                }   
                fullDetailStr[14] += "<br/>已用:<br/>" + fullDetailStr[2] + "<br/>" + fullDetailStr[3];
                
                for(int i = 0 ; i < laptopData.MobileDeviceCC.Count() ; i++ )
                {
                    fullDetailStr[15] += laptopData.MobileDeviceCC.ToArray()[i].CC + "<br/>";
                }   
                 
                for(int i = 0 ; i < laptopData.MobileDeviceColor.Count() ; i++ )
                {
                    fullDetailStr[16] += laptopData.MobileDeviceColor.ToArray()[i].Color + "<br/>";
                }
                  
                for(int i = 0 ; i < laptopData.MobileDeviceMutimedia.Count() ; i++ )
                {
                    fullDetailStr[17] += laptopData.MobileDeviceMutimedia.ToArray()[i].Mutimedia + "<br/>";
                }  

                for(int i = 0 ; i < laptopData.MobileDeviceOther.Count() ; i++ )
                {
                    fullDetailStr[18] += laptopData.MobileDeviceOther.ToArray()[i].Other + "<br/>";
                }  
            }
        }
    }
}