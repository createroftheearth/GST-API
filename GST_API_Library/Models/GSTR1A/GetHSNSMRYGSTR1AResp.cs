using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GST_API_Library.Models.GSTR1A;


namespace Integrated.API.GSTN.GSTR1A
{
    public class GetHSNSMRYGSTR1AResp
    {
        public Hsn hsn { get; set; }

    }
    public class Datum
    {
        public int num { get; set; }
        public string hsn_sc { get; set; }
        public string desc { get; set; }
        public string uqc { get; set; }
        public double qty { get; set; }
        public double txval { get; set; }
        public double iamt { get; set; }
        public double camt { get; set; }
        public double samt { get; set; }
        public int csamt { get; set; }
        public double rt { get; set; }
    }

    public class Hsn
    {
        public string flag { get; set; }
        public string chksum { get; set; }
        public List<Datum> data { get; set; }
    }
}
