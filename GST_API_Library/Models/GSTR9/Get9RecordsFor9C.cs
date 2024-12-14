using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GST_API_Library.Models.GSTR9;

namespace GST_API_Library.Models.GSTR9
{
    public class Get9RecordsFor9C
    {
        public Gstr9ToGstr9c gstr9_to_gstr9c { get; set; }
    }
    public class Gstr9ToGstr9c
    {
        public string gstin { get; set; }
        public string fp { get; set; }
        public Table5_9C table5 { get; set; }
        public Table7_9C table7 { get; set; }
        public Table9_9C table9 { get; set; }
        public Table12_9C table12 { get; set; }
        public Table14_9C table14 { get; set; }
    }

    public class ItcClaimedfrom9
    {
        public long cgst { get; set; }
        public long sgst { get; set; }
        public long igst { get; set; }
        public long cess { get; set; }
    }

    public class Table12_9C
    {
        public ItcClaimedfrom9 itc_claimedfrom9 { get; set; }
    }

    public class Table14_9C
    {
        public ItcClaimedfrom9 itc_claimedfrom9 { get; set; }
    }

    public class Table5_9C
    {
        public int annul_turn_decl { get; set; }
    }

    public class Table7_9C
    {
        public int tax_turn_annul { get; set; }
    }

    public class Table9_9C
    {
        public TotAmtPaid tot_amt_paid { get; set; }
    }

    public class TotAmtPaid
    {
        public long cgst { get; set; }
        public long sgst { get; set; }
        public long igst { get; set; }
        public long cess { get; set; }
    }



}
