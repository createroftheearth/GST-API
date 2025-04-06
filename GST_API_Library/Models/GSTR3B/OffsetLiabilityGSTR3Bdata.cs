using Newtonsoft.Json;
using Integrated.API.GSTN.GSTR3B;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GST_API_Library.Models.GSTR3B
{
    public class OffsetLiabilityGSTR3Bdata
    {
        public List<Pdcash2> pdcash { get; set; }
        public Pditc2 pditc { get; set; }
        public List<Nettaxpay1> nettaxpay { get; set; }
        public List<Pdnl2> pdnls { get; set; }
    }


    public class Cess1
    {
        public int intr { get; set; }
        public int tx { get; set; }
    }

    public class Cgst1
    {
        public int intr { get; set; }
        public int tx { get; set; }
        public int fee { get; set; }
    }

    public class Igst1
    {
        public int intr { get; set; }
        public int tx { get; set; }
    }

    public class Sgst1
    {
        public int intr { get; set; }
        public int tx { get; set; }
        public int fee { get; set; }
    }

    public class Nettaxpay1
    {
        public int trans_typ { get; set; }
        public string trans_desc { get; set; }
        public int liab_ldg_id { get; set; }
        public Sgst1 sgst { get; set; }
        public Cgst1 cgst { get; set; }
        public Cess1 cess { get; set; }
        public Igst1 igst { get; set; }
    }

    public class Pdcash2
    {
        public int liab_ldg_id { get; set; }
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

    public class Pditc2
    {
        public int liab_ldg_id { get; set; }
        public int trans_typ { get; set; }
        public int i_pdi { get; set; }
        public int i_pdc { get; set; }
        public int i_pds { get; set; }
        public int c_pdi { get; set; }
        public int c_pdc { get; set; }
        public int s_pdi { get; set; }
        public int s_pds { get; set; }
        public int cs_pdcs { get; set; }
    }

    public class Pdnl2
    {
        public int liab_ldg_id { get; set; }
        public int trans_typ { get; set; }
        public int ipd { get; set; }
        public int cpd { get; set; }
        public int spd { get; set; }
        public int cspd { get; set; }
    }
    







    //// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    //public class PdcashFor3BOffset
    //{
    //    public int liab_ldg_id { get; set; }
    //    public int trans_typ { get; set; }
    //    public int ipd { get; set; }
    //    public int cpd { get; set; }
    //    public int spd { get; set; }
    //    public int cspd { get; set; }
    //    public int i_intrpd { get; set; }
    //    public int c_intrpd { get; set; }
    //    public int s_intrpd { get; set; }
    //    public int cs_intrpd { get; set; }
    //    public int c_lfeepd { get; set; }
    //    public int s_lfeepd { get; set; }
    //}

    //public class PditcFor3BOffset
    //{
    //    public int liab_ldg_id { get; set; }
    //    public int trans_typ { get; set; }
    //    public int i_pdi { get; set; }
    //    public int i_pdc { get; set; }
    //    public int i_pds { get; set; }
    //    public int c_pdi { get; set; }
    //    public int c_pdc { get; set; }
    //    public int s_pdi { get; set; }
    //    public int s_pds { get; set; }
    //    public int cs_pdcs { get; set; }
    //}


}
