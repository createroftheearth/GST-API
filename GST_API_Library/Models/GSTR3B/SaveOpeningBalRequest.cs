using Newtonsoft.Json;
using Integrated.API.GSTN.GSTR3B;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GST_API_Library.Models.GSTR3B
{
   
    public class SaveOpeningBalRequest
    {
        public string gstin { get; set; }
        public Opnbal1 opnbal { get; set; }
        public string action { get; set; }
    }

    public class Opnbal1
    {
        public double igst { get; set; }
        public double cgst { get; set; }
        public double sgst { get; set; }
        public double cess { get; set; }
    }
}
