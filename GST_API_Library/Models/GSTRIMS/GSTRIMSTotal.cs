using GST_API_Library.Models.GSTRIMS;
using Integrated.API.GSTN.GSTRIMS;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GST_API_Library.Models.GSTRIMSTotal
{
    public class GSTRIMSTotal
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
        
        public List<GetIMSInvoiceCountResp> invoicecount { get; set; }

        
    }
}
