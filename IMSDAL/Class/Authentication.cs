using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;

namespace IMSDAL.Class
{
    public class Authentication
    {
        public string Auth { get; set; }
        public string AccesToken { get; set; }
        public string TokenType { get; set; }
        public string Expired { get; set; }
        public string CreatedBy { get; set; }

    }

    public interface IAuthentication
    {

        List<Authentication> InsertAuthentication(string Auth, string AccesToken, string TokenType, string Expired, string CreatedBy);
        List<Authentication> GetAuthentication();

    }

    public class AuthenticationReposity : IAuthentication
    {

        private List<Authentication> authentication = new List<Authentication>();

        private DataTable dt = new DataTable();
        private DataSet ds = new DataSet();


        private GlobalCode gc = new GlobalCode();
        public List<Authentication> InsertAuthentication(string Auth, string AccesToken, string TokenType, string Expired, string CreatedBy)
        {
            authentication = new List<Authentication>();
            Database SFDatebase = DatabaseFactory.CreateDatabase();
            DbCommand SFDbCommand = null;

            SFDbCommand = SFDatebase.GetStoredProcCommand("uspInsertAuthentication");
            SFDatebase.AddInParameter(SFDbCommand, "@pAuthenticationId", DbType.Int32, gc.Field2Int(Auth));
            SFDatebase.AddInParameter(SFDbCommand, "@pAccesToken", DbType.String, AccesToken);
            SFDatebase.AddInParameter(SFDbCommand, "@pTokenType", DbType.String, TokenType);
            SFDatebase.AddInParameter(SFDbCommand, "@pExpiredInt", DbType.Int32, gc.Field2Int(Expired));
            SFDatebase.AddInParameter(SFDbCommand, "@pCreatedBy", DbType.String, CreatedBy);
 
            ds = SFDatebase.ExecuteDataSet(SFDbCommand);
            authentication = (from a in ds.Tables[0].AsEnumerable()
                              select new Authentication
                              {

                                  AccesToken = a["colAccesTokenVarchar"].ToString(),
                                  TokenType = a["colTokenTypeVarchar"].ToString(),
                                  Expired = a["colExpiredInt"].ToString(),
                                  CreatedBy = a["colCreatedByVarchar"].ToString(),

                              }).ToList();

            return authentication;
        }

        public List<Authentication> GetAuthentication() 
        {
            authentication = new List<Authentication>();
            Database SFDatebase = DatabaseFactory.CreateDatabase();
            DbCommand SFDbCommand = null;

            SFDbCommand = SFDatebase.GetStoredProcCommand("upsGetAuthentication");
            ds = SFDatebase.ExecuteDataSet(SFDbCommand);
            authentication = (from a in ds.Tables[0].AsEnumerable()
                              select new Authentication
                              {


                                  AccesToken = a["AccesToken"].ToString(),
                                  TokenType = a["TokenType"].ToString(),
                                  Expired = a["Expired"].ToString(),

                              }).ToList();

            return authentication;
        }



    }





}
