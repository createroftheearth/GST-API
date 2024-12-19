using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GST_API_Library.Models.GSTR1A;


namespace Integrated.API.GSTN.GSTR1A
{
    public class GetATGSTR1AResp
    {
        public List<At> at { get; set; }

    }
    public class At
    {
        public string flag { get; set; }
        public string chksum { get; set; }
        public string pos { get; set; }
        public string sply_ty { get; set; }
        public double diff_percent { get; set; }
        public List<Itm> itms { get; set; }
    }

    public class Itm
    {
        public int rt { get; set; }
        public int ad_amt { get; set; }
        public double iamt { get; set; }
        public int csamt { get; set; }
    }
}
