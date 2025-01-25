using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GST_API_Library.Models.CommonAPI
{
    public class SavePrefernceRequest
    {
        public string gstin { get; set; }
        public string fy { get; set; }
        public string quarter { get; set; }
        public string preference { get; set; }
    }
}
