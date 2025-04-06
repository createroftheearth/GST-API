using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GST_API_Library.Models.GSTR1A;


namespace Integrated.API.GSTN.GSTR1A
{
    public class GetNILGSTR1AResp
    {
        public Nil nil { get; set; }

    }
    public class Inv
    {
        public string sply_ty { get; set; }
        public double expt_amt { get; set; }
        public double nil_amt { get; set; }
        public double ngsup_amt { get; set; }
    }

    public class Nil
    {
        public string flag { get; set; }
        public string chksum { get; set; }
        public List<Inv> inv { get; set; }
    }
}
