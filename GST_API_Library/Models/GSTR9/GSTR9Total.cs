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
    public class GSTR9Total
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

        [Required]
        [Display(Name = "Gross Turnover of the taxpayer in the previous FY")]
        public double gt { get; set; }
        public List<Get8A_Details> get8ADetails { get; set; }
        public List<GetAutocalculatedDetails> getAutocalculatedDetails { get; set; }

        public List<GetDetails> getDetails { get; set; }

        public List<GetAutocalculatedDetailsGSTR9A> getAutocalculatedDetails9A { get; set; }

        public List<GetDetailsGSTR9A> getDetails9A { get; set; }

        public List<Get9RecordsFor9C> get9RecordsFor9C { get; set; }

        public List<GSTR9CGetSummary> get9CSummary { get; set; }

    }
}
