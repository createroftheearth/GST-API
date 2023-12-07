using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GST_API_Library.Models.PublicAPI
{
    public class ViewandTrackReturns
    {
        public List<EFiledlist> EFiledlist { get; set; }

    }
    public class EFiledlist
    {
        public string valid { get; set; }
        public string mof { get; set; }
        public string dof { get; set; }
        public string ret_prd { get; set; }
        public string rtntype { get; set; }
        public string arn { get; set; }
        public string status { get; set; }
    }
}
