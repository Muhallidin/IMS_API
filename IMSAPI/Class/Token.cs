using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Xml;
using System.IO;
using System.Collections.ObjectModel;
using Newtonsoft.Json.Linq;
using System.Web.Script.Serialization;
using IMSBLL.Class;

namespace IMSAPI.Class
{

   
    public class token
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public string expires_in { get; set; }
    }

    public class Token
    {

        JavaScriptSerializer jc = new JavaScriptSerializer();
        public  Authentication  AccessToken(string Method, string Uri)
        {
            HttpResponseMessage responseMessage;
            token access_token = new token();
            IMSLibrary BLL = new IMSLibrary();
            Authentication aut = new Authentication();

            aut = BLL.GetAuthentication();

 
            if (aut.AccesToken == "No Token")
            { 

                using (var client = new HttpClient())
                {

                    //setup client
                    client.BaseAddress = new Uri(Uri);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                
                    //setup login data
                    var formContent = new FormUrlEncodedContent(new[]
                    {
                    
                        new KeyValuePair<string, string>("grant_type", "password"), 
                        new KeyValuePair<string, string>("username", "testapiuser"), 
                        new KeyValuePair<string, string>("password", "Testing123"), 

                    });

                    responseMessage = client.PostAsync(Uri, formContent).Result;
                    //get access token from response body
                    var responseJson = responseMessage.Content.ReadAsStringAsync();
                    access_token = jc.Deserialize<token>(responseJson.Result);
                }
                aut = BLL.InsertAuthentication("", access_token.access_token, access_token.token_type, access_token.expires_in, "TM IMS API");
          
            }
            return aut;
        } 

    }


    
}