using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GST_API_Library.Models.GSTR9;

namespace GST_API_Library.Models.GSTR9
{
    public class GetAutocalculatedDetails
    {
        public string gstin { get; set; }
        public string fp { get; set; }
        public Table4 table4 { get; set; }
        public Table5 table5 { get; set; }
        public Table6 table6 { get; set; }
        public Table8 table8 { get; set; }
        public Table9 table9 { get; set; }
        public int hsnMinLen { get; set; }
    }
    public class AmdNeg
    {
        public int txval { get; set; }
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
    }

    public class AmdPos
    {
        public int txval { get; set; }
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
    }

    public class At
    {
        public int txval { get; set; }
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
    }

    public class B2btax
    {
        public int txval { get; set; }
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
    }

    public class B2c
    {
        public int txval { get; set; }
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
    }

    public class Camt
    {
        public int txpyble { get; set; }
        public int txpaid_cash { get; set; }
        public int tax_paid_itc_iamt { get; set; }
        public int tax_paid_itc_camt { get; set; }
    }

    public class CrNt
    {
        public int txval { get; set; }
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
    }

    public class Csamt
    {
        public int txpyble { get; set; }
        public int txpaid_cash { get; set; }
        public int tax_paid_itc_csamt { get; set; }
        public int txpaid { get; set; }
    }

    public class Deemed
    {
        public int txval { get; set; }
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
    }

    public class DrNt
    {
        public int txval { get; set; }
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
    }

    public class Exmt
    {
        public int txval { get; set; }
    }

    public class Exp9
    {
        public int txval { get; set; }
        public int iamt { get; set; }
        public int csamt { get; set; }
    }

    public class Fee
    {
        public int txpyble { get; set; }
        public int txpaid_cash { get; set; }
    }

    public class Iamt
    {
        public int txpyble { get; set; }
        public int txpaid_cash { get; set; }
        public int tax_paid_itc_iamt { get; set; }
        public int tax_paid_itc_camt { get; set; }
        public int tax_paid_itc_samt { get; set; }
        public int txpaid { get; set; }
    }

    public class Intr
    {
        public int txpyble { get; set; }
        public int txpaid_cash { get; set; }
        public int txpaid { get; set; }
    }

    public class Isd
    {
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
    }

    public class Itc2a
    {
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
    }

    public class Itc3b
    {
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
    }

    public class Nil
    {
        public int txval { get; set; }
    }

    public class NonGst
    {
        public int txval { get; set; }
    }

    public class Rchrg
    {
        public int txval { get; set; }
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
    }

    public class Samt
    {
        public int txpyble { get; set; }
        public int txpaid_cash { get; set; }
        public int tax_paid_itc_iamt { get; set; }
        public int tax_paid_itc_samt { get; set; }
        public int txpaid { get; set; }//added for GetDetails Model //Garima
    }

    public class Sez
    {
        public int txval { get; set; }
        public int iamt { get; set; }
        public int csamt { get; set; }
    }

    public class Table4
    {
        public string chksum { get; set; }
        public B2c b2c { get; set; }
        public B2btax b2b { get; set; }
        public Exp9 exp { get; set; }
        public Sez sez { get; set; }
        public Deemed deemed { get; set; }
        public At at { get; set; }
        public Rchrg rchrg { get; set; }
        public CrNt cr_nt { get; set; }
        public DrNt dr_nt { get; set; }
        public AmdPos amd_pos { get; set; }
        public AmdNeg amd_neg { get; set; }
    }

    public class Table5
    {
        public string chksum { get; set; }
        public ZeroRtd zero_rtd { get; set; }
        public Sez sez { get; set; }
        public Rchrg rchrg { get; set; }
        public Exmt exmt { get; set; }
        public Nil nil { get; set; }
        public NonGst non_gst { get; set; }
        public CrNt cr_nt { get; set; }
        public DrNt dr_nt { get; set; }
        public AmdPos amd_pos { get; set; }
        public AmdNeg amd_neg { get; set; }
    }

    public class Table6
    {
        public string chksum { get; set; }
        public Itc3b itc_3b { get; set; }
        public Isd isd { get; set; }
        public Tran1 tran1 { get; set; }
        public Tran2 tran2 { get; set; }
    }

    public class Table8
    {
        public string chksum { get; set; }
        public Itc2a itc_2a { get; set; }
    }

    public class Table9
    {
        public string chksum { get; set; }
        public Iamt iamt { get; set; }
        public Camt camt { get; set; }
        public Samt samt { get; set; }
        public Csamt csamt { get; set; }
        public Intr intr { get; set; }
        public Fee fee { get; set; }
    }

    public class Tran1
    {
        public int camt { get; set; }
        public int samt { get; set; }
    }

    public class Tran2
    {
        public int camt { get; set; }
        public int samt { get; set; }
    }

    public class ZeroRtd
    {
        public int txval { get; set; }
    }
}
