using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using WebMVC.Models;

namespace WebMVC.App_Class.Models_Class
{
    public class MyData
    {
        public static MobileDevice getMobileDevice(System.Data.Common.DbDataReader reader)
        {
            MobileDevice mobileDevice = new MobileDevice();

            mobileDevice.MD_ = reader.GetString(reader.GetOrdinal("MD#"));
            mobileDevice.MDName = reader.GetString(reader.GetOrdinal("MDName"));
            mobileDevice.MDType = reader.GetString(reader.GetOrdinal("MDType"));
            mobileDevice.OfficialWebsite = reader.GetString(reader.GetOrdinal("OfficialWebsite"));
            mobileDevice.OS = reader.GetString(reader.GetOrdinal("OS"));
            mobileDevice.Weight = reader.GetString(reader.GetOrdinal("Weight"));
            mobileDevice.Size = reader.GetString(reader.GetOrdinal("Size"));
            mobileDevice.Battery = reader.GetString(reader.GetOrdinal("Battery"));
            mobileDevice.Warranty = reader.GetString(reader.GetOrdinal("Warranty"));
            mobileDevice.Ram = reader.GetString(reader.GetOrdinal("Ram"));
            mobileDevice.ImageURL = reader.GetString(reader.GetOrdinal("ImageURL"));
            mobileDevice.Screen_ = reader.GetString(reader.GetOrdinal("Screen#"));
            mobileDevice.ManuName = reader.GetString(reader.GetOrdinal("ManuName"));
            mobileDevice.Series_ = reader.GetString(reader.GetOrdinal("Series#"));

            return mobileDevice;
        }
        public static LapTop getLapTop(System.Data.Common.DbDataReader reader)
        {
            LapTop laptop= new LapTop();

            laptop.MD_      = reader.GetString(reader.GetOrdinal("MD#"));
            laptop.CDPlayer = reader.GetString(reader.GetOrdinal("CDPlayer"));
            laptop.Adapter  = reader.GetString(reader.GetOrdinal("Adapter"));
            laptop.Port     = reader.GetString(reader.GetOrdinal("Port"));
            laptop.Webcam   = reader.GetString(reader.GetOrdinal("Webcam"));
            laptop.CpuName  = reader.GetString(reader.GetOrdinal("CpuName"));
            laptop.CPUManuName = reader.GetString(reader.GetOrdinal("CPUManuName"));
            laptop.InPort   = reader.GetString(reader.GetOrdinal("InPort")); 

            return laptop;
        }
        public static x86CPU getX86CPU(System.Data.Common.DbDataReader reader)
        {
            x86CPU x86CPU= new x86CPU();

            x86CPU.CpuName    = reader.GetString(reader.GetOrdinal("CpuName"));
            x86CPU.ManuName   = reader.GetString(reader.GetOrdinal("ManuName"));
            x86CPU.CAndT      = reader.GetString(reader.GetOrdinal("CAndT"));
            x86CPU.BaseClock  = reader.GetString(reader.GetOrdinal("BaseClock"));
            x86CPU.TurboClock = reader.GetString(reader.GetOrdinal("TurboClock"));
            x86CPU.TDP        = reader.GetString(reader.GetOrdinal("TDP"));
            x86CPU.Graphics   = reader.GetString(reader.GetOrdinal("Graphics"));
            x86CPU.Cache      = reader.GetString(reader.GetOrdinal("Cache"));

            return x86CPU;
        }
        public static GPU getGPU(System.Data.Common.DbDataReader reader)
        {
            GPU GPU= new GPU();

            GPU.GPU_         = reader.GetString(reader.GetOrdinal("GPU#"));
            GPU.ManuName     = reader.GetString(reader.GetOrdinal("ManuName"));
            GPU.GPUName      = reader.GetString(reader.GetOrdinal("GPUName"));
            GPU.Cores        = reader.GetString(reader.GetOrdinal("Cores"));
            GPU.BaseClock    = reader.GetString(reader.GetOrdinal("BaseClock"));
            GPU.BoostClock   = reader.GetString(reader.GetOrdinal("BoostClock"));
            GPU.MemorySpeed  = reader.GetString(reader.GetOrdinal("MemorySpeed"));
            GPU.MemoryConfig = reader.GetString(reader.GetOrdinal("MemoryConfig"));
            GPU.PowerDraw    = reader.GetString(reader.GetOrdinal("PowerDraw"));

            return GPU;
        }
        public static Storage getStorage(System.Data.Common.DbDataReader reader)
        {
            Storage storage= new Storage();

            storage.Storage_        = reader.GetString(reader.GetOrdinal("Storage#"));
            storage.StorageName     = reader.GetString(reader.GetOrdinal("StorageName"));
            storage.ManuName        = reader.GetString(reader.GetOrdinal("ManuName"));
            storage.StorageType     = reader.GetString(reader.GetOrdinal("StorageType"));
            storage.StoragePort     = reader.GetString(reader.GetOrdinal("StoragePort"));
            storage.StorageCapacity = reader.GetString(reader.GetOrdinal("StorageCapacity"));

            return storage;
        }
        public static Screen getScreen(System.Data.Common.DbDataReader reader)
        {
            Screen screen = new Screen();

            screen.Screen_    = reader.GetString(reader.GetOrdinal("Screen#"));
            screen.Resulation = reader.GetString(reader.GetOrdinal("Resulation"));
            screen.Reflash    = reader.GetString(reader.GetOrdinal("Reflash"));
            screen.SRGB       = reader.GetString(reader.GetOrdinal("SRGB"));
            screen.SType      = reader.GetString(reader.GetOrdinal("SType"));
            screen.Size       = reader.GetString(reader.GetOrdinal("Size"));
            screen.HDR        = reader.GetString(reader.GetOrdinal("HDR"));

            return screen;
        }
        public static Manufacture getManufacture(System.Data.Common.DbDataReader reader)
        {
            Manufacture manufacture = new Manufacture();

            manufacture.ManuName = reader.GetString(reader.GetOrdinal("ManuName"));
            manufacture.ManuURL  = reader.GetString(reader.GetOrdinal("ManuURL"));

            return manufacture;
        }
        public static MobileDeviceCC getMobileDeviceCC(System.Data.Common.DbDataReader reader)
        {
            MobileDeviceCC mobileDeviceCC = new MobileDeviceCC();

           mobileDeviceCC.MD_ = reader.GetString(reader.GetOrdinal("MD#"));
           mobileDeviceCC.CC  = reader.GetString(reader.GetOrdinal("CC"));

            return mobileDeviceCC;
        }
        public static MobileDeviceColor getMobileDeviceColor(System.Data.Common.DbDataReader reader)
        {
           MobileDeviceColor mobileDeviceColor = new MobileDeviceColor();

           mobileDeviceColor.MD_   = reader.GetString(reader.GetOrdinal("MD#"));
           mobileDeviceColor.Color = reader.GetString(reader.GetOrdinal("Color"));

            return mobileDeviceColor;
        }
        public static MobileDeviceMutimedia getMobileDeviceMutimedia(System.Data.Common.DbDataReader reader)
        {
           MobileDeviceMutimedia mobileDeviceMutimedia = new MobileDeviceMutimedia();

           mobileDeviceMutimedia.MD_   = reader.GetString(reader.GetOrdinal("MD#"));
           mobileDeviceMutimedia.Mutimedia = reader.GetString(reader.GetOrdinal("Mutimedia"));

            return mobileDeviceMutimedia;
        }
        public static MobileDeviceOther getMobileDeviceOther(System.Data.Common.DbDataReader reader)
        {
           MobileDeviceOther mobileDeviceOther = new MobileDeviceOther();

           mobileDeviceOther.MD_   = reader.GetString(reader.GetOrdinal("MD#"));
           mobileDeviceOther.Other = reader.GetString(reader.GetOrdinal("Other"));

            return mobileDeviceOther;
        }
        public static MobileDeviceReview getMobileDeviceReview(System.Data.Common.DbDataReader reader)
        {
           MobileDeviceReview mobileDeviceReview = new MobileDeviceReview();

           mobileDeviceReview.MD_   = reader.GetString(reader.GetOrdinal("MD#"));
           mobileDeviceReview.ReviewURL = reader.GetString(reader.GetOrdinal("ReviewURL"));
           mobileDeviceReview.ReviewType = reader.GetString(reader.GetOrdinal("ReviewType"));
           mobileDeviceReview.ReviewName = reader.GetString(reader.GetOrdinal("ReviewName"));
           mobileDeviceReview.ReviewMainSite = reader.GetString(reader.GetOrdinal("ReviewMainSite"));

            return mobileDeviceReview;
        }
       public static SMD getSMD(System.Data.Common.DbDataReader reader)
        {
           SMD SMD = new SMD();

           SMD.StoreName = reader.GetString(reader.GetOrdinal("StoreName"));
           SMD.MD_       = reader.GetString(reader.GetOrdinal("MD#"));
           SMD.SMDURL    = reader.GetString(reader.GetOrdinal("SMDURL"));
           SMD.SMDPrice  = reader.GetInt32(reader.GetOrdinal("SMDPrice"));

            return SMD;
        }
    }
}