using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using IMSAPI.Class;
using System.Net.Http.Headers;

using System.Web.Script.Serialization;
using IMSBLL.Class;
using System.Configuration;
using System.Text;


namespace IMSAPI.Controllers
{
    public class SingleInvoiceController : ApiController
    {

        IMSAPI.Class.GlobalCode at = new IMSAPI.Class.GlobalCode();

        ProcessInvoices B = new ProcessInvoices();

        Token t = new Token();
        JavaScriptSerializer jc = new JavaScriptSerializer();
        SubmitInvoices smi = new SubmitInvoices();
         Authentication aut = new Authentication();
         
        // GET api/values
        [HttpGet]
        public HttpResponseMessage Get()
         {

            string currentDate = ConfigurationSettings.AppSettings["InvoiceDate"];
            string BranchID = ConfigurationSettings.AppSettings["BranchID"];

            string invoicenumber = "";
            string invoice = B.CreateInvoicesSingle(ref invoicenumber, BranchID, currentDate);

            string result = smi.SendInvoiceXML("POST", "https://uatrcclhrapi.brenock.com/api/invoice/Submit", invoice, at.GetAuthentication(), invoicenumber);
            return new HttpResponseMessage() { Content = new StringContent(result, Encoding.UTF8, "application/json") };
        
        }

        // GET api/values/5
        [HttpGet]
        [ActionName("api/singleinvoice?id={id}&date={date}")]
        public HttpResponseMessage Get(string id, string date)
        {
            string invoicenumber = "";
            string invoice = B.CreateInvoicesSingle(ref invoicenumber, id, date);

            string result = smi.SendInvoiceXML("POST", "https://uatrcclhrapi.brenock.com/api/invoice/Submit", invoice, at.GetAuthentication(), invoicenumber);
            return new HttpResponseMessage() { Content = new StringContent(result, Encoding.UTF8, "application/json") };
      
        
        }

        // POST api/values
        public void Post([FromBody]string value)
        {

        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}