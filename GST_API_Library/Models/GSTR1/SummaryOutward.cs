using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace GST_API_Library.Models.GSTR1
{
    public class SummaryOutward
    {

        //public string gstin { get; set; }
        //public string ret_period { get; set; }
        //public string chksum { get; set; }
        ////public string smryTyp { get; set; }
        //public bool newSumFlag { get; set; }
        //public List<SecSum> sec_sum { get; set; }

        //public string gstin { get; set; }
        //public string ret_period { get; set; }
        //public string chksum { get; set; }
        //public string smryTyp { get; set; }
        //public bool newSumFlag { get; set; }
        //public List<SecSum1> sec_sum { get; set; }
    }


    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    //public class CptySum1
    //{
    //    public string ctin { get; set; }
    //    public string chksum { get; set; }
    //    public int ttl_rec { get; set; }
    //    public double ttl_tax { get; set; }
    //    public double ttl_igst { get; set; }
    //    public double ttl_sgst { get; set; }
    //    public double ttl_cgst { get; set; }
    //    public double ttl_val { get; set; }
    //    public double ttl_cess { get; set; }
    //    public string trade_name { get; set; }
    //}
    //public class SecSum1
    //{
    //    public string sec_nm { get; set; }
    //    public string chksum { get; set; }
    //    public int ttl_rec { get; set; }
    //    public double ttl_tax { get; set; }
    //    public double ttl_igst { get; set; }
    //    public double ttl_sgst { get; set; }
    //    public double ttl_cgst { get; set; }
    //    public double ttl_val { get; set; }
    //    public double ttl_cess { get; set; }
    //    public double act_tax { get; set; }
    //    public double act_igst { get; set; }
    //    public double act_sgst { get; set; }
    //    public double act_cgst { get; set; }
    //    public double act_val { get; set; }
    //    public double act_cess { get; set; }
    //    public List<CptySum1> cpty_sum { get; set; }
    //    public double ttl_expt_amt { get; set; }
    //    public double ttl_ngsup_amt { get; set; }
    //    public double ttl_nilsup_amt { get; set; }
    //    public long ttl_doc_issued { get; set; }
    //    public int ttl_doc_cancelled { get; set; }
    //    public long net_doc_issued { get; set; }
    //    public List<SubSection1> sub_sections { get; set; }
    //}

    //public class SubSection1
    //{
    //    public string sec_nm { get; set; }
    //    public string chksum { get; set; }
    //    public int ttl_rec { get; set; }
    //    public double ttl_tax { get; set; }
    //    public double ttl_igst { get; set; }
    //    public double ttl_sgst { get; set; }
    //    public double ttl_cgst { get; set; }
    //    public double ttl_val { get; set; }
    //    public double ttl_cess { get; set; }
    //    public List<CptySum> cpty_sum { get; set; }
    //    public double act_tax { get; set; }
    //    public double act_igst { get; set; }
    //    public double act_sgst { get; set; }
    //    public double act_cgst { get; set; }
    //    public double act_val { get; set; }
    //    public double act_cess { get; set; }
    //    public string typ { get; set; }
    //}

    //public class CptySum1
    //{

    //    [Required]
    //    [Display(Name = "Supplier TIN for B2B & CDN/ISD TIN for ISD/deductor TIN for TDS/ Ecommerce Portal TIN for TCS/")]
    //    [MaxLength(15)]
    //    [MinLength(15)]
    //    [RegularExpression("^[a-zA-Z0-9]+$")]
    //    public string ctin { get; set; }

    //    [Required]
    //    [Display(Name = "Invoice Check sum value")]
    //    [MaxLength(15)]
    //    public string chksum { get; set; }

    //    [Required]
    //    [Display(Name = "Total Record Count")]
    //    public int ttl_rec { get; set; }

    //    [Required]
    //    [Display(Name = "Total records value")]
    //    public double ttl_val { get; set; }

    //    [Required]
    //    [Display(Name = "Total Cess")]
    //    public double ttl_cess { get; set; }

    //    [Required]
    //    [Display(Name = "Total taxable value of records")]
    //    public double ttl_tax { get; set; }


    //    [Required]
    //    [Display(Name = "total IGST amount")]
    //    public double ttl_igst { get; set; }

    //    [Required]
    //    [Display(Name = "total SGST amount")]
    //    public double ttl_sgst { get; set; }

    //    [Required]
    //    [Display(Name = "total CGST amount")]
    //    public double ttl_cgst { get; set; }
    //    [Required]
    //    [Display(Name = "Trade Name")]
    //    public string trade_name { get; set; }
    //}

    //public class SecSum1
    //{

    //    [Required]
    //    [Display(Name = "Return Section")]
    //    [MaxLength(5)]
    //    public string sec_nm { get; set; }

    //    [Required]
    //    [Display(Name = "Invoice Check sum value")]
    //    [MaxLength(15)]
    //    public string chksum { get; set; }

    //    [Required]
    //    [Display(Name = "Total Record Count")]
    //    public int ttl_rec { get; set; }

    //    [Required]
    //    [Display(Name = "Total records value")]
    //    public double ttl_val { get; set; }

    //    [Required]
    //    [Display(Name = "Total Cess")]
    //    public double ttl_cess { get; set; }

    //    [Required]
    //    [Display(Name = "Total taxable value of records")]
    //    public double ttl_tax { get; set; }

    //    [Required]
    //    [Display(Name = "total IGST amount")]
    //    public double ttl_igst { get; set; }

    //    [Required]
    //    [Display(Name = "total SGST amount")]
    //    public double ttl_sgst { get; set; }

    //    [Required]
    //    [Display(Name = "total CGST amount")]
    //    public double ttl_cgst { get; set; }


    //    //[Display(Name = "cpty_sum")]
    //    //public List<CptySum> cpty_sum { get; set; }
    //}

    //public class SummaryOutward: BaseErrorData
    //{

    //    [Required]
    //    [Display(Name = "GSTIN of the taxpayer")]
    //    [MaxLength(15)]
    //    [MinLength(15)]
    //    [RegularExpression("^[a-zA-Z0-9]+$")]
    //    public string gstin { get; set; }

    //    [Required]
    //    [Display(Name = "Return Period")]
    //    [RegularExpression("^((0[1-9]|1[012])((19|20)\\d\\d))*$")]
    //    public string ret_period { get; set; }

    //    [Required]
    //    [Display(Name = "Invoice Check sum value")]
    //    [MaxLength(15)]
    //    public string chksum { get; set; }
    //    public bool newSumFlag { get; set; }

    //    //public string summ_typ { get; set; }

    //    [Display(Name = "section_summary")]
    //    public List<SecSum1> sec_sum { get; set; }
    //}
}