namespace GST_API_Library.Models.GSTR2A
{
    public class APIRequestParameters
    {
        public string ret_period { get; set; }
        public string gstin { get; set; }
        public string? file_num { get; set; }
        public string int_tran_id { get; set; }

        public string from_time { get; set; }
        public string ctin { get; set; }
    }
}
