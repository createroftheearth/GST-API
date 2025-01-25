using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GST_API_Library.Models.PublicAPI
{
    public class UnregApplicantsResponse
    {
        public string name { get; set; }
        public string pan { get; set; }
        public string state { get; set; }
        public Addtls addtls { get; set; }
        public string goodsdetails { get; set; }
        public string servicedetails { get; set; }
    }

        public class Addtls
        {
            public string bno { get; set; }
            public string bnm { get; set; }
            public string st { get; set; }
            public string loc { get; set; }
            public string pncd { get; set; }
            public string stcd { get; set; }
            public string lg { get; set; }
            public string lt { get; set; }
            public string dst { get; set; }
            public string cnty { get; set; }
            public string landMark { get; set; }
            public string city { get; set; }
        }
 }
