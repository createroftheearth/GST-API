using GST_API_Library.Models.GSTR1A;
using Integrated.API.GSTN.GSTR1A;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GST_API_Library.Models.GSTR1A
{
    public class GSTR1ATotal
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

        //[Required]
        //[Display(Name = "Gross Turnover of the taxpayer in the previous FY")]
        //public double gt { get; set; }
        
        public List<GetATGSTR1AResp> at { get; set; }

        public List<GetATAGSTR1AResp> ata { get; set; }

        public List<GetGSTR1ASummaryResp> smry { get; set; }

        public List<GetB2BGSTR1AResp> b2b { get; set; }

        public List<GetB2BAGSTR1AResp> b2ba { get; set; }

        public List<GetB2CLGSTR1AResp> b2cl { get; set; }

        public List<GetB2CLAGSTR1AResp> b2cla { get; set; }

        public List<GetB2CSGSTR1AResp> b2cs { get; set; }

        public List<GetB2CSAGSTR1AResp> b2csa { get; set; }

        public List<GetTXPGSTR1AResp> txp { get; set; }

        public List<GetHSNSMRYGSTR1AResp> hsn { get; set; }

        public List<GetNILGSTR1AResp> nil { get; set; }
    }
}
