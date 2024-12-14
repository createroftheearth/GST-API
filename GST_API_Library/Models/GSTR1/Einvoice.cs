using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using GST_API_Library.Models.GSTR1;

namespace Integrated.API.GSTN.GSTR1
{
    public class Einvoice
    {
        public string gstin { get; set; }
        public string fp { get; set; }
        public List<b2b> b2b { get; set; }
        public List<cdnur> cdnur { get; set; }
        public List<exp> exp { get; set; }
        public List<cdnr> cdnr { get; set; }
    }

    public class b2b
    {
        public string ctin { get; set; }
        public string trdname { get; set; }
        public List<inv> inv { get; set; }
    }

    public class inv
    {
        public string chksum { get; set; }
        public string inum { get; set; }
        public string idt { get; set; }
        public double val { get; set; }
        public string pos { get; set; }
        public string rchrg { get; set; }
        public string etin { get; set; }
        public string inv_typ { get; set; }
        public string srctyp { get; set; }
        public string irn { get; set; }
        public string irngendate { get; set; }
        public string einvstatus { get; set; }
        public string autodft { get; set; }
        public string autodftdt { get; set; }
        public string errorCd { get; set; }
        public string errorMsg { get; set; }
        public List<itms> itms { get; set; }
        public string sbpcode { get; set; }
        public string sbnum { get; set; }
        public string sbdt { get; set; }
    }

    public class itms
    {
        public int num { get; set; }
        public List<itm_det> itm_det { get; set; }

    }

    public class itm_det
    {
        public int rt { get; set; }
        public int txval { get; set; }
        public double iamt { get; set; }
        public int camt { get; set; }
        public double samt { get; set; }
        public int csamt { get; set; }
    }

    public class cdnur
    {
        public string chksum { get; set; }
        public string typ { get; set; }
        public string ntty { get; set; }
        public string nt_num { get; set; }
        public string nt_dt { get; set; }
        public int val { get; set; }
        public string pos { get; set; }
        public string srctyp { get; set; }
        public string irn { get; set; }
        public string irngendate { get; set; }
        public string einvstatus { get; set; }
        public string autodft { get; set; }
        public string autodftdt { get; set; }
        public string errorCd { get; set; }
        public string errorMsg { get; set; }
        public List<itms> itms { get; set; }
    }

    public class exp
    {
        public string exp_typ { get; set; }
        public List<inv> inv { get; set; }
    }

    public class cdnr
    {
        public string ctin { get; set; }
        public string trdname { get; set; }
        public List<nt> nt { get; set; }
    }

    public class nt
    {
        public string chksum { get; set; }
        public string ntty { get; set; }
        public string nt_num { get; set; }
        public string nt_dt { get; set; }
        public int val { get; set; }
        public string pos { get; set; }
        public string rchrg { get; set; }
        public string inv_typ { get; set; }
        public string srctyp { get; set; }
        public string irn { get; set; }
        public string irngendate { get; set; }
        public string einvstatus { get; set; }
        public string autodft { get; set; }
        public string autodftdt { get; set; }
        public string errorCd { get; set; }
        public string errorMsg { get; set; }
        public List<itms> itms { get; set; }
    }
}
