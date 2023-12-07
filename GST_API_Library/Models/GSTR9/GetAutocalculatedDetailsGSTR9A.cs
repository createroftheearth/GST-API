using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GST_API_Library.Models.GSTR9;

namespace GST_API_Library.Models.GSTR9
{
    public class GetAutocalculatedDetailsGSTR9A
    {
        public string gstin { get; set; }
        public string fp { get; set; }
        public string cmp_frmdt { get; set; }
        public string cmp_todt { get; set; }
        public GetAuto9ATable5 table5 { get; set; }
        public GetAuto9ATable6 table6 { get; set; }
        public GetAuto9ATable7 table7 { get; set; }
        public GetAuto9ATable8 table8 { get; set; }
        public GetAuto9ATable9 table9 { get; set; }
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class GetAuto9AB2b
    {
        public int txval { get; set; }
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
    }

    public class B2bur
    {
        public int txval { get; set; }
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
    }

    public class Exmp
    {
        public int trnovr { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
    }

    public class Impg
    {
        public int txval { get; set; }
        public int iamt { get; set; }
        public int csamt { get; set; }
    }

    public class Imps
    {
        public int txval { get; set; }
        public int iamt { get; set; }
        public int csamt { get; set; }
    }
    public class GetAuto9ATable5
    {
        public string chksum { get; set; }
        public double gt { get; set; }
    }

    public class GetAuto9ATable6
    {
        public string chksum { get; set; }
        public List<TxTrnovr> tx_trnovr { get; set; }
        public Exmp exmp { get; set; }
        public Tot tot { get; set; }
    }

    public class GetAuto9ATable7
    {
        public string chksum { get; set; }
        public GetAuto9AB2b b2b { get; set; }
        public B2bur b2bur { get; set; }
        public Imps imps { get; set; }
        public Tot tot { get; set; }
    }

    public class GetAuto9ATable8
    {
        public string chksum { get; set; }
        public B2b b2b { get; set; }
        public Impg impg { get; set; }
    }

    public class GetAuto9ATable9
    {
        public string chksum { get; set; }
        public TxPay tx_pay { get; set; }
        public Txpd txpd { get; set; }
    }

    public class Tot
    {
        public int trnovr { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int txval { get; set; }
        public int iamt { get; set; }
        public int csamt { get; set; }
    }

    public class TxPay
    {
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
        public int intr { get; set; }
        public int fee { get; set; }
    }

    public class Txpd
    {
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
        public int intr { get; set; }
        public int fee { get; set; }
    }

    public class TxTrnovr
    {
        public int rt { get; set; }
        public int trnovr { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
    }



}
