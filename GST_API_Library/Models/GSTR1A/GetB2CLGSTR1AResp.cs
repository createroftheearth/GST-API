using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GST_API_Library.Models.GSTR1A
{
    public class GetB2CLGSTR1AResp
    {

        public List<B2cl> b2cl { get; set; }
    }
    public class B2cl
    {
        public string pos { get; set; }
        public List<InvS> inv { get; set; }
    }

    public class InvS
    {
        public string flag { get; set; }
        public string chksum { get; set; }
        public string inum { get; set; }
        public string idt { get; set; }
        public double val { get; set; }
        public string inv_typ { get; set; }
        public string etin { get; set; }
        public List<Itm> itms { get; set; }
    }

    public class Itm
    {
        public int num { get; set; }
        public ItmDetS itm_det { get; set; }
    }

    public class ItmDetS
    {
        public int rt { get; set; }
        public int txval { get; set; }
        public int iamt { get; set; }
    }

}
