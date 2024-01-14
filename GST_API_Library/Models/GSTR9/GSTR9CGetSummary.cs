using GST_API_Library.Models.GSTR9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GST_API_Library.Models.GSTR9
{
    public class GSTR9CGetSummary
    {
        public Gstr9cdata gstr9cdata { get; set; }
        public Dcupdtls dcupdtls { get; set; }
    }

    public class AddLiab
    {
        public List<TaxPay_9CGet> tax_pay { get; set; }
    }

    public class AuditedData
    {
        public string gstin { get; set; }
        public string fp { get; set; }
        public string lgl_name { get; set; }
        public string trd_name { get; set; }
        public string act_name { get; set; }
        public string arn { get; set; }
        public string arn_date { get; set; }
        public string signatoryname { get; set; }
        public string designation { get; set; }
        public Table5_9CGet table5 { get; set; }
        public Table6_9CGet table6 { get; set; }
        public Table7_9CGet table7 { get; set; }
        public Table8_9CGet table8 { get; set; }
        public Table9_9CGet table9 { get; set; }
        public Table10_9CGet table10 { get; set; }
        public Table11_9CGet table11 { get; set; }
        public Table12_9CGet table12 { get; set; }
        public Table13_9CGet table13 { get; set; }
        public Table14_9CGet table14 { get; set; }
        public Table15_9CGet table15 { get; set; }
        public Table16_9CGet table16 { get; set; }
        public AddLiab add_liab { get; set; }
    }

    public class BalanceSheet
    {
        public string doc_nam { get; set; }
        public string doc_id { get; set; }
    }

    public class Dcupdtls
    {
        public List<BalanceSheet> balance_sheet { get; set; }
        public List<Profitloss> profitloss { get; set; }
        public List<Otherdoc1> otherdoc1 { get; set; }
        public List<Otherdoc2> otherdoc2 { get; set; }
    }

    public class Gstr9cdata
    {
        public AuditedData audited_data { get; set; }
    }

    public class Inter
    {
        public double cgst { get; set; }
        public double sgst { get; set; }
        public double igst { get; set; }
        public double cess { get; set; }
    }

    public class ItcClaim
    {
        public long itc_avail { get; set; }
    }

    public class Item_9CGet
    {
        public string desc { get; set; }
        public double val { get; set; }
        public double itc_amt { get; set; }
        public double itc_avail { get; set; }
    }

    public class LateFee
    {
        public double cgst { get; set; }
        public double sgst { get; set; }
        public double igst { get; set; }
        public double cess { get; set; }
    }

    public class Oth
    {
        public double cgst { get; set; }
        public double sgst { get; set; }
        public double igst { get; set; }
        public double cess { get; set; }
    }

    public class Otherdoc1
    {
        public string doc_nam { get; set; }
        public string doc_id { get; set; }
    }

    public class Otherdoc2
    {
        public string doc_nam { get; set; }
        public string doc_id { get; set; }
    }

    public class Pen_9CGet
    {
        public double cgst { get; set; }
        public double sgst { get; set; }
        public double igst { get; set; }
        public double cess { get; set; }
    }

    public class Profitloss
    {
        public string doc_nam { get; set; }
        public string doc_id { get; set; }
    }

    public class Rate
    {
        public string desc { get; set; }
        public double tax_val { get; set; }
        public double cgst { get; set; }
        public double sgst { get; set; }
        public double igst { get; set; }
        public double cess { get; set; }
    }

    public class Rsn
    {
        public string number { get; set; }
        public string desc { get; set; }
    }

    public class Table10_9CGet
    {
        public List<Rsn> rsn { get; set; }
    }

    public class Table11_9CGet
    {
        public List<Rate> rate { get; set; }
        public Inter inter { get; set; }
        public LateFee late_fee { get; set; }
        public Pen pen { get; set; }
        public Oth oth { get; set; }
    }

    public class Table12_9CGet
    {
        public double itc_avail { get; set; }
        public double itc_book_earl { get; set; }
        public double itc_book_curr { get; set; }
        public long itc_avail_audited { get; set; }
        public int itc_claim { get; set; }
        public int unrec_itc { get; set; }
    }

    public class Table13_9CGet
    {
        public List<Rsn> rsn { get; set; }
    }

    public class Table14_9CGet
    {
        public List<Item_9CGet> items { get; set; }
        public TotEligItc tot_elig_itc { get; set; }
        public ItcClaim itc_claim { get; set; }
        public UnrecItc unrec_itc { get; set; }
    }

    public class Table15_9CGet
    {
        public List<Rsn> rsn { get; set; }
    }

    public class Table16_9CGet
    {
        public double cgst { get; set; }
        public double sgst { get; set; }
        public double igst { get; set; }
        public double cess { get; set; }
        public double inter { get; set; }
        public double pen { get; set; }
    }

    public class Table5_9CGet
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

    public class Table6_9CGet
    {
        public List<Rsn> rsn { get; set; }
    }

    public class Table7_9CGet
    {
        public int annul_turn_adj { get; set; }
        public double othr_turnovr { get; set; }
        public double zero_sup { get; set; }
        public double rev_sup { get; set; }
        public int tax_turn_annul { get; set; }
        public int tax_turn_adj { get; set; }
        public int unrec_tax_turn { get; set; }
    }

    public class Table8_9CGet
    {
        public List<Rsn> rsn { get; set; }
    }

    public class Table9_9CGet
    {
        public List<Rate> rate { get; set; }
        public Inter inter { get; set; }
        public LateFee late_fee { get; set; }
        public Pen_9CGet pen { get; set; }
        public Oth oth { get; set; }
        public TotAmtPayable tot_amt_payable { get; set; }
        public UnrecAmt unrec_amt { get; set; }
        public TotAmtPaid_9CGet tot_amt_paid { get; set; }
    }

    public class TaxPay_9CGet
    {
        public string desc { get; set; }
        public double val { get; set; }
        public double igst { get; set; }
        public double cgst { get; set; }
        public double sgst { get; set; }
        public double cess { get; set; }
    }

    public class TotAmtPaid_9CGet
    {
        public long cgst { get; set; }
        public long sgst { get; set; }
        public long igst { get; set; }
        public long cess { get; set; }
    }

    public class TotAmtPayable
    {
        public long cgst { get; set; }
        public long sgst { get; set; }
        public long igst { get; set; }
        public long cess { get; set; }
    }

    public class TotEligItc
    {
        public long itc_avail { get; set; }
    }

    public class UnrecAmt
    {
        public long cgst { get; set; }
        public long sgst { get; set; }
        public long igst { get; set; }
        public long cess { get; set; }
    }

    public class UnrecItc
    {
        public int itc_avail { get; set; }
    }


}
