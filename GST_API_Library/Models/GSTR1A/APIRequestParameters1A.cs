namespace GST_API_Library.Models.GSTR1A
{
    public class APIRequestParameters1A
    {
        public string ret_period { get; set; }
        public string gstin { get; set; }
        public string? action_required { get; set; }
        public string? ctin { get; set; }
        public string? from_time { get; set; }
        public string? state_cd { get; set; }
        public string? file_num { get; set; }
        public string? smrytyp { get; set; }

        //Garima 19 March 2024

        public string? sub_section { get; set; }
        public string? rtin { get; set; }
        public string sec { get; set; }
    }
}
