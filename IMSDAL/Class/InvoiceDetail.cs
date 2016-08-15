using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMSDAL.Class
{
    public class InvoiceDetail
    {

        public string InvoiceDetailID { get; set; }
        public string ExpenseTypeCode { get; set; }
        public string InvoiceNumID { get; set; }
        public string Quantity { get; set; }
        public string UnitCost { get; set; }
        public string CurrencyCode { get; set; }
        public string TotalCost { get; set; }
        public string Comment { get; set; }
        public string EmployeeNumber { get; set; }
        public string CrewServiceStartDate { get; set; }
        public string CrewServiceEndDate { get; set; }
        public string UnitofMeasureType { get; set; }
        public string TripNumber { get; set; }
        public string CreatedByVarchar { get; set; }
        public string CreatedDateTime { get; set; } 

 
    }
}