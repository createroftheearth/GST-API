using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GST_API_Library.Models.GSTRIMS;


namespace Integrated.API.GSTN.GSTRIMS
{
    public class GetIMSFileDetailResp
    {

        public int fc { get; set; }
        public List<Url> urls { get; set; }
        public string ek { get; set; }
    }
    public class Url
    {
        public string ul { get; set; }
        public int ic { get; set; }
        public string hash { get; set; }
    }


}
