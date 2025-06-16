using GST_API_Library.Models.GSTR2A;
//using Integrated.API.GSTN.GSTR2A;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GST_API_Library.Models.GSTR2A
{
    public class GSTR2ATotal
    {
        [Display(Name = "GSTIN of the Tax Payer")]
        [Required]
        [MaxLength(15)]
        [MinLength(15)]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string gstin { get; set; }

        
        [Display(Name = "Financial Period")]
        [MaxLength(10)]
        [MinLength(3)]
        [RegularExpression("^[0-9]+$")]
        public string fp { get; set; }

        [Required]
        [Display(Name = "Gross Turnover of the taxpayer in the previous FY")]
        public double gt { get; set; }

        public string ret_period { get; set; }

        public List<GetAMDHISTGSTR2A> GetAMDHISTGSTR2A { get; set; }

        public List<GetB2BGSTR2A> GetB2BGSTR2A { get; set; }

        public List<GetB2BAGSTR2A> GetB2BAGSTR2A { get; set; }

        public List<GetCDNInvGSTR2A> GetCDNInvGSTR2A { get; set; }

        public List<GetCDNAInvGSTR2A> GetCDNAInvGSTR2A { get; set; }

        public List<GetECOMGSTR2A> GetECOMGSTR2A { get; set; }

        public List<GetECOMAGSTR2A> GetECOMAGSTR2A { get; set; }
        public List<GetIMPGGSTR2A> GetIMPGGSTR2A { get; set; }
        public List<GetIMPGSEZGSTR2A> GetIMPGSEZGSTR2A { get; set; }
        public List<GetISDCreditGSTR2A> GetISDCreditGSTR2A { get; set; }
        public List<GetTCSCreditGSTR2A> GetTCSCreditGSTR2A { get; set; }
        public List<GetTDSCreditGSTR2A> GetTDSCreditGSTR2A { get; set; }

    }
}
