using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GST_API_Library.Models.GSTR3B
{
    public class GetOpeningBalance_RCM
    {
        public string gstin { get; set; }
        public List<Tr2> tr { get; set; }
    }
    public class Opnbal2
    {
        public int igst { get; set; }
        public int cgst { get; set; }
        public int sgst { get; set; }
        public int cess { get; set; }
    }

    public class Tr2
    {
        public string trandt { get; set; }
        public string refno { get; set; }
        public Opnbal2 opnbal { get; set; }
        public string action { get; set; }
    }
}
