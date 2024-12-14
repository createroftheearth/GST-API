using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GST_API_Library.Models.PublicAPI
{
    public class GetDayWiseChangedListofGSTINs
    {
        public int tpgcnt { get; set; }
        public int cpgnum { get; set; }
        public string ismpg { get; set; }
        public int cnt { get; set; }
        public List<GstLst> gstLst { get; set; }
        public int totalCount { get; set; }
    }
    public class Gstdtl
    {
        public string chng_typ { get; set; }
        public string gstin { get; set; }
        public string chng_dt { get; set; }
    }

    public class GstLst
    {
        public string state_cd { get; set; }
        public List<Gstdtl> gstdtls { get; set; }
    }
}
