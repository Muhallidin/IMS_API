using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections;
using System.Reflection;
using System.Globalization;
using IMSAPI.Class;
using System.Configuration;
using IMSBLL.Class;
using System.Web.Script.Serialization;
using System.Web.Configuration;
using System.IO;
using System.Web.Providers.Entities;

namespace IMSAPI.Class
{
    public class GlobalCode
    {
         
        string Authethication;
        string autdate;
         
        public Vendors Vendors()
        {

            Vendors Vendors = new Vendors();
            List<Vendor> Vendor = new List<Vendor>();
            Invoices  Invoices = new  Invoices ();
            List<Invoice> Invoice = new List<Invoice>();
            InvoiceHeader  InvoiceHeader = new  InvoiceHeader();
            List<InvoiceDetails> InvoiceDetails = new List<InvoiceDetails>();
            

            InvoiceHeader.InvoiceNumber = "CREWHBOOK1";
            InvoiceHeader.InvoiceDate = "4/10/2014 12:00:00 AM";
            InvoiceHeader.InvoiceTotal = 138.0000;
            InvoiceHeader.isCancelled = "false";
            InvoiceHeader.BusinessUnitCode = "HR";


            InvoiceDetails.Add(new InvoiceDetails { 
            
                ExpenseTypeCode = "Hotel Stay: Double Occupancy",
                Quantity = 1.0,
                UnitCost = 69.0000,
                CurrencyCode = "USD", 
                TotalCost = 69.0000,
                Comment = "Test only",
                ShipmentNumber = "849683", 
                PortNumber = "1001",  
                ShipNumber = "21",  
                CallDate = "",  
                ShipCode = "",  
                ServiceStartDate = "4/10/2014 12:00:00 AM",
                ServiceEndDate = "4/10/2014 12:00:00 AM",
                Errors = null,
             
            });

            InvoiceDetails.Add(new InvoiceDetails
            {

                ExpenseTypeCode = "Hotel Stay: Double Occupancy",
                Quantity = 1.0,
                UnitCost = 69.0000,
                CurrencyCode = "USD",
                TotalCost = 69.0000,
                Comment = "Test only",
                ShipmentNumber = "849682",
                PortNumber = "1001",
                ShipNumber = "21",
                CallDate = "",
                ShipCode = "",
                ServiceStartDate = "4/10/2014 12:00:00 AM",
                ServiceEndDate = "4/10/2014 12:00:00 AM",
                Errors = null,

            });

            var res = Dictionary(InvoiceHeader, "InvoiceHeader");
            Invoice.Add(new Invoice {
                InvoiceHeader = InvoiceHeader,
                InvoiceDetails = InvoiceDetails,
                Errors = null
            });

            Invoices.Invoice = Invoice;

            Vendor.Add(new Vendor { Invoices = Invoices, VendorNumber = "897969" });
            Vendors.Vendor = Vendor;

            return Vendors;
        
        }
         
        
        Dictionary<string, string> Dictionary(object obj, string sender)
        {

            PropertyInfo[] infos = obj.GetType().GetProperties();

            Dictionary<string, string> dix = new Dictionary<string, string>();

            foreach (PropertyInfo info in infos)
            {
                dix.Add(info.Name, info.GetValue(obj, null).ToString());
            }
            return dix;
        }


        public void createXMLMultipleInvoice(Vendors vendors)
        {
 
            //string Invoice = "<?xml version=\"1.0\" encoding=\"utf-8\"?>";

           string Invoice = "<Vendors xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">";

           if ( vendors.Vendor.Count > 0)
           {

                for(int i= 0 ; vendors.Vendor.Count > i ; i++)
                {
                
                
                
                }

               foreach(Vendor vndor in vendors.Vendor)
               {

                   Invoice += "<Vendor VendorNumber=\"" + vndor.VendorNumber + "\">";
                   Invoice += "<Invoices>";
                   Invoice += "<Invoice>";

                   if (vndor.Invoices.Invoice.Count > 0)
                   {
                       foreach (Invoice IV in vndor.Invoices.Invoice)
                       {

                           //Invoice += "<InvoiceHeader>";
                           //Invoice += "<InvoiceNumber>" + IV.InvoiceHeader.InvoiceNumber + "</InvoiceNumber>";
                           //Invoice += "<InvoiceDate>" + IV.InvoiceHeader.InvoiceDate + "</InvoiceDate>";
                           //Invoice += "<InvoiceTotal>" + IV.InvoiceHeader.InvoiceTotal + "</InvoiceTotal>";
                           //Invoice += "<VendorNumber>" + IV.InvoiceHeader.InvoiceNumber + "</VendorNumber>";
                           //Invoice += "<isCancelled>" + IV.InvoiceHeader.isCancelled + "</isCancelled>";
                           //Invoice += "<PortNumber>" + 0 + "</PortNumber>";
                           //Invoice += "<ShipNumber>" + 0 + "</ShipNumber>";
                           //Invoice += "<TransactionDate>" + 0 + "</TransactionDate>";


                           //<TransactionDate>sample string 8</TransactionDate>
                           //<ShipmentNumbers>
                           //  <ShipmentNumber>sample string 1</ShipmentNumber>
                           //  <ShipmentNumber>sample string 2</ShipmentNumber>
                           //</ShipmentNumbers>
                           //<PurchaseOrder>sample string 9</PurchaseOrder>
                           //<PurchaseOrderNumbers>
                           //  <PurchaseOrderNumber>sample string 1</PurchaseOrderNumber>
                           //  <PurchaseOrderNumber>sample string 2</PurchaseOrderNumber>
                           //</PurchaseOrderNumbers>
                           //<ProjectCode>sample string 10</ProjectCode>
                           //<BusinessUnitCode>sample string 11</BusinessUnitCode>

                           Invoice += "</InvoiceHeader>";
                       }

                   
                   }

               
               } 

           
           }
          
            Invoice += "</Vendors>";
             
        }

        public List<Invoice> Invoice()
        {

            List<Invoice> Invoice = new List<Invoice>();
            List<InvoiceHeader> InvoiceHeader = new List<InvoiceHeader>();
            List<InvoiceDetails> InvoiceDetails = new List<InvoiceDetails>();

            return Invoice;
        }

        string[] Field2StringArray(object obj)
        {
            string[] arr = ((IEnumerable)obj).Cast<object>()
                                 .Select(x => x.ToString())
                                 .ToArray();
            return arr;
        }

        /// <summary>
        /// Author By:       Muhallidin G Wali
        /// Date Modified:   02/02/2012
        /// Description      Convert object to Date
        /// </summary>
        /// <param name="sender"/>
        /// <returns/>
        public static DateTime Field2DateTime(object sender)
        {
            CultureInfo enCulture = new CultureInfo(FormatData.UserCultureInfo);
            DateTime vDateTime = DateTime.Now;
            try
            {
                if (sender != null)
                {
                    switch (sender.GetType().Name.ToString())
                    {
                        
                        case "String":
                            String SType = (String)sender;
                            vDateTime = DateTime.Parse(SType.ToString(), enCulture);
                            break;
                        default:
                            vDateTime = DateTime.Parse(sender.ToString(), enCulture);
                            break;
                    }
                }
                return vDateTime;
            }
            catch
            {
                return DateTime.Parse(DateTime.Now.ToString(FormatData.DateFormat), enCulture);
            }
        }

        public bool IsValidToken(string value)
        {
            try {
                DateTime startDate = Field2DateTime(value);
                //TimeSpan span = startDate.Subtract(DateTime.Now);
                TimeSpan span = DateTime.Now.Subtract(startDate);
                double hours = span.TotalHours;
                if (hours >= 23)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
            catch {
                return false;
            }
        }

        void UpdateAppSetting(string Authentication, string AutDate)
        {

            Configuration config = WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath);
            config.AppSettings.Settings.Remove("Authentication");
            config.AppSettings.Settings.Add("Authentication", Authentication);

            config.AppSettings.Settings.Remove("AuthDate");
            config.AppSettings.Settings.Add("AuthDate", AutDate);
            
            ConfigurationManager.RefreshSection("appSettings");

            config.Save();
        
        }


        public string GetAuthentication()
        {
            Token t = new Token();
            Authentication aut = new Authentication();

            Authethication = ConfigurationManager.AppSettings["Authentication"];
            autdate = ConfigurationManager.AppSettings["AuthDate"];

            if (Authethication == "No Token")
            {
                
                aut = t.AccessToken("POST", "https://uatrcclhrapi.brenock.com/token");
                Authethication = aut.AccesToken;
             
                UpdateAppSetting(Authethication, DateTime.Now.ToString());

                ConfigurationManager.AppSettings["Authentication"] = Authethication;
                ConfigurationManager.AppSettings["AuthDate"] = DateTime.Now.ToString();
                
            }
            else
            {
                if (!IsValidToken(autdate))
                {
                    
                    aut = t.AccessToken("POST", "https://uatrcclhrapi.brenock.com/token");
                    Authethication = aut.AccesToken;
                    
                    UpdateAppSetting(Authethication, DateTime.Now.ToString());

                    ConfigurationManager.AppSettings["Authentication"] = Authethication;
                    ConfigurationManager.AppSettings["AuthDate"] = DateTime.Now.ToString();

                }
            }

            return Authethication;
        
        }



        private string CreateTextFile(string p)
        {
            string path = HttpContext.Current.Server.MapPath(p); //("/Logs/exception");


           string FileName = path + @"\Logs_" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";

           FileStream fs = null;
           if (!File.Exists(FileName))
           {
               using (fs = File.Create(FileName))
               {
                   fs.Close();
               }
           }
           return FileName;

        }

        public void LogError(string ex, string path)
        {

            string message =  string.Format("Time: {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;
            //message += string.Format("Message: {0}", ex);
            message += string.Format("{0}", ex);

            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;
            message += Environment.NewLine;

            using (StreamWriter writer = new StreamWriter(CreateTextFile(path), true))
            {
                writer.WriteLine(message);
                writer.Close();
            }
        }
    }


   



}