using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using WebMVC.Models;
using WebMVC.Models.ViewModels;

using System.Web.Configuration;
using System.Data.SqlClient;

using WebMVC.App_Class.Models_Class;

namespace WebMVC.Controllers
{
    public class DetialController : Controller
    {
        private MobileDeviceSpecEntities db = new MobileDeviceSpecEntities();
        
        public ActionResult Display()
        {
            String mobileDeviceID = "Laptop00000000000001";           
            if( TempData["MDID"] != null)
            {               
                mobileDeviceID = TempData["MDID"].ToString();
            }
            return View( getAllMobileDeviceData(mobileDeviceID) );
        }
            private AllLaptopDataViewModel getAllMobileDeviceData(String MDID)
            {
                AllLaptopDataViewModel laptopData = new AllLaptopDataViewModel();

                laptopData.MobileDevice = getMobileDevice(MDID);
                laptopData.LapTop       = getLaptop(MDID);
                laptopData.x86CPU       = getX86CPU(MDID);
                laptopData.GPU          = getGPU(MDID);
                laptopData.Storage      = getStorage(MDID);
                laptopData.Screen       = getScreen(MDID);
                laptopData.Manufacture  = getManufacture(MDID);
                
                laptopData.MobileDeviceCC        = getMobileDeviceCC(MDID);
                laptopData.MobileDeviceColor     = getMobileDeviceColor(MDID);
                laptopData.MobileDeviceMutimedia = getMobileDeviceMutimedia(MDID);
                laptopData.MobileDeviceOther     = getMobileDeviceOther(MDID);
                laptopData.MobileDeviceReview    = getMobileDeviceReview(MDID);
                laptopData.SMD                   = getSMD(MDID);
                
                laptopData.setDetail();
                return laptopData;
            }
                private MobileDevice getMobileDevice(String MDID)//測試
                {   
                    MobileDevice mobileDevice = new MobileDevice();     
                    var rawSqlCmd = db.Database.Connection.CreateCommand();
                    rawSqlCmd.CommandText = @"SELECT *
                                              FROM  MobileDevice
                                              WHERE MobileDevice.MD# = @ID;";
                    
                    rawSqlCmd.Parameters.Add(new SqlParameter("@ID" ,MDID));
                    rawSqlCmd.Connection.Open();

                    var reader = rawSqlCmd.ExecuteReader();

                    reader.Read();
                    mobileDevice = MyData.getMobileDevice(reader);  

                    rawSqlCmd.Connection.Close();
                    return mobileDevice;
                }
                private LapTop getLaptop(String MDID)
                {
                    LapTop laptop = new LapTop();

                    var rawSqlCmd = db.Database.Connection.CreateCommand();
                    rawSqlCmd.CommandText = @"SELECT *
                                              From  LapTop
                                              WHERE LapTop.MD# = @ID;";

                    rawSqlCmd.Parameters.Add(new SqlParameter("@ID" ,MDID));
                    rawSqlCmd.Connection.Open();

                    var reader = rawSqlCmd.ExecuteReader();

                    reader.Read();
                    laptop  = MyData.getLapTop(reader);
                
                    rawSqlCmd.Connection.Close();

                    return laptop;
                }
                private x86CPU getX86CPU(String MDID)
                {
                    x86CPU x86CPU = new x86CPU();

                    var rawSqlCmd = db.Database.Connection.CreateCommand();
                    rawSqlCmd.CommandText = @"SELECT x86CPU.*
                                              From  LapTop ,x86CPU
                                              WHERE LapTop.CPUManuName = x86CPU.ManuName
                                              AND   LapTop.CpuName  = x86CPU.CpuName
                                              AND   LapTop.MD# = @ID;";

                    rawSqlCmd.Parameters.Add(new SqlParameter("@ID" ,MDID));
                    rawSqlCmd.Connection.Open();

                    var reader = rawSqlCmd.ExecuteReader();

                    reader.Read();
                    x86CPU  = MyData.getX86CPU(reader);
                
                    rawSqlCmd.Connection.Close();

                    return x86CPU;
                }
                private GPU getGPU(String MDID)
                {
                    GPU gpu = new GPU();

                    var rawSqlCmd = db.Database.Connection.CreateCommand();
                    rawSqlCmd.CommandText = @"SELECT GPU.*
                                              From  LapTop ,LapTopGpu ,GPU
                                              WHERE LapTop.MD# = LapTopGpu.MD#
                                              AND   LapTopGpu.Gpu#  = GPU.Gpu#
                                              AND   LapTop.MD# = @ID;";

                    rawSqlCmd.Parameters.Add(new SqlParameter("@ID" ,MDID));
                    rawSqlCmd.Connection.Open();

                    var reader = rawSqlCmd.ExecuteReader();

                    reader.Read();
                    gpu  = MyData.getGPU(reader);
                
                    rawSqlCmd.Connection.Close();

                    return gpu;
                }
                private List<Storage> getStorage(String MDID)
                {
                    List<Storage> storages = new List<Storage>();
                    Storage storage = new Storage();

                    var rawSqlCmd = db.Database.Connection.CreateCommand();
                    rawSqlCmd.CommandText = @"SELECT Storage.*
                                              From  LapTop ,LapTopStorage ,Storage
                                              WHERE LapTop.MD# = LapTopStorage.MD#
                                              AND   LapTopStorage.Storage# = Storage.Storage#
                                              AND   LapTop.MD# = @ID;";

                    rawSqlCmd.Parameters.Add(new SqlParameter("@ID" ,MDID));
                    rawSqlCmd.Connection.Open();

                    var reader = rawSqlCmd.ExecuteReader();

                    while( reader.Read() )
                    {
                        storage  = new Storage();
                        storage = MyData.getStorage(reader);
                        storages.Add(storage);
                    }                                
                    rawSqlCmd.Connection.Close();

                    return storages;
                }
                private Screen getScreen(String MDID)
                {
                    Screen screen = new Screen();

                    var rawSqlCmd = db.Database.Connection.CreateCommand();
                    rawSqlCmd.CommandText = @"SELECT Screen.*
                                              From  MobileDevice ,Screen
                                              WHERE MobileDevice.Screen# = Screen.Screen#
                                              AND   MobileDevice.MD# = @ID;";

                    rawSqlCmd.Parameters.Add(new SqlParameter("@ID" ,MDID));
                    rawSqlCmd.Connection.Open();

                    var reader = rawSqlCmd.ExecuteReader();

                    reader.Read();
                    screen  = MyData.getScreen(reader);
                
                    rawSqlCmd.Connection.Close();

                    return screen;
                }
                private Manufacture getManufacture(String MDID)
                {
                    Manufacture manufacture = new Manufacture();

                    var rawSqlCmd = db.Database.Connection.CreateCommand();
                    rawSqlCmd.CommandText = @"SELECT Manufacture.*
                                              From  MobileDevice ,Manufacture
                                              WHERE MobileDevice.ManuName = Manufacture.ManuName
                                              AND   MobileDevice.MD# = @ID;";

                    rawSqlCmd.Parameters.Add(new SqlParameter("@ID" ,MDID));
                    rawSqlCmd.Connection.Open();

                    var reader = rawSqlCmd.ExecuteReader();

                    reader.Read();
                    manufacture  = MyData.getManufacture(reader);
                
                    rawSqlCmd.Connection.Close();

                    return manufacture;
                }
                
                private List<MobileDeviceCC> getMobileDeviceCC(String MDID)
                {
                    List<MobileDeviceCC> mobileDeviceCCs = new List<MobileDeviceCC>();
                    MobileDeviceCC mobileDeviceCC;

                    var rawSqlCmd = db.Database.Connection.CreateCommand();
                    rawSqlCmd.CommandText = @"SELECT MobileDeviceCC.*
                                              From  MobileDeviceCC
                                              WHERE MobileDeviceCC.MD# = @ID;";

                    rawSqlCmd.Parameters.Add(new SqlParameter("@ID" ,MDID));
                    rawSqlCmd.Connection.Open();

                    var reader = rawSqlCmd.ExecuteReader();

                    while(reader.Read())
                    {
                        mobileDeviceCC = new MobileDeviceCC();
                        mobileDeviceCC  = MyData.getMobileDeviceCC(reader);
                        mobileDeviceCCs.Add(mobileDeviceCC);
                    }
                
                    rawSqlCmd.Connection.Close();

                    return mobileDeviceCCs;
                }
                private List<MobileDeviceColor> getMobileDeviceColor(String MDID)
                {
                    List<MobileDeviceColor> mobileDeviceColors = new List<MobileDeviceColor>();
                    MobileDeviceColor mobileDeviceColor;

                    var rawSqlCmd = db.Database.Connection.CreateCommand();
                    rawSqlCmd.CommandText = @"SELECT MobileDeviceColor.*
                                              From  MobileDeviceColor
                                              WHERE MobileDeviceColor.MD# = @ID;";

                    rawSqlCmd.Parameters.Add(new SqlParameter("@ID" ,MDID));
                    rawSqlCmd.Connection.Open();

                    var reader = rawSqlCmd.ExecuteReader();

                    while(reader.Read())
                    {
                        mobileDeviceColor = new MobileDeviceColor();
                        mobileDeviceColor  = MyData.getMobileDeviceColor(reader);
                        mobileDeviceColors.Add(mobileDeviceColor);
                    }
                    rawSqlCmd.Connection.Close();

                    return mobileDeviceColors;
                }
                private List<MobileDeviceMutimedia> getMobileDeviceMutimedia(String MDID)
                {
                    List<MobileDeviceMutimedia> mobileDeviceMutimedias = new List<MobileDeviceMutimedia>();
                    MobileDeviceMutimedia mobileDeviceMutimedia;

                    var rawSqlCmd = db.Database.Connection.CreateCommand();
                    rawSqlCmd.CommandText = @"SELECT MobileDeviceMutimedia.*
                                              From  MobileDeviceMutimedia
                                              WHERE MobileDeviceMutimedia.MD# = @ID;";

                    rawSqlCmd.Parameters.Add(new SqlParameter("@ID" ,MDID));
                    rawSqlCmd.Connection.Open();

                    var reader = rawSqlCmd.ExecuteReader();

                    while(reader.Read())
                    {
                        mobileDeviceMutimedia = new MobileDeviceMutimedia();
                        mobileDeviceMutimedia  = MyData.getMobileDeviceMutimedia(reader);
                        mobileDeviceMutimedias.Add(mobileDeviceMutimedia);
                    }
                    rawSqlCmd.Connection.Close();

                    return mobileDeviceMutimedias;
                }
                private List<MobileDeviceOther> getMobileDeviceOther(String MDID)
                {
                    List<MobileDeviceOther> mobileDeviceOthers = new List<MobileDeviceOther>();
                    MobileDeviceOther mobileDeviceOther;

                    var rawSqlCmd = db.Database.Connection.CreateCommand();
                    rawSqlCmd.CommandText = @"SELECT MobileDeviceOther.*
                                              From  MobileDeviceOther
                                              WHERE MobileDeviceOther.MD# = @ID;";

                    rawSqlCmd.Parameters.Add(new SqlParameter("@ID" ,MDID));
                    rawSqlCmd.Connection.Open();

                    var reader = rawSqlCmd.ExecuteReader();

                    while( reader.Read() )
                    {
                        mobileDeviceOther = new MobileDeviceOther();
                        mobileDeviceOther = MyData.getMobileDeviceOther(reader);
                        mobileDeviceOthers.Add(mobileDeviceOther);
                    }
                    
                
                    rawSqlCmd.Connection.Close();

                    return mobileDeviceOthers;
                }
                private List<MobileDeviceReview> getMobileDeviceReview(String MDID)
                {
                    List<MobileDeviceReview> mobileDeviceReviews = new List<MobileDeviceReview>();
                    MobileDeviceReview mobileDeviceReview;

                    var rawSqlCmd = db.Database.Connection.CreateCommand();
                    rawSqlCmd.CommandText = @"SELECT MobileDeviceReview.*
                                              From  MobileDeviceReview
                                              WHERE MobileDeviceReview.MD# = @ID;";

                    rawSqlCmd.Parameters.Add(new SqlParameter("@ID" ,MDID));
                    rawSqlCmd.Connection.Open();

                    var reader = rawSqlCmd.ExecuteReader();

                    while( reader.Read() )
                    {
                        mobileDeviceReview = new MobileDeviceReview();
                        mobileDeviceReview  = MyData.getMobileDeviceReview(reader);
                        mobileDeviceReviews.Add(mobileDeviceReview);
                    }
                    
                
                    rawSqlCmd.Connection.Close();

                    return mobileDeviceReviews;
                }
                private List<SMD> getSMD(String MDID)
                {
                    List<SMD> SMDs = new List<SMD>();
                    SMD SMD;

                    var rawSqlCmd = db.Database.Connection.CreateCommand();
                    rawSqlCmd.CommandText = @"SELECT SMD.*
                                              From   SMD
                                              WHERE  SMD.MD# = @ID;";

                    rawSqlCmd.Parameters.Add(new SqlParameter("@ID" ,MDID));
                    rawSqlCmd.Connection.Open();

                    var reader = rawSqlCmd.ExecuteReader();

                    while( reader.Read() )
                    {
                        SMD = new SMD();
                        SMD  = MyData.getSMD(reader);
                        SMDs.Add(SMD);
                    }
                              
                    rawSqlCmd.Connection.Close();

                    return SMDs;
                }
    }
}