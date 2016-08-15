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
    public class tokenController : ApiController
    {

        IMSAPI.Class.GlobalCode at = new IMSAPI.Class.GlobalCode();
        Token t = new Token();
        JavaScriptSerializer jc = new JavaScriptSerializer();
        //List<Authentication> aut = new List<Authentication>();
         Authentication  aut = new  Authentication ();
         
        // GET api/values
        [HttpGet]
        public HttpResponseMessage Get()
        {
            aut = t.AccessToken("POST", "https://uatrcclhrapi.brenock.com/token");
            string result = jc.Serialize(aut);
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
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}