using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GST_API_Library.Models.GSTR3B
{
    public class GetOpeningBalanceReclaimDetails
    {
        public string gstin { get; set; }
        public List<Tr> tr { get; set; }
    }
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Opnbal
    {
        public int igst { get; set; }
        public int cgst { get; set; }
        public int sgst { get; set; }
        public int cess { get; set; }
    }


    public class Tr
    {
        public string trandt { get; set; }
        public string refno { get; set; }
        public string action { get; set; }
        public Opnbal opnbal { get; set; }
    }

}
