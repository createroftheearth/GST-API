using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GST_API_Library.Models.GSTR2B
{
    public class GetGSTR2BGenStatus
    {
        public string status_cd { get; set; }
        public string err_cd { get; set; }

        public string err_msg { get; set; }
    }
        
}
