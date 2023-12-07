using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GST_API_Library.Models.GSTR9;

namespace GST_API_Library.Models.GSTR9
{
    public class APIRequestParamtersGSTR9
    {
        public string ret_period { get; set; }
        public string gstin { get; set; }
        public string? action_required { get; set; }
        public string? ctin { get; set; }
        public string? from_time { get; set; }
        public string? state_cd { get; set; }
        public string? file_num { get; set; }
        public string? fy { get; set; }
        public string? docid { get; set; }
    }
}
