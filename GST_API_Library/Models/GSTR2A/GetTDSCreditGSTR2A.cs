using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GST_API_Library.Models.GSTR2A
{
    public class GetTDSCreditGSTR2A
    {
        public List<Td> tds { get; set; }
    }
    public class Td
    {
        public string gstin_ded { get; set; }
        public int amt_ded { get; set; }
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
    }

}
