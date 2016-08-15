using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Net.Http.Formatting;



using System.Diagnostics;
using System.Threading.Tasks;
using System.IO;
using IMSBLL.Class;

 

namespace IMSAPI.Class
{
    public class SubmitInvoices
    {


        

        GlobalCode G = new GlobalCode();

        delegate void submitInvoiceTask(string invoice);
 
        public string SubmitInvoiceJson(string Method, string Uri, string Body, Vendors Vendor)
        {



            const string _CredentialBase64 = "E3fvvbLSffw0ct7NnbVINfgsbJhWAlDCFhEwiXady1XeNX_UHb4BVVl-pvg51eVAwD3EwK4WO8unZhbdHGM4buThqyvF7WXFQU_jj20bqq5VTSmIzTS-P6D1xgRfO0JAuVSpHwOXMZpze9OemIAGnQ96HRGr7WrS4ctEYUivWztkf0E8X8_diBKVkaxvza_muadkWAY8kWtEJMS-dvXjVhJKniodBdPr0k8To2S73GXyodVd2c8IYPFU1tZaSnyO";
            const string _ContentType = "application/json";

            var request = new HttpRequestMessage();
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(_ContentType));
            request.Headers.Add("Content-Type", _ContentType);
            request.Headers.Add("Authorization", String.Format("Bearer {0}", _CredentialBase64));

            request.Headers.Add("Cache-Control", "no-cache");
            request.Method = HttpMethod.Post;
            request.RequestUri = new Uri(Uri);

            request.Content = new ObjectContent<Vendors>(Vendor, new JsonMediaTypeFormatter());
            //request.Content = new StringContent(  Body) ;//new ObjectContent(,Body, new JsonMediaTypeFormatter());

            var httpClient = new HttpClient();

            var response = httpClient.SendAsync(request).Result;
            if (response.IsSuccessStatusCode)
            {
                // handle result code
                Console.WriteLine(response.StatusCode);
                Console.ReadLine();
            }
             

             return "";
             
        }

        public string SendInvoiceXML(string Method, string Uri, string Body, string authentication)
        {
            try
            {
                var content = "";

                string InvoiceNumber = "";

                //const string _CredentialBase64 = "E3fvvbLSffw0ct7NnbVINfgsbJhWAlDCFhEwiXady1XeNX_UHb4BVVl-pvg51eVAwD3EwK4WO8unZhbdHGM4buThqyvF7WXFQU_jj20bqq5VTSmIzTS-P6D1xgRfO0JAuVSpHwOXMZpze9OemIAGnQ96HRGr7WrS4ctEYUivWztkf0E8X8_diBKVkaxvza_muadkWAY8kWtEJMS-dvXjVhJKniodBdPr0k8To2S73GXyodVd2c8IYPFU1tZaSnyO";
                string _CredentialBase64 = authentication;
                const string _ContentType = "application/json";

                var request = new HttpRequestMessage();
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(_ContentType));
                request.Headers.Add("Authorization", String.Format("Bearer {0}", _CredentialBase64));
                request.Headers.Add("Cache-Control", "no-cache");
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(Uri);

                request.Content = new StringContent(Body, UTF8Encoding.UTF8, "Application/xml");//new ObjectContent(,Body, new JsonMediaTypeFormatter());

                var httpClient = new HttpClient();
                var response = httpClient.SendAsync(request).Result;

                // handle result code
                content = response.Content.ReadAsStringAsync().Result;
                if (!response.IsSuccessStatusCode)
                {
                    G.LogError(content, "/Logs/exception");
                }
                else
                {
                    //if (InvoiceNumber == "") 
                    SubmittedInvoices(InvoiceNumber);
                    G.LogError(content, "/Logs/success");
                }
                
                return content;

            }
            catch (Exception e)
            {
                throw e;
            }
        }
         
        public string SendInvoiceXML(string Method, string Uri, string Body, string authentication, string InvoiceNumber)
        {
            try
            {
                var content = "";
                
                string _CredentialBase64 = authentication;
                const string _ContentType = "application/json";

                var request = new HttpRequestMessage();
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(_ContentType));
                request.Headers.Add("Authorization", String.Format("Bearer {0}", _CredentialBase64));
                request.Headers.Add("Cache-Control", "no-cache");
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(Uri);

                request.Content = new StringContent(Body, UTF8Encoding.UTF8, "Application/xml");//new ObjectContent(,Body, new JsonMediaTypeFormatter());

                var httpClient = new HttpClient();
                var response = httpClient.SendAsync(request).Result;

                // handle result code
                content = response.Content.ReadAsStringAsync().Result;

                if (!response.IsSuccessStatusCode)
                {
                    G.LogError(content, "/Logs/exception");
                }
                else
                {
                    SubmittedInvoices(InvoiceNumber);
                    //G.LogError(content, "/Logs/success");
                }

                
                return content;

            }
            catch (Exception e)
            {
                throw e;
            }
        }



        void SubmittedInvoices(string InvoiceNumber)
        { 
           submitInvoiceTask objTask = new submitInvoiceTask(InvoiceTask);
           objTask.BeginInvoke(InvoiceNumber, null, objTask);
        }
         
        public static void InvoiceTask(string InvoiceNumber)
        {
            try {
                IMSLibrary BLL = new IMSLibrary();
                BLL.SubmittedInvoice(0, InvoiceNumber);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


         
         




    }


}