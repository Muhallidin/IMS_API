using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMSAPI.Class
{

    public class Vendors
    {
        public List<Vendor> Vendor { get; set; }
    }
    public class Vendor
    {
        public Invoices Invoices { get; set; }
        public string VendorNumber { get; set; }
    }
    public class Invoices
    {
        public List<Invoice> Invoice { get; set; }
    } 
    public class Invoice
    {
        public InvoiceHeader InvoiceHeader { get; set; }
        public List<InvoiceDetails> InvoiceDetails { get; set; }
        public string Errors { get; set; }
    }


}