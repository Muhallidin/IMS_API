using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace IMSBLL.BLL
{
    public class GlobalCode
    {

        /// <summary>
        /// Date Created:   20/04/2012
        /// Created By:     Josephine Gad
        /// (description)   Convert string to double with validation
        /// =============================================================
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        public double Field2Double(object sender)
        {
            double vDouble = 0;
            try
            {
                if (sender != null)
                {
                    switch (sender.GetType().Name.ToString())
                    {

                        
                        case "String":
                            string sType = (string)sender;
                            vDouble = Convert.ToDouble(sType.ToString());
                            break;
                        default:
                            vDouble = Convert.ToDouble(sender.ToString());
                            break;
                    }
                }
                return vDouble;
            }
            catch
            {
                return 0;
            }
        }

        private string CreateTextFile()
        {

            // to get the location the assembly is executing from
            //(not necessarily where the it normally resides on disk)
            // in the case of the using shadow copies, for instance in NUnit tests, 
            // this will be in a temp directory.
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location;

            //once you have the path you get the directory with:
            var directory = System.IO.Path.GetDirectoryName(path);

            return directory;


            //string p1 = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            //string p2 = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath;
            //string p3 = this.Server.MapPath("");
            //Console.WriteLine("p1 = " + p1);
            //Console.WriteLine("p2 = " + p2);
            //Console.WriteLine("p3 = " + p3);

        }

        public void LogError(string ex)
        {



            string message = string.Format("Time: {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;
            message += string.Format("Message: {0}", ex);
            //message += Environment.NewLine;
            //message += string.Format("StackTrace: {0}", ex.StackTrace);
            //message += Environment.NewLine;
            //message += string.Format("Source: {0}", ex.Source);
            //message += Environment.NewLine;
            //message += string.Format("TargetSite: {0}", ex.TargetSite.ToString());
            //message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;



            using (StreamWriter writer = new StreamWriter(CreateTextFile(), true))
            {
                writer.WriteLine(message);
                writer.Close();
            }
        }

    }
}
