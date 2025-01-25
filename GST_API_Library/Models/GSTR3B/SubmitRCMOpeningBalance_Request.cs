using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GST_API_Library.Models.GSTR3B
{
    public class SubmitRCMOpeningBalance_Request
    {
        public string gstin { get; set; }
        public Opnbal3 opnbal { get; set; }
        public string action { get; set; }
    }
    public class Opnbal3
    {
        public int igst { get; set; }
        public int cgst { get; set; }
        public int sgst { get; set; }
        public int cess { get; set; }
    }

}
