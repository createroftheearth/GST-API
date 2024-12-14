using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GST_API_Library.Models.GSTR1
{
    public class HSNDetails
    {
        public Hsn1 hsn { get; set; }

    }
    public class Datum1
    {
        public int num { get; set; }
        public string hsn_sc { get; set; }
        public string desc { get; set; }
        public string uqc { get; set; }
        public double qty { get; set; }
        public double txval { get; set; }
        public double iamt { get; set; }
        public int csamt { get; set; }
        public double rt { get; set; }
    }

    public class Hsn1
    {
        public string flag { get; set; }
        public string chksum { get; set; }
        public List<Datum1> data { get; set; }
    }

}
