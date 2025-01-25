using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GST_API_Library.Models.GSTR1A
{
    public class GetB2CSGSTR1AResp
    {
        public List<B2cs> b2cs { get; set; }

    }

    public class B2cs
    {
        public string flag { get; set; }
        public string chksum { get; set; }
        public string sply_ty { get; set; }
        public double diff_percent { get; set; }
        public int rt { get; set; }
        public string typ { get; set; }
        public string etin { get; set; }
        public string pos { get; set; }
        public int txval { get; set; }
        public int iamt { get; set; }
        public int csamt { get; set; }
        public int? camt { get; set; }
        public int? samt { get; set; }
    }
}
