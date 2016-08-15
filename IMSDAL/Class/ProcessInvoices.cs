using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
 
namespace IMSDAL.Class
{

    public interface IInvoices
    {

        List<InvoiceHeader> GetSingleInvoicesToBill(string VendorNum, string InvoiceDate);
        List<Vendor> GetMultipleInvoicesToBill(string VendorNum, string InvoiceDate);
        void SubmittedInvoice(int BranchID, string InvoiceNumber);
        List<Vendor> GetVendor(string loadType, string vendorNo);

    }
    
     

    public class Invoices : IInvoices
    {

        private List<Vendor> vendor = new List<Vendor>();
        private List<InvoiceHeader> InvoiceHeader = new List<InvoiceHeader>();
        private DataTable dt = new DataTable();
        private DataSet ds = new DataSet();

        private GlobalCode gc = new GlobalCode();

        public List<InvoiceHeader> GetSingleInvoicesToBill(string VendorNum, string InvoiceDate)
        {
            Database SFDatebase = DatabaseFactory.CreateDatabase();
            DbCommand SFDbCommand = null;

            try
            {

                InvoiceHeader = new List<InvoiceHeader>();
               
                SFDbCommand = SFDatebase.GetStoredProcCommand("uspGetSingleInvoicesToBill");
                SFDatebase.AddInParameter(SFDbCommand, "@pLoadType", DbType.Int16, 0);
                SFDatebase.AddInParameter(SFDbCommand, "@pVendorNum", DbType.String, VendorNum);
                SFDatebase.AddInParameter(SFDbCommand, "@pInvoiceDate", DbType.DateTime, GlobalCode.Field2DateTime(InvoiceDate));

                ds = SFDatebase.ExecuteDataSet(SFDbCommand);
                InvoiceHeader = (from n in ds.Tables[0].AsEnumerable()
                                 select new InvoiceHeader
                                 {

                                     InvoiceNumID = n["colInvoiceNumIDInt"].ToString(),
                                     VendorNumber = n["colVendorNumber"].ToString(),
                                     InvoiceNumber = n["colInvoiceNumber"].ToString(),
                                     //InvoiceDate = String.Format("{0:yyyy-MM-dd 00.00.00.000}", n["colInvoiceDate"]),// n["colInvoiceDate"].ToString(),
                                     InvoiceDate =   n["colInvoiceDate"].ToString(),
                                     InvoiceTotal = n["colInvoiceTotal"].ToString(),
                                     PortNumber = n["colPortNumber"].ToString(),
                                     ShipNumber = n["colShipNumber"].ToString(),
                                     BusinessUnitCode = n["colBusinessUnitCode"].ToString(),
                                     CreatedByVarchar = n["colCreatedByVarchar"].ToString(),
                                     Port = n["PortName"].ToString(),
                                     Ship = n["VesselName"].ToString(),

                                     InvoiceDetail = (from e in ds.Tables[1].AsEnumerable()
                                                      where n["colVendorNumber"].ToString() == e["colVendorNumber"].ToString()
                                                          && n["colInvoiceNumIDInt"].ToString() == e["colInvoiceNumIDInt"].ToString()
                                                      select new InvoiceDetail
                                                      {

                                                          InvoiceNumID = e["colInvoiceDetailIDInt"].ToString(),
                                                          InvoiceDetailID = e["colInvoiceNumIDInt"].ToString(),
                                                          ExpenseTypeCode = e["colExpenseTypeCodeVarchar"].ToString(),
                                                          Quantity = e["colQuantity"].ToString(),
                                                          UnitCost = e["colUnitCost"].ToString(),
                                                          CurrencyCode = e["colCurrencyCode"].ToString(),
                                                          TotalCost = e["colTotalCost"].ToString(),
                                                          Comment = e["colComment"].ToString(),
                                                          EmployeeNumber = e["colEmployeeNumber"].ToString(),
                                                          //CrewServiceStartDate = String.Format("{0:yyyy-MM-dd}", e["colCrewServiceStartDate"]),//e["colCrewServiceStartDate"].ToString(),
                                                          //CrewServiceEndDate = String.Format("{0:yyyy-MM-dd}", e["colCrewServiceEndDate"]),// e["colCrewServiceEndDate"].ToString(),

                                                          CrewServiceStartDate =  e["colCrewServiceStartDate"].ToString(),
                                                          CrewServiceEndDate =   e["colCrewServiceEndDate"].ToString(),

                                                          UnitofMeasureType = e["colUnitofMeasureType"].ToString(),
                                                          TripNumber = e["colTripNumber"].ToString(),
                                                          CreatedByVarchar = e["colCreatedByVarchar"].ToString(),
                                                          CreatedDateTime = e["colCreatedDateTime"].ToString(),


                                                      }).ToList()

                                 }).ToList();

            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SFDbCommand != null)
                {
                    SFDbCommand.Dispose();
                }
                if (ds != null)
                {
                    ds.Dispose();
                }
            }

            return InvoiceHeader;
        }

        public List<Vendor> GetMultipleInvoicesToBill(string BranchID, string InvoiceDate)
        {
            Database SFDatebase = DatabaseFactory.CreateDatabase();
            DbCommand SFDbCommand = null;

            try
            {

                vendor = new List<Vendor>();

                SFDbCommand = SFDatebase.GetStoredProcCommand("uspGetMultipleInvoicesToBill");
                SFDatebase.AddInParameter(SFDbCommand, "@pLoadType", DbType.Int16, 0);
                SFDatebase.AddInParameter(SFDbCommand, "@pBranchID", DbType.String, BranchID);
                SFDatebase.AddInParameter(SFDbCommand, "@pInvoiceDate", DbType.DateTime, GlobalCode.Field2DateTime(dt));

                ds = SFDatebase.ExecuteDataSet(SFDbCommand);
                vendor = (from a in ds.Tables[0].AsEnumerable()
                          select new Vendor
                          {
                              VendorNumber = a["colVendorNumber"].ToString(),
                              VendorNumID = a["colVendorNumIDInt"].ToString(),
                              UserID = a["colCreatedByVarchar"].ToString(),
                              createdDate = a["colCreatedDateTime"].ToString(),
                              InvoiceHeader = (from n in ds.Tables[1].AsEnumerable()
                                               where a["colVendorNumber"].ToString() == n["colVendorNumber"].ToString()
                                               select new InvoiceHeader
                                               {

                                                   InvoiceNumID = n["colInvoiceNumIDInt"].ToString(),
                                                   VendorNumber = n["colVendorNumber"].ToString(),
                                                   InvoiceNumber = n["colInvoiceNumber"].ToString(),
                                                   InvoiceDate = n["colInvoiceDate"].ToString(),
                                                   InvoiceTotal = n["colInvoiceTotal"].ToString(),
                                                   PortNumber = n["colPortNumber"].ToString(),
                                                   ShipNumber = n["colShipNumber"].ToString(),
                                                   BusinessUnitCode = n["colBusinessUnitCode"].ToString(),
                                                   CreatedByVarchar = n["colCreatedByVarchar"].ToString(),
                                                   Port = n["PortName"].ToString(),
                                                   Ship = n["VesselName"].ToString(),
                                                   InvoiceDetail = (from e in ds.Tables[2].AsEnumerable()
                                                                    where n["colVendorNumber"].ToString() == e["colVendorNumber"].ToString()
                                                                       && n["colInvoiceNumIDInt"].ToString() == e["colInvoiceNumIDInt"].ToString()
                                                                    select new InvoiceDetail
                                                                    {
                                                                        
                                                                        InvoiceNumID = e["colInvoiceDetailIDInt"].ToString(),
                                                                        InvoiceDetailID = e["colInvoiceNumIDInt"].ToString(),
                                                                        ExpenseTypeCode = e["colExpenseTypeCodeVarchar"].ToString(),
                                                                        Quantity = e["colQuantity"].ToString(),
                                                                        UnitCost = e["colUnitCost"].ToString(),
                                                                        CurrencyCode = e["colCurrencyCode"].ToString(),
                                                                        TotalCost = e["colTotalCost"].ToString(),
                                                                        Comment = e["colComment"].ToString(),
                                                                        EmployeeNumber = e["colEmployeeNumber"].ToString(),
                                                                        CrewServiceStartDate = e["colCrewServiceStartDate"].ToString(),
                                                                        CrewServiceEndDate = e["colCrewServiceEndDate"].ToString(),
                                                                        UnitofMeasureType = e["colUnitofMeasureType"].ToString(),
                                                                        TripNumber = e["colTripNumber"].ToString(),
                                                                        CreatedByVarchar = e["colCreatedByVarchar"].ToString(),
                                                                        CreatedDateTime = e["colCreatedDateTime"].ToString(),
                                                                    
                                                                    }).ToList()

                                               }).ToList()

                          }).ToList();

               

            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SFDbCommand != null)
                {
                    SFDbCommand.Dispose();
                }
                if (ds != null)
                {
                    ds.Dispose();
                }
            }
            return vendor;
        }

        public void SubmittedInvoice(int BranchID, string InvoiceNumber)
        {
            Database SFDatebase = DatabaseFactory.CreateDatabase();
            DbCommand SFDbCommand = null;
            try
            {

                SFDbCommand = SFDatebase.GetStoredProcCommand("uspSubmittedInvoice");
                SFDatebase.AddInParameter(SFDbCommand, "@pLoadType", DbType.Int16, 0);
                SFDatebase.AddInParameter(SFDbCommand, "@pVendorNumber", DbType.Int32, BranchID);
                SFDatebase.AddInParameter(SFDbCommand, "@pInvoiceNumber", DbType.String, InvoiceNumber);
                SFDatebase.ExecuteNonQuery(SFDbCommand);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SFDbCommand != null)
                {
                    SFDbCommand.Dispose();
                }
                if (ds != null)
                {
                    ds.Dispose();
                }
            }
        }

        public List<Vendor> GetVendor(string loadType, string vendorNo)
        {
            vendor = new List<Vendor>();
            Database SFDatebase = DatabaseFactory.CreateDatabase();
            DbCommand SFDbCommand = null;

            SFDbCommand = SFDatebase.GetStoredProcCommand("uspGetIMSVendor");
            SFDatebase.AddInParameter(SFDbCommand, "@pLoadType", DbType.Int16, 0);
            SFDatebase.AddInParameter(SFDbCommand, "@pBranchID", DbType.Int32, gc.Field2Int(vendorNo));

            ds = SFDatebase.ExecuteDataSet(SFDbCommand);
            vendor = (from a in ds.Tables[0].AsEnumerable()
                      select new Vendor
                      {
                          VendorNumber = a["colVendorNumber"].ToString(),
                          VendorNumID = a["colVendorNumIDInt"].ToString(),
                          BranchID =  gc.Field2Int( a["BranchID"].ToString()),
                          BranchName = a["Branch"].ToString(),
                          UserID = a["colCreatedByVarchar"].ToString(),
                          createdDate = a["colCreatedDateTime"].ToString(), 
                      }).ToList();

            return vendor;
        }

    }

}