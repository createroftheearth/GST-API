using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GST_API_Library.Models.GSTRIMS;


namespace Integrated.API.GSTN.GSTRIMS
{
    public class GetIMSSUPInvoices
    {
        public string gstin { get; set; }
        public string rtnprd { get; set; }
        public Gstr1 gstr1 { get; set; }
        public Gstr1a gstr1a { get; set; }
    }
    public class B2bSUP
    {
        public string ctin { get; set; }
        public string cfs { get; set; }
        public List<Inv> inv { get; set; }
        public string rtin { get; set; }
        public string stin { get; set; }
    }

    public class B2baSUP
    {
        public string ctin { get; set; }
        public string cfs { get; set; }
        public List<Inv> inv { get; set; }
        public string rtin { get; set; }
        public string stin { get; set; }
    }

    public class Cdnr
    {
        public string ctin { get; set; }
        public string cfs { get; set; }
        public List<Nt> nt { get; set; }
    }

    public class Cdnra
    {
        public string ctin { get; set; }
        public string cfs { get; set; }
        public List<Nt> nt { get; set; }
    }

    public class EcomSUP
    {
        public List<B2b> b2b { get; set; }
        public List<Urp2b> urp2b { get; set; }
    }

    public class EcomaSUP
    {
        public List<B2ba> b2ba { get; set; }
        public List<Urp2ba> urp2ba { get; set; }
    }

    public class Gstr1
    {
        public List<B2bSUP> b2b { get; set; }
        public List<B2baSUP> b2ba { get; set; }
        public List<Cdnr> cdnr { get; set; }
        public List<Cdnra> cdnra { get; set; }
        public EcomSUP ecom { get; set; }
        public EcomaSUP ecoma { get; set; }
    }

    public class Gstr1a
    {
        public List<B2bSUP> b2b { get; set; }
        public List<B2baSUP> b2ba { get; set; }
        public List<Cdnr> cdnr { get; set; }
        public List<Cdnra> cdnra { get; set; }
        public EcomSUP ecom { get; set; }
        public EcomaSUP ecoma { get; set; }
    }

    public class Inv
    {
        public string chksum { get; set; }
        public string updby { get; set; }
        public string inum { get; set; }
        public string idt { get; set; }
        public double val { get; set; }
        public string pos { get; set; }
        public string rchrg { get; set; }
        public string etin { get; set; }
        public string inv_typ { get; set; }
        public string flag { get; set; }
        public string cflag { get; set; }
        public double diff_percent { get; set; }
        public string opd { get; set; }
        public string srctyp { get; set; }
        public string irn { get; set; }
        public string irngendate { get; set; }
        public string imsactn { get; set; }
        public string remarks { get; set; }
        public List<Itm> itms { get; set; }
        public string sply_ty { get; set; }
        public string oinum { get; set; }
        public string oidt { get; set; }
    }

    public class Itm
    {
        public int num { get; set; }
        public ItmDet itm_det { get; set; }
    }

    public class ItmDet
    {
        public int rt { get; set; }
        public int txval { get; set; }
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
    }

    public class Nt
    {
        public string chksum { get; set; }
        public string cflag { get; set; }
        public string updby { get; set; }
        public string ntty { get; set; }
        public string nt_num { get; set; }
        public string nt_dt { get; set; }
        public string p_gst { get; set; }
        public string inum { get; set; }
        public string idt { get; set; }
        public int val { get; set; }
        public string opd { get; set; }
        public string pos { get; set; }
        public string rchrg { get; set; }
        public string inv_typ { get; set; }
        public string d_flag { get; set; }
        public string flag { get; set; }
        public string srctyp { get; set; }
        public string irn { get; set; }
        public string irngendate { get; set; }
        public string imsactn { get; set; }
        public string remarks { get; set; }
        public List<Itm> itms { get; set; }
        public string ont_num { get; set; }
        public string ont_dt { get; set; }
    }
    public class Urp2b
    {
        public List<Inv> inv { get; set; }
        public string rtin { get; set; }
    }

    public class Urp2ba
    {
        public List<Inv> inv { get; set; }
        public string rtin { get; set; }
    }



}
