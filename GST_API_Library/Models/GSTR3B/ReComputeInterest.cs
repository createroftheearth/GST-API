using Newtonsoft.Json;
using Integrated.API.GSTN.GSTR3B;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GST_API_Library.Models.GSTR3B
{
   
    public class ReComputeInterest
    {
        public string gstin { get; set; }
        public string ret_period { get; set; }
    }

}
