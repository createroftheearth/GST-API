using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GST_API_Library.Models.PublicAPI
{
    public class SearchTaxpayer
    {
        public string stjCd { get; set; }
        public string lgnm { get; set; }
        public string stj { get; set; }
        public string dty { get; set; }
        public string cxdt { get; set; }
        public string gstin { get; set; }
        public string einvoiceStatus { get; set; }
        public List<string> nba { get; set; }
        public string lstupdt { get; set; }
        public string rgdt { get; set; }
        public string ctb { get; set; }
        public string sts { get; set; }
        public string ctjCd { get; set; }
        public string ctj { get; set; }
        public string tradeNam { get; set; }
        public List<Adadr> adadr { get; set; }
        public Pradr pradr { get; set; }
    }
    public class Adadr
    {
        public Addr addr { get; set; }
        public List<string> ntr { get; set; }
    }

    public class Addr
    {
        public string bnm { get; set; }
        public string st { get; set; }
        public string loc { get; set; }
        public string bno { get; set; }
        public string stcd { get; set; }
        public string flno { get; set; }
        public string lt { get; set; }
        public string lg { get; set; }
        public string pncd { get; set; }
    }

    public class Pradr
    {
        public Addr addr { get; set; }
        public List<string> ntr { get; set; }
    }
}
