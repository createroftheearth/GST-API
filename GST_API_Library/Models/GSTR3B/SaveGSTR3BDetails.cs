using Newtonsoft.Json;
using Integrated.API.GSTN.GSTR3B;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GST_API_Library.Models.GSTR3B
{
   
    public class SaveGSTR3BDetails
    {
        public string gstin { get; set; }
        public string ret_period { get; set; }
        public SupDetails3B sup_details { get; set; }
        public InterSup3B inter_sup { get; set; }
        public EcoDtls3B eco_dtls { get; set; }
        public ItcElg3B itc_elg { get; set; }
        public InwardSup3B inward_sup { get; set; }
        public IntrLtfee3B intr_ltfee { get; set; }
    }

    public class CompDetail3B
    {
        public string pos { get; set; }
        public double? txval { get; set; }
        public double? iamt { get; set; }
    }

    public class EcoDtls3B
    {
        public EcoSup3B eco_sup { get; set; }
        public EcoRegSup3B eco_reg_sup { get; set; }
    }

    public class EcoRegSup3B
    {
        public double? txval { get; set; }
    }

    public class EcoSup3B
    {
        public double? txval { get; set; }
        public double? iamt { get; set; }
        public double? camt { get; set; }
        public double? samt { get; set; }
        public double? csamt { get; set; }
    }

    public class InterSup3B
    {
        public List<UnregDetail3B> unreg_details { get; set; }
        public List<CompDetail3B> comp_details { get; set; }
        public List<UinDetail3B> uin_details { get; set; }
    }

    public class IntrDetails3B
    {
        public double? iamt { get; set; }
        public double? camt { get; set; }
        public double? samt { get; set; }
        public double? csamt { get; set; }
    }

    public class IntrLtfee3B
    {
        public IntrDetails3B intr_details { get; set; }
    }

    public class InwardSup3B
    {
        public List<IsupDetail3B> isup_details { get; set; }
    }

    public class IsupDetail3B
    {
        public string ty { get; set; }
        public double? inter { get; set; }
        public double? intra { get; set; }
    }

    public class IsupRev3B
    {
        public double? txval { get; set; }
        public double? iamt { get; set; }
        public double? camt { get; set; }
        public double? samt { get; set; }
        public double? csamt { get; set; }
    }

    public class ItcAvl3B
    {
        public string ty { get; set; }
        public double? iamt { get; set; }
        public double? camt { get; set; }
        public double? samt { get; set; }
        public double? csamt { get; set; }
    }

    public class ItcElg3B
    {
        public List<ItcAvl3B> itc_avl { get; set; }
        public List<ItcRev3B> itc_rev { get; set; }
        public ItcNet3B itc_net { get; set; }
        public List<ItcInelg3B> itc_inelg { get; set; }
    }

    public class ItcInelg3B
    {
        public string ty { get; set; }
        public double? iamt { get; set; }
        public double? camt { get; set; }
        public double? samt { get; set; }
        public double? csamt { get; set; }
    }

    public class ItcNet3B
    {
        public double? iamt { get; set; }
        public double? camt { get; set; }
        public double? samt { get; set; }
        public double? csamt { get; set; }
    }

    public class ItcRev3B
    {
        public string ty { get; set; }
        public double? iamt { get; set; }
        public double? camt { get; set; }
        public double? samt { get; set; }
        public double? csamt { get; set; }
    }

    public class OsupDet3B
    {
        public double? txval { get; set; }
        public double? iamt { get; set; }
        public double? camt { get; set; }
        public double? samt { get; set; }
        public double? csamt { get; set; }
    }

    public class OsupNilExmp3B
    {
        public double? txval { get; set; }
    }

    public class OsupNongst3B
    {
        public double? txval { get; set; }
    }

    public class OsupZero3B
    {
        public double? txval { get; set; }
        public double? iamt { get; set; }
        public double? csamt { get; set; }
    }

    

    public class SupDetails3B
    {
        public OsupDet3B osup_det { get; set; }
        public OsupZero3B osup_zero { get; set; }
        public OsupNilExmp3B osup_nil_exmp { get; set; }
        public IsupRev3B isup_rev { get; set; }
        public OsupNongst3B osup_nongst { get; set; }
    }

    public class UinDetail3B
    {
        public string pos { get; set; }
        public double? txval { get; set; }
        public double? iamt { get; set; }
    }

    public class UnregDetail3B
    {
        public string pos { get; set; }
        public double? txval { get; set; }
        public double? iamt { get; set; }
    }
}
