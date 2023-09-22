namespace GST_API_Library.Models.GSTR2B
{
    public class APIRequestParameters
    {
        public string ret_period { get; set; }
        public string gstin { get; set; }
        public string? file_num { get; set; }
    }
}
