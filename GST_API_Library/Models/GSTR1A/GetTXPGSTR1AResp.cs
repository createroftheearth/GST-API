using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GST_API_Library.Models.GSTR1A;


namespace Integrated.API.GSTN.GSTR1A
{
    public class GetTXPGSTR1AResp
    {
        public List<Txpd> txpd { get; set; }

    }
    public class ItmTXP
    {
        public int rt { get; set; }
        public int ad_amt { get; set; }
        public int iamt { get; set; }
        public int csamt { get; set; }
    }
    public class Txpd
    {
        public string flag { get; set; }
        public string chksum { get; set; }
        public string pos { get; set; }
        public string sply_ty { get; set; }
        public List<ItmTXP> itms { get; set; }
    }


}
