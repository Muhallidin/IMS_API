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
using System.Text;


namespace IMSAPI.Controllers
{
    public class MultipleInvoiceController : ApiController
    {

        IMSAPI.Class.GlobalCode at = new IMSAPI.Class.GlobalCode();

        SubmitInvoices smi = new SubmitInvoices();
        ProcessInvoices B = new ProcessInvoices();

        

        // GET api/values
        [HttpGet]
        public HttpResponseMessage Get()
        {
            string invoice = B.CreateInvoiceMultiple ();
            string result = smi.SendInvoiceXML("POST", "https://uatrcclhrapi.brenock.com/api/invoice/SubmitMultipleVendor", invoice, at.GetAuthentication());
            return new HttpResponseMessage() { Content = new StringContent(result, Encoding.UTF8, "application/json") };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return (id * 2).ToString() ; 
        }

        // POST api/values
        public void Post([FromBody]string value)
        {

        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE api/values/5
        public void Delete(int id){}
        

        
    }
}