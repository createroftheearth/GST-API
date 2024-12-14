using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GST_API_Library.Models.GSTR3B
{
    public class GetITCReversalBalance
    {
        public string gstin { get; set; }
        public Clsbal clsbal { get; set; }
    }
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Clsbal
    {
        public int igst { get; set; }
        public int cgst { get; set; }
        public int sgst { get; set; }
        public int cess { get; set; }
    }
}
