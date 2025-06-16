using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GST_API_Library.Models.GSTR2A
{
    public class GetIMPGSEZGSTR2A
    {
        public List<Impgsez> impgsez { get; set; }
    }

    public class Impgsez
    {
        public string refdt { get; set; }
        public string portcd { get; set; }
        public int benum { get; set; }
        public string bedt { get; set; }
        public string sgstin { get; set; }
        public string tdname { get; set; }
        public double txval { get; set; }
        public double iamt { get; set; }
        public int csamt { get; set; }
        public string amd { get; set; }
    }
}
