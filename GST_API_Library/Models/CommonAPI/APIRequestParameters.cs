namespace GST_API_Library.Models.CommonAPI
{
    public class APIRequestParameters
    {
        public string ret_period { get; set; }
        public string gstin { get; set; }
        public string? doc_id { get; set; }
        public string? file_num { get; set; }
        public string? ret_type { get; set; }

        public string? token { get; set; }

        public string rtn_typ { get; set; }
    }


}
