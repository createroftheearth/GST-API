using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GST_API_Library.Models.CommonAPI
{
    public class UploadDocumentRequest
    {
        public string ct { get; set; }
        public string data { get; set; }
        public string doc_nam { get; set; }

        public string ret_period { get; set; }
    }
}
