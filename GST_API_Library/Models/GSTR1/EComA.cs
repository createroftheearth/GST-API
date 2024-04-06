using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using GST_API_Library.Models.GSTR1;

namespace GST_API_Library.Models.GSTR1
{
    public class EComA
    {

        public class B2ba
        {
            public List<Inv> inv { get; set; }
            public string rtin { get; set; }
            public string stin { get; set; }
        }

        public class B2ca
        {
            public string pos { get; set; }
            public List<PosItm> posItms { get; set; }
        }

        public class Ecoma
        {
            public List<B2ba> b2ba { get; set; }
            public List<B2ca> b2ca { get; set; }
            public List<Urp2ba> urp2ba { get; set; }
            public List<Urp2ca> urp2ca { get; set; }
        }

        public class Inv
        {
            public int val { get; set; }
            public List<Itm> itms { get; set; }
            public string oinum { get; set; }
            public string flag { get; set; }
            public string inum { get; set; }
            public string inv_typ { get; set; }
            public string pos { get; set; }
            public string idt { get; set; }
            public string oidt { get; set; }
            public string sply_ty { get; set; }
            public string chksum { get; set; }
        }

        public class Itm
        {
            public int num { get; set; }
            public ItmDet itm_det { get; set; }
            public int csamt { get; set; }
            public int samt { get; set; }
            public double rt { get; set; }
            public int txval { get; set; }
            public int camt { get; set; }
            public double iamt { get; set; }
        }

        public class ItmDet
        {
            public int rt { get; set; }
            public int txval { get; set; }
            public double iamt { get; set; }
            public double? camt { get; set; }
            public double? samt { get; set; }
            public double? csamt { get; set; }
        }

        public class PosItm
        {
            public string flag { get; set; }
            public string omon { get; set; }
            public string sply_ty { get; set; }
            public string stin { get; set; }
            public string chksum { get; set; }
            public List<Itm> itms { get; set; }
        }

        public class Root
        {
            public Ecoma ecoma { get; set; }
        }

        public class Urp2ba
        {
            public List<Inv> inv { get; set; }
            public string rtin { get; set; }
        }

        public class Urp2ca
        {
            public List<Itm> itms { get; set; }
            public string flag { get; set; }
            public string pos { get; set; }
            public string omon { get; set; }
            public string sply_ty { get; set; }
            public string chksum { get; set; }
        }
    }
}