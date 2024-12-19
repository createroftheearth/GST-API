using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GST_API_Library.Models.GSTR1A
{
    public class GetB2BAGSTR1AResp
    {
        public List<B2ba> b2ba { get; set; }

    }
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class B2ba
    {
        public string ctin { get; set; }
        public string cfs { get; set; }
        public List<Inv1> inv { get; set; }
    }

    public class Inv1
    {
        public string chksum { get; set; }
        public string updby { get; set; }
        public string cflag { get; set; }
        public string oinum { get; set; }
        public string oidt { get; set; }
        public string inum { get; set; }
        public string idt { get; set; }
        public double val { get; set; }
        public string pos { get; set; }
        public string rchrg { get; set; }
        public string etin { get; set; }
        public string inv_typ { get; set; }
        public string opd { get; set; }
        public List<Itm1> itms { get; set; }
    }

    public class Itm1
    {
        public int num { get; set; }
        public ItmDet1 itm_det { get; set; }
    }

    public class ItmDet1
    {
        public int rt { get; set; }
        public int txval { get; set; }
        public double iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
    }
}
