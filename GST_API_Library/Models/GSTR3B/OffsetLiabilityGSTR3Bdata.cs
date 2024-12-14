using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GST_API_Library.Models.GSTR3B
{
    public class OffsetLiabilityGSTR3Bdata
    {
        public List<PdcashFor3BOffset> pdcash { get; set; }
        public PditcFor3BOffset pditc { get; set; }
    }
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class PdcashFor3BOffset
    {
        public int liab_ldg_id { get; set; }
        public int trans_typ { get; set; }
        public int ipd { get; set; }
        public int cpd { get; set; }
        public int spd { get; set; }
        public int cspd { get; set; }
        public int i_intrpd { get; set; }
        public int c_intrpd { get; set; }
        public int s_intrpd { get; set; }
        public int cs_intrpd { get; set; }
        public int c_lfeepd { get; set; }
        public int s_lfeepd { get; set; }
    }

    public class PditcFor3BOffset
    {
        public int liab_ldg_id { get; set; }
        public int trans_typ { get; set; }
        public int i_pdi { get; set; }
        public int i_pdc { get; set; }
        public int i_pds { get; set; }
        public int c_pdi { get; set; }
        public int c_pdc { get; set; }
        public int s_pdi { get; set; }
        public int s_pds { get; set; }
        public int cs_pdcs { get; set; }
    }
}
