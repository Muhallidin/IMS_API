using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMSAPI.Class
{

    public class InvoiceHeader
    {
        public string InvoiceNumber { get; set; } //"InvoiceNumber":"sample string 1",
        public string InvoiceDate { get; set; } // "InvoiceDate":"sample string 2",
        public double? InvoiceTotal { get; set; } // "InvoiceTotal":3.0,
        public string isCancelled { get; set; } //  "isCancelled":"sample string 5",
        public string BusinessUnitCode { get; set; } //  "BusinessUnitCode":"sample string 11"
    }






}