using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMSAPI.Class
{
    
    public class GenericCollection {}

    public static class FormatData
    {
        public static String DateFormat { get { return "MM/dd/yyyy"; } }
        public static String DateTimeFormat { get { return "MM/dd/yyyy HH:mm:ss:fff"; } }
        public static String DateTimeFormatFileExtension { get { return "MMddyy_HH-mm-ss-fff"; } }
        public static String UserCultureInfo { get { return "en-US"; } }
    }




}