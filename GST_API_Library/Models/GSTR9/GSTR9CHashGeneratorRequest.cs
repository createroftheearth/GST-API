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
    public class GSTR9CHashGeneratorRequest
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
        public Gstr9cdata_9CHash gstr9cdata { get; set; }
    }
    public class AddAddr
    {
        public string bno { get; set; }
        public string fno { get; set; }
        public string building { get; set; }
        public string road { get; set; }
        public string city { get; set; }
        public string district { get; set; }
        public string state { get; set; }
        public int pin_code { get; set; }
    }

    public class AddLiab_9CHash
    {
        public List<TaxPay_9CHash> tax_pay { get; set; }
        public string place { get; set; }
        public string signatory { get; set; }
        public string mem_no { get; set; }
        public string date { get; set; }
        public AuditAddr audit_addr { get; set; }
        public string pan_no { get; set; }
    }

    public class Addr
    {
        public string bno { get; set; }
        public string fno { get; set; }
        public string building { get; set; }
        public string road { get; set; }
        public string city { get; set; }
        public string district { get; set; }
        public string state { get; set; }
        public int pin_code { get; set; }
    }

    public class AuditAddr
    {
        public string bno { get; set; }
        public string fno { get; set; }
        public string building { get; set; }
        public string road { get; set; }
        public string city { get; set; }
        public string district { get; set; }
        public string state { get; set; }
        public int pin_code { get; set; }
    }

    public class AuditedData_9CHash
    {
        public string gstin { get; set; }
        public string fp { get; set; }
        public string act_name { get; set; }
        public string isauditor { get; set; }
        public Table5_9CHash table5 { get; set; }
        public Table6_9CHash table6 { get; set; }
        public Table7 table7 { get; set; }
        public Table8_9CHash table8 { get; set; }
        public Table9_9CHash table9 { get; set; }
        public Table10_9CHash table10 { get; set; }
        public Table11 table11 { get; set; }
        public Table12 table12 { get; set; }
        public Table13 table13 { get; set; }
        public Table14_9CHash table14 { get; set; }
        public Table15_9CHash table15 { get; set; }
        public Table16_9CHash table16 { get; set; }
        public AddLiab_9CHash add_liab { get; set; }
    }

    public class CertData
    {
        public string pronoun { get; set; }
        public string bal_sheet_date { get; set; }
        public string acc_typ { get; set; }
        public string beg_date { get; set; }
        public string end_date { get; set; }
        public string cash_from_date { get; set; }
        public string cash_to_date { get; set; }
        public string taxpayer_name { get; set; }
        public Addr addr { get; set; }
        public string doc_stat { get; set; }
        public string place { get; set; }
        public string signatory { get; set; }
        public string mem_no { get; set; }
        public string date { get; set; }
        public AuditAddr audit_addr { get; set; }
        public CertTextpartb1 cert_textpartb1 { get; set; }
        public CertTextpartb2 cert_textpartb2 { get; set; }
    }

    public class Certificate
    {
        public CertData cert_data { get; set; }
        public CertText cert_text { get; set; }
    }

    public class CertText
    {
        public CertTextpartb1 cert_text_partb1 { get; set; }
        public CertTextpartb2 cert_text_partb2 { get; set; }
    }

    public class CertTextpartb1
    {
        public List<Qualification> qualifications { get; set; }
        public string gstin { get; set; }
        public PrincipalAddr principal_addr { get; set; }
        public AddAddr add_addr { get; set; }
        public string ishave { get; set; }
        public string isagree { get; set; }
        public string info_stat { get; set; }
    }

    public class CertTextPartb12
    {
        public Section1 section1 { get; set; }
        public Section2 section2 { get; set; }
        public Section3 section3 { get; set; }
        public Section4 section4 { get; set; }
        public Section5 section5 { get; set; }
        public List<Qualification> qualifications { get; set; }
        public Signature signature { get; set; }
    }

    public class CertTextpartb2
    {
        public List<Qualification> qualifications { get; set; }
        public string audit_typ { get; set; }
        public string audit_date { get; set; }
        public string member_no { get; set; }
        public ConductedBy conducted_by { get; set; }
    }

    public class CertTextPartb22
    {
        public Section1 section1 { get; set; }
        public Section2 section2 { get; set; }
        public Section3 section3 { get; set; }
        public Section4 section4 { get; set; }
        public List<Qualification> qualifications { get; set; }
        public Signature signature { get; set; }
    }

    public class ConductedBy
    {
        public string name { get; set; }
        public Addr addr { get; set; }
    }

    public class Gstr9cdata_9CHash
    {
        public AuditedData_9CHash audited_data { get; set; }
        public Certificate certificate { get; set; }
    }

    public class Inter_9CHash
    {
        public double cgst { get; set; }
        public double sgst { get; set; }
        public double igst { get; set; }
        public double cess { get; set; }
    }

    public class ItcClaim_9CHash
    {
        public long itc_avail { get; set; }
    }

    public class Item_9CHash
    {
        public string desc { get; set; }
        public double val { get; set; }
        public double itc_amt { get; set; }
        public double itc_avail { get; set; }
    }

    public class LateFee_9CHash
    {
        public double cgst { get; set; }
        public double sgst { get; set; }
        public double igst { get; set; }
        public double cess { get; set; }
    }

    public class Oth_9CHash
    {
        public double cgst { get; set; }
        public double sgst { get; set; }
        public double igst { get; set; }
        public double cess { get; set; }
    }

    public class Pen_9CHash
    {
        public double cgst { get; set; }
        public double sgst { get; set; }
        public double igst { get; set; }
        public double cess { get; set; }
    }

    public class PrincipalAddr
    {
        public string bno { get; set; }
        public string fno { get; set; }
        public string building { get; set; }
        public string road { get; set; }
        public string city { get; set; }
        public string district { get; set; }
        public string state { get; set; }
        public int pin_code { get; set; }
    }

    public class Qualification
    {
        public string qual_type { get; set; }
        public string value { get; set; }
    }

    public class Rate_9CHash
    {
        public string desc { get; set; }
        public double tax_val { get; set; }
        public double cgst { get; set; }
        public double sgst { get; set; }
        public double igst { get; set; }
        public double cess { get; set; }
    }
    public class Rsn_9CHash
    {
        public string number { get; set; }
        public string desc { get; set; }
    }

    public class Sec3a
    {
        public string line0 { get; set; }
    }

    public class Sec3b
    {
        public string line0 { get; set; }
        public string line1 { get; set; }
        public string line2 { get; set; }
        public string line3 { get; set; }
    }

    public class Section1
    {
        public string line0 { get; set; }
        public string line1 { get; set; }
        public string line2 { get; set; }
        public string line3 { get; set; }
        public string line4 { get; set; }
    }

    public class Section2
    {
        public string line0 { get; set; }
        public string line1 { get; set; }
    }

    public class Section3
    {
        public Sec3a sec_3a { get; set; }
        public Sec3b sec_3b { get; set; }
        public string line0 { get; set; }
    }

    public class Section4
    {
        public string line0 { get; set; }
    }

    public class Section5
    {
        public string line0 { get; set; }
    }

    public class Signature
    {
        public string line0 { get; set; }
        public string place { get; set; }
        public string nameOfTheSignatory { get; set; }
        public string membershipNo { get; set; }
        public string date { get; set; }
        public string fullAddress { get; set; }
    }

    public class Table10_9CHash
    {
        public List<Rsn_9CHash> rsn { get; set; }
    }

    public class Table11
    {
        public List<Rate_9CHash> rate { get; set; }
        public Inter_9CHash inter { get; set; }
        public LateFee_9CHash late_fee { get; set; }
        public Pen_9CHash pen { get; set; }
        public Oth_9CHash oth { get; set; }
    }

    public class Table12
    {
        public double itc_avail { get; set; }
        public double itc_book_earl { get; set; }
        public double itc_book_curr { get; set; }
        public long itc_avail_audited { get; set; }
        public int itc_claim { get; set; }
        public int unrec_itc { get; set; }
    }

    public class Table13
    {
        public List<Rsn_9CHash> rsn { get; set; }
    }

    public class Table14_9CHash
    {
        public List<Item_9CHash> items { get; set; }
        public TotEligItc_9CHash tot_elig_itc { get; set; }
        public ItcClaim_9CHash itc_claim { get; set; }
        public UnrecItc_9CHash unrec_itc { get; set; }
    }

    public class Table15_9CHash
    {
        public List<Rsn_9CHash> rsn { get; set; }
    }

    public class Table16_9CHash
    {
        public double cgst { get; set; }
        public double sgst { get; set; }
        public double igst { get; set; }
        public double cess { get; set; }
        public double inter { get; set; }
        public double pen { get; set; }
    }

    public class Table5_9CHash
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

    public class Table6_9CHash
    {
        public List<Rsn_9CHash> rsn { get; set; }
    }

    public class Table7
    {
        public int annul_turn_adj { get; set; }
        public double othr_turnovr { get; set; }
        public double zero_sup { get; set; }
        public double rev_sup { get; set; }
        public int tax_turn_annul { get; set; }
        public int tax_turn_adj { get; set; }
        public int unrec_tax_turn { get; set; }
    }

    public class Table8_9CHash
    {
        public List<Rsn_9CHash> rsn { get; set; }
    }

    public class Table9_9CHash
    {
        public List<Rate_9CHash> rate { get; set; }
        public Inter_9CHash inter { get; set; }
        public LateFee_9CHash late_fee { get; set; }
        public Pen_9CHash pen { get; set; }
        public Oth_9CHash oth { get; set; }
        public TotAmtPayable_9CHash tot_amt_payable { get; set; }
        public UnrecAmt_9CHash unrec_amt { get; set; }
        public TotAmtPaid_9CHash tot_amt_paid { get; set; }
    }

    public class TaxPay_9CHash
    {
        public string desc { get; set; }
        public double val { get; set; }
        public double igst { get; set; }
        public double cgst { get; set; }
        public double sgst { get; set; }
        public double cess { get; set; }
    }

    public class TotAmtPaid_9CHash
    {
        public long cgst { get; set; }
        public long sgst { get; set; }
        public long igst { get; set; }
        public long cess { get; set; }
    }

    public class TotAmtPayable_9CHash
    {
        public long cgst { get; set; }
        public long sgst { get; set; }
        public long igst { get; set; }
        public long cess { get; set; }
    }

    public class TotEligItc_9CHash
    {
        public long itc_avail { get; set; }
    }

    public class UnrecAmt_9CHash
    {
        public long cgst { get; set; }
        public long sgst { get; set; }
        public long igst { get; set; }
        public long cess { get; set; }
    }

    public class UnrecItc_9CHash
    {
        public int itc_avail { get; set; }
    }


}
