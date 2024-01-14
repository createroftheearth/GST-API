using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GST_API_Library.Models.GSTR9;

namespace GST_API_Library.Models.GSTR9
{
    public class Get8A_Details
    {
        public string gstin { get; set; }
        public string fy { get; set; }
        public int docid { get; set; }
        public List<B2b> b2b { get; set; }
        public List<B2ba> b2ba { get; set; }
        public List<Cdn> cdn { get; set; }
        public List<Cdna> cdna { get; set; }
    }
    public class B2b
    {
        public string stin { get; set; }
        public string rtnPrd { get; set; }
        public string filingdt { get; set; }
        public List<Document> documents { get; set; }
    }

    public class B2ba
    {
        public string stin { get; set; }
        public string rtnPrd { get; set; }
        public string filingdt { get; set; }
        public List<Document> documents { get; set; }
    }

    public class Cdn
    {
        public string stin { get; set; }
        public string rtnPrd { get; set; }
        public string filingdt { get; set; }
        public List<Document> documents { get; set; }
    }

    public class Cdna
    {
        public string stin { get; set; }
        public string rtnPrd { get; set; }
        public string filingdt { get; set; }
        public List<Document> documents { get; set; }
    }

    public class Document
    {
        public string inum { get; set; }
        public string idt { get; set; }
        public int val { get; set; }
        public string pos { get; set; }
        public string rchrg { get; set; }
        public int txval { get; set; }
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
        public string inv_typ { get; set; }
        public string iseligible { get; set; }
        public string reason { get; set; }
        public string oinum { get; set; }
        public string oidt { get; set; }
        public string ntty { get; set; }
        public string nt_num { get; set; }
        public string nt_dt { get; set; }
        public string ont_num { get; set; }
        public string ont_dt { get; set; }
        public string ontty { get; set; }
    }

}
