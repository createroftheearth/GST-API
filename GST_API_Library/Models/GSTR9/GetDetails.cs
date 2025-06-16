using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GST_API_Library.Models.GSTR9;

namespace GST_API_Library.Models.GSTR9
{
    public class GetDetails
    {
        public string gstin { get; set; }
        public string fp { get; set; }
        public GetDTable4 table4 { get; set; }
        public GetDTable5 table5 { get; set; }
        public GetDTable6 table6 { get; set; }
        public GetDTable7 table7 { get; set; }
        public GetDTable8 table8 { get; set; }
        public GetDTable9 table9 { get; set; }
        public Table10 table10 { get; set; }
        public Table14 table14 { get; set; }
        public Table15 table15 { get; set; }
        public Table16 table16 { get; set; }
        public Table17 table17 { get; set; }
        public Table18 table18 { get; set; }
        public List<TaxPay> tax_pay { get; set; }
        public TaxPaid tax_paid { get; set; }
    }
    //public class AmdNeg
    //{
    //    public int txval { get; set; }
    //    public int iamt { get; set; }
    //    public int camt { get; set; }
    //    public int samt { get; set; }
    //    public int csamt { get; set; }
    //}

    //public class AmdPos
    //{
    //    public int txval { get; set; }
    //    public int iamt { get; set; }
    //    public int camt { get; set; }
    //    public int samt { get; set; }
    //    public int csamt { get; set; }
    //}

    //public class At
    //{
    //    public int txval { get; set; }
    //    public int iamt { get; set; }
    //    public int camt { get; set; }
    //    public int samt { get; set; }
    //    public int csamt { get; set; }
    //}

    //public class B2b
    //{
    //    public int txval { get; set; }
    //    public int iamt { get; set; }
    //    public int camt { get; set; }
    //    public int samt { get; set; }
    //    public int csamt { get; set; }
    //}

    //public class B2c
    //{
    //    public int txval { get; set; }
    //    public int iamt { get; set; }
    //    public int camt { get; set; }
    //    public int samt { get; set; }
    //    public int csamt { get; set; }
    //}

    //public class Camt
    //{
    //    public int txpyble { get; set; }
    //    public int txpaid_cash { get; set; }
    //    public int tax_paid_itc_iamt { get; set; }
    //    public int tax_paid_itc_camt { get; set; }
    //    public int txpaid { get; set; }
    //}

    public class CdnAmd
    {
        public int txval { get; set; }
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
    }

    public class Cgst10
    {
        public int tx { get; set; }
        public int intr { get; set; }
        public int pen { get; set; }
        public int fee { get; set; }
        public int oth { get; set; }
        public int tot { get; set; }
    }

    public class CompSupp
    {
        public int txval { get; set; }
    }

    //public class CrNt
    //{
    //    public int txval { get; set; }
    //    public int iamt { get; set; }
    //    public int camt { get; set; }
    //    public int samt { get; set; }
    //    public int csamt { get; set; }
    //}

    //public class Csamt
    //{
    //    public int txpyble { get; set; }
    //    public int txpaid_cash { get; set; }
    //    public int tax_paid_itc_csamt { get; set; }
    //    public int txpaid { get; set; } //Added in GetAutocalulatedDetails.cs
    //}

    public class DbnAmd
    {
        public int txval { get; set; }
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
    }

    public class DbNt
    {
        public int txval { get; set; }
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
    }

    //public class Deemed
    //{
    //    public int txval { get; set; }
    //    public int iamt { get; set; }
    //    public int camt { get; set; }
    //    public int samt { get; set; }
    //    public int csamt { get; set; }
    //}

    public class DeemedSupp
    {
        public int txval { get; set; }
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
    }

    public class Difference
    {
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
    }

    public class DifferenceABC
    {
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
    }

    public class DifferenceGH
    {
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
    }

    public class DmndPend
    {
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
        public int intr { get; set; }
        public int fee { get; set; }
        public int pen { get; set; }
    }

    //public class Exmt
    //{
    //    public int txval { get; set; }
    //}

    //public class Exp
    //{
    //    public int txval { get; set; }
    //    public int iamt { get; set; }
    //    public int csamt { get; set; }
    //}

    //public class Iamt
    //{
    //    public int txpyble { get; set; }
    //    public int txpaid_cash { get; set; }
    //    public int tax_paid_itc_iamt { get; set; }
    //    public int tax_paid_itc_camt { get; set; }
    //    public int tax_paid_itc_samt { get; set; }
    //    public int txpaid { get; set; }
    //}

    //public class Intr
    //{
    //    public int txpyble { get; set; }
    //    public int txpaid_cash { get; set; }
    //    public int txpaid { get; set; }
    //}

    public class Iog
    {
        public string itc_typ { get; set; }
        public int iamt { get; set; }
        public int csamt { get; set; }
    }

    public class IogItcAvaild
    {
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
    }

    public class IogItcNtavaild
    {
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
    }

    public class IogTaxpaid
    {
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
    }

    public class Ios
    {
        public int iamt { get; set; }
        public int csamt { get; set; }
    }

    //public class Isd
    //{
    //    public int iamt { get; set; }
    //    public int camt { get; set; }
    //    public int samt { get; set; }
    //    public int csamt { get; set; }
    //}

    //public class Itc2a
    //{
    //    public int iamt { get; set; }
    //    public int camt { get; set; }
    //    public int samt { get; set; }
    //    public int csamt { get; set; }
    //}

    //public class Itc3b
    //{
    //    public int iamt { get; set; }
    //    public int camt { get; set; }
    //    public int samt { get; set; }
    //    public int csamt { get; set; }
    //}

    public class ItcAvaild
    {
        public int txval { get; set; }
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
    }

    public class ItcClmd
    {
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
    }

    public class ItcInwdSupp
    {
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
    }

    public class ItcNtAvaild
    {
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
    }

    public class ItcNtEleg
    {
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
    }

    public class ItcRvsl
    {
        public int txval { get; set; }
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
    }

    public class ItcTot
    {
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
    }

    public class Item
    {
        public string hsn_sc { get; set; }
        public string uqc { get; set; }
        public string desc { get; set; }
        public string isconcesstional { get; set; }
        public int qty { get; set; }
        public int txval { get; set; }
        public int rt { get; set; }
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
    }

    public class NetItcAval
    {
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
    }

    //public class Nil
    //{
    //    public int txval { get; set; }
    //}

    //public class NonGst
    //{
    //    public int txval { get; set; }
    //}

    public class NotReturned
    {
        public int txval { get; set; }
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
    }

    public class Other
    {
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
        public string desc { get; set; }
        public int txpyble { get; set; }
        public int txpaid_cash { get; set; }
    }

    public class PdByCash
    {
        public Sgst10 sgst { get; set; }
        public Cgst10 cgst { get; set; }
        public int liab_id { get; set; }
        public string debit_id { get; set; }
        public int trancd { get; set; }
        public string trandate { get; set; }
    }

    public class Pen
    {
        public int txpyble { get; set; }
        public int txpaid_cash { get; set; }
    }

    //public class Rchrg
    //{
    //    public int txval { get; set; }
    //    public int iamt { get; set; }
    //    public int camt { get; set; }
    //    public int samt { get; set; }
    //    public int csamt { get; set; }
    //}

    public class RevslTran1
    {
        public int camt { get; set; }
        public int samt { get; set; }
    }

    public class RevslTran2
    {
        public int camt { get; set; }
        public int samt { get; set; }
    }

    public class RfdClmd
    {
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
    }

    public class RfdPend
    {
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
    }

    public class RfdRejt
    {
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
    }

    public class RfdSanc
    {
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
    }

    public class Rule37
    {
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
    }

    public class Rule39
    {
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
    }

    public class Rule42
    {
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
    }

    public class Rule43
    {
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
    }

    //public class Samt
    //{
    //    public int txpyble { get; set; }
    //    public int txpaid_cash { get; set; }
    //    public int tax_paid_itc_iamt { get; set; }
    //    public int tax_paid_itc_samt { get; set; }
    //    public int txpaid { get; set; } //Added in GetAutoCalculatedDetails //Garima
    //}

    public class Sec17
    {
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
    }

    //public class Sez
    //{
    //    public int txval { get; set; }
    //    public int iamt { get; set; }
    //    public int csamt { get; set; }
    //}

    public class Sgst10
    {
        public int tx { get; set; }
        public int intr { get; set; }
        public int pen { get; set; }
        public int fee { get; set; }
        public int oth { get; set; }
        public int tot { get; set; }
    }

    public class SubTotalAF
    {
        public int txval { get; set; }
    }

    public class SubTotalAG
    {
        public int txval { get; set; }
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
    }

    public class SubTotalBH
    {
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
    }

    public class SubTotalHK
    {
        public int txval { get; set; }
    }

    public class SubTotalIL
    {
        public int txval { get; set; }
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
    }

    public class SubTotalKM
    {
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
    }

    public class SupAdv
    {
        public int txval { get; set; }
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
    }

    public class SuppNonRchrg
    {
        public string itc_typ { get; set; }
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
    }

    public class SuppRchrgReg
    {
        public string itc_typ { get; set; }
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
    }

    public class SuppRchrgUnreg
    {
        public string itc_typ { get; set; }
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
    }

    public class Table10
    {
        public string chksum { get; set; }
        public DbnAmd dbn_amd { get; set; }
        public CdnAmd cdn_amd { get; set; }
        public ItcRvsl itc_rvsl { get; set; }
        public ItcAvaild itc_availd { get; set; }
        public TotalTurnover total_turnover { get; set; }
    }

    public class Table14
    {
        public string chksum { get; set; }
        public Iamt iamt { get; set; }
        public Camt camt { get; set; }
        public Samt samt { get; set; }
        public Csamt csamt { get; set; }
        public Intr intr { get; set; }
    }

    public class Table15
    {
        public string chksum { get; set; }
        public RfdClmd rfd_clmd { get; set; }
        public RfdSanc rfd_sanc { get; set; }
        public RfdRejt rfd_rejt { get; set; }
        public RfdPend rfd_pend { get; set; }
        public TaxDmnd tax_dmnd { get; set; }
        public TaxPaid tax_paid { get; set; }
        public DmndPend dmnd_pend { get; set; }
    }

    public class Table16
    {
        public string chksum { get; set; }
        public CompSupp comp_supp { get; set; }
        public DeemedSupp deemed_supp { get; set; }
        public NotReturned not_returned { get; set; }
    }

    public class Table17
    {
        public string chksum { get; set; }
        public List<Item> items { get; set; }
    }

    public class Table18
    {
        public string chksum { get; set; }
        public List<Item> items { get; set; }
    }

    public class GetDTable4
    {
        public string chksum { get; set; }
        public B2c b2c { get; set; }
        public B2b b2b { get; set; }
        public Exp9 exp { get; set; }
        public Sez sez { get; set; }
        public Deemed deemed { get; set; }
        public At at { get; set; }
        public Rchrg rchrg { get; set; }
        public CrNt cr_nt { get; set; }
        public DbNt db_nt { get; set; }
        public AmdPos amd_pos { get; set; }
        public AmdNeg amd_neg { get; set; }
        public SubTotalAG sub_totalAG { get; set; }
        public SubTotalIL sub_totalIL { get; set; }
        public SupAdv sup_adv { get; set; }
    }

    public class GetDTable5
    {
        public string chksum { get; set; }
        public ZeroRtd zero_rtd { get; set; }
        public Sez sez { get; set; }
        public Rchrg rchrg { get; set; }
        public Exmt exmt { get; set; }
        public Nil nil { get; set; }
        public NonGst non_gst { get; set; }
        public CrNt cr_nt { get; set; }
        public DbNt db_nt { get; set; }
        public AmdPos amd_pos { get; set; }
        public AmdNeg amd_neg { get; set; }
        public SubTotalAF sub_totalAF { get; set; }
        public SubTotalHK sub_totalHK { get; set; }
        public ToverTaxNp tover_tax_np { get; set; }
        public TotalTover total_tover { get; set; }
    }

    public class GetDTable6
    {
        public string chksum { get; set; }
        public Itc3b itc_3b { get; set; }
        public List<SuppNonRchrg> supp_non_rchrg { get; set; }
        public List<SuppRchrgUnreg> supp_rchrg_unreg { get; set; }
        public List<SuppRchrgReg> supp_rchrg_reg { get; set; }
        public List<Iog> iog { get; set; }
        public Ios ios { get; set; }
        public Isd isd { get; set; }
        public ItcClmd itc_clmd { get; set; }
        public Tran1 tran1 { get; set; }
        public Tran2 tran2 { get; set; }
        public Other other { get; set; }
        public SubTotalBH sub_totalBH { get; set; }
        public Difference difference { get; set; }
        public SubTotalKM sub_totalKM { get; set; }
        public TotalItcAvailed total_itc_availed { get; set; }
    }

    public class GetDTable7
    {
        public string chksum { get; set; }
        public Rule37 rule37 { get; set; }
        public Rule39 rule39 { get; set; }
        public Rule42 rule42 { get; set; }
        public Rule43 rule43 { get; set; }
        public Sec17 sec17 { get; set; }
        public RevslTran1 revsl_tran1 { get; set; }
        public RevslTran2 revsl_tran2 { get; set; }
        public List<Other> other { get; set; }
        public TotItcRevd tot_itc_revd { get; set; }
        public NetItcAval net_itc_aval { get; set; }
    }

    public class GetDTable8
    {
        public string chksum { get; set; }
        public Itc2a itc_2a { get; set; }
        public ItcTot itc_tot { get; set; }
        public ItcInwdSupp itc_inwd_supp { get; set; }
        public ItcNtAvaild itc_nt_availd { get; set; }
        public ItcNtEleg itc_nt_eleg { get; set; }
        public IogTaxpaid iog_taxpaid { get; set; }
        public IogItcAvaild iog_itc_availd { get; set; }
        public IogItcNtavaild iog_itc_ntavaild { get; set; }
        public DifferenceABC differenceABC { get; set; }
        public DifferenceGH differenceGH { get; set; }
        public TotItcLapsed tot_itc_lapsed { get; set; }
    }

    public class GetDTable9
    {
        public string chksum { get; set; }
        public Iamt iamt { get; set; }
        public Camt camt { get; set; }
        public Samt samt { get; set; }
        public Csamt csamt { get; set; }
        public Intr intr { get; set; }
        public Tee tee { get; set; }
        public Pen pen { get; set; }
        public Other other { get; set; }
    }

    public class TaxDmnd
    {
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
        public int intr { get; set; }
        public int fee { get; set; }
        public int pen { get; set; }
    }

    public class TaxPaid
    {
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
        public int intr { get; set; }
        public int fee { get; set; }
        public int pen { get; set; }
        public List<PdByCash> pd_by_cash { get; set; }
    }

    public class TaxPay
    {
        public Sgst10 sgst { get; set; }
        public Cgst10 cgst { get; set; }
        public int liab_id { get; set; }
        public int trancd { get; set; }
        public string trandate { get; set; }
    }

    public class Tee
    {
        public int txpyble { get; set; }
        public int txpaid_cash { get; set; }
    }

    public class TotalItcAvailed
    {
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
    }

    public class TotalTover
    {
        public int txval { get; set; }
        public int csamt { get; set; }
        public int samt { get; set; }
        public int camt { get; set; }
        public int iamt { get; set; }
    }

    public class TotalTurnover
    {
        public int txval { get; set; }
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
    }

    public class TotItcLapsed
    {
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
    }

    public class TotItcRevd
    {
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
    }

    public class ToverTaxNp
    {
        public int txval { get; set; }
    }

    //public class Tran1
    //{
    //    public int camt { get; set; }
    //    public int samt { get; set; }
    //}

    //public class Tran2
    //{
    //    public int camt { get; set; }
    //    public int samt { get; set; }
    //}

    //public class ZeroRtd
    //{
    //    public int txval { get; set; }
    //}


}
