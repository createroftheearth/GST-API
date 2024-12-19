using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GST_API_Library.Models.CommonAPI
{
    public class GetFileDetails
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
