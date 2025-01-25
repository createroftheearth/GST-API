using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GST_API_Library.Models.GSTR3B
{
    public class GetLatestBalance_RCM
    {
        public string gstin { get; set; }
        public Clsbal1 clsbal { get; set; }
    }
    public class Clsbal1
    {
        public int igst { get; set; }
        public int cgst { get; set; }
        public int sgst { get; set; }
        public int cess { get; set; }
    }
}
