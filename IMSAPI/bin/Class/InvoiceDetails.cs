using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMSAPI.Class
{
    public class InvoiceDetails
    {
       
       public string ExpenseTypeCode { get; set; }// "ExpenseTypeCode": "sample string 1",
       public double Quantity { get; set; }// "Quantity": 2.0,
       public double UnitCost { get; set; }// "UnitCost": 3.0,
       public string CurrencyCode {get; set; } //"CurrencyCode": "sample string 4",
       public double TotalCost { get; set; } // "TotalCost": 5.1,
       public string Comment { get; set; } // "Comment": "sample string 6",
       public string ShipmentNumber { get; set; } // "ShipmentNumber": "sample string 7",
       public string PortNumber { get; set; } // "PortNumber": "sample string 8",
       public string ShipNumber { get; set; } // "ShipNumber": "sample string 9",
       public string CallDate { get; set; } // "CallDate": "sample string 10",
       public string ShipCode { get; set; } // "ShipCode": "sample string 16",
       public string ServiceStartDate { get; set; } //"ServiceStartDate": "sample string 17",
       public string ServiceEndDate { get; set; } // "ServiceEndDate": "sample string 18",
       public string Errors { get; set; } //"Errors": null

    }
}