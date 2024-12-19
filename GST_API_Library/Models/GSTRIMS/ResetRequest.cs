using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GST_API_Library.Models.GSTRIMS
{
    public class ResetRequest
    {
        public string rtin { get; set; }
        public string reqtyp { get; set; }
        public Invdata invdata { get; set; }
    }
    public class B2b
    {
        public string stin { get; set; }
        public string inum { get; set; }
        public string inv_typ { get; set; }
        public string srcform { get; set; }
        public string rtnprd { get; set; }
        public string idt { get; set; }
        public int val { get; set; }
        public string pos { get; set; }
        public int txval { get; set; }
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int cess { get; set; }
        public string prev_status { get; set; }
    }

    public class B2ba
    {
        public string stin { get; set; }
        public string inum { get; set; }
        public string oinum { get; set; }
        public string inv_typ { get; set; }
        public string srcform { get; set; }
        public string rtnprd { get; set; }
        public string idt { get; set; }
        public string oidt { get; set; }
        public double val { get; set; }
        public string pos { get; set; }
        public double txval { get; set; }
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int cess { get; set; }
        public string prev_status { get; set; }
    }

    public class B2bcn
    {
        public string stin { get; set; }
        public string nt_num { get; set; }
        public string inv_typ { get; set; }
        public string srcform { get; set; }
        public string rtnprd { get; set; }
        public string nt_dt { get; set; }
        public double val { get; set; }
        public string pos { get; set; }
        public double txval { get; set; }
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int cess { get; set; }
        public string prev_status { get; set; }
    }

    public class B2bcna
    {
        public string stin { get; set; }
        public string ont_num { get; set; }
        public string ont_dt { get; set; }
        public string nt_num { get; set; }
        public string inv_typ { get; set; }
        public string srcform { get; set; }
        public string rtnprd { get; set; }
        public string nt_dt { get; set; }
        public double val { get; set; }
        public string pos { get; set; }
        public double txval { get; set; }
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int cess { get; set; }
        public string prev_status { get; set; }
    }

    public class B2bdn
    {
        public string stin { get; set; }
        public string nt_num { get; set; }
        public string inv_typ { get; set; }
        public string srcform { get; set; }
        public string rtnprd { get; set; }
        public string nt_dt { get; set; }
        public double val { get; set; }
        public string pos { get; set; }
        public double txval { get; set; }
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int cess { get; set; }
        public string prev_status { get; set; }
    }

    public class B2bdna
    {
        public string stin { get; set; }
        public string ont_num { get; set; }
        public string ont_dt { get; set; }
        public string nt_num { get; set; }
        public string inv_typ { get; set; }
        public string srcform { get; set; }
        public string rtnprd { get; set; }
        public string nt_dt { get; set; }
        public double val { get; set; }
        public string pos { get; set; }
        public double txval { get; set; }
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int cess { get; set; }
        public string prev_status { get; set; }
    }

    public class Ecom
    {
        public string stin { get; set; }
        public string rtnprd { get; set; }
        public string inum { get; set; }
        public string srcform { get; set; }
        public string idt { get; set; }
        public int val { get; set; }
        public string pos { get; set; }
        public int txval { get; set; }
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int cess { get; set; }
        public string prev_status { get; set; }
    }

    public class Ecoma
    {
        public string stin { get; set; }
        public string oinum { get; set; }
        public string oidt { get; set; }
        public string rtnprd { get; set; }
        public string inum { get; set; }
        public string srcform { get; set; }
        public string idt { get; set; }
        public int val { get; set; }
        public string pos { get; set; }
        public int txval { get; set; }
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int cess { get; set; }
        public string prev_status { get; set; }
    }

    public class Invdata
    {
        public List<B2b> b2b { get; set; }
        public List<B2ba> b2ba { get; set; }
        public List<B2bdn> b2bdn { get; set; }
        public List<B2bdna> b2bdna { get; set; }
        public List<B2bcn> b2bcn { get; set; }
        public List<B2bcna> b2bcna { get; set; }
        public List<Ecom> ecom { get; set; }
        public List<Ecoma> ecoma { get; set; }
    }

}
