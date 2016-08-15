using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMSDAL.Class
{
    public class InvoiceHeader
    {


        public string InvoiceNumID { get; set; }
        public string VendorNumber { get; set; }  
        public string InvoiceNumber { get; set; }
        public string InvoiceDate { get; set; }
        public string InvoiceTotal { get; set; } 
        public string PortNumber { get; set; }
        public string Port { get; set; }
        public string ShipNumber { get; set; }
        public string Ship { get; set; }
        public string BusinessUnitCode { get; set; }  
        public string CreatedByVarchar { get; set; }
        public string CreatedDateTime { get; set; }
        public List<InvoiceDetail> InvoiceDetail { get; set; }

    }

}