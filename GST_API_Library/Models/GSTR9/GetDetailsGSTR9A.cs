using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GST_API_Library.Models.GSTR9;

namespace GST_API_Library.Models.GSTR9
{
    public class GetDetailsGSTR9A
    {
        public string gstin { get; set; }
        public string fp { get; set; }
        public string cmp_frmdt { get; set; }
        public string cmp_todt { get; set; }
        public GetDtl9ATable5 table5 { get; set; }
        public GetDtl9ATable6 table6 { get; set; }
        public GetDtl9ATable7 table7 { get; set; }
        public GetDtl9ATable8 table8 { get; set; }
        public GetDtl9ATable9 table9 { get; set; }
        public GetDtl9ATable10 table10 { get; set; }
        public GetDtl9ATable14 table14 { get; set; }
        public GetDtl9ATable15 table15 { get; set; }
        public GetDtl9ATable16 table16 { get; set; }
    }
    public class B2b9A
    {
        public int txval { get; set; }
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
    }

    public class B2bCn
    {
        public int trnovr { get; set; }
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
    }

    public class B2bDn
    {
        public int trnovr { get; set; }
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
    }

    public class GetDtl9AB2bur
    {
        public int txval { get; set; }
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
    }

    public class Credit
    {
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
    }

    public class Debit
    {
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
    }

    public class GetDtl9ADmndPend
    {
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
        public int intr { get; set; }
        public int fee { get; set; }
        public int pen { get; set; }
    }

    public class GetDtl9AExmp
    {
        public int trnovr { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
    }

    public class GetDtl9AImpg
    {
        public int txval { get; set; }
        public int iamt { get; set; }
        public int csamt { get; set; }
    }

    public class GetDtl9AImps
    {
        public int txval { get; set; }
        public int iamt { get; set; }
        public int csamt { get; set; }
    }

    public class Paid
    {
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
        public int intr { get; set; }
    }

    public class Pay
    {
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
        public int intr { get; set; }
    }

    public class GetDtl9ARfdClmd
    {
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
        public int intr { get; set; }
        public int fee { get; set; }
        public int pen { get; set; }
    }

    public class GetDtl9ARfdPend
    {
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
        public int intr { get; set; }
        public int fee { get; set; }
        public int pen { get; set; }
    }

    public class GetDtl9ARfdRejt
    {
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
        public int intr { get; set; }
        public int fee { get; set; }
        public int pen { get; set; }
    }

    public class GetDtl9ARfdSanc
    {
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
        public int intr { get; set; }
        public int fee { get; set; }
        public int pen { get; set; }
    }
    public class GetDtl9ATable10
    {
        public string chksum { get; set; }
        public TxosaDn txosa_dn { get; set; }
        public B2bDn b2b_dn { get; set; }
        public TxosaCn txosa_cn { get; set; }
        public B2bCn b2b_cn { get; set; }
        public TotTrnovr tot_trnovr { get; set; }
    }

    public class GetDtl9ATable14
    {
        public string chksum { get; set; }
        public Pay pay { get; set; }
        public Paid paid { get; set; }
    }

    public class GetDtl9ATable15
    {
        public string chksum { get; set; }
        public GetDtl9ARfdClmd rfd_clmd { get; set; }
        public GetDtl9ARfdSanc rfd_sanc { get; set; }
        public GetDtl9ARfdRejt rfd_rejt { get; set; }
        public GetDtl9ARfdPend rfd_pend { get; set; }
        public GetDtl9ATaxDmnd tax_dmnd { get; set; }
        public GetDtl9ATxpd txpd { get; set; }
        public GetDtl9ADmndPend dmnd_pend { get; set; }
    }

    public class GetDtl9ATable16
    {
        public string chksum { get; set; }
        public Debit debit { get; set; }
        public Credit credit { get; set; }
    }

    public class GetDtl9ATable5
    {
        public string chksum { get; set; }
        public double gt { get; set; }
    }

    public class GetDtl9ATable6
    {
        public string chksum { get; set; }
        public List<TxTrnovr> tx_trnovr { get; set; }
        public GetDtl9AExmp exmp { get; set; }
        public GetDtl9ATot tot { get; set; }
    }

    public class GetDtl9ATable7
    {
        public string chksum { get; set; }
        public B2b9A b2b { get; set; }
        public GetDtl9AB2bur b2bur { get; set; }
        public GetDtl9AImps imps { get; set; }
        public GetDtl9ATot tot { get; set; }
    }

    public class GetDtl9ATable8
    {
        public string chksum { get; set; }
        public B2b b2b { get; set; }
        public GetDtl9AImpg impg { get; set; }
    }

    public class GetDtl9ATable9
    {
        public string chksum { get; set; }
        public TxPay tx_pay { get; set; }
        public Txpd txpd { get; set; }
    }

    public class GetDtl9ATaxDmnd
    {
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
        public int intr { get; set; }
        public int fee { get; set; }
        public int pen { get; set; }
    }

    public class GetDtl9ATot
    {
        public int trnovr { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int txval { get; set; }
        public int iamt { get; set; }
        public int csamt { get; set; }
    }

    public class TotTrnovr
    {
        public int trnovr { get; set; }
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
    }

    public class TxosaCn
    {
        public int trnovr { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
    }

    public class TxosaDn
    {
        public int trnovr { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
    }

    public class GetDtl9ATxPay
    {
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
        public int intr { get; set; }
        public int fee { get; set; }
    }

    public class GetDtl9ATxpd
    {
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
        public int intr { get; set; }
        public int fee { get; set; }
        public int pen { get; set; }
    }

    public class GetDtl9ATxTrnovr
    {
        public int rt { get; set; }
        public int trnovr { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
    }


}
