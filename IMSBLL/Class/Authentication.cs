using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMSBLL.Class
{
    
    public class Authentication
    {
        public string Auth { get; set; }
        public string AccesToken { get; set; }
        public string TokenType { get; set; }
        public string Expired { get; set; }
        public string CreatedBy { get; set; }

    }

}
