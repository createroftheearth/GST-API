using GST_API_Library.Models.GSTR9;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GST_API_Library.Models.GSTR9
{
    public class GSTR9CSaveRequest
    {
        [Display(Name = "GSTIN of the Tax Payer")]
        [Required]
        [MaxLength(15)]
        [MinLength(15)]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string gstin { get; set; }

        [Required]
        [Display(Name = "Financial Period")]
        [MaxLength(10)]
        [MinLength(3)]
        [RegularExpression("^[0-9]+$")]
        public string fp { get; set; }
        public Gstr9cdata_Save9C gstr9cdata { get; set; }
        public Dcupdtls_Save9C dcupdtls { get; set; }
    }
    public class AddLiab_Save9C
    {
        public List<TaxPay_Save9C> tax_pay { get; set; }
    }

    public class AuditedData_Save9C
    {
        public string gstin { get; set; }
        public string fp { get; set; }
        public string act_name { get; set; }
        public Table5_Save9C table5 { get; set; }
        public Table6_Save9C table6 { get; set; }
        public Table7_Save9C table7 { get; set; }
        public Table8_Save9C table8 { get; set; }
        public Table9_Save9C table9 { get; set; }
        public Table10_Save9C table10 { get; set; }
        public Table11_Save9C table11 { get; set; }
        public Table12_Save9C table12 { get; set; }
        public Table13_Save9C table13 { get; set; }
        public Table14_Save9C table14 { get; set; }
        public Table15_Save9C table15 { get; set; }
        public Table16_Save9C table16 { get; set; }
        public AddLiab_Save9C add_liab { get; set; }
    }

    public class BalanceSheet_Save9C
    {
        public string doc_nam { get; set; }
        public string doc_id { get; set; }
    }

    public class Dcupdtls_Save9C
    {
        public List<BalanceSheet_Save9C> balance_sheet { get; set; }
        public List<Profitloss_Save9C> profitloss { get; set; }
        public List<Otherdoc1_Save9C> otherdoc1 { get; set; }
        public List<Otherdoc2_Save9C> otherdoc2 { get; set; }
    }

    public class Gstr9cdata_Save9C
    {
        public AuditedData_Save9C audited_data { get; set; }
    }

    public class Inter_Save9C
    {
        public double cgst { get; set; }
        public double sgst { get; set; }
        public double igst { get; set; }
        public double cess { get; set; }
    }

    public class ItcClaim_Save9C
    {
        public long itc_avail { get; set; }
    }

    public class Item_Save9C
    {
        public string desc { get; set; }
        public double val { get; set; }
        public double itc_amt { get; set; }
        public double itc_avail { get; set; }
    }

    public class LateFee_Save9C
    {
        public double cgst { get; set; }
        public double sgst { get; set; }
        public double igst { get; set; }
        public double cess { get; set; }
    }

    public class Oth_Save9C
    {
        public double cgst { get; set; }
        public double sgst { get; set; }
        public double igst { get; set; }
        public double cess { get; set; }
    }

    public class Otherdoc1_Save9C
    {
        public string doc_nam { get; set; }
        public string doc_id { get; set; }
    }

    public class Otherdoc2_Save9C
    {
        public string doc_nam { get; set; }
        public string doc_id { get; set; }
    }

    public class Pen_Save9C
    {
        public double cgst { get; set; }
        public double sgst { get; set; }
        public double igst { get; set; }
        public double cess { get; set; }
    }

    public class Profitloss_Save9C
    {
        public string doc_nam { get; set; }
        public string doc_id { get; set; }
    }

    public class Rate_Save9C
    {
        public string desc { get; set; }
        public double tax_val { get; set; }
        public double cgst { get; set; }
        public double sgst { get; set; }
        public double igst { get; set; }
        public double cess { get; set; }
    }

    public class Rsn_Save9C
    {
        public string number { get; set; }
        public string desc { get; set; }
    }

    public class Table10_Save9C
    {
        public List<Rsn_Save9C> rsn { get; set; }
    }

    public class Table11_Save9C
    {
        public List<Rate_Save9C> rate { get; set; }
        public Inter_Save9C inter { get; set; }
        public LateFee_Save9C late_fee { get; set; }
        public Pen_Save9C pen { get; set; }
        public Oth_Save9C oth { get; set; }
    }

    public class Table12_Save9C
    {
        public double itc_avail { get; set; }
        public double itc_book_earl { get; set; }
        public double itc_book_curr { get; set; }
        public long itc_avail_audited { get; set; }
        public int itc_claim { get; set; }
        public int unrec_itc { get; set; }
    }

    public class Table13_Save9C
    {
        public List<Rsn_Save9C> rsn { get; set; }
    }

    public class Table14_Save9C
    {
        public List<Item_Save9C> items { get; set; }
        public TotEligItc_Save9C tot_elig_itc { get; set; }
        public ItcClaim_Save9C itc_claim { get; set; }
        public UnrecItc_Save9C unrec_itc { get; set; }
    }

    public class Table15_Save9C
    {
        public List<Rsn_Save9C> rsn { get; set; }
    }

    public class Table16_Save9C
    {
        public double cgst { get; set; }
        public double sgst { get; set; }
        public double igst { get; set; }
        public double cess { get; set; }
        public double inter { get; set; }
        public double pen { get; set; }
    }

    public class Table5_Save9C
    {
        public double turnovr { get; set; }
        public double unbil_rev_beg { get; set; }
        public double unadj_adv_end { get; set; }
        public double dmd_sup { get; set; }
        public double crd_nts_issued { get; set; }
        public double trd_dis { get; set; }
        public double turnovr_apr_jun { get; set; }
        public double unbil_rev_end { get; set; }
        public double unadj_adv_beg { get; set; }
        public double crd_note_acc { get; set; }
        public double adj_dta { get; set; }
        public double turnovr_comp { get; set; }
        public double adj_turn_sec { get; set; }
        public double adj_turn_fef { get; set; }
        public double adj_turn_othrsn { get; set; }
        public int annul_turn_adj { get; set; }
        public int annul_turn_decl { get; set; }
        public int unrec_turnovr { get; set; }
    }

    public class Table6_Save9C
    {
        public List<Rsn_Save9C> rsn { get; set; }
    }

    public class Table7_Save9C
    {
        public int annul_turn_adj { get; set; }
        public double othr_turnovr { get; set; }
        public double zero_sup { get; set; }
        public double rev_sup { get; set; }
        public int tax_turn_annul { get; set; }
        public int tax_turn_adj { get; set; }
        public int unrec_tax_turn { get; set; }
    }

    public class Table8_Save9C
    {
        public List<Rsn_Save9C> rsn { get; set; }
    }

    public class Table9_Save9C
    {
        public List<Rate> rate { get; set; }
        public Inter_Save9C inter { get; set; }
        public LateFee late_fee { get; set; }
        public Pen pen { get; set; }
        public Oth oth { get; set; }
        public TotAmtPayable_Save9C tot_amt_payable { get; set; }
        public UnrecAmt_Save9C unrec_amt { get; set; }
        public TotAmtPaid_Save9C tot_amt_paid { get; set; }
    }

    public class TaxPay_Save9C
    {
        public string desc { get; set; }
        public double val { get; set; }
        public double igst { get; set; }
        public double cgst { get; set; }
        public double sgst { get; set; }
        public double cess { get; set; }
        public double? tax_val { get; set; }
    }

    public class TotAmtPaid_Save9C
    {
        public long cgst { get; set; }
        public long sgst { get; set; }
        public long igst { get; set; }
        public long cess { get; set; }
    }

    public class TotAmtPayable_Save9C
    {
        public long cgst { get; set; }
        public long sgst { get; set; }
        public long igst { get; set; }
        public long cess { get; set; }
    }

    public class TotEligItc_Save9C
    {
        public long itc_avail { get; set; }
    }

    public class UnrecAmt_Save9C
    {
        public long cgst { get; set; }
        public long sgst { get; set; }
        public long igst { get; set; }
        public long cess { get; set; }
    }

    public class UnrecItc_Save9C
    {
        public int itc_avail { get; set; }
    }


}
