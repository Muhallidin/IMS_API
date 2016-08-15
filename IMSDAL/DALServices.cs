using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMSDAL.Class;

namespace IMSDAL
{

    public interface IDALServices
    {

        List<Authentication> InsertAuthentication(string Auth, string AccesToken, string TokenType, string Expired, string CreatedBy);
        List<Authentication> GetAuthentication();
        List<InvoiceHeader> GetSingleInvoicesToBill(string VendorNum, string InvoiceDate);
        List<Vendor> GetMultipleInvoicesToBill(string VendorNum, string InvoiceDate);
        void SubmittedInvoice(int BranchID, string InvoiceNumber);
        
    }

    public class DALServices: IDALServices
    {

        static IAuthentication auth = new AuthenticationReposity();
        static IInvoices invoice = new Invoices();

        public List<Authentication> InsertAuthentication(string Auth, string AccesToken, string TokenType, string Expired, string CreatedBy)
        {
            return auth.InsertAuthentication(Auth, AccesToken, TokenType, Expired, CreatedBy);
        }

        public List<Authentication> GetAuthentication()
        {
            return auth.GetAuthentication();
        }

        public List<InvoiceHeader> GetSingleInvoicesToBill(string VendorNum, string InvoiceDate)
        {
            return invoice.GetSingleInvoicesToBill(VendorNum, InvoiceDate);
        }

        public List<Vendor> GetMultipleInvoicesToBill(string VendorNum, string InvoiceDate)
        {
            return invoice.GetMultipleInvoicesToBill(VendorNum, InvoiceDate);
        }

        public void SubmittedInvoice(int BranchID, string InvoiceNumber)
        {
            invoice.SubmittedInvoice(BranchID, InvoiceNumber);
        }
         
    }

}
