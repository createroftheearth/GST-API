using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GST_API_Library.Models.GSTR1A
{
    public class GetB2BGSTR1AResp
    {
        public List<B2b> b2b { get; set; }

    }
    public class B2b
    {
        public string ctin { get; set; }
        public string cfs { get; set; }
        public List<Inv> inv { get; set; }
    }

    public class Inv
    {
        public string chksum { get; set; }
        public string updby { get; set; }
        public string inum { get; set; }
        public string idt { get; set; }
        public double val { get; set; }
        public string pos { get; set; }
        public string rchrg { get; set; }
        public string etin { get; set; }
        public string inv_typ { get; set; }
        public string cflag { get; set; }
        public double diff_percent { get; set; }
        public string opd { get; set; }
        public string srctyp { get; set; }
        public string irn { get; set; }
        public string irngendate { get; set; }
        public List<Itm2> itms { get; set; }
    }

    public class Itm2
    {
        public int num { get; set; }
        public ItmDet itm_det { get; set; }
    }

    public class ItmDet
    {
        public int rt { get; set; }
        public int txval { get; set; }
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
    }
}
