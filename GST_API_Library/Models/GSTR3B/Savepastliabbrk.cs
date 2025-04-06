using Newtonsoft.Json;
using Integrated.API.GSTN.GSTR3B;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GST_API_Library.Models.GSTR3B
{
    public class Savepastliabbrk
    {
        public string gstin { get; set; }
        public string ret_period { get; set; }
        public List<Breakup> breakup { get; set; }
    }

    public class Breakup
    {
        public string ret_period { get; set; }
        public Liability1 liability { get; set; }
    }

    public class Liability1
    {
        public double iamt { get; set; }
        public double camt { get; set; }
        public double samt { get; set; }
        public double csamt { get; set; }
    }

}
