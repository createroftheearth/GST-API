using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GST_API_Library.Models.GSTR2A
{
    public class GetCDNAInvGSTR2A
    {
        public List<Cdna> cdna { get; set; }
    }

    public class Cdna
    {
        public string ctin { get; set; }
        public string cfs { get; set; }
        public string dtcancel { get; set; }
        public string cfs3b { get; set; }
        public string fldtr1 { get; set; }
        public string flprdr1 { get; set; }
        public List<Nt1> nt { get; set; }
    }

    public class Itm4
    {
        public int num { get; set; }
        public ItmDet4 itm_det { get; set; }
    }

    public class ItmDet4
    {
        public double rt { get; set; }
        public double txval { get; set; }
        public int iamt { get; set; }
        public double camt { get; set; }
        public double samt { get; set; }
        public double csamt { get; set; }
    }

    public class Nt1
    {
        public string chksum { get; set; }
        public string ntty { get; set; }
        public string nt_num { get; set; }
        public string nt_dt { get; set; }
        public string ont_num { get; set; }
        public string ont_dt { get; set; }
        public string p_gst { get; set; }
        public string inum { get; set; }
        public string idt { get; set; }
        public double val { get; set; }
        public double diff_percent { get; set; }
        public string d_flag { get; set; }
        public string pos { get; set; }
        public string rchrg { get; set; }
        public string inv_typ { get; set; }
        public string aspd { get; set; }
        public string atyp { get; set; }
        public List<Itm> itms { get; set; }
    }
}
