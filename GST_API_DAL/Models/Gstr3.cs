using System.ComponentModel.DataAnnotations;

namespace GST_API_DAL.Models
{
    public class Gstr3 : BaseEntity
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "GSTIN is mandatory.")]
        [StringLength(15, ErrorMessage = "GSTIN No cannot exceed 15 characters.")]
        [Display(Name = "GSTIN No")]
        [RegularExpression(@"\d{2}[A-Z]{5}\d{4}[A-Z]{1}[A-Z\d]{1}[Z\d]{1}[A-Z\d]{1}", ErrorMessage = "Not a valid GSTIN-No.")]
        public required string GSTINNo { get; set; }

        [Required(ErrorMessage = "Financial Period is mandatory.")]
        [Display(Name = "Financial Period")]
        public DateTime FinancialPeriod { get; set; }
        public int? SaveGstr3Status { get; set; }

        public string? GetGSTR3Request { get; set; }
        public string? GetGSTR3Response { get; set; }

        [Required(ErrorMessage = "GSTR3 Save Data is mandatory.")]
        [Display(Name = "GSTR3 Save Request Data")]
        public string? Gstr3SaveRequest { get; set; }
        public string? SaveGstr3Reponse { get; set; }
    }
}
