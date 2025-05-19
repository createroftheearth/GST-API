using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GST_API_Library.Models.GSTRIMS;


namespace Integrated.API.GSTN.GSTRIMS
{
    public class SaveRequestIMS
    {
        public string rtin { get; set; }
        public string reqtyp { get; set; }
        public Invdata invdata { get; set; }

    }

    public class B2bIMS
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

    public class B2baIMS
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

    public class B2bcnIMS
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

    public class B2bcnaIMS
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

    public class B2bdnIMS
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

    public class B2bdnaIMS
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

    public class EcomIMS
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

    public class EcomaIMS
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

    public class ImpgIMS
    {
        public string rgstinrefId { get; set; }
        public string ispendactblocked { get; set; }
        public string irefdt { get; set; }
        public string itcprd { get; set; }
        public string portcd { get; set; }
        public string boenum { get; set; }
        public string boedt { get; set; }
        public string action { get; set; }
        public int txval { get; set; }
        public int igst { get; set; }
        public int cess { get; set; }
        public string srtinprd { get; set; }
        public string hash { get; set; }
    }

    public class ImpgaIMS
    {
        public string rgstinrefId { get; set; }
        public string ispendactblocked { get; set; }
        public string irefdt { get; set; }
        public string itcprd { get; set; }
        public string portcd { get; set; }
        public string boenum { get; set; }
        public string boedt { get; set; }
        public string action { get; set; }
        public int txval { get; set; }
        public int igst { get; set; }
        public int cess { get; set; }
        public string srtinprd { get; set; }
        public string hash { get; set; }
    }

    public class ImpgsezIMS
    {
        public string rgstinrefId { get; set; }
        public string ispendactblocked { get; set; }
        public string irefdt { get; set; }
        public string itcprd { get; set; }
        public string portcd { get; set; }
        public string boenum { get; set; }
        public string boedt { get; set; }
        public string action { get; set; }
        public int txval { get; set; }
        public int igst { get; set; }
        public int cess { get; set; }
        public string srtinprd { get; set; }
        public string hash { get; set; }
    }

    public class ImpgsezaIMS
    {
        public string rgstinrefId { get; set; }
        public string ispendactblocked { get; set; }
        public string irefdt { get; set; }
        public string itcprd { get; set; }
        public string portcd { get; set; }
        public string boenum { get; set; }
        public string boedt { get; set; }
        public string action { get; set; }
        public int txval { get; set; }
        public int igst { get; set; }
        public int cess { get; set; }
        public string srtinprd { get; set; }
        public string hash { get; set; }
    }

    public class Invdata
    {
        public List<B2bIMS> b2b { get; set; }
        public List<B2baIMS> b2ba { get; set; }
        public List<B2bdnIMS> b2bdn { get; set; }
        public List<B2bdnaIMS> b2bdna { get; set; }
        public List<B2bcnIMS> b2bcn { get; set; }
        public List<B2bcnaIMS> b2bcna { get; set; }
        public List<EcomIMS> ecom { get; set; }
        public List<EcomaIMS> ecoma { get; set; }
        public List<ImpgIMS> impg { get; set; }
        public List<ImpgaIMS> impga { get; set; }
        public List<ImpgsezIMS> impgsez { get; set; }
        public List<ImpgsezaIMS> impgseza { get; set; }
    }
}
