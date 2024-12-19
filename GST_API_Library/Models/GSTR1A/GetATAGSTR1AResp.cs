using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GST_API_Library.Models.GSTR1A
{
    public class GetATAGSTR1AResp
    {
        public List<AtA> ata { get; set; }

    }
    public class AtA
    {
        public string flag { get; set; }
        public string chksum { get; set; }
        public string omon { get; set; }
        public string pos { get; set; }
        public string sply_ty { get; set; }
        public double diff_percent { get; set; }
        public List<Itms> itms { get; set; }
    }

    public class Itms
    {
        public int rt { get; set; }
        public int ad_amt { get; set; }
        public double iamt { get; set; }
        public int csamt { get; set; }
    }
}
