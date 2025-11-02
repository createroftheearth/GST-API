using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GST_API_Library.Models.GSTR3DTO
{
    public class Gstr3Dto
    {
        public string? GetGstr3Request { get; set; }
        public DateTime FinancialPeriod { get; set; }
        public string? GSTINNo { get; set; }
        public string? GetGstr3Response { get; set; }
        public string? Gstr3SaveRequest { get; set; }
        public string? SaveGstr3Reponse { get; set; }
    }
}
