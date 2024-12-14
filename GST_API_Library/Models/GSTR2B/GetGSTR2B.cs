using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GST_API_Library.Models.GSTR2B
{
    public class GetGSTR2B
    {
        public string chksum { get; set; }
        public Data data { get; set; }
    }
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class B2b
    {
        public int igst { get; set; }
        public int cgst { get; set; }
        public int sgst { get; set; }
        public int cess { get; set; }
        public string ctin { get; set; }
        public string trdnm { get; set; }
        public string supprd { get; set; }
        public string supfildt { get; set; }
        public int ttldocs { get; set; }
        public int txval { get; set; }
        public List<Inv> inv { get; set; }
    }

    public class B2ba
    {
        public int igst { get; set; }
        public int cgst { get; set; }
        public int sgst { get; set; }
        public int cess { get; set; }
        public string ctin { get; set; }
        public string trdnm { get; set; }
        public string supprd { get; set; }
        public string supfildt { get; set; }
        public int ttldocs { get; set; }
        public int txval { get; set; }
        public List<Inv> inv { get; set; }
    }

    public class Boe
    {
        public string refdt { get; set; }
        public string recdt { get; set; }
        public string portcode { get; set; }
        public string boenum { get; set; }
        public string boedt { get; set; }
        public string isamd { get; set; }
        public double txval { get; set; }
        public double igst { get; set; }
        public double cess { get; set; }
    }

    public class Cdnr
    {
        public int igst { get; set; }
        public int cgst { get; set; }
        public int sgst { get; set; }
        public int cess { get; set; }
        public string ctin { get; set; }
        public string trdnm { get; set; }
        public string supprd { get; set; }
        public string supfildt { get; set; }
        public string nttyp { get; set; }
        public int ttldocs { get; set; }
        public int txval { get; set; }
        public List<Nt> nt { get; set; }
    }

    public class Cdnra
    {
        public int igst { get; set; }
        public int cgst { get; set; }
        public int sgst { get; set; }
        public int cess { get; set; }
        public string ctin { get; set; }
        public string trdnm { get; set; }
        public string supprd { get; set; }
        public string supfildt { get; set; }
        public string nttyp { get; set; }
        public int ttldocs { get; set; }
        public int txval { get; set; }
        public List<Nt> nt { get; set; }
    }

    public class Cdnrarev
    {
        public int igst { get; set; }
        public int cgst { get; set; }
        public int sgst { get; set; }
        public int cess { get; set; }
    }

    public class Cdnrrev
    {
        public int igst { get; set; }
        public int cgst { get; set; }
        public int sgst { get; set; }
        public int cess { get; set; }
    }

    public class Cpsumm
    {
        public List<B2b> b2b { get; set; }
        public List<B2ba> b2ba { get; set; }
        public List<Cdnr> cdnr { get; set; }
        public List<Cdnra> cdnra { get; set; }
        public List<Isd> isd { get; set; }
        public List<Isda> isda { get; set; }
        public List<Impgsez> impgsez { get; set; }
        public List<Ecom> ecom { get; set; }
        public List<Ecoma> ecoma { get; set; }
    }

    public class Data
    {
        public string gstin { get; set; }
        public string rtnprd { get; set; }
        public string version { get; set; }
        public string gendt { get; set; }
        public Itcsumm itcsumm { get; set; }
        public Cpsumm cpsumm { get; set; }
        public Docdata docdata { get; set; }
    }

    public class Docdata
    {
        public List<B2b> b2b { get; set; }
        public List<B2ba> b2ba { get; set; }
        public List<Cdnr> cdnr { get; set; }
        public List<Cdnra> cdnra { get; set; }
        public List<Isd> isd { get; set; }
        public List<Isda> isda { get; set; }
        public List<Impg> impg { get; set; }
        public List<Impgsez> impgsez { get; set; }
        public List<Ecom> ecom { get; set; }
        public List<Ecoma> ecoma { get; set; }
    }

    public class Doclist
    {
        public string doctyp { get; set; }
        public string docnum { get; set; }
        public string docdt { get; set; }
        public string oinvnum { get; set; }
        public string oinvdt { get; set; }
        public int igst { get; set; }
        public int cgst { get; set; }
        public int sgst { get; set; }
        public int cess { get; set; }
        public string itcelg { get; set; }
        public string odoctyp { get; set; }
        public string odocnum { get; set; }
        public string odocdt { get; set; }
    }

    public class Ecom
    {
        public int igst { get; set; }
        public int cgst { get; set; }
        public int sgst { get; set; }
        public int cess { get; set; }
        public int ttldocs { get; set; }
        public string trdnm { get; set; }
        public string supprd { get; set; }
        public string supfildt { get; set; }
        public int txval { get; set; }
        public string ctin { get; set; }
        public List<Inv> inv { get; set; }
    }

    public class Ecoma
    {
        public int igst { get; set; }
        public int cgst { get; set; }
        public int sgst { get; set; }
        public int cess { get; set; }
        public int ttldocs { get; set; }
        public string trdnm { get; set; }
        public string supprd { get; set; }
        public string supfildt { get; set; }
        public int txval { get; set; }
        public string ctin { get; set; }
        public List<Inv> inv { get; set; }
    }

    public class Impg
    {
        public int igst { get; set; }
        public int cgst { get; set; }
        public int sgst { get; set; }
        public int cess { get; set; }
        public string refdt { get; set; }
        public string recdt { get; set; }
        public string portcode { get; set; }
        public string boenum { get; set; }
        public string boedt { get; set; }
        public string isamd { get; set; }
        public double txval { get; set; }
    }

    public class Impga
    {
        public int igst { get; set; }
        public int cgst { get; set; }
        public int sgst { get; set; }
        public int cess { get; set; }
    }

    public class Impgasez
    {
        public int igst { get; set; }
        public int cgst { get; set; }
        public int sgst { get; set; }
        public int cess { get; set; }
    }

    public class Impgsez
    {
        public int igst { get; set; }
        public int cgst { get; set; }
        public int sgst { get; set; }
        public int cess { get; set; }
        public string ctin { get; set; }
        public string trdnm { get; set; }
        public string portcode { get; set; }
        public int ttldocs { get; set; }
        public int txval { get; set; }
        public List<Boe> boe { get; set; }
    }

    public class Imports
    {
        public int igst { get; set; }
        public int cgst { get; set; }
        public int sgst { get; set; }
        public int cess { get; set; }
        public Impg impg { get; set; }
        public Impgsez impgsez { get; set; }
        public Impga impga { get; set; }
        public Impgasez impgasez { get; set; }
    }

    public class Inv
    {
        public string inum { get; set; }
        public string typ { get; set; }
        public string dt { get; set; }
        public double val { get; set; }
        public string pos { get; set; }
        public string rev { get; set; }
        public string itcavl { get; set; }
        public string rsn { get; set; }
        public int diffprcnt { get; set; }
        public string srctyp { get; set; }
        public string irn { get; set; }
        public string irngendate { get; set; }
        public List<Item> items { get; set; }
        public string oinum { get; set; }
        public string oidt { get; set; }
    }

    public class Isd
    {
        public int igst { get; set; }
        public int cgst { get; set; }
        public int sgst { get; set; }
        public int cess { get; set; }
        public string ctin { get; set; }
        public string trdnm { get; set; }
        public string supprd { get; set; }
        public string supfildt { get; set; }
        public string doctyp { get; set; }
        public int ttldocs { get; set; }
        public List<Doclist> doclist { get; set; }
    }

    public class Isda
    {
        public int igst { get; set; }
        public int cgst { get; set; }
        public int sgst { get; set; }
        public int cess { get; set; }
        public string ctin { get; set; }
        public string trdnm { get; set; }
        public string supprd { get; set; }
        public string supfildt { get; set; }
        public string doctyp { get; set; }
        public int ttldocs { get; set; }
        public List<Doclist> doclist { get; set; }
    }

    public class Isdsup
    {
        public int igst { get; set; }
        public int cgst { get; set; }
        public int sgst { get; set; }
        public int cess { get; set; }
        public Isd isd { get; set; }
        public Isda isda { get; set; }
    }

    public class Itcavl
    {
        public Nonrevsup nonrevsup { get; set; }
        public Isdsup isdsup { get; set; }
        public Revsup revsup { get; set; }
        public Imports imports { get; set; }
        public Othersup othersup { get; set; }
    }

    public class Itcsumm
    {
        public Itcavl itcavl { get; set; }
        public Itcunavl itcunavl { get; set; }
    }

    public class Itcunavl
    {
        public Nonrevsup nonrevsup { get; set; }
        public Isdsup isdsup { get; set; }
        public Revsup revsup { get; set; }
        public Imports imports { get; set; }
        public Othersup othersup { get; set; }
    }

    public class Item
    {
        public int num { get; set; }
        public int rt { get; set; }
        public int txval { get; set; }
        public int igst { get; set; }
        public int cgst { get; set; }
        public int sgst { get; set; }
        public int cess { get; set; }
    }

    public class Nonrevsup
    {
        public int igst { get; set; }
        public int cgst { get; set; }
        public int sgst { get; set; }
        public int cess { get; set; }
        public B2b b2b { get; set; }
        public B2ba b2ba { get; set; }
        public Cdnr cdnr { get; set; }
        public Cdnra cdnra { get; set; }
        public Ecom ecom { get; set; }
        public Ecoma ecoma { get; set; }
    }

    public class Nt
    {
        public string ntnum { get; set; }
        public string typ { get; set; }
        public string suptyp { get; set; }
        public string dt { get; set; }
        public double val { get; set; }
        public string pos { get; set; }
        public string rev { get; set; }
        public string itcavl { get; set; }
        public string rsn { get; set; }
        public int diffprcnt { get; set; }
        public string srctyp { get; set; }
        public string irn { get; set; }
        public string irngendate { get; set; }
        public List<Item> items { get; set; }
        public string onttyp { get; set; }
        public string ontnum { get; set; }
        public string ontdt { get; set; }
    }

    public class Othersup
    {
        public int igst { get; set; }
        public int cgst { get; set; }
        public int sgst { get; set; }
        public int cess { get; set; }
        public Cdnr cdnr { get; set; }
        public Cdnra cdnra { get; set; }
        public Cdnrrev cdnrrev { get; set; }
        public Cdnrarev cdnrarev { get; set; }
        public Isd isd { get; set; }
        public Isda isda { get; set; }
    }

    public class Revsup
    {
        public int igst { get; set; }
        public int cgst { get; set; }
        public int sgst { get; set; }
        public int cess { get; set; }
        public B2b b2b { get; set; }
        public B2ba b2ba { get; set; }
        public Cdnr cdnr { get; set; }
        public Cdnra cdnra { get; set; }
        public Ecom ecom { get; set; }
        public Ecoma ecoma { get; set; }
    }
}
