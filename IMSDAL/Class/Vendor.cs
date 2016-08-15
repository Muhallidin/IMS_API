using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMSDAL.Class
{
    public class Vendor
    {

        public string VendorNumID { get; set; }
        public string VendorNumber { get; set; }
        public int? BranchID { get; set; }
        public string BranchName { get; set; }
        public string UserID { get; set; }
        public string createdDate { get; set; }
        public List<InvoiceHeader> InvoiceHeader { get; set; }

    }
}
