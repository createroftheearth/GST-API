using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GST_API_Library.Models.CommonAPI
{
    public class GetAddLateFeeBrkup
    {
        public string gstin { get; set; }
        public string rtnTyp { get; set; }
        public string rtnPrd { get; set; }
        public List<CurrLateFee> currLateFee { get; set; }
        public PriorPrdLtFee priorPrdLtFee { get; set; }

    }

    public class CurrLateFee
    {
        public string rtnTyp { get; set; }
        public string rtnPrd { get; set; }
        public int cgst { get; set; }
        public int sgst { get; set; }
    }

    public class LtFeeDet
    {
        public string rtnTypOrg { get; set; }
        public string rtnPrdOrg { get; set; }
        public string filingDtOrg { get; set; }
        public string isNilOrg { get; set; }
        public int totalDays { get; set; }
        public int paidDays { get; set; }
        public int dueDays { get; set; }
        public int totalAmtCgst { get; set; }
        public int totalAmtSgst { get; set; }
        public int paidAmtCgst { get; set; }
        public int paidAmtSgst { get; set; }
        public int dueAmtCgst { get; set; }
        public int dueAmtSgst { get; set; }
        public string tranTyp { get; set; }
    }

    public class PriorPrdLtFee
    {
        public int totcgstamnt { get; set; }
        public int totsgstamnt { get; set; }
        public List<LtFeeDet> ltFeeDet { get; set; }
    }
}
