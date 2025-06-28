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
        public int id { get; set; }
    }
    public class PanRequest : Request
    {
        public string panNo { get; set; }
    }
    public class Gstr1Request : Request
    {
        public Gstr1FileRequest Data { get; set; }
        public string OTP { get; set; }
        public string PAN { get; set; }
    }

    public class Gstr1FileRequest
    {
        //public string Data { get; set; } = null!;
        //public string OTP { get; set; } = null!;
        //public string PAN { get; set; } = null!;

        public string gstin { get; set; }
        public string ret_period { get; set; }

        public string chksum { get; set; }

        public string smryTyp { get; set; } = "L";

        public bool? newSumFlag { get; set; }

        public List<SecSumDto> sec_sum { get; set; }

    }
    //public class Gstr1FileRequest: Request
    //{
    //    public string OTP { get; set; } = null!;
    //    public string PAN { get; set; } = null!;
    //    public string gstin { get; set; }

    //    public string ret_period { get; set; }

    //    public string chksum { get; set; }

    //    public string smryTyp { get; set; }

    //    public bool? newSumFlag { get; set; }

    //    public List<SecSum> sec_sum { get; set; }

    //}

    public class SecSumDto
    {
        public string sec_nm { get; set; }

        public string chksum { get; set; }

        public double? ttl_rec { get; set; }

        public double? ttl_tax { get; set; }

        public double? ttl_igst { get; set; }

        public double? ttl_sgst { get; set; }

        public double? ttl_cgst { get; set; }

        public double? ttl_val { get; set; }

        public double? ttl_cess { get; set; }
        public double? act_tax { get; set; }

        public double? act_igst { get; set; }

        public double? act_sgst { get; set; }

        public double? act_cgst { get; set; }

        public double? act_val { get; set; }

        public double? act_cess { get; set; }

        public List<CptySumDto> cpty_sum { get; set; }

        public double? ttl_expt_amt { get; set; }

        public double? ttl_ngsup_amt { get; set; }

        public double? ttl_nilsup_amt { get; set; }

        public long? ttl_doc_issued { get; set; }

        public double? ttl_doc_cancelled { get; set; }

        public long? net_doc_issued { get; set; }

        public List<SubSectionDto> sub_sections { get; set; }
    }

    public class CptySumDto
    {
        public string ctin { get; set; }

        public string chksum { get; set; }

        public double? ttl_rec { get; set; }

        public double? ttl_tax { get; set; }

        public double? ttl_igst { get; set; }

        public double? ttl_sgst { get; set; }

        public double? ttl_cgst { get; set; }

        public double? ttl_val { get; set; }

        public double? ttl_cess { get; set; }
    }

    public class SubSectionDto
    {
        public string sec_nm { get; set; }

        public string chksum { get; set; }

        public double? ttl_rec { get; set; }

        public double? ttl_tax { get; set; }

        public double? ttl_igst { get; set; }

        public double? ttl_sgst { get; set; }

        public double? ttl_cgst { get; set; }

        public double? ttl_val { get; set; }

        public double? ttl_cess { get; set; }

        public List<CptySumDto> cpty_sum { get; set; }

        public double? act_tax { get; set; }

        public double? act_igst { get; set; }

        public double? act_sgst { get; set; }

        public double? act_cgst { get; set; }

        public double? act_val { get; set; }

        public double? act_cess { get; set; }

        public string? typ { get; set; }
    }

}
