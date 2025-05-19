namespace GST_API_Library.Models.GSTRIMS
{
    public class APIRequestParameters
    {
        public string ret_period { get; set; }
        public string gstin { get; set; }
        public string? goods_typ { get; set; }

        public string? section { get; set; }
        public string? status { get; set; }
        public string? token { get; set; }

        public string int_tran_id { get; set; }

        public string rtn_typ { get; set; }
    }
}
