using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GST_API_Library.Models.GSTR1A
{
    public class GetB2CSAGSTR1AResp
    {
        public List<B2csa> b2csa { get; set; }

    }
    public class B2csa
    {
        public List<ItmSa> itms { get; set; }
        public string flag { get; set; }
        public string pos { get; set; }
        public string omon { get; set; }
        public string typ { get; set; }
        public string chksum { get; set; }
        public string sply_ty { get; set; }
    }

    public class ItmSa
    {
        public int csamt { get; set; }
        public int rt { get; set; }
        public int txval { get; set; }
        public double iamt { get; set; }
    }
}
