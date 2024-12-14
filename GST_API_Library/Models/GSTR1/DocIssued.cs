using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GST_API_Library.Models.GSTR1
{
    public class DocIssued
    {
        public DocIssue doc_issue { get; set; }

    }
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Doc
    {
        public int num { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public int totnum { get; set; }
        public int cancel { get; set; }
        public int net_issue { get; set; }
    }

    public class DocDet
    {
        public int doc_num { get; set; }
        public List<Doc> docs { get; set; }
    }

    public class DocIssue
    {
        public string flag { get; set; }
        public string chksum { get; set; }
        public List<DocDet> doc_det { get; set; }
    }
}
