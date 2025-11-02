using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GST_API_Library.Models
{
    public class Request
    {
        public int? id { get; set; }
        public string? gstin { get; set; }
        public string? ret_period { get; set; }
        public string? isnil { get; set; }
    }
    public class PanRequest : Request
    {
        public string panNo { get; set; }
    }
    public class Gstr1Request
    {
        public GetGSTR1SummaryResponse Data { get; set; }
        public string OTP { get; set; }
        public string PAN { get; set; }
        public int? id { get; set; }
    }
    public class Gstr1NilRequest
    {
        public GetGSTR1SummaryResponse Data { get; set; }
        public string OTP { get; set; }
        public string PAN { get; set; }
        public int? id { get; set; }

    }
    public class GetGSTR1SummaryResponse
    {
        [JsonProperty("gstin", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("gstin")]
        public string gstin { get; set; }

        [JsonProperty("ret_period", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("ret_period")]
        public string ret_period { get; set; }

        [JsonProperty("chksum", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("chksum")]
        public string chksum { get; set; }

        //[JsonProperty("isnil", NullValueHandling = NullValueHandling.Ignore)]
        //[JsonPropertyName("isnil")]
        //public string isnil { get; set; }

        [JsonProperty("smryTyp", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("smryTyp")]
        public string smryTyp { get; set; }

        [JsonProperty("newSumFlag", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("newSumFlag")]
        public bool? newSumFlag { get; set; }

        [JsonProperty("sec_sum", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("sec_sum")]
        public List<SecSumDTO> sec_sum { get; set; }

        public static implicit operator GetGSTR1SummaryResponse(string v)
        {
            throw new NotImplementedException();
        }
    }
    public class CptySumDTO
    {
        [JsonProperty("ctin", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("ctin")]
        public string ctin { get; set; }

        [JsonProperty("chksum", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("chksum")]
        public string chksum { get; set; }

        [JsonProperty("ttl_rec", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("ttl_rec")]
        public double? ttl_rec { get; set; }

        [JsonProperty("ttl_tax", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("ttl_tax")]
        public double? ttl_tax { get; set; }

        [JsonProperty("ttl_igst", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("ttl_igst")]
        public double? ttl_igst { get; set; }

        [JsonProperty("ttl_sgst", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("ttl_sgst")]
        public double? ttl_sgst { get; set; }

        [JsonProperty("ttl_cgst", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("ttl_cgst")]
        public double? ttl_cgst { get; set; }

        [JsonProperty("ttl_val", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("ttl_val")]
        public double? ttl_val { get; set; }

        [JsonProperty("ttl_cess", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("ttl_cess")]
        public double? ttl_cess { get; set; }
    }

    public class SecSumSecSumDTO
    {
        [JsonProperty("sec_nm", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("sec_nm")]
        public string sec_nm { get; set; }

        [JsonProperty("chksum", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("chksum")]
        public string chksum { get; set; }

        [JsonProperty("ttl_rec", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("ttl_rec")]
        public double? ttl_rec { get; set; }

        [JsonProperty("ttl_tax", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("ttl_tax")]
        public double? ttl_tax { get; set; }

        [JsonProperty("ttl_igst", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("ttl_igst")]
        public double? ttl_igst { get; set; }

        [JsonProperty("ttl_sgst", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("ttl_sgst")]
        public double? ttl_sgst { get; set; }

        [JsonProperty("ttl_cgst", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("ttl_cgst")]
        public double? ttl_cgst { get; set; }

        [JsonProperty("ttl_val", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("ttl_val")]
        public double? ttl_val { get; set; }

        [JsonProperty("ttl_cess", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("ttl_cess")]
        public double? ttl_cess { get; set; }
        [JsonProperty("act_tax", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("act_tax")]
        public double? act_tax { get; set; }

        [JsonProperty("act_igst", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("act_igst")]
        public double? act_igst { get; set; }

        [JsonProperty("act_sgst", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("act_sgst")]
        public double? act_sgst { get; set; }

        [JsonProperty("act_cgst", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("act_cgst")]
        public double? act_cgst { get; set; }

        [JsonProperty("act_val", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("act_val")]
        public double? act_val { get; set; }

        [JsonProperty("act_cess", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("act_cess")]
        public double? act_cess { get; set; }

        [JsonProperty("cpty_sum", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("cpty_sum")]
        public List<CptySumDTO> cpty_sum { get; set; }

        [JsonProperty("ttl_expt_amt", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("ttl_expt_amt")]
        public double? ttl_expt_amt { get; set; }

        [JsonProperty("ttl_ngsup_amt", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("ttl_ngsup_amt")]
        public double? ttl_ngsup_amt { get; set; }

        [JsonProperty("ttl_nilsup_amt", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("ttl_nilsup_amt")]
        public double? ttl_nilsup_amt { get; set; }

        [JsonProperty("ttl_doc_issued", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("ttl_doc_issued")]
        public long? ttl_doc_issued { get; set; }

        [JsonProperty("ttl_doc_cancelled", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("ttl_doc_cancelled")]
        public double? ttl_doc_cancelled { get; set; }

        [JsonProperty("net_doc_issued", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("net_doc_issued")]
        public long? net_doc_issued { get; set; }

        [JsonProperty("sub_sections", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("sub_sections")]
        public List<SubSectionDTO> sub_sections { get; set; }
    }

    public class SubSectionDTO
    {
        [JsonProperty("sec_nm", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("sec_nm")]
        public string sec_nm { get; set; }

        [JsonProperty("chksum", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("chksum")]
        public string chksum { get; set; }

        [JsonProperty("ttl_rec", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("ttl_rec")]
        public double? ttl_rec { get; set; }

        [JsonProperty("ttl_tax", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("ttl_tax")]
        public double? ttl_tax { get; set; }

        [JsonProperty("ttl_igst", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("ttl_igst")]
        public double? ttl_igst { get; set; }

        [JsonProperty("ttl_sgst", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("ttl_sgst")]
        public double? ttl_sgst { get; set; }

        [JsonProperty("ttl_cgst", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("ttl_cgst")]
        public double? ttl_cgst { get; set; }

        [JsonProperty("ttl_val", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("ttl_val")]
        public double? ttl_val { get; set; }

        [JsonProperty("ttl_cess", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("ttl_cess")]
        public double? ttl_cess { get; set; }

        [JsonProperty("cpty_sum", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("cpty_sum")]
        public List<CptySumDTO> cpty_sum { get; set; }

        [JsonProperty("act_tax", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("act_tax")]
        public double? act_tax { get; set; }

        [JsonProperty("act_igst", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("act_igst")]
        public double? act_igst { get; set; }

        [JsonProperty("act_sgst", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("act_sgst")]
        public double? act_sgst { get; set; }

        [JsonProperty("act_cgst", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("act_cgst")]
        public double? act_cgst { get; set; }

        [JsonProperty("act_val", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("act_val")]
        public double? act_val { get; set; }

        [JsonProperty("act_cess", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("act_cess")]
        public double? act_cess { get; set; }

        [JsonProperty("typ", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("typ")]
        public string typ { get; set; }
    }

    public class SecSumDTO
    {
        [JsonProperty("sec_nm", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("sec_nm")]
        public string sec_nm { get; set; }

        [JsonProperty("chksum", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("chksum")]
        public string chksum { get; set; }

        [JsonProperty("ttl_rec", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("ttl_rec")]
        public double? ttl_rec { get; set; }

        [JsonProperty("ttl_tax", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("ttl_tax")]
        public double? ttl_tax { get; set; }

        [JsonProperty("ttl_igst", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("ttl_igst")]
        public double? ttl_igst { get; set; }

        [JsonProperty("ttl_sgst", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("ttl_sgst")]
        public double? ttl_sgst { get; set; }

        [JsonProperty("ttl_cgst", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("ttl_cgst")]
        public double? ttl_cgst { get; set; }

        [JsonProperty("ttl_val", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("ttl_val")]
        public double? ttl_val { get; set; }

        [JsonProperty("ttl_cess", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("ttl_cess")]
        public double? ttl_cess { get; set; }
        // [Newtonsoft.Json.JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonProperty("act_tax", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("act_tax")]
        public double? act_tax { get; set; }

        [JsonProperty("act_igst", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("act_igst")]
        public double? act_igst { get; set; }

        [JsonProperty("act_sgst", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("act_sgst")]
        public double? act_sgst { get; set; }

        [JsonProperty("act_cgst", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("act_cgst")]
        public double? act_cgst { get; set; }

        [JsonProperty("act_val", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("act_val")]
        public double? act_val { get; set; }

        [JsonProperty("act_cess", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("act_cess")]
        public double? act_cess { get; set; }

        [JsonProperty("cpty_sum", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("cpty_sum")]
        public List<CptySumDTO> cpty_sum { get; set; }

        [JsonProperty("ttl_expt_amt", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("ttl_expt_amt")]
        public double? ttl_expt_amt { get; set; }

        [JsonProperty("ttl_ngsup_amt", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("ttl_ngsup_amt")]
        public double? ttl_ngsup_amt { get; set; }

        [JsonProperty("ttl_nilsup_amt", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("ttl_nilsup_amt")]
        public double? ttl_nilsup_amt { get; set; }

        [JsonProperty("ttl_doc_issued", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("ttl_doc_issued")]
        public long? ttl_doc_issued { get; set; }

        [JsonProperty("ttl_doc_cancelled", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("ttl_doc_cancelled")]
        public double? ttl_doc_cancelled { get; set; }

        [JsonProperty("net_doc_issued", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("net_doc_issued")]
        public long? net_doc_issued { get; set; }

        [JsonProperty("sub_sections", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("sub_sections")]
        public List<SubSectionDTO> sub_sections { get; set; }
    }

    public class Gstr1NilFileRequest1
    {
        public string gstin { get; set; }
        public string? ret_period { get; set; }
        public string OTP { get; set; }
        public string PAN { get; set; }
        public string? isnil { get; set; } = "Y";
    }
}
