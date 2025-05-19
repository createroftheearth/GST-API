using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GST_API_Library.Models.GSTR2A
{
    public class GetISDCreditGSTR2A
    {
        public List<Isd> isd { get; set; }
    }
    public class Doclist
    {
        public string chksum { get; set; }
        public string isd_docty { get; set; }
        public string docnum { get; set; }
        public string docdt { get; set; }
        public string itc_elg { get; set; }
        public string aspd { get; set; }
        public string atyp { get; set; }
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int cess { get; set; }
    }

    public class Isd
    {
        public string ctin { get; set; }
        public string cfs { get; set; }
        public List<Doclist> doclist { get; set; }
    }

}
