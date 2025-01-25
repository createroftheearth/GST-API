using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using GST_API_Library.Models.GSTR1;
using System.Text.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.Globalization;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;
using System.Text.Json.Serialization;


namespace GST_API_Library.Models.GSTR1
{
    public class GetGSTR1SummaryRes
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

        [JsonProperty("smryTyp", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("smryTyp")]
        public string smryTyp { get; set; }

        [JsonProperty("newSumFlag", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("newSumFlag")]
        public bool? newSumFlag { get; set; }

        [JsonProperty("sec_sum", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("sec_sum")]
        public List<SecSum> sec_sum { get; set; }

        public static implicit operator GetGSTR1SummaryRes(string v)
        {
            throw new NotImplementedException();
        }
    }
    public class CptySum
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

    

    public class SecSum
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
        public List<CptySum> cpty_sum { get; set; }

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
        public List<SubSection> sub_sections { get; set; }
    }

    public class SubSection
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
        public List<CptySum> cpty_sum { get; set; }

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
    //public class GetGSTR1SummaryRes
    //{

    //    [JsonProperty("gstin")]
    //    public string gstin { get; set; }

    //    [JsonProperty("ret_period")]
    //    public string ret_period { get; set; }

    //    [JsonProperty("chksum")]
    //    public string Chksum { get; set; }

    //    [JsonProperty("smryTyp")]
    //    public string SmryTyp { get; set; }

    //    [JsonProperty("newSumFlag")]
    //    public bool NewSumFlag { get; set; }

    //    [JsonProperty("sec_sum")]
    //    public SecSum[] SecSum { get; set; }
    //    //public string gstin { get; set; }
    //    //public string ret_period { get; set; }
    //    //public string chksum { get; set; }
    //    ////public string smryTyp { get; set; }
    //    //public bool newSumFlag { get; set; }
    //    //public List<SecSum> sec_sum { get; set; }
    //}


    //public partial class SecSum
    //{
    //    [JsonProperty("sec_nm")]
    //    public string SecNm { get; set; }

    //    [JsonProperty("chksum")]
    //    public string Chksum { get; set; }

    //    [JsonProperty("ttl_rec")]
    //    public long TtlRec { get; set; }

    //    [JsonProperty("ttl_tax", NullValueHandling = NullValueHandling.Ignore)]
    //    public double? TtlTax { get; set; }

    //    [JsonProperty("ttl_igst", NullValueHandling = NullValueHandling.Ignore)]
    //    public double? TtlIgst { get; set; }

    //    [JsonProperty("ttl_sgst", NullValueHandling = NullValueHandling.Ignore)]
    //    public double? TtlSgst { get; set; }

    //    [JsonProperty("ttl_cgst", NullValueHandling = NullValueHandling.Ignore)]
    //    public double? TtlCgst { get; set; }

    //    [JsonProperty("ttl_val", NullValueHandling = NullValueHandling.Ignore)]
    //    public double? TtlVal { get; set; }

    //    [JsonProperty("ttl_cess", NullValueHandling = NullValueHandling.Ignore)]
    //    public double? TtlCess { get; set; }

    //    [JsonProperty("act_tax", NullValueHandling = NullValueHandling.Ignore)]
    //    public long? ActTax { get; set; }

    //    [JsonProperty("act_igst", NullValueHandling = NullValueHandling.Ignore)]
    //    public double? ActIgst { get; set; }

    //    [JsonProperty("act_sgst", NullValueHandling = NullValueHandling.Ignore)]
    //    public double? ActSgst { get; set; }

    //    [JsonProperty("act_cgst", NullValueHandling = NullValueHandling.Ignore)]
    //    public double? ActCgst { get; set; }

    //    [JsonProperty("act_val", NullValueHandling = NullValueHandling.Ignore)]
    //    public double? ActVal { get; set; }

    //    [JsonProperty("act_cess", NullValueHandling = NullValueHandling.Ignore)]
    //    public long? ActCess { get; set; }

    //    [JsonProperty("cpty_sum", NullValueHandling = NullValueHandling.Ignore)]
    //    public CptySum[] CptySum { get; set; }

    //    [JsonProperty("ttl_expt_amt", NullValueHandling = NullValueHandling.Ignore)]
    //    public double? TtlExptAmt { get; set; }

    //    [JsonProperty("ttl_ngsup_amt", NullValueHandling = NullValueHandling.Ignore)]
    //    public double? TtlNgsupAmt { get; set; }

    //    [JsonProperty("ttl_nilsup_amt", NullValueHandling = NullValueHandling.Ignore)]
    //    public double? TtlNilsupAmt { get; set; }

    //    [JsonProperty("ttl_doc_issued", NullValueHandling = NullValueHandling.Ignore)]
    //    public long? TtlDocIssued { get; set; }

    //    [JsonProperty("ttl_doc_cancelled", NullValueHandling = NullValueHandling.Ignore)]
    //    public long? TtlDocCancelled { get; set; }

    //    [JsonProperty("net_doc_issued", NullValueHandling = NullValueHandling.Ignore)]
    //    public long? NetDocIssued { get; set; }

    //    [JsonProperty("sub_sections", NullValueHandling = NullValueHandling.Ignore)]
    //    public SubSection[] SubSections { get; set; }
    //}

    //public partial class CptySum
    //{
    //    [JsonProperty("ctin")]
    //    public string Ctin { get; set; }

    //    [JsonProperty("chksum")]
    //    public string Chksum { get; set; }

    //    [JsonProperty("ttl_rec")]
    //    public long TtlRec { get; set; }

    //    [JsonProperty("ttl_tax")]
    //    public double TtlTax { get; set; }

    //    [JsonProperty("ttl_igst")]
    //    public double TtlIgst { get; set; }

    //    [JsonProperty("ttl_sgst")]
    //    public long TtlSgst { get; set; }

    //    [JsonProperty("ttl_cgst")]
    //    public long TtlCgst { get; set; }

    //    [JsonProperty("ttl_val")]
    //    public double TtlVal { get; set; }

    //    [JsonProperty("ttl_cess")]
    //    public double TtlCess { get; set; }

    //    [JsonProperty("trade_name", NullValueHandling = NullValueHandling.Ignore)]
    //    public string TradeName { get; set; }
    //}

    //public partial class SubSection
    //{
    //    [JsonProperty("sec_nm", NullValueHandling = NullValueHandling.Ignore)]
    //    public string SecNm { get; set; }

    //    [JsonProperty("chksum")]
    //    public string Chksum { get; set; }

    //    [JsonProperty("ttl_rec")]
    //    public long TtlRec { get; set; }

    //    [JsonProperty("ttl_tax")]
    //    public double TtlTax { get; set; }

    //    [JsonProperty("ttl_igst")]
    //    public double TtlIgst { get; set; }

    //    [JsonProperty("ttl_sgst")]
    //    public double TtlSgst { get; set; }

    //    [JsonProperty("ttl_cgst")]
    //    public double TtlCgst { get; set; }

    //    [JsonProperty("ttl_val")]
    //    public double TtlVal { get; set; }

    //    [JsonProperty("ttl_cess")]
    //    public double TtlCess { get; set; }

    //    [JsonProperty("cpty_sum", NullValueHandling = NullValueHandling.Ignore)]
    //    public CptySum[] CptySum { get; set; }

    //    [JsonProperty("act_tax", NullValueHandling = NullValueHandling.Ignore)]
    //    public long? ActTax { get; set; }

    //    [JsonProperty("act_igst", NullValueHandling = NullValueHandling.Ignore)]
    //    public long? ActIgst { get; set; }

    //    [JsonProperty("act_sgst", NullValueHandling = NullValueHandling.Ignore)]
    //    public long? ActSgst { get; set; }

    //    [JsonProperty("act_cgst", NullValueHandling = NullValueHandling.Ignore)]
    //    public long? ActCgst { get; set; }

    //    [JsonProperty("act_val", NullValueHandling = NullValueHandling.Ignore)]
    //    public long? ActVal { get; set; }

    //    [JsonProperty("act_cess", NullValueHandling = NullValueHandling.Ignore)]
    //    public long? ActCess { get; set; }

    //    [JsonProperty("typ", NullValueHandling = NullValueHandling.Ignore)]
    //    public Typ? Typ { get; set; }
    //}

    //public enum Typ { B2Cl, Expwop, Expwp };

    //doubleernal static class Converter
    //{
    //    public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
    //    {
    //        MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
    //        DateParseHandling = DateParseHandling.None,
    //        Converters =
    //        {
    //            TypConverter.Singleton,
    //            new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
    //        },
    //    };
    //}

    //doubleernal class TypConverter : JsonConverter
    //{
    //    public override bool CanConvert(Type t) => t == typeof(Typ) || t == typeof(Typ?);

    //    public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
    //    {
    //        if (reader.TokenType == JsonToken.Null) return null;
    //        var value = serializer.Deserialize<string>(reader);
    //        switch (value)
    //        {
    //            case "B2CL":
    //                return Typ.B2Cl;
    //            case "EXPWOP":
    //                return Typ.Expwop;
    //            case "EXPWP":
    //                return Typ.Expwp;
    //        }
    //        throw new Exception("Cannot unmarshal type Typ");
    //    }

    //    public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
    //    {
    //        if (untypedValue == null)
    //        {
    //            serializer.Serialize(writer, null);
    //            return;
    //        }
    //        var value = (Typ)untypedValue;
    //        switch (value)
    //        {
    //            case Typ.B2Cl:
    //                serializer.Serialize(writer, "B2CL");
    //                return;
    //            case Typ.Expwop:
    //                serializer.Serialize(writer, "EXPWOP");
    //                return;
    //            case Typ.Expwp:
    //                serializer.Serialize(writer, "EXPWP");
    //                return;
    //        }
    //        throw new Exception("Cannot marshal type Typ");
    //    }

    //    public static readonly TypConverter Singleton = new TypConverter();
    //}
    ////public class CptySum
    ////{
    ////    public string ctin { get; set; }
    ////    public string chksum { get; set; }
    ////    public double ttl_rec { get; set; }
    ////    public double ttl_tax { get; set; }
    ////    public double ttl_igst { get; set; }
    ////    public double ttl_sgst { get; set; }
    ////    public double ttl_cgst { get; set; }
    ////    public double ttl_val { get; set; }
    ////    public double ttl_cess { get; set; }
    ////}

    ////public class SecSum
    ////{
    ////    public string sec_nm { get; set; }
    ////    public string chksum { get; set; }
    ////    public double ttl_rec { get; set; }
    ////    public double ttl_tax { get; set; }
    ////    public double ttl_igst { get; set; }
    ////    public double ttl_sgst { get; set; }
    ////    public double ttl_cgst { get; set; }
    ////    public double ttl_val { get; set; }
    ////    public double ttl_cess { get; set; }
    ////    public double act_tax { get; set; }
    ////    public double act_igst { get; set; }
    ////    public double act_sgst { get; set; }
    ////    public double act_cgst { get; set; }
    ////    public double act_val { get; set; }
    ////    public double act_cess { get; set; }
    ////    public List<CptySum> cpty_sum { get; set; }
    ////    public double ttl_expt_amt { get; set; }
    ////    public double ttl_ngsup_amt { get; set; }
    ////    public double ttl_nilsup_amt { get; set; }
    ////    public long ttl_doc_issued { get; set; }
    ////    public double ttl_doc_cancelled { get; set; }
    ////    public long net_doc_issued { get; set; }
    ////    public List<SubSection> sub_sections { get; set; }
    ////}

    ////public class SubSection
    ////{
    ////    public string sec_nm { get; set; }
    ////    public string chksum { get; set; }
    ////    public double ttl_rec { get; set; }
    ////    public double ttl_tax { get; set; }
    ////    public double ttl_igst { get; set; }
    ////    public double ttl_sgst { get; set; }
    ////    public double ttl_cgst { get; set; }
    ////    public double ttl_val { get; set; }
    ////    public double ttl_cess { get; set; }
    ////    public List<CptySum> cpty_sum { get; set; }
    ////    public double act_tax { get; set; }
    ////    public double act_igst { get; set; }
    ////    public double act_sgst { get; set; }
    ////    public double act_cgst { get; set; }
    ////    public double act_val { get; set; }
    ////    public double act_cess { get; set; }
    ////    public string typ { get; set; }
    ////}



}