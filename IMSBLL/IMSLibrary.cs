using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMSDAL.Class;
using System.Web.Script.Serialization;
using IMSDAL;

namespace IMSBLL.Class
{
    public class IMSLibrary
    {

        IDALServices dal = new DALServices();

        JavaScriptSerializer jc = new JavaScriptSerializer();
        
        Authentication  aut = new  Authentication();
        List<IMSDAL.Class.Authentication> obj;

        public Authentication GetAuthentication()
        {
            
            obj = new List<IMSDAL.Class.Authentication>();
            obj = dal.GetAuthentication();

            foreach (IMSDAL.Class.Authentication n in obj)
            {
                    aut.AccesToken = n.AccesToken;
                    aut.Auth = n.Auth;
                    aut.CreatedBy = n.CreatedBy;
                    aut.Expired = n.Expired;
                    aut.TokenType = n.TokenType;
               
            }

            return aut;
        }

        public Authentication InsertAuthentication(string Auth, string AccesToken, string TokenType, string Expired, string CreatedBy)
        {
            try {

                obj = new List<IMSDAL.Class.Authentication>();
                obj = dal.InsertAuthentication(Auth, AccesToken, TokenType, Expired, CreatedBy);
                
                foreach (IMSDAL.Class.Authentication n in obj)
                {
                    aut.AccesToken = n.AccesToken;
                    aut.Auth = n.Auth;
                    aut.CreatedBy = n.CreatedBy;
                    aut.Expired = n.Expired;
                    aut.TokenType = n.TokenType;
                }
                return aut;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<InvoiceHeader> GetSingleInvoicesToBill(string VendorNum, string InvoiceDate)
        {
            try
            {
                
                List<InvoiceHeader> InvoiceHeader = new List<InvoiceHeader>();
                InvoiceHeader = dal.GetSingleInvoicesToBill(VendorNum, InvoiceDate);
                return InvoiceHeader;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Vendor> GetMultipleInvoicesToBill(string VendorNum, string InvoiceDate)
        {
            try
            {

                List<Vendor> InvoiceHeader = new List<Vendor>();
                InvoiceHeader = dal.GetMultipleInvoicesToBill(VendorNum, InvoiceDate);
                return InvoiceHeader;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void SubmittedInvoice(int BranchID, string InvoiceNumber)
        {
            try
            {
                dal.SubmittedInvoice(BranchID, InvoiceNumber);
            }
            catch (Exception e)
            {
                throw e;
            }
        }



    }
}
