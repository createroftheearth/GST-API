using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GST_API_Library.Models.GSTRIMS;


namespace Integrated.API.GSTN.GSTRIMS
{
    public class GetIMSRequestStatus
    {
        public string status_cd { get; set; }
        public string transTypCd { get; set; }
        public string proc_cnt { get; set; }
        public string err_cnt { get; set; }
        public string err_cd { get; set; }
        public string err_msg { get; set; }
        public ErrorReport error_report { get; set; }

    }

    public class B2b1
    {
        public string stin { get; set; }
        public string error_cd { get; set; }
        public string error_msg { get; set; }
        public List<Inv1> inv { get; set; }
    }

    public class Dn1
    {
        public string stin { get; set; }
        public string error_cd { get; set; }
        public string error_msg { get; set; }
        public List<Inv1> inv { get; set; }
    }

    public class ErrorReport
    {
        public List<B2b1> b2b { get; set; }
        public List<Dn1> dn { get; set; }
    }

    public class Inv1
    {
        public string rtnprd { get; set; }
        public string inum { get; set; }
    }

}
