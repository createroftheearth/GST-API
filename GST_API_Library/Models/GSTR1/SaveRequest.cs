using GST_API_Library.Models.GSTR1;
using Integrated.API.GSTN.GSTR1;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GST_API_Library.Models.GSTR1
{
    public class SaveRequest
    {
        public string gstin { get; set; }
        public string fp { get; set; }
        public double gt { get; set; }
        public double cur_gt { get; set; }
        public List<B2b1> b2b { get; set; }
        public List<B2ba1> b2ba { get; set; }
        public List<B2cl1> b2cl { get; set; }
        public List<B2cla1> b2cla { get; set; }
        public List<Cdnr1> cdnr { get; set; }
        public List<Cdnra1> cdnra { get; set; }
        public List<B2cs1> b2cs { get; set; }
        public List<B2csa1> b2csa { get; set; }
        public List<Exp1> exp { get; set; }
        public List<Expa1> expa { get; set; }
        public Hsn2 hsn { get; set; }
        public Nil1 nil { get; set; }
        public List<Txpd1> txpd { get; set; }
        public List<Txpdum1> txpda { get; set; }
        public List<At1> at { get; set; }
        public List<Atum1> ata { get; set; }
        public DocIssue1 doc_issue { get; set; }
        public List<Cdnur1> cdnur { get; set; }
        public List<Cdnura1> cdnura { get; set; }
        public Supeco1 supeco { get; set; }
        public Supecoa1 supecoa { get; set; }
        public Ecom1 ecom { get; set; }
        public Ecoma1 ecoma { get; set; }

    }
    public class At1
    {
        public string pos { get; set; }
        public string sply_ty { get; set; }
        public double? diff_percent { get; set; }
        public List<ItmTxpd> itms { get; set; }
    }

    public class Atum1
    {
        public string omon { get; set; }
        public string pos { get; set; }
        public string sply_ty { get; set; }
        public double? diff_percent { get; set; }
        public List<ItmTxpd> itms { get; set; }
    }

    public class B2b1
    {
        public string? ctin { get; set; }
        public List<InvB2b> inv { get; set; }
        public string? rtin { get; set; }
        public string? stin { get; set; }
    }

    public class InvB2b
    {
        public string inum { get; set; }
        public string idt { get; set; }
        public double val { get; set; }
        public string pos { get; set; }
        public string? rchrg { get; set; }
        public string? etin { get; set; }
        public string inv_typ { get; set; }
        public double? diff_percent { get; set; }
        public List<ItmB2b> itms { get; set; }
        public string? flag { get; set; }
        public string? sply_ty { get; set; }
    }

    public class ItmB2b
    {
        public int num { get; set; }
        public ItmDetB2b itm_det { get; set; }
    }

    public class ItmDetB2b
    {
        public double rt { get; set; }
        public double txval { get; set; }
        public double? iamt { get; set; }
        public double? csamt { get; set; }
        public double? camt { get; set; }
        public double? samt {  get; set; }
    }

    public class B2ba1
    {
        public string ctin { get; set; }
        public List<InvB2ba> inv { get; set; }
        public string? rtin { get; set; }
        public string? stin { get; set; }
    }

    public class InvB2ba
    {
        public string inum { get; set; }
        public string idt { get; set; }
        public double val { get; set; }
        public string pos { get; set; }
        public string rchrg { get; set; }
        public string? etin { get; set; }
        public string inv_typ { get; set; }
        public double? diff_percent { get; set; }
        public List<ItmB2ba> itms { get; set; }
        public string oinum { get; set; }
        public string? flag { get; set; }
        public string oidt { get; set; }
 
    }

    public class ItmB2ba
    {
        public int num { get; set; }
        public ItmDetB2ba itm_det { get; set; }
    }

    public class ItmDetB2ba
    {
        public double rt { get; set; }
        public double txval { get; set; }
        public double? iamt { get; set; }
        public double? csamt { get; set; }
        public double? camt { get; set; }
        public double? samt { get; set; }
    }

    public class B2cs1
    {
        public string sply_ty { get; set; }
        public double? diff_percent { get; set; }
        public int rt { get; set; }
        public string typ { get; set; }
        public string? etin { get; set; }
        public string pos { get; set; }
        public int txval { get; set; }
        public int iamt { get; set; }
        public int csamt { get; set; }
        //public  string flag { get; set; }
    }

    public class B2c2
    {
        public string stin { get; set; }
        public double csamt { get; set; }
        public double samt { get; set; }
        public double rt { get; set; }
        public string flag { get; set; }
        public string pos { get; set; }
        public double txval { get; set; }
        public double camt { get; set; }
        public double iamt { get; set; }
        public string sply_ty { get; set; }
    }

    public class B2ca1
    {
        public string pos { get; set; }
        public List<PosItm> posItms { get; set; }
    }

    public class B2cl1
    {
        public string pos { get; set; }
        public List<InvB2CL> inv { get; set; }
    }

    public class InvB2CL
    {
        public string inum { get; set; }
        public string idt { get; set; }
        public double val { get; set; }
        public List<ItmB2CL> itms { get; set; }
        public string flag { get; set; }
    }

    public class ItmB2CL
    {
        public int num { get; set; }
        public ItmDetB2CL itm_det { get; set; }
    }


    public class ItmDetB2CL
    {
        public int rt { get; set; }
        public int txval { get; set; }
        public int iamt { get; set; }
        public int? csamt { get; set; }
        public double? camt { get; set; }
        public double? samt { get; set; }
    }
    public class B2cla1
    {
        public string pos { get; set; }
        public List<InvB2cla> inv { get; set; }
    }

    public class InvB2cla
    {
        public string inum { get; set; }
        public string idt { get; set; }
        public double val { get; set; }
       public string? flag { get; set; }
        public List<ItmB2cla> itms { get; set; }
        public string oinum { get; set; }
     
        public string oidt { get; set; }
    }

    public class ItmB2cla
    {
        public int num { get; set; }
        public ItmDetB2cla itm_det { get; set; }
    }

    public class ItmDetB2cla
    {
        public double rt { get; set; }
        public double txval { get; set; }
        public double iamt { get; set; }
        public double? csamt { get; set; }
        public double? camt { get; set; }
        public double? samt { get; set; }
    }

    public class B2csa1
    {
        public string omon { get; set; }
        public string sply_ty { get; set; }
        public double? diff_percent { get; set; }
        public string typ { get; set; }
        public string? etin { get; set; }
        public string pos { get; set; }
        public List<ItmB2CSA> itms { get; set; }
        //public string flag { get; set; }
    }

    public class ItmB2CSA
    {
        public int? num { get; set; }
        public int rt { get; set; }
        public int? ad_amt { get; set; }
        public int? iamt { get; set; }
        public int? csamt { get; set; }
        public int? samt { get; set; }
        public int txval { get; set; }
        public int? camt { get; set; }
    }

    public class Cdnr1
    {
        public string ctin { get; set; }
        public List<Nt> nt { get; set; }
    }

    public class Cdnra1
    {
        public string ctin { get; set; }
        public List<Nt> nt { get; set; }
    }

    public class Cdnur1
    {
        public string flag { get; set; }
        public string typ { get; set; }
        public string ntty { get; set; }
        public string nt_num { get; set; }
        public string nt_dt { get; set; }
        public string pos { get; set; }
        public double val { get; set; }
        public double? diff_percent { get; set; }
        public List<ItmCdnur> itms { get; set; }
    }

    public class ItmCdnur
    {
        public int num { get; set; }
        public ItmDet1 itm_det { get; set; }
        
    }

    public class Cdnura1
    {
        public string flag { get; set; }
        public string ont_num { get; set; }
        public string ont_dt { get; set; }
        public string nt_num { get; set; }
        public string nt_dt { get; set; }
        public string ntty { get; set; }
        public string typ { get; set; }
        public string pos { get; set; }
        public double val { get; set; }
        public double? diff_percent { get; set; }
        public List<ItmCdnur> itms { get; set; }
    }

    public class Clttx1
    {
        public string etin { get; set; }
        public decimal suppval { get; set; }
        public decimal igst { get; set; }
        public decimal cgst { get; set; }
        public decimal sgst { get; set; }
        public decimal cess { get; set; }
        public string flag { get; set; }
    }

    public class Clttxa1
    {
        public string oetin { get; set; }
        public string etin { get; set; }
        public int suppval { get; set; }
        public int igst { get; set; }
        public int cgst { get; set; }
        public int sgst { get; set; }
        public int cess { get; set; }
        public string flag { get; set; }
        public string omon { get; set; }
    }

    public class Doc1
    {
        public int num { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public int totnum { get; set; }
        public int cancel { get; set; }
        public int net_issue { get; set; }
    }

    public class DocDet1
    {
        public int doc_num { get; set; }
        public List<Doc1> docs { get; set; }
    }

    public class DocIssue1
    {
        public List<DocDet1> doc_det { get; set; }
    }

    public class Ecom1
    {
        public List<B2b1> b2b { get; set; }
        public List<B2c2> b2c { get; set; }
        public List<Urp2b> urp2b { get; set; }
        public List<Urp2c> urp2c { get; set; }
    }

    public class Ecoma1
    {
        public List<B2ba1> b2ba { get; set; }
        public List<B2ca1> b2ca { get; set; }
        public List<Urp2ba> urp2ba { get; set; }
        public List<Urp2ca> urp2ca { get; set; }
    }

    public class Exp1
    {
        public string exp_typ { get; set; }
        public List<InvExp> inv { get; set; }
    }

    public class InvExp
    {
        public string? flag { get; set; }
        public string inum { get; set; }
        public string idt { get; set; }
        public double val { get; set; }      
        public List<ItmExp> itms { get; set; }       
        public string sbpcode { get; set; }
        public string sbnum { get; set; }
        public string sbdt { get; set; }
    }

    public class ItmExp
    {
        public double txval { get; set; }
        public double? rt { get; set; }
        public double? iamt { get; set; }
        public double csamt { get; set; }
       
    }


    public class Expa1
    {
        public string exp_typ { get; set; }
        public List<InvExpa> inv { get; set; }
    }

    public class InvExpa
    {
        public string? flag { get; set; }
        public string inum { get; set; }
        public string idt { get; set; }
        public string oinum { get; set; }
        public string oidt { get; set; }
        public double val { get; set; }
        public List<ItmExpa> itms { get; set; }
        public string sbpcode { get; set; }
        public string sbnum { get; set; }
        public string sbdt { get; set; }
    }

    public class ItmExpa
    {
        public double txval { get; set; }
        public double? rt { get; set; }
        public double? iamt { get; set; }
        public double csamt { get; set; }
    }

    public class Hsn2
    {
        public List<HsnB2b1> hsn_b2b { get; set; }
        public List<HsnB2c1> hsn_b2c { get; set; }
    }

    public class HsnB2b1
    {
        public int num { get; set; }
        public string hsn_sc { get; set; }
        public string desc { get; set; }
        public string user_desc { get; set; }
        public string uqc { get; set; }
        public double qty { get; set; }
        public double txval { get; set; }
        public double iamt { get; set; }
        public int csamt { get; set; }
        public double rt { get; set; }
    }

    public class HsnB2c1
    {
        public int num { get; set; }
        public string hsn_sc { get; set; }
        public string desc { get; set; }
        public string user_desc { get; set; }
        public string uqc { get; set; }
        public double qty { get; set; }
        public double txval { get; set; }
        public double iamt { get; set; }
        public int csamt { get; set; }
        public double rt { get; set; }
    }

    public class Inv
    {
        public string inum { get; set; }
        public string idt { get; set; }
        public double val { get; set; }
        public string pos { get; set; }
        public string rchrg { get; set; }
        public string etin { get; set; }
        public string inv_typ { get; set; }
        public double diff_percent { get; set; }
        public List<Itm> itms { get; set; }
        public string oinum { get; set; }
        public string flag { get; set; }
        public string oidt { get; set; }
        public string sply_ty { get; set; }
        public string sbpcode { get; set; }
        public string sbnum { get; set; }
        public string sbdt { get; set; }
        public double expt_amt { get; set; }
        public double nil_amt { get; set; }
        public double ngsup_amt { get; set; }
    }

    public class Itm
    {
        public int num { get; set; }
        public ItmDet1 itm_det { get; set; }
        public int rt { get; set; }
        public int ad_amt { get; set; }
        public int iamt { get; set; }
        public int csamt { get; set; }
        public int samt { get; set; }
        public int txval { get; set; }
        public int camt { get; set; }
    }

    public class ItmDet1
    {
        public int rt { get; set; }
        public double txval { get; set; }
        public double iamt { get; set; }
        public double csamt { get; set; }
    }

    public class Nil1
    {
        public List<Inv2> inv { get; set; }
    }

    public class Inv2
    {
       
        public string sply_ty { get; set; }
        public double expt_amt { get; set; }
        public double nil_amt { get; set; }
        public double ngsup_amt { get; set; }
    }

    public class Nt
    {
        public string ntty { get; set; }
        public string nt_num { get; set; }
        public string nt_dt { get; set; }
        public string pos { get; set; }
        public string rchrg { get; set; }
        public string inv_typ { get; set; }
        public int val { get; set; }
        public double diff_percent { get; set; }
        public List<Itm> itms { get; set; }
        public string ont_num { get; set; }
        public string ont_dt { get; set; }
    }

    public class Paytx1
    {
        public string etin { get; set; }
        public decimal suppval { get; set; }
        public decimal igst { get; set; }
        public decimal cgst { get; set; }
        public decimal sgst { get; set; }
        public decimal cess { get; set; }
        public string flag { get; set; }
    }

    public class Paytxa1
    {
        public string oetin { get; set; }
        public string etin { get; set; }
        public int suppval { get; set; }
        public int igst { get; set; }
        public int cgst { get; set; }
        public int sgst { get; set; }
        public int cess { get; set; }
        public string flag { get; set; }
        public string omon { get; set; }
    }

    public class PosItm
    {
        public string flag { get; set; }
        public string omon { get; set; }
        public string sply_ty { get; set; }
        public string stin { get; set; }
        public string ostin { get; set; }
        public List<Itm> itms { get; set; }
    }
    public class Supeco1
    {
        public List<Clttx1> clttx { get; set; }
        public List<Paytx1> paytx { get; set; }
    }

    public class Supecoa1
    {
        public List<Clttxa1> clttxa { get; set; }
        public List<Paytxa1> paytxa { get; set; }
    }

    public class Txpd1
    {
        public string pos { get; set; }
        public string sply_ty { get; set; }
        public double? diff_percent { get; set; }
        public List<ItmTxpd> itms { get; set; }
    }

    public class ItmTxpd
    {
        public int rt { get; set; }
        public int ad_amt { get; set; }
        public int iamt { get; set; }
        public int csamt { get; set; }
        public int? samt { get; set; }
        public int? camt { get; set; }
    }

    public class Txpdum1
    {
        public string omon { get; set; }
        public string pos { get; set; }
        public string sply_ty { get; set; }
        public double? diff_percent { get; set; }
        public List<ItmTxpd> itms { get; set; }
    }

    public class Urp2b
    {
        public List<Inv> inv { get; set; }
        public string rtin { get; set; }
    }

    public class Urp2ba
    {
        public List<InvB2b> inv { get; set; }
        public string rtin { get; set; }
    }

    public class Urp2c
    {
        public double csamt { get; set; }
        public double samt { get; set; }
        public double rt { get; set; }
        public string flag { get; set; }
        public string pos { get; set; }
        public double txval { get; set; }
        public double camt { get; set; }
        public double iamt { get; set; }
        public string sply_ty { get; set; }
    }

    public class Urp2ca
    {
        public List<Itm> itms { get; set; }
        public string flag { get; set; }
        public string pos { get; set; }
        public string omon { get; set; }
        public string sply_ty { get; set; }
    }

}
