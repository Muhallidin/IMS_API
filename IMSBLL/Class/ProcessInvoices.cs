using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IMSDAL.Class;

using System.Web.Configuration;
using System.Configuration;





namespace IMSBLL.Class
{
    public class ProcessInvoices
    {


        IMSLibrary BLL = new IMSLibrary();
        GlobalCode G = new GlobalCode();
        List<InvoiceHeader> InvoiceHeader;

        public string SampleSingleInvoice()
        {
            InvoiceHeader = new List<IMSDAL.Class.InvoiceHeader>();

            InvoiceHeader =  BLL.GetSingleInvoicesToBill("46", "2016-07-25");


            string Invoice = "<?xml version=\"1.0\" encoding=\"utf-8\"?>";
            Invoice += "<Invoice>";
            Invoice += "<InvoiceHeader>";
            Invoice += "<InvoiceNumber>CREWHBOOK2</InvoiceNumber>";
            Invoice += "<InvoiceDate>2014-4-10 00:00:00.000</InvoiceDate>";
            Invoice += "<InvoiceTotal>138.0000</InvoiceTotal>";
            Invoice += "<PortNumber>1001</PortNumber>";
            Invoice += "<ShipNumber>21</ShipNumber>";
            Invoice += "<BusinessUnitCode>HR</BusinessUnitCode>";
            Invoice += "<VendorNumber>897969</VendorNumber>";
            Invoice += "</InvoiceHeader>";
            Invoice += "<InvoiceDetails>";

            Invoice += "<InvoiceDetail>";
            Invoice += "<ExpenseTypeCode>Hotel Stay: Double Occupancy</ExpenseTypeCode>";
            Invoice += "<Quantity>1.0000</Quantity>";
            Invoice += "<UnitCost>69.0000</UnitCost>";
            Invoice += "<CurrencyCode>USD</CurrencyCode>";
            Invoice += "<TotalCost>69.0000</TotalCost>";
            Invoice += "<Comment></Comment>";
            Invoice += "<EmployeeNumber>849683</EmployeeNumber>";
            Invoice += "<CrewServiceStartDate>2015-04-10</CrewServiceStartDate>";
            Invoice += "<CrewServiceEndDate>2015-04-10</CrewServiceEndDate>";
            Invoice += "<UnitOfMeasureType>PERNIGHT</UnitOfMeasureType>";
            Invoice += "<TripNumber>0</TripNumber>";
            Invoice += "</InvoiceDetail>";

            Invoice += "<InvoiceDetail>";
            Invoice += "<ExpenseTypeCode>Hotel Stay: Double Occupancy</ExpenseTypeCode>";
            Invoice += "<Quantity>1.0000</Quantity>";
            Invoice += "<UnitCost>69.0000</UnitCost>";
            Invoice += "<CurrencyCode>USD</CurrencyCode>";
            Invoice += "<TotalCost>69.0000</TotalCost>";
            Invoice += "<Comment></Comment>";
            Invoice += "<EmployeeNumber>256211</EmployeeNumber>";
            Invoice += "<CrewServiceStartDate>2015-04-10</CrewServiceStartDate>";
            Invoice += "<CrewServiceEndDate>2015-04-10</CrewServiceEndDate>";
            Invoice += "<UnitOfMeasureType>PERNIGHT</UnitOfMeasureType>";
            Invoice += "<TripNumber>0</TripNumber>";
            Invoice += "</InvoiceDetail>";

            Invoice += "</InvoiceDetails>";
            Invoice += "</Invoice>";

            return Invoice;

        }


        public string CreateInvoicesSingle(ref string InvoiceNumber, string BranchID, string currentDate)
        {
          
            List<InvoiceHeader> InvoiceHeader = BLL.GetSingleInvoicesToBill(BranchID, currentDate); //DateTime.Now.ToString("yyyy-MM-dd")); 
             
            string result = "<?xml version=\"1.0\" encoding=\"utf-8\"?>";
            if (InvoiceHeader.Count > 0)
            {

                for (var h = 0; h < InvoiceHeader.Count; h++)
                {

                    var sum = InvoiceHeader[h].InvoiceDetail.Sum(e => G.Field2Double(e.TotalCost));
                    result += "<Invoice>";
                    result += "<InvoiceHeader>";
                    result += "<InvoiceNumber>" + InvoiceHeader[h].InvoiceNumber + "</InvoiceNumber>";
                    result += "<InvoiceDate>" + InvoiceHeader[h].InvoiceDate + "</InvoiceDate>";
                    result += "<InvoiceTotal>" + string.Format("{0:0.0000}", sum) + "</InvoiceTotal>";
                    result += "<PortNumber>" + InvoiceHeader[h].PortNumber + "</PortNumber>";
                    result += "<ShipNumber>" + InvoiceHeader[h].ShipNumber + "</ShipNumber>";
                    result += "<BusinessUnitCode>" + InvoiceHeader[h].BusinessUnitCode + "</BusinessUnitCode>";
                    result += "<VendorNumber>" + InvoiceHeader[0].VendorNumber + "</VendorNumber>";
                    result += "</InvoiceHeader>";
                    if (InvoiceHeader[h].InvoiceDetail.Count > 0)
                    {

                        var detail = InvoiceHeader[h].InvoiceDetail;
                        result += "<InvoiceDetails>";

                        for (var d = 0; d < detail.Count; d++)
                        {

                            result += "<InvoiceDetail>"; 
                            result += "<ExpenseTypeCode>" + detail[d].ExpenseTypeCode + "</ExpenseTypeCode>";
                            result += "<Quantity>" + detail[d].Quantity + "</Quantity>";
                            result += "<UnitCost>" + string.Format("{0:0.0000}", detail[d].UnitCost) + "</UnitCost>";
                            result += "<CurrencyCode>" + detail[d].CurrencyCode + "</CurrencyCode>";
                            result += "<TotalCost>" + string.Format("{0:0.0000}", detail[d].TotalCost) + "</TotalCost>";
                            result += "<Comment>" + detail[d].Comment + "</Comment>";
                            result += "<EmployeeNumber>" + detail[d].EmployeeNumber + "</EmployeeNumber>";
                            result += "<CrewServiceStartDate>" + detail[d].CrewServiceStartDate + "</CrewServiceStartDate>";
                            result += "<CrewServiceEndDate>" + detail[d].CrewServiceStartDate + "</CrewServiceEndDate>";
                            result += "<UnitOfMeasureType>" + detail[d].UnitofMeasureType + "</UnitOfMeasureType>";
                            result += "<TripNumber>" + detail[d].TripNumber + "</TripNumber>"; 
                            result += "</InvoiceDetail>";

                        }
                        result += "</InvoiceDetails>";
                    }
                    result += "</Invoice>";
                }

                InvoiceNumber = InvoiceHeader[0].InvoiceNumber;

            }

            return result;
        }

        public string CreateInvoiceMultiple()
        {

            GlobalCode gc = new GlobalCode();

            string currentDate = ConfigurationSettings.AppSettings["InvoiceDate"];
            string BranchID = ConfigurationSettings.AppSettings["BranchID"];

            List<Vendor> Vendor = BLL.GetMultipleInvoicesToBill(BranchID, currentDate); //DateTime.Now.ToString("yyyy-MM-dd"));//BLL.GetMultipleInvoicesToBill("46", "2015-07-25");
            string result = "<?xml version=\"1.0\" encoding=\"utf-8\"?>";
            result += "<Vendors>";

            foreach (Vendor v in Vendor)
            {

                result += "<vendor VendorNumber=\""  + v.VendorNumber + "\">";
                result += "<invoices>";
                
                foreach (InvoiceHeader h in v.InvoiceHeader)
                {

                    var sum = h.InvoiceDetail.Sum(e => G.Field2Double(e.TotalCost));

                    result += "<invoice>";

                    result += "<InvoiceHeader>";
                    result += "<InvoiceNumber>" + h.InvoiceNumber + "</InvoiceNumber>";
                    result += "<InvoiceDate>" + h.InvoiceDate + "</InvoiceDate>";
                    result += "<InvoiceTotal>" + string.Format("{0:0.0000}", sum) + "</InvoiceTotal>";
                    result += "<PortNumber>" + h.PortNumber + "</PortNumber>";
                    result += "<ShipNumber>" + h.ShipNumber + "</ShipNumber>";
                    result += "<BusinessUnitCode>" + h.BusinessUnitCode + "</BusinessUnitCode>";
                    result += "<VendorNumber>" + h.VendorNumber + "</VendorNumber>";
                    result += "</InvoiceHeader>";

                    foreach (InvoiceDetail d in h.InvoiceDetail)
                    {
                        
                        result += "<InvoiceDetail>";

                        result += "<ExpenseTypeCode>" + d.ExpenseTypeCode + "</ExpenseTypeCode>";
                        result += "<Quantity>" + d.Quantity + "</Quantity>";
                        result += "<UnitCost>" + string.Format("{0:0.0000}", d.UnitCost) + "</UnitCost>";
                        result += "<CurrencyCode>" + d.CurrencyCode + "</CurrencyCode>";
                        result += "<TotalCost>" + string.Format("{0:0.0000}", d.TotalCost) + "</TotalCost>";
                        result += "<Comment>" + d.Comment + "</Comment>";
                        result += "<EmployeeNumber>" + d.EmployeeNumber + "</EmployeeNumber>";
                        result += "<CrewServiceStartDate>" + d.CrewServiceStartDate + "</CrewServiceStartDate>";
                        result += "<CrewServiceEndDate>" + d.CrewServiceStartDate + "</CrewServiceEndDate>";
                        result += "<UnitOfMeasureType>" + d.UnitofMeasureType + "</UnitOfMeasureType>";
                        result += "<TripNumber>" + d.TripNumber + "</TripNumber>";

                        result += "</InvoiceDetail>";
                    
                    }
                    result += "</InvoiceDetails>";
                    result += "<invoice>";
                }

                result += "<invoices>";
                result += "</vendor>";
            }
             
            result += "</Vendors>";
            return result;

        }  


    }
}