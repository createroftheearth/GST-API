using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GST_API_Library.Models.GSTRIMS;


namespace Integrated.API.GSTN.GSTRIMS
{
    public class GetIMSInvoices
    {
        public List<B2bIMS1> b2b { get; set; }
        public List<B2baIMS1> b2ba { get; set; }
        public List<B2bdnIMS1> b2bdn { get; set; }
        public List<B2bdnaIMS1> b2bdna { get; set; }
        public List<B2bcnIMS1> b2bcn { get; set; }
        public List<B2bcnaIMS1> b2bcna { get; set; }
        public List<EcomIMS1> ecom { get; set; }
        public List<EcomaIMS1> ecoma { get; set; }
        public List<ImpgIMS1> impg { get; set; }
        public List<ImpgaIMS1> impga { get; set; }
        public List<ImpgsezIMS1> impgsez { get; set; }
        public List<ImpgsezaIMS1> impgseza { get; set; }

    }

    public class B2bIMS1
    {
        public string stin { get; set; }
        public string inum { get; set; }
        public string inv_typ { get; set; }
        public string action { get; set; }
        public string ispendactnallwd { get; set; }
        public string srcform { get; set; }
        public string rtnprd { get; set; }
        public string srcfilstatus { get; set; }
        public string idt { get; set; }
        public int val { get; set; }
        public string pos { get; set; }
        public int txval { get; set; }
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int cess { get; set; }
        public string hash { get; set; }
    }

    public class B2baIMS1
    {
        public string oinum { get; set; }
        public string oidt { get; set; }
        public string stin { get; set; }
        public string rtnprd { get; set; }
        public string inum { get; set; }
        public string action { get; set; }
        public string ispendactnallwd { get; set; }
        public string inv_typ { get; set; }
        public string srcform { get; set; }
        public string idt { get; set; }
        public int val { get; set; }
        public string pos { get; set; }
        public int txval { get; set; }
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int cess { get; set; }
        public string srcfilstatus { get; set; }
        public string hash { get; set; }
    }

    public class B2bcnIMS1
    {
        public string stin { get; set; }
        public string nt_num { get; set; }
        public string action { get; set; }
        public string inv_typ { get; set; }
        public string srcform { get; set; }
        public string rtnprd { get; set; }
        public string ispendactnallwd { get; set; }
        public string nt_dt { get; set; }
        public double val { get; set; }
        public string pos { get; set; }
        public double txval { get; set; }
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int cess { get; set; }
        public string srcfilstatus { get; set; }
        public string hash { get; set; }
    }

    public class B2bcnaIMS1
    {
        public string stin { get; set; }
        public string ont_num { get; set; }
        public string ont_dt { get; set; }
        public string nt_num { get; set; }
        public string action { get; set; }
        public string inv_typ { get; set; }
        public string srcform { get; set; }
        public string ispendactnallwd { get; set; }
        public string rtnprd { get; set; }
        public string nt_dt { get; set; }
        public double val { get; set; }
        public string pos { get; set; }
        public double txval { get; set; }
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int cess { get; set; }
        public string srcfilstatus { get; set; }
        public string hash { get; set; }
    }

    public class B2bdnIMS1
    {
        public string stin { get; set; }
        public string nt_num { get; set; }
        public string action { get; set; }
        public string inv_typ { get; set; }
        public string srcform { get; set; }
        public string ispendactnallwd { get; set; }
        public string rtnprd { get; set; }
        public string nt_dt { get; set; }
        public double val { get; set; }
        public string pos { get; set; }
        public double txval { get; set; }
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int cess { get; set; }
        public string srcfilstatus { get; set; }
        public string hash { get; set; }
    }

    public class B2bdnaIMS1
    {
        public string stin { get; set; }
        public string ont_num { get; set; }
        public string ont_dt { get; set; }
        public string nt_num { get; set; }
        public string action { get; set; }
        public string inv_typ { get; set; }
        public string srcform { get; set; }
        public string ispendactnallwd { get; set; }
        public string rtnprd { get; set; }
        public string nt_dt { get; set; }
        public double val { get; set; }
        public string pos { get; set; }
        public double txval { get; set; }
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int cess { get; set; }
        public string srcfilstatus { get; set; }
        public string hash { get; set; }
    }

    public class EcomIMS1
    {
        public string stin { get; set; }
        public string rtnprd { get; set; }
        public string inum { get; set; }
        public string action { get; set; }
        public string srcform { get; set; }
        public string ispendactnallwd { get; set; }
        public string idt { get; set; }
        public int val { get; set; }
        public string pos { get; set; }
        public int txval { get; set; }
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int cess { get; set; }
        public string srcfilstatus { get; set; }
        public string hash { get; set; }
    }

    public class EcomaIMS1
    {
        public string stin { get; set; }
        public string oinum { get; set; }
        public string oidt { get; set; }
        public string rtnprd { get; set; }
        public string inum { get; set; }
        public string action { get; set; }
        public string srcform { get; set; }
        public string ispendactnallwd { get; set; }
        public string idt { get; set; }
        public int val { get; set; }
        public string pos { get; set; }
        public int txval { get; set; }
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int cess { get; set; }
        public string srcfilstatus { get; set; }
        public string hash { get; set; }
    }

    public class ImpgIMS1
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

    public class ImpgaIMS1
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

    public class ImpgsezIMS1
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

    public class ImpgsezaIMS1
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

}
