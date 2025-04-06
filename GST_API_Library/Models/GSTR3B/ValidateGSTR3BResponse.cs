using Newtonsoft.Json;
using Integrated.API.GSTN.GSTR3B;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GST_API_Library.Models.GSTR3B
{
   
    public class ValidateGSTR3BResponse
    {
        public string gstin { get; set; }
        public string ret_period { get; set; }
        public string isValid { get; set; }
        public string error_message { get; set; }
        public SupDetails2 sup_details { get; set; }
        public InterSup2 inter_sup { get; set; }
        public EcoDtls2 eco_dtls { get; set; }
        public Elgitc2 elgitc { get; set; }
    }

    public class EcoDtls2
    {
        public EcoSup2 eco_sup { get; set; }
        public EcoRegSup2 eco_reg_sup { get; set; }
    }

    public class EcoRegSup2
    {
        public List<string> error_fields { get; set; }
    }

    public class EcoSup2
    {
        public List<string> error_fields { get; set; }
    }

    public class Elgitc2
    {
        public Itc4a1 itc4a1 { get; set; }
        public Itc4a3 itc4a3 { get; set; }
        public Itc4a4 itc4a4 { get; set; }
        public Itc4a5 itc4a5 { get; set; }
        public Itc4b2 itc4b2 { get; set; }
        public Itc4d2 itc4d2 { get; set; }
    }

    public class InterSup2
    {
        public List<OsupUnreg32> osup_unreg_3_2 { get; set; }
        public List<OsupComp32> osup_comp_3_2 { get; set; }
        public List<OsupUin32> osup_uin_3_2 { get; set; }
    }

    public class Isup31d
    {
        public List<string> error_fields { get; set; }
    }

    public class Itc4a1
    {
        public List<string> error_fields { get; set; }
    }

    public class Itc4a3
    {
        public List<string> error_fields { get; set; }
    }

    public class Itc4a4
    {
        public List<string> error_fields { get; set; }
    }

    public class Itc4a5
    {
        public List<string> error_fields { get; set; }
    }

    public class Itc4b2
    {
        public List<string> error_fields { get; set; }
    }

    public class Itc4d2
    {
        public List<string> error_fields { get; set; }
    }

    public class Osup31a
    {
        public List<string> error_fields { get; set; }
    }

    public class Osup31b
    {
        public List<string> error_fields { get; set; }
    }

    public class Osup31c
    {
        public List<string> error_fields { get; set; }
    }

    public class Osup31e
    {
        public List<string> error_fields { get; set; }
    }

    public class OsupComp32
    {
        public string pos { get; set; }
        public List<string> error_fields { get; set; }
    }

    public class OsupUin32
    {
        public string pos { get; set; }
        public List<string> error_fields { get; set; }
    }

    public class OsupUnreg32
    {
        public string pos { get; set; }
        public List<string> error_fields { get; set; }
    }

    public class SupDetails2
    {
        public Osup31a osup_3_1a { get; set; }
        public Osup31b osup_3_1b { get; set; }
        public Osup31c osup_3_1c { get; set; }
        public Isup31d isup_3_1d { get; set; }
        public Osup31e osup_3_1e { get; set; }
    }


}
