using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GST_API_Library.Models.GSTR2A
{
    public class GetB2BGSTR2A
    {
        public List<B2b> b2b { get; set; }
    }
    public class B2b
    {
        public string ctin { get; set; }
        public string cfs { get; set; }
        public string dtcancel { get; set; }
        public string cfs3b { get; set; }
        public string fldtr1 { get; set; }
        public string flprdr1 { get; set; }
        public List<Inv> inv { get; set; }
    }

    public class Inv
    {
        public string chksum { get; set; }
        public string inum { get; set; }
        public string idt { get; set; }
        public double val { get; set; }
        public string pos { get; set; }
        public string rchrg { get; set; }
        public string inv_typ { get; set; }
        public double diff_percent { get; set; }
        public string aspd { get; set; }
        public string atyp { get; set; }
        public string srctyp { get; set; }
        public string irn { get; set; }
        public string irngendate { get; set; }
        public List<Itm> itms { get; set; }
    }

    public class Itm
    {
        public int num { get; set; }
        public ItmDet2 itm_det { get; set; }
    }

    public class ItmDet2
    {
        public int rt { get; set; }
        public double txval { get; set; }
        public int iamt { get; set; }
        public double camt { get; set; }
        public double samt { get; set; }
        public double csamt { get; set; }
    }

}
