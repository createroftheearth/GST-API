using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GST_API_Library.Models.GSTR2A
{
    public class GetAMDHISTGSTR2A
    {
        public string gstin { get; set; }
        public string portcd { get; set; }
        public int benum { get; set; }
        public string bedt { get; set; }
        public List<Amddtl> amddtl { get; set; }
    }
    public class Amddtl
    {
        public string sgstin { get; set; }
        public string tdname { get; set; }
        public string refdt { get; set; }
        public double txval { get; set; }
        public double iamt { get; set; }
        public double csamt { get; set; }
    }


}
