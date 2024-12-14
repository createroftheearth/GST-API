using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using GST_API_Library.Models.GSTR1;

namespace Integrated.API.GSTN.GSTR1
{
    public class TXPA
    {
        public List<Txpdum> txpda { get; set; }
    }

    public class Itms
    {
        public int rt { get; set; }
        public int ad_amt { get; set; }
        public int iamt { get; set; }
        public int csamt { get; set; }
    }
    public class Txpdum
    {
        public string flag { get; set; }
        public string chksum { get; set; }
        public string omon { get; set; }
        public string pos { get; set; }
        public string sply_ty { get; set; }
        public List<Itms> itms { get; set; }
    }


}
