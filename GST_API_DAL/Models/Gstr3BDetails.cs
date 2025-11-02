namespace GST_API_DAL.Models
{
    public class Gstr3BDetails
    {
        public string gstin { get; set; }
        public string ret_period { get; set; }


        public string isnil { get; set; }
        public SupDetails44 sup_details { get; set; }
        public InterSup44 inter_sup { get; set; }
        public EcoDtls44 eco_dtls { get; set; }
        public ItcElg44 itc_elg { get; set; }
        public InwardSup44 inward_sup { get; set; }
        public TxPmt44 tx_pmt { get; set; }
        public IntrLtfee44 intr_ltfee { get; set; }
        public List<LiabBreakup44> liab_breakup { get; set; }
    }



    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Adjnegliab44
    {
        public double trans_typ { get; set; }
        public string trans_desc { get; set; }
        public double liab_ldg_id { get; set; }
        public Sgst44 sgst { get; set; }
        public Cgst44 cgst { get; set; }
        public Cess44 cess { get; set; }
        public Igst44 igst { get; set; }
    }

    public class Cess44
    {
        public double intr { get; set; }
        public double tx { get; set; }
    }

    public class Cgst44
    {
        public double intr { get; set; }
        public double tx { get; set; }
        public double fee { get; set; }
    }

    public class CompDetail44
    {
        public string pos { get; set; }
        public double txval { get; set; }
        public double iamt { get; set; }
    }

    public class EcoDtls44
    {
        public EcoSup44 eco_sup { get; set; }
        public EcoRegSup44 eco_reg_sup { get; set; }
    }

    public class EcoRegSup44
    {
        public double txval { get; set; }
    }

    public class EcoSup44
    {
        public double txval { get; set; }
        public double iamt { get; set; }
        public double camt { get; set; }
        public double samt { get; set; }
        public double csamt { get; set; }
    }

    public class Igst44
    {
        public double intr { get; set; }
        public double tx { get; set; }
    }

    public class InterSup44
    {
        public List<UnregDetail44> unreg_details { get; set; }
        public List<CompDetail44> comp_details { get; set; }
        public List<UinDetail44> uin_details { get; set; }
    }

    public class IntrDetails44
    {
        public double iamt { get; set; }
        public double camt { get; set; }
        public double samt { get; set; }
        public double csamt { get; set; }
    }

    public class IntrLtfee44
    {
        public IntrDetails44 intr_details { get; set; }
        public LtfeeDetails44 ltfee_details { get; set; }
    }

    public class InwardSup44
    {
        public List<IsupDetail44> isup_details { get; set; }
    }

    public class IsupDetail44
    {
        public string ty { get; set; }
        public double inter { get; set; }
        public double intra { get; set; }
    }

    public class IsupRev44
    {
        public double txval { get; set; }
        public double iamt { get; set; }
        public double camt { get; set; }
        public double samt { get; set; }
        public double csamt { get; set; }
    }

    public class ItcAvl44
    {
        public string ty { get; set; }
        public double iamt { get; set; }
        public double camt { get; set; }
        public double samt { get; set; }
        public double csamt { get; set; }
    }

    public class ItcElg44
    {
        public List<ItcAvl44> itc_avl { get; set; }
        public List<ItcRev44> itc_rev { get; set; }
        public ItcNet44 itc_net { get; set; }
        public List<ItcInelg44> itc_inelg { get; set; }
    }

    public class ItcInelg44
    {
        public string ty { get; set; }
        public double iamt { get; set; }
        public double camt { get; set; }
        public double samt { get; set; }
        public double csamt { get; set; }
    }

    public class ItcNet44
    {
        public double iamt { get; set; }
        public double camt { get; set; }
        public double samt { get; set; }
        public double csamt { get; set; }
    }

    public class ItcRev44
    {
        public string ty { get; set; }
        public double iamt { get; set; }
        public double camt { get; set; }
        public double samt { get; set; }
        public double csamt { get; set; }
    }

    public class LiabBreakup44
    {
        public string ret_period { get; set; }
        public Liability44 liability { get; set; }
    }

    public class Liability44
    {
        public double iamt { get; set; }
        public double camt { get; set; }
        public double samt { get; set; }
        public double csamt { get; set; }
    }

    public class LtfeeDetails44
    {
        public double camt { get; set; }
        public double samt { get; set; }
    }

    public class Nettaxpay44
    {
        public double trans_typ { get; set; }
        public string trans_desc { get; set; }
        public double liab_ldg_id { get; set; }
        public Sgst44 sgst { get; set; }
        public Cgst44 cgst { get; set; }
        public Cess44 cess { get; set; }
        public Igst44 igst { get; set; }
    }

    public class OsupDet44
    {
        public double txval { get; set; }
        public double? iamt { get; set; }
        public double? camt { get; set; }
        public double? samt { get; set; }
        public double? csamt { get; set; }
    }

    public class OsupNilExmp44
    {
        public double txval { get; set; }
    }

    public class OsupNongst44
    {
        public double txval { get; set; }
    }

    public class OsupZero44
    {
        public double txval { get; set; }
        public double iamt { get; set; }
        public double csamt { get; set; }
    }

    public class Pdcash44
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

    public class Pditc44
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

    public class Pdnl44
    {
        public double trans_typ { get; set; }
        public string trans_desc { get; set; }
        public double liab_ldg_id { get; set; }
        public double ipd { get; set; }
        public double spd { get; set; }
        public double cpd { get; set; }
        public double cspd { get; set; }
    }
    public class Sgst44
    {
        public double intr { get; set; }
        public double tx { get; set; }
        public double fee { get; set; }
    }

    public class SupDetails44
    {
        public OsupDet44 osup_det { get; set; }
        public OsupZero44 osup_zero { get; set; }
        public OsupNilExmp44 osup_nil_exmp { get; set; }
        public IsupRev44 isup_rev { get; set; }
        public OsupNongst44 osup_nongst { get; set; }
    }

    public class TxPmt44
    {
        public List<TxPy44> tx_py { get; set; }
        public List<Adjnegliab44> adjnegliab { get; set; }
        public List<Nettaxpay44> nettaxpay { get; set; }
        public List<Pdcash44> pdcash { get; set; }
        public Pditc44 pditc { get; set; }
        public List<Pdnl44> pdnls { get; set; }
    }

    public class TxPy44
    {
        public double trans_typ { get; set; }
        public string trans_desc { get; set; }
        public double liab_ldg_id { get; set; }
        public Sgst44 sgst { get; set; }
        public Cgst44 cgst { get; set; }
        public Cess44 cess { get; set; }
        public Igst44 igst { get; set; }
    }

    public class UinDetail44
    {
        public string pos { get; set; }
        public double txval { get; set; }
        public double iamt { get; set; }
    }

    public class UnregDetail44
    {
        public string pos { get; set; }
        public double txval { get; set; }
        public double iamt { get; set; }
    }
}