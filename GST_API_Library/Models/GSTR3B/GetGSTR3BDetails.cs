using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using GST_API_Library.Models.GSTR3B;
using System.Text.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.Globalization;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;
using System.Text.Json.Serialization;

namespace GST_API_Library.Models.GSTR3B
{
    public class GetGSTR3BDetails
    {
        public string gstin { get; set; }
        public string ret_period { get; set; }
        public SupDetails sup_details { get; set; }
        public InterSup inter_sup { get; set; }
        public EcoDtls eco_dtls { get; set; }
        public ItcElg itc_elg { get; set; }
        public InwardSup inward_sup { get; set; }
        public TxPmt tx_pmt { get; set; }
        public IntrLtfee intr_ltfee { get; set; }
        public List<LiabBreakup> liab_breakup { get; set; }
    }



    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Adjnegliab
    {
        public double trans_typ { get; set; }
        public string tran_desc { get; set; }
        public double liab_ldg_id { get; set; }
        public Sgst sgst { get; set; }
        public Cgst cgst { get; set; }
        public Cess cess { get; set; }
        public Igst igst { get; set; }
    }

    public class Cess
    {
        public double intr { get; set; }
        public double tx { get; set; }
    }

    public class Cgst
    {
        public double intr { get; set; }
        public double tx { get; set; }
        public double fee { get; set; }
    }

    public class CompDetail
    {
        public string pos { get; set; }
        public double txval { get; set; }
        public double iamt { get; set; }
    }

    public class EcoDtls
    {
        public EcoSup eco_sup { get; set; }
        public EcoRegSup eco_reg_sup { get; set; }
    }

    public class EcoRegSup
    {
        public double txval { get; set; }
    }

    public class EcoSup
    {
        public double txval { get; set; }
        public double iamt { get; set; }
        public double camt { get; set; }
        public double samt { get; set; }
        public double csamt { get; set; }
    }

    public class Igst
    {
        public double intr { get; set; }
        public double tx { get; set; }
    }

    public class InterSup
    {
        public List<UnregDetail> unreg_details { get; set; }
        public List<CompDetail> comp_details { get; set; }
        public List<UinDetail> uin_details { get; set; }
    }

    public class IntrDetails
    {
        public double iamt { get; set; }
        public double camt { get; set; }
        public double samt { get; set; }
        public double csamt { get; set; }
    }

    public class IntrLtfee
    {
        public IntrDetails intr_details { get; set; }
        public LtfeeDetails ltfee_details { get; set; }
    }

    public class InwardSup
    {
        public List<IsupDetail> isup_details { get; set; }
    }

    public class IsupDetail
    {
        public string ty { get; set; }
        public double inter { get; set; }
        public double intra { get; set; }
    }

    public class IsupRev
    {
        public double txval { get; set; }
        public double iamt { get; set; }
        public double camt { get; set; }
        public double samt { get; set; }
        public double csamt { get; set; }
    }

    public class ItcAvl
    {
        public string ty { get; set; }
        public double iamt { get; set; }
        public double camt { get; set; }
        public double samt { get; set; }
        public double csamt { get; set; }
    }

    public class ItcElg
    {
        public List<ItcAvl> itc_avl { get; set; }
        public List<ItcRev> itc_rev { get; set; }
        public ItcNet itc_net { get; set; }
        public List<ItcInelg> itc_inelg { get; set; }
    }

    public class ItcInelg
    {
        public string ty { get; set; }
        public double iamt { get; set; }
        public double camt { get; set; }
        public double samt { get; set; }
        public double csamt { get; set; }
    }

    public class ItcNet
    {
        public double iamt { get; set; }
        public double camt { get; set; }
        public double samt { get; set; }
        public double csamt { get; set; }
    }

    public class ItcRev
    {
        public string ty { get; set; }
        public double iamt { get; set; }
        public double camt { get; set; }
        public double samt { get; set; }
        public double csamt { get; set; }
    }

    public class LiabBreakup
    {
        public string ret_period { get; set; }
        public Liability liability { get; set; }
    }

    public class Liability
    {
        public double iamt { get; set; }
        public double camt { get; set; }
        public double samt { get; set; }
        public double csamt { get; set; }
    }

    public class LtfeeDetails
    {
        public double camt { get; set; }
        public double samt { get; set; }
    }

    public class Nettaxpay
    {
        public double trans_typ { get; set; }
        public string tran_desc { get; set; }
        public double liab_ldg_id { get; set; }
        public Sgst sgst { get; set; }
        public Cgst cgst { get; set; }
        public Cess cess { get; set; }
        public Igst igst { get; set; }
    }

    public class OsupDet
    {
        public double txval { get; set; }
        public double? iamt { get; set; }
        public double? camt { get; set; }
        public double? samt { get; set; }
        public double? csamt { get; set; }
    }

    public class OsupNilExmp
    {
        public double txval { get; set; }
    }

    public class OsupNongst
    {
        public double txval { get; set; }
    }

    public class OsupZero
    {
        public double txval { get; set; }
        public double iamt { get; set; }
        public double csamt { get; set; }
    }

    public class Pdcash
    {
        public double liab_ldg_id { get; set; }
        public double trans_typ { get; set; }
        public double ipd { get; set; }
        public double cpd { get; set; }
        public double spd { get; set; }
        public double cspd { get; set; }
        public double i_intrpd { get; set; }
        public double c_intrpd { get; set; }
        public double s_intrpd { get; set; }
        public double cs_intrpd { get; set; }
        public double c_lfeepd { get; set; }
        public double s_lfeepd { get; set; }
    }

    public class Pditc
    {
        public double liab_ldg_id { get; set; }
        public double trans_typ { get; set; }
        public double i_pdi { get; set; }
        public double i_pdc { get; set; }
        public double i_pds { get; set; }
        public double c_pdi { get; set; }
        public double c_pdc { get; set; }
        public double s_pdi { get; set; }
        public double s_pds { get; set; }
        public double cs_pdcs { get; set; }
    }

    public class Pdnl
    {
        public double trans_typ { get; set; }
        public string tran_desc { get; set; }
        public double liab_ldg_id { get; set; }
        public double ipd { get; set; }
        public double spd { get; set; }
        public double cpd { get; set; }
        public double cspd { get; set; }
    }
    public class Sgst
    {
        public double intr { get; set; }
        public double tx { get; set; }
        public double fee { get; set; }
    }

    public class SupDetails
    {
        public OsupDet osup_det { get; set; }
        public OsupZero osup_zero { get; set; }
        public OsupNilExmp osup_nil_exmp { get; set; }
        public IsupRev isup_rev { get; set; }
        public OsupNongst osup_nongst { get; set; }
    }

    public class TxPmt
    {
        public List<TxPy> tx_py { get; set; }
        public List<Adjnegliab> adjnegliab { get; set; }
        public List<Nettaxpay> nettaxpay { get; set; }
        public List<Pdcash> pdcash { get; set; }
        public Pditc pditc { get; set; }
        public List<Pdnl> pdnls { get; set; }
    }

    public class TxPy
    {
        public double trans_typ { get; set; }
        public string tran_desc { get; set; }
        public double liab_ldg_id { get; set; }
        public Sgst sgst { get; set; }
        public Cgst cgst { get; set; }
        public Cess cess { get; set; }
        public Igst igst { get; set; }
    }

    public class UinDetail
    {
        public string pos { get; set; }
        public double txval { get; set; }
        public double iamt { get; set; }
    }

    public class UnregDetail
    {
        public string pos { get; set; }
        public double txval { get; set; }
        public double iamt { get; set; }
    }
}


//using Newtonsoft.Json;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace GST_API_Library.Models.GSTR3B
//{
//    //need to ask wit himanshu
//    public class GetGSTR3BDetails
//    {
//        public string gstin { get; set; }
//        public string ret_period { get; set; }
//        public SupDetails sup_details { get; set; }
//        public InterSup inter_sup { get; set; }
//        public EcoDtls eco_dtls { get; set; }
//        public ItcElg itc_elg { get; set; }
//        public InwardSup inward_sup { get; set; }
//        public TxPmt tx_pmt { get; set; }
//        public IntrLtfee intr_ltfee { get; set; }
//        public List<LiabBreakup> liab_breakup { get; set; }
//    }
//    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
//    public class Cess
//    {
//        public int intr { get; set; }
//        public int tx { get; set; }
//    }

//    public class Cgst
//    {
//        public int intr { get; set; }
//        public int tx { get; set; }
//        public int fee { get; set; }
//    }

//    public class CompDetail
//    {
//        public string pos { get; set; }
//        public int txval { get; set; }
//        public int iamt { get; set; }
//    }

//    public class EcoDtls
//    {
//        public EcoSup eco_sup { get; set; }
//        public EcoRegSup eco_reg_sup { get; set; }
//    }

//    public class EcoRegSup
//    {
//        public int txval { get; set; }
//    }

//    public class EcoSup
//    {
//        public int txval { get; set; }
//        public int iamt { get; set; }
//        public int camt { get; set; }
//        public int samt { get; set; }
//        public int csamt { get; set; }
//    }

//    public class Igst
//    {
//        public int intr { get; set; }
//        public int tx { get; set; }
//    }

//    public class InterSup
//    {
//        public List<UnregDetail> unreg_details { get; set; }
//        public List<CompDetail> comp_details { get; set; }
//        public List<UinDetail> uin_details { get; set; }
//    }

//    public class IntrDetails
//    {
//        public int iamt { get; set; }
//        public int camt { get; set; }
//        public int samt { get; set; }
//        public int csamt { get; set; }
//    }

//    public class IntrLtfee
//    {
//        public IntrDetails intr_details { get; set; }
//        public LtfeeDetails ltfee_details { get; set; }
//    }

//    public class InwardSup
//    {
//        public List<IsupDetail> isup_details { get; set; }
//    }

//    public class IsupDetail
//    {
//        public string ty { get; set; }
//        public int inter { get; set; }
//        public int intra { get; set; }
//    }

//    public class IsupRev
//    {
//        public int txval { get; set; }
//        public int iamt { get; set; }
//        public int camt { get; set; }
//        public int samt { get; set; }
//        public int csamt { get; set; }
//    }

//    public class ItcAvl
//    {
//        public string ty { get; set; }
//        public double iamt { get; set; }
//        public int camt { get; set; }
//        public double samt { get; set; }
//        public int csamt { get; set; }
//    }

//    public class ItcElg
//    {
//        public List<ItcAvl> itc_avl { get; set; }
//        public List<ItcRev> itc_rev { get; set; }
//        public ItcNet itc_net { get; set; }

//        [JsonProperty(" itc_inelg")]
//        public List<ItcInelg> itc_inelg { get; set; }
//    }

//    public class ItcInelg
//    {
//        public string ty { get; set; }
//        public double iamt { get; set; }
//        public int camt { get; set; }
//        public double samt { get; set; }
//        public int csamt { get; set; }
//    }

//    public class ItcNet
//    {
//        public double iamt { get; set; }
//        public int camt { get; set; }
//        public double samt { get; set; }
//        public int csamt { get; set; }
//    }

//    public class ItcRev
//    {
//        public string ty { get; set; }
//        public double iamt { get; set; }
//        public int camt { get; set; }
//        public double samt { get; set; }
//        public int csamt { get; set; }
//    }

//    public class LiabBreakup
//    {
//        public string ret_period { get; set; }
//        public Liability liability { get; set; }
//    }

//    public class Liability
//    {
//        public int iamt { get; set; }
//        public int camt { get; set; }
//        public int samt { get; set; }
//        public int csamt { get; set; }
//    }

//    public class LtfeeDetails
//    {
//        public int camt { get; set; }
//        public int samt { get; set; }
//    }

//    public class OsupDet
//    {
//        public int txval { get; set; }
//        public int iamt { get; set; }
//        public int camt { get; set; }
//        public int samt { get; set; }
//        public int csamt { get; set; }
//    }

//    public class OsupNilExmp
//    {
//        public int txval { get; set; }
//    }

//    public class OsupNongst
//    {
//        public int txval { get; set; }
//    }

//    public class OsupZero
//    {
//        public int txval { get; set; }
//        public int iamt { get; set; }
//        public int csamt { get; set; }
//    }

//    public class Pd_cash
//    {
//        public int liab_ldg_id { get; set; }
//        public int trans_typ { get; set; }
//        public int ipd { get; set; }
//        public int cpd { get; set; }
//        public int spd { get; set; }
//        public int cspd { get; set; }
//        public int i_intrpd { get; set; }
//        public int c_intrpd { get; set; }
//        public int s_intrpd { get; set; }
//        public int cs_intrpd { get; set; }
//        public int c_lfeepd { get; set; }
//        public int s_lfeepd { get; set; }
//    }

//    public class Pd_itc
//    {
//        public int liab_ldg_id { get; set; }
//        public int trans_typ { get; set; }
//        public int i_pdi { get; set; }
//        public int i_pdc { get; set; }
//        public int i_pds { get; set; }
//        public int c_pdi { get; set; }
//        public int c_pdc { get; set; }
//        public int s_pdi { get; set; }
//        public int s_pds { get; set; }
//        public int cs_pdcs { get; set; }
//    }


//    public class Sgst
//    {
//        public int intr { get; set; }
//        public int tx { get; set; }
//        public int fee { get; set; }
//    }

//    public class SupDetails
//    {
//        public OsupDet osup_det { get; set; }
//        public OsupZero osup_zero { get; set; }
//        public OsupNilExmp osup_nil_exmp { get; set; }
//        public IsupRev isup_rev { get; set; }
//        public OsupNongst osup_nongst { get; set; }
//    }

//    //need to ask wit himanshu
//    public class TxPmt
//    {
//        public List<TxPy> tx_py { get; set; }
//        public List<Pd_cash> pdcash { get; set; }
//        public Pd_itc pditc { get; set; }
//    }

//    public class TxPy
//    {
//        public int trans_typ { get; set; }
//        public string trans_desc { get; set; }
//        public int liab_ldg_id { get; set; }
//        public Sgst sgst { get; set; }
//        public Cgst cgst { get; set; }
//        public Cess cess { get; set; }
//        public Igst igst { get; set; }
//    }

//    public class UinDetail
//    {
//        public string pos { get; set; }
//        public int txval { get; set; }
//        public int iamt { get; set; }
//    }

//    public class UnregDetail
//    {
//        public string pos { get; set; }
//        public int txval { get; set; }
//        public int iamt { get; set; }
//    }


//}
