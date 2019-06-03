using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Models;
using WebMVC.Models.ViewModels;

using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Data.Entity;

using WebMVC.App_Class.Models_Class;

namespace WebMVC.Controllers
{
    public class HomeController : Controller
    {
        private MobileDeviceSpecEntities db = new MobileDeviceSpecEntities();
        private const int PAGE_MAX_PNUM = 1;
        private static int tabNum = 0;

        public ActionResult Index()
        {
            List<MobileDevice> md  = getMobileDevices();

            return View(new LaptopGpuX86CPUViewModel()
            {
                MobileDevice = md,
                LapTop       = getLaptops(md),
                GPU          = getGpus(md),
                Manufacture  = getLapTopManufacturers()
            });
        }
        public ActionResult Browsing()
        {
            List<MobileDevice> md = getMobileDevices();
            setTabNum(md.Count() );

            return View(new MoblieDeviceBrowsingViewModel()
            {
                pageProductNum = PAGE_MAX_PNUM ,
                MobileDevice = md ,
                LapTop       = getLaptops(md),             
                GPU          = getGpus(md),

                ManufactureSelector = getLapTopManufacturers(),//先只有筆電(之後根據MDType做不同的sql)
                RamSelector = getRam(),
                X86CPUSelector = db.x86CPU ,
                GPUSelector = getGpus() ,
                SSDSelector = getStorage("SSD"),
                HDDSelector = getStorage("HDD")
            });
        }
        private List<MobileDevice> getMobileDevices(String[] specStr = null)
        {
            if( specStr != null )
            {
                List<MobileDevice> manufacturers = new List<MobileDevice>();
            
                var rawSqlCmd = db.Database.Connection.CreateCommand();
                rawSqlCmd.CommandText = getSqlCommand(specStr);

                rawSqlCmd.Connection.Open();

                var reader = rawSqlCmd.ExecuteReader();

                while (reader.Read())
                {
                    manufacturers.Add( MyData.getMobileDevice(reader) );
                }
                rawSqlCmd.Connection.Close();
                return manufacturers;
            }
            else return db.MobileDevice.ToList();          
        }
            private String getSqlCommand(String[] specStr)
            {
                String command =  @"SELECT DISTINCT MobileDevice.* 
                                    From MobileDevice ,LapTop ,LapTopGpu ,GPU ,LapTopStorage ,Storage 
                                    WHERE MobileDevice.MD# = LapTop.MD#
                                    AND   LapTop.MD# = LapTopGpu.MD#
                                    AND   LapTop.MD# = LapTopStorage.MD#
                                    AND   LapTopGpu.GPU# = GPU.GPU#
                                    AND	  LapTopStorage.Storage# = Storage.Storage#";

                for(int i = 0 ; i < specStr.Length ; i++ )
                {
                    for(int j = 0 ; j < MoblieDeviceBrowsingViewModel.ulTitleStr.Length ; j++ )
                    {
                        if( specStr[i] != "" && specStr[i].Contains( MoblieDeviceBrowsingViewModel.ulTitleStr[j] ) )
                        {
                            specStr[i] = specStr[i].Remove(0 ,specStr[i].IndexOf(" ")+1);
                            command += " AND " + MoblieDeviceBrowsingViewModel.SQLSelector[j] + " '" + specStr[i] + "' ";
                            specStr[i] = "";
                            
                            for(int k = i+1 ; k < specStr.Length ; k++)
                            {
                                if( specStr[k].Contains( MoblieDeviceBrowsingViewModel.ulTitleStr[j] ) )
                                {
                                    specStr[k] = specStr[k].Remove(0 ,specStr[k].IndexOf(" ")+1);
                                    command += " OR " + MoblieDeviceBrowsingViewModel.SQLSelector[j] + " '" + specStr[k] + "' ";
                                    specStr[k] = "";
                                }
                            }
                            //command += ")";
                        }
                    }
                }   
                command += ";";

                return command; 
            }
        
        private List<LapTop> getLaptops(List<MobileDevice> md = null)
        {
            List<LapTop> laptops = new List<LapTop>();
            if (md != null)
            {               
                for (int i = 0 ; i < 4 && i < md.Count ; i++)
                {
                    laptops.Add( getLaptop(md[i].MD_) );
                }
            }
            else
            {
                LapTop laptop;

                var rawSqlCmd = db.Database.Connection.CreateCommand();
                rawSqlCmd.CommandText = @"SELECT CpuName
                                          From LapTop;";

                rawSqlCmd.Connection.Open();

                var reader = rawSqlCmd.ExecuteReader();

                while (reader.Read())
                {
                    laptop = new LapTop();
                    laptop.CpuName = reader.GetString(0);
                    laptops.Add(laptop);
                }
                rawSqlCmd.Connection.Close();
            }
            return laptops;
        }
            private LapTop getLaptop(String MDID)
            {
                LapTop laptop = new LapTop();

                var rawSqlCmd = db.Database.Connection.CreateCommand();
                rawSqlCmd.CommandText = @"SELECT CpuName
                                          From LapTop
                                          WHERE LapTop.MD# = @ID;";

                rawSqlCmd.Parameters.Add(new SqlParameter("@ID" ,MDID));
                rawSqlCmd.Connection.Open();

                var reader = rawSqlCmd.ExecuteReader();

                reader.Read();
                laptop.CpuName = reader.GetString(0);
                
                rawSqlCmd.Connection.Close();

                return laptop;
            }

        private List<Manufacture> getLapTopManufacturers()
        {
            List<Manufacture> manufacturers = new List<Manufacture>();
            Manufacture manu;
            var rawSqlCmd = db.Database.Connection.CreateCommand();
            rawSqlCmd.CommandText = @"SELECT DISTINCT Manufacture.ManuName 
                                      From Manufacture ,MobileDevice ,LapTop
                                      WHERE MobileDevice.MD# = LapTop.MD#
                                      AND   MobileDevice.ManuName = Manufacture.ManuName;";
            rawSqlCmd.Connection.Open();

            var reader = rawSqlCmd.ExecuteReader();

            while (reader.Read())
            {
                manu = new Manufacture();
                manu.ManuName = reader.GetString(0);
                manufacturers.Add(manu);
            }
            rawSqlCmd.Connection.Close();

            return manufacturers;
        }
        private List<GPU> getGpus(List<MobileDevice> md = null)
        {
            List<GPU> Gpus = new List<GPU>();
            if (md != null)
            {               
                for (int i = 0 ; i < 4 && i < md.Count ; i++)
                {
                    Gpus.Add( getGpu(md[i].MD_) );
                }
            }
            else
            {
                GPU Gpu;

                var rawSqlCmd = db.Database.Connection.CreateCommand();
                rawSqlCmd.CommandText = @"SELECT DISTINCT GPUName
                                      From GPU ,LapTopGpu
                                      WHERE LapTopGpu.GPU# = GPU.GPU#;";

                rawSqlCmd.Connection.Open();

                var reader = rawSqlCmd.ExecuteReader();

                while (reader.Read())
                {
                    Gpu = new GPU();
                    Gpu.GPUName = reader.GetString(0);
                    Gpus.Add(Gpu);
                }
                rawSqlCmd.Connection.Close();
            }
            return Gpus;
        }
            private GPU getGpu(String MDID)
            {
                GPU Gpu = new GPU();

                var rawSqlCmd = db.Database.Connection.CreateCommand();
                rawSqlCmd.CommandText = @"SELECT GPUName
                                          From GPU ,LapTopGpu
                                          WHERE LapTopGpu.GPU# = GPU.GPU#
                                          AND LapTopGpu.MD# = @ID;";

                rawSqlCmd.Parameters.Add(new SqlParameter("@ID" ,MDID));
                rawSqlCmd.Connection.Open();

                var reader = rawSqlCmd.ExecuteReader();

                reader.Read();
                Gpu.GPUName = reader.GetString(0);
                
                rawSqlCmd.Connection.Close();

                return Gpu;
            }

        private List<String> getRam()
        {
            List<String> Ram = new List<String>();

            var rawSqlCmd = db.Database.Connection.CreateCommand();
            rawSqlCmd.CommandText = "SELECT DISTINCT Ram From MobileDevice;";
            rawSqlCmd.Connection.Open();

            var reader = rawSqlCmd.ExecuteReader();

            while (reader.Read())
            {
                Ram.Add( reader.GetString(0) );
            }
            rawSqlCmd.Connection.Close();

            return Ram;
        }
        private List<Storage> getStorage(String type)
        {
            List<Storage> storages = new List<Storage>();
            Storage storage;

            var rawSqlCmd = db.Database.Connection.CreateCommand();
            rawSqlCmd.CommandText = @"SELECT Storage# ,StorageType ,StoragePort ,StorageCapacity
                                      From Storage 
                                      WHERE StorageType = @Type";
     
            if (type == "HDD")
            {
                rawSqlCmd.CommandText += " OR StorageType = 'SSHD';";
            }
            else rawSqlCmd.CommandText += ';';
            rawSqlCmd.Parameters.Add( new SqlParameter("@Type" ,type) );
            
            rawSqlCmd.Connection.Open();

            var reader = rawSqlCmd.ExecuteReader();

            while (reader.Read())
            {
                storage = new Storage();
                storage.Storage_    = reader.GetString( reader.GetOrdinal("Storage#") );
                storage.StorageType = reader.GetString( reader.GetOrdinal("StorageType") );
                storage.StoragePort = reader.GetString( reader.GetOrdinal("StoragePort") );
                storage.StorageCapacity = reader.GetString( reader.GetOrdinal("StorageCapacity") );

                storages.Add( storage );
            }
            rawSqlCmd.Connection.Close();

            return storages;
        }

        /*=======通用===================================================================*/
        private void setTabNum(int productNum)
        {
            tabNum = (productNum % PAGE_MAX_PNUM == 0) ? productNum / PAGE_MAX_PNUM : productNum / PAGE_MAX_PNUM + 1;
        }

        /*=======JavaScriptResult===================================================================*/
        public ActionResult PaginationSeg()
        {
            if (tabNum == 0)
            {
                setTabNum(db.MobileDevice.Count());
            }

            String jqueryStr = @"$('#pagination-demo').twbsPagination({
                                    totalPages: " + tabNum + @",
                                    visiblePages: " + 5 + @",
                                    onPageClick: function (event, page)
                                    {
                                        $('.page-active').removeClass('page-active');
                                        $('#page'+page).addClass('page-active');
                                    }
                                });";

            return JavaScript(jqueryStr);
        }

        /*=======PartialView===================================================================*/
        [HttpPost]
        public ActionResult _BrowsingProductPartial(String[] specStr)
        {
            List<MobileDevice> md = getMobileDevices(specStr);
            setTabNum(md.Count());

            return PartialView(new MoblieDeviceBrowsingViewModel()
            {
                pageProductNum = PAGE_MAX_PNUM ,
                MobileDevice = md ,
                LapTop       = getLaptops(md) ,             
                GPU          = getGpus(md) ,
            });
        }

        /*=======RedirectToAction===================================================================*/
        [HttpPost]
        public ActionResult DisplayProductDetail(String mobileDeviceID)
        {
            //persist data for next request
            TempData["MDID"] = mobileDeviceID;

            //return RedirectToAction("Display" ,"Detial");
            return Json( Url.Action("Display" ,"Detial") );
        }
    }
}