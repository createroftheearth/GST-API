using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GST_API_Library.Models.GSTR1A
{
    public class GetGSTR1ASummaryResp
    {
        public string gstin { get; set; }
        public string ret_period { get; set; }
        public string chksum { get; set; }
        public string smryTyp { get; set; }
        public bool newSumFlag { get; set; }
        public List<SecSum10> sec_sum { get; set; }

    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class CptySum10
    {
        public string ctin { get; set; }
        public string chksum { get; set; }
        public int ttl_rec { get; set; }
        public double ttl_tax { get; set; }
        public double ttl_igst { get; set; }
        public int ttl_sgst { get; set; }
        public int ttl_cgst { get; set; }
        public double ttl_val { get; set; }
        public double ttl_cess { get; set; }
        public string trade_name { get; set; }
    }

    public class SecSum10
    {
        public string sec_nm { get; set; }
        public string chksum { get; set; }
        public int ttl_rec { get; set; }
        public double ttl_tax { get; set; }
        public double ttl_igst { get; set; }
        public double ttl_sgst { get; set; }
        public double ttl_cgst { get; set; }
        public double ttl_val { get; set; }
        public double ttl_cess { get; set; }
        public int? act_tax { get; set; }
        public double? act_igst { get; set; }
        public double? act_sgst { get; set; }
        public double? act_cgst { get; set; }
        public double? act_val { get; set; }
        public int? act_cess { get; set; }
        public List<CptySum10> cpty_sum { get; set; }
        public double? ttl_expt_amt { get; set; }
        public double? ttl_ngsup_amt { get; set; }
        public double? ttl_nilsup_amt { get; set; }
        public long? ttl_doc_issued { get; set; }
        public int? ttl_doc_cancelled { get; set; }
        public long? net_doc_issued { get; set; }
        public List<SubSection10> sub_sections { get; set; }
    }

    public class SubSection10
    {
        public string sec_nm { get; set; }
        public string chksum { get; set; }
        public int ttl_rec { get; set; }
        public double ttl_tax { get; set; }
        public double ttl_igst { get; set; }
        public double ttl_sgst { get; set; }
        public double ttl_cgst { get; set; }
        public double ttl_val { get; set; }
        public double ttl_cess { get; set; }
        public List<CptySum10> cpty_sum { get; set; }
        public int? act_tax { get; set; }
        public int? act_igst { get; set; }
        public int? act_sgst { get; set; }
        public int? act_cgst { get; set; }
        public int? act_val { get; set; }
        public int? act_cess { get; set; }
        public string typ { get; set; }
    }



}
