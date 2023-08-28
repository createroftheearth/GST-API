namespace GST_API_Library.Models.GSTR1
{
    public class APIRequestParameters
    {
        public string ret_period { get; set; }
        public string gstin { get; set; }
        public string? action_required { get; set; }
        public string? ctin { get; set; }
        public string? from_time { get; set; }  
        public string? state_cd { get; set; }
    }
}
