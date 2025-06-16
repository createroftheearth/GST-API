using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GST_API_Library.Models.GSTR2A
{
    public class GetECOMGSTR2A
    {
        public List<Ecom> ecom { get; set; }
    }

    public class Ecom
    {
        public string ctin { get; set; }
        public string cfs { get; set; }
        public string dtcancel { get; set; }
        public string cfs3b { get; set; }
        public string fldtr1 { get; set; }
        public string flprdr1 { get; set; }
        public List<Inv5> inv { get; set; }
    }

    public class Inv5
    {
        public string chksum { get; set; }
        public string inum { get; set; }
        public string idt { get; set; }
        public double val { get; set; }
        public string pos { get; set; }
        public string inv_typ { get; set; }
        public string aspd { get; set; }
        public string atyp { get; set; }
        public string rchrg { get; set; }
        public List<Itm5> itms { get; set; }
    }

    public class Itm5
    {
        public int num { get; set; }
        public ItmDet5 itm_det { get; set; }
    }

    public class ItmDet5
    {
        public int rt { get; set; }
        public double txval { get; set; }
        public int iamt { get; set; }
        public double camt { get; set; }
        public double samt { get; set; }
        public double csamt { get; set; }
    }
}
