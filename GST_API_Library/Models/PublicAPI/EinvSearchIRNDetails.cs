using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GST_API_Library.Models.PublicAPI
{
    public class EinvSearchIRNDetails
    {
        public string irn { get; set; }
        public string regirp { get; set; }
        public string cnclirp { get; set; }
        public string status { get; set; }
        public string regtime { get; set; }
        public string cncltime { get; set; }
    }
}
