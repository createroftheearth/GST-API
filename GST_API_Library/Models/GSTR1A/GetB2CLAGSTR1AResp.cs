using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GST_API_Library.Models.GSTR1A
{
    public class GetB2CLAGSTR1AResp
    {
        public List<B2cla> b2cla { get; set; }

    }
    public class B2cla
    {
        public string pos { get; set; }
        public List<InvSaa> inv { get; set; }
    }

    public class InvSaa
    {
        public string flag { get; set; }
        public string chksum { get; set; }
        public string oinum { get; set; }
        public string oidt { get; set; }
        public string inum { get; set; }
        public string idt { get; set; }
        public double val { get; set; }
        public string inv_typ { get; set; }
        public string etin { get; set; }
        public double diff_percent { get; set; }
        public List<ItmS> itms { get; set; }
    }

    public class ItmS
    {
        public int num { get; set; }
        public ItmDetSa itm_det { get; set; }
    }

    public class ItmDetSa
    {
        public int rt { get; set; }
        public int txval { get; set; }
        public int iamt { get; set; }
    }
}
