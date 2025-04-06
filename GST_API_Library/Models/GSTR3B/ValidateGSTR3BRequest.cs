using Newtonsoft.Json;
using Integrated.API.GSTN.GSTR3B;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GST_API_Library.Models.GSTR3B
{
   
    public class ValidateGSTR3BRequest
    {
        public string gstin { get; set; }
        public string ret_period { get; set; }
        public SupDetails1 sup_details { get; set; }
        public InterSup1 inter_sup { get; set; }
        public EcoDtls1 eco_dtls { get; set; }
        public ItcElg1 itc_elg { get; set; }
        public InwardSup1 inward_sup { get; set; }
        public IntrLtfee1 intr_ltfee { get; set; }
        public TxPmt1 tx_pmt { get; set; }
    }

    public class CompDetail1
    {
        public string pos { get; set; }
        public int txval { get; set; }
        public int iamt { get; set; }
    }

    public class EcoDtls1
    {
        public EcoSup1 eco_sup { get; set; }
        public EcoRegSup1 eco_reg_sup { get; set; }
    }

    public class EcoRegSup1
    {
        public string txval { get; set; }
    }

    public class EcoSup1
    {
        public int txval { get; set; }
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
    }

    public class InterSup1
    {
        public List<UnregDetail1> unreg_details { get; set; }
        public List<CompDetail1> comp_details { get; set; }
        public List<UinDetail1> uin_details { get; set; }
    }

    public class IntrDetails1
    {
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
    }

    public class IntrLtfee1
    {
        public IntrDetails1 intr_details { get; set; }
    }

    public class InwardSup1
    {
        public List<IsupDetail1> isup_details { get; set; }
    }

    public class IsupDetail1
    {
        public string ty { get; set; }
        public int inter { get; set; }
        public int intra { get; set; }
    }

    public class IsupRev1
    {
        public int txval { get; set; }
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
    }

    public class ItcAvl1
    {
        public string ty { get; set; }
        public double iamt { get; set; }
        public int camt { get; set; }
        public double samt { get; set; }
        public int csamt { get; set; }
    }

    public class ItcElg1
    {
        public List<ItcAvl1> itc_avl { get; set; }
        public List<ItcRev1> itc_rev { get; set; }
        public ItcNet1 itc_net { get; set; }
        public List<ItcInelg1> itc_inelg { get; set; }
    }

    public class ItcInelg1
    {
        public string ty { get; set; }
        public double iamt { get; set; }
        public int camt { get; set; }
        public double samt { get; set; }
        public int csamt { get; set; }
    }

    public class ItcNet1
    {
        public double iamt { get; set; }
        public int camt { get; set; }
        public double samt { get; set; }
        public int csamt { get; set; }
    }

    public class ItcRev1
    {
        public string ty { get; set; }
        public double iamt { get; set; }
        public int camt { get; set; }
        public double samt { get; set; }
        public int csamt { get; set; }
    }

    public class OsupDet1
    {
        public int txval { get; set; }
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
    }

    public class OsupNilExmp1
    {
        public int txval { get; set; }
    }

    public class OsupNongst1
    {
        public int txval { get; set; }
    }

    public class OsupZero1
    {
        public int txval { get; set; }
        public int iamt { get; set; }
        public int csamt { get; set; }
    }

    public class Pdcash3
    {
        public int trans_typ { get; set; }
        public int ipd { get; set; }
        public int cpd { get; set; }
        public int spd { get; set; }
        public int cspd { get; set; }
        public int i_intrpd { get; set; }
        public int c_intrpd { get; set; }
        public int s_intrpd { get; set; }
        public int cs_intrpd { get; set; }
        public int c_lfeepd { get; set; }
        public int s_lfeepd { get; set; }
    }

    public class SupDetails1
    {
        public OsupDet1 osup_det { get; set; }
        public OsupZero1 osup_zero { get; set; }
        public OsupNilExmp1 osup_nil_exmp { get; set; }
        public IsupRev1 isup_rev { get; set; }
        public OsupNongst1 osup_nongst { get; set; }
    }

    public class TxPmt1
    {
        public List<Pdcash3> pdcash { get; set; }
    }

    public class UinDetail1
    {
        public string pos { get; set; }
        public int txval { get; set; }
        public int iamt { get; set; }
    }

    public class UnregDetail1
    {
        public string pos { get; set; }
        public int txval { get; set; }
        public int iamt { get; set; }
    }


}
