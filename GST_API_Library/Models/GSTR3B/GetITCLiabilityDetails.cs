using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GST_API_Library.Models.GSTR3B
{
    public class GetITCLiabilityDetails
    {
        public R3bautopop r3bautopop { get; set; }
    }
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Det
    {
        public Tbl4a tbl4a { get; set; }
        public Tbl4b tbl4b { get; set; }
        public Tbl4c tbl4c { get; set; }
        public Tbl5a tbl5a { get; set; }
        public Tbl5b tbl5b { get; set; }
        public Tbl6c tbl6c { get; set; }
        public Tbl7a1 tbl7a_1 { get; set; }
        public Tbl7b1 tbl7b_1 { get; set; }
        public Tbl9a tbl9a { get; set; }
        public Tbl9b tbl9b { get; set; }
        public Tbl9c tbl9c { get; set; }
        public Tbl10a tbl10a { get; set; }
        public Tbl10b tbl10b { get; set; }
        public Tbl11IA1 tbl11_i_a_1 { get; set; }
        public Tbl11IA2 tbl11_i_a_2 { get; set; }
        public Tbl11IB1 tbl11_i_b_1 { get; set; }
        public Tbl11IB2 tbl11_i_b_2 { get; set; }
        public Tbl11Ii tbl11_ii { get; set; }
        public List<Tbl15b2c> tbl15b2c { get; set; }
        public List<Tbl15urp2c> tbl15urp2c { get; set; }
        public Itcavl itcavl { get; set; }
        public ItcavlCn itcavl_cn { get; set; }
        public Itcunavl itcunavl { get; set; }
        public Itcrev itcrev { get; set; }
        public Tbl6a tbl6a { get; set; }
        public Tbl6b tbl6b { get; set; }
        public Tbl8 tbl8 { get; set; }
        public Tbl14b tbl14b { get; set; }
        public Tbl15b2b tbl15b2b { get; set; }
        public Tbl15urp2b tbl15urp2b { get; set; }
    }

    public class DetQ
    {
        public List<Tbl4a> tbl4a { get; set; }
        public List<Tbl4b> tbl4b { get; set; }
        public List<Tbl4c> tbl4c { get; set; }
        public List<Tbl5a> tbl5a { get; set; }
        public List<Tbl5b> tbl5b { get; set; }
        public List<Tbl6c> tbl6c { get; set; }
        public List<Tbl7a1> tbl7a_1 { get; set; }
        public List<Tbl7b1> tbl7b_1 { get; set; }
        public List<Tbl9a> tbl9a { get; set; }
        public List<Tbl9b> tbl9b { get; set; }
        public List<Tbl9c> tbl9c { get; set; }
        public List<Tbl10a> tbl10a { get; set; }
        public List<Tbl10b> tbl10b { get; set; }
        public List<Tbl11IA1> tbl11_i_a_1 { get; set; }
        public List<Tbl11IA2> tbl11_i_a_2 { get; set; }
        public List<Tbl11IB1> tbl11_i_b_1 { get; set; }
        public List<Tbl11IB2> tbl11_i_b_2 { get; set; }
        public List<Tbl11Ii> tbl11_ii { get; set; }
        public List<Tbl15b2c> tbl15b2c { get; set; }
        public List<Tbl15urp2c> tbl15urp2c { get; set; }
        public List<Itcavl> itcavl { get; set; }
        public List<ItcavlCn> itcavl_cn { get; set; }
        public List<Itcunavl> itcunavl { get; set; }
        public List<Itcrev> itcrev { get; set; }
        public List<Tbl6a> tbl6a { get; set; }
        public List<Tbl6b> tbl6b { get; set; }
        public List<Tbl8> tbl8 { get; set; }
        public Tbl14b tbl14b { get; set; }
        public List<Tbl15b2b> tbl15b2b { get; set; }
        public List<Tbl15urp2b> tbl15urp2b { get; set; }
    }

    public class Elgitc
    {
        public Itc4a1 itc4a1 { get; set; }
        public Itc4a3 itc4a3 { get; set; }
        public Itc4a4 itc4a4 { get; set; }
        public Itc4a5 itc4a5 { get; set; }
        public Itc4b2 itc4b2 { get; set; }
        public Itc4d2 itc4d2 { get; set; }
    }

    public class Error
    {
        public string error_cd { get; set; }
        public string error_desc { get; set; }
    }

    public class Esup311a
    {
        public Subtotal subtotal { get; set; }
        public Det det { get; set; }
        public DetQ det_q { get; set; }
    }

    public class Esup311b
    {
        public Subtotal subtotal { get; set; }
        public Det det { get; set; }
        public DetQ det_q { get; set; }
    }
    //Himanshu
    public class Inter_Sup
    {
        public OsupUnreg32 osup_unreg_3_2 { get; set; }
        public OsupComp32 osup_comp_3_2 { get; set; }
        public OsupUin32 osup_uin_3_2 { get; set; }
    }

    public class Isup31d
    {
        public Subtotal subtotal { get; set; }
        public Det det { get; set; }
        public DetQ det_q { get; set; }
    }

    public class Itc4a1
    {
        public Subtotal subtotal { get; set; }
        public Det det { get; set; }
        public DetQ det_q { get; set; }
    }

    public class Itc4a3
    {
        public Subtotal subtotal { get; set; }
        public Det det { get; set; }
        public DetQ det_q { get; set; }
    }

    public class Itc4a4
    {
        public Subtotal subtotal { get; set; }
        public Det det { get; set; }
        public DetQ det_q { get; set; }
    }

    public class Itc4a5
    {
        public Subtotal subtotal { get; set; }
        public Det det { get; set; }
        public DetQ det_q { get; set; }
    }

    public class Itc4b2
    {
        public Subtotal subtotal { get; set; }
        public Det det { get; set; }
        public DetQ det_q { get; set; }
    }

    public class Itc4d2
    {
        public Subtotal subtotal { get; set; }
        public Det det { get; set; }
        public DetQ det_q { get; set; }
    }

    public class Itcavl
    {
        public int txval { get; set; }
        public int igst { get; set; }
        public int cgst { get; set; }
        public int sgst { get; set; }
        public int cess { get; set; }
        public string form { get; set; }
    }

    public class ItcavlCn
    {
        public int igst { get; set; }
        public int cgst { get; set; }
        public int sgst { get; set; }
        public int cess { get; set; }
        public string form { get; set; }
    }

    public class Itcrev
    {
        public int igst { get; set; }
        public int cgst { get; set; }
        public int sgst { get; set; }
        public int cess { get; set; }
    }

    public class Itcunavl
    {
        public int txval { get; set; }
        public int igst { get; set; }
        public int cgst { get; set; }
        public int sgst { get; set; }
        public int cess { get; set; }
        public string form { get; set; }
    }

    public class Liabitc
    {
        public string gstin { get; set; }
        public string ret_period { get; set; }
        public Sup_Details sup_details { get; set; }
        public Inter_Sup inter_sup { get; set; }
        public Elgitc elgitc { get; set; }
    }

    public class Osup31a
    {
        public Subtotal subtotal { get; set; }
        public Det det { get; set; }
        public DetQ det_q { get; set; }
    }

    public class Osup31b
    {
        public Subtotal subtotal { get; set; }
        public Det det { get; set; }
        public DetQ det_q { get; set; }
    }

    public class Osup31c
    {
        public Subtotal subtotal { get; set; }
        public Det det { get; set; }
        public DetQ det_q { get; set; }
    }

    public class Osup31e
    {
        public Subtotal subtotal { get; set; }
        public Det det { get; set; }
        public DetQ det_q { get; set; }
    }

    public class OsupComp32
    {
        public List<Subtotal> subtotal { get; set; }
        public Det det { get; set; }
        public DetQ det_q { get; set; }
    }

    public class OsupUin32
    {
        public List<Subtotal> subtotal { get; set; }
        public Det det { get; set; }
        public DetQ det_q { get; set; }
    }

    public class OsupUnreg32
    {
        public List<Subtotal> subtotal { get; set; }
        public Det det { get; set; }
        public DetQ det_q { get; set; }
    }

    public class PosDet
    {
        public string pos { get; set; }
        public int txval { get; set; }
        public int iamt { get; set; }
    }

    public class R3bautopop
    {
        public string r1fildt { get; set; }
        public string r2bgendt { get; set; }
        public string r3bgendt { get; set; }
        public Liabitc liabitc { get; set; }
        public List<Error> error { get; set; }
    }

    

    public class Subtotal
    {
        public int txval { get; set; }
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
        public string pos { get; set; }
    }

    public class Sup_Details
    {
        public Osup31a osup_3_1a { get; set; }
        public Osup31b osup_3_1b { get; set; }
        public Osup31c osup_3_1c { get; set; }
        public Osup31e osup_3_1e { get; set; }
        public Isup31d isup_3_1d { get; set; }
        public Esup311b esup_3_1_1b { get; set; }
        public Esup311a esup_3_1_1a { get; set; }
    }

    public class Tbl10a
    {
        public int txval { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
        public string form { get; set; }
    }

    public class Tbl10b
    {
        public int txval { get; set; }
        public int iamt { get; set; }
        public int csamt { get; set; }
        public string form { get; set; }
        public string pos { get; set; }
        public List<PosDet> pos_det { get; set; }
    }

    public class Tbl11IA1
    {
        public int txval { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
        public string form { get; set; }
    }

    public class Tbl11IA2
    {
        public int txval { get; set; }
        public int iamt { get; set; }
        public int csamt { get; set; }
        public string form { get; set; }
        public string pos { get; set; }
        public List<PosDet> pos_det { get; set; }
    }

    public class Tbl11IB1
    {
        public int txval { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
        public string form { get; set; }
    }

    public class Tbl11IB2
    {
        public int txval { get; set; }
        public int iamt { get; set; }
        public int csamt { get; set; }
        public string form { get; set; }
        public string pos { get; set; }
        public List<PosDet> pos_det { get; set; }
    }

    public class Tbl11Ii
    {
        public int txval { get; set; }
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
        public string form { get; set; }
        public string pos { get; set; }
        public List<PosDet> pos_det { get; set; }
    }

    public class Tbl14b
    {
        public int txval { get; set; }
        public string form { get; set; }
    }

    public class Tbl15b2b
    {
        public int txval { get; set; }
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
        public string form { get; set; }
    }

    public class Tbl15b2c
    {
        public string pos { get; set; }
        public double txval { get; set; }
        public double iamt { get; set; }
        public string form { get; set; }
        public List<PosDet> pos_det { get; set; }
    }

    public class Tbl15urp2b
    {
        public int txval { get; set; }
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
        public string form { get; set; }
    }

    public class Tbl15urp2c
    {
        public string pos { get; set; }
        public double txval { get; set; }
        public double iamt { get; set; }
        public string form { get; set; }
        public List<PosDet> pos_det { get; set; }
    }

    public class Tbl4a
    {
        public int txval { get; set; }
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
        public string form { get; set; }
        public string pos { get; set; }
        public List<PosDet> pos_det { get; set; }
    }

    public class Tbl4b
    {
        public int txval { get; set; }
        public string form { get; set; }
    }

    public class Tbl4c
    {
        public int txval { get; set; }
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
        public string form { get; set; }
        public string pos { get; set; }
        public List<PosDet> pos_det { get; set; }
    }

    public class Tbl5a
    {
        public int txval { get; set; }
        public int iamt { get; set; }
        public int csamt { get; set; }
        public string form { get; set; }
        public string pos { get; set; }
        public List<PosDet> pos_det { get; set; }
    }

    public class Tbl5b
    {
        public int txval { get; set; }
        public int iamt { get; set; }
        public int csamt { get; set; }
        public string form { get; set; }
    }

    public class Tbl6a
    {
        public int txval { get; set; }
        public int iamt { get; set; }
        public int csamt { get; set; }
        public string form { get; set; }
    }

    public class Tbl6b
    {
        public int txval { get; set; }
        public int iamt { get; set; }
        public int csamt { get; set; }
        public string form { get; set; }
    }

    public class Tbl6c
    {
        public int txval { get; set; }
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
        public string form { get; set; }
    }

    public class Tbl7a1
    {
        public int txval { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
        public string form { get; set; }
    }

    public class Tbl7b1
    {
        public int txval { get; set; }
        public int iamt { get; set; }
        public int csamt { get; set; }
        public string form { get; set; }
        public string pos { get; set; }
        public List<PosDet> pos_det { get; set; }
    }

    public class Tbl8
    {
        public int txval { get; set; }
        public string form { get; set; }
    }

    public class Tbl9a
    {
        public int txval { get; set; }
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
        public string form { get; set; }
        public List<PosDet> pos_det { get; set; }
        public string pos { get; set; }
    }

    public class Tbl9b
    {
        public int txval { get; set; }
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
        public string form { get; set; }
        public List<PosDet> pos_det { get; set; }
        public string pos { get; set; }
    }

    public class Tbl9c
    {
        public int txval { get; set; }
        public int iamt { get; set; }
        public int camt { get; set; }
        public int samt { get; set; }
        public int csamt { get; set; }
        public string form { get; set; }
        public List<PosDet> pos_det { get; set; }
        public string pos { get; set; }
    }


}
