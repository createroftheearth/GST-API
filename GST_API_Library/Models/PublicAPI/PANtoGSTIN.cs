using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GST_API_Library.Models.PublicAPI
{
    public class PANtoGSTIN
    {
        public string panNum { get; set; }
        public List<GstinResList> gstinResList { get; set; }
    }
    public class GstinResList
    {
        public string gstin { get; set; }
        public string authStatus { get; set; }
        public string stateCd { get; set; }
    }
}
