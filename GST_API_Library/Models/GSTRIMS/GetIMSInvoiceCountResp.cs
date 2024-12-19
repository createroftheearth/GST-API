using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GST_API_Library.Models.GSTRIMS;


namespace Integrated.API.GSTN.GSTRIMS
{
    public class GetIMSInvoiceCountResp
    {
        public AllOth all_oth { get; set; }
        public InvSuppIsd inv_supp_isd { get; set; }
        public ImpGds imp_gds { get; set; }

    }
    public class AllOth
    {
        public B2bcn b2bcn { get; set; }
        public B2bdn b2bdn { get; set; }
        public B2ba b2ba { get; set; }
        public B2b b2b { get; set; }
        public Ecom ecom { get; set; }
        public int ttl_cnt { get; set; }
        public Ecoma ecoma { get; set; }
        public B2bdna b2bdna { get; set; }
        public B2bcna b2bcna { get; set; }
    }

    public class B2b
    {
        public int noaction { get; set; }
        public int reject { get; set; }
        public int pending { get; set; }
        public int accept { get; set; }
    }

    public class B2ba
    {
        public int noaction { get; set; }
        public int reject { get; set; }
        public int pending { get; set; }
        public int accept { get; set; }
    }

    public class B2bcn
    {
        public int noaction { get; set; }
        public int reject { get; set; }
        public int pending { get; set; }
        public int accept { get; set; }
    }

    public class B2bcna
    {
        public int noaction { get; set; }
        public int reject { get; set; }
        public int pending { get; set; }
        public int accept { get; set; }
    }

    public class B2bdn
    {
        public int noaction { get; set; }
        public int reject { get; set; }
        public int pending { get; set; }
        public int accept { get; set; }
    }

    public class B2bdna
    {
        public int noaction { get; set; }
        public int reject { get; set; }
        public int pending { get; set; }
        public int accept { get; set; }
    }

    public class Ecom
    {
        public int noaction { get; set; }
        public int reject { get; set; }
        public int pending { get; set; }
        public int accept { get; set; }
    }

    public class Ecoma
    {
        public int noaction { get; set; }
        public int reject { get; set; }
        public int pending { get; set; }
        public int accept { get; set; }
    }

    public class Impg
    {
        public int noaction { get; set; }
        public int accept { get; set; }
        public int reject { get; set; }
        public int pending { get; set; }
    }

    public class Impga
    {
        public int noaction { get; set; }
        public int accept { get; set; }
        public int reject { get; set; }
        public int pending { get; set; }
    }

    public class ImpGds
    {
        public int ttl_cnt { get; set; }
        public Impg impg { get; set; }
        public Impga impga { get; set; }
        public Impgsez impgsez { get; set; }
        public Impgseza impgseza { get; set; }
    }

    public class Impgsez
    {
        public int noaction { get; set; }
        public int accept { get; set; }
        public int reject { get; set; }
        public int pending { get; set; }
    }

    public class Impgseza
    {
        public int noaction { get; set; }
        public int accept { get; set; }
        public int reject { get; set; }
        public int pending { get; set; }
    }

    public class InvSuppIsd
    {
        public int ttl_cnt { get; set; }
        public Isd isd { get; set; }
        public Isda isda { get; set; }
        public Isdcn isdcn { get; set; }
        public Isdcna isdcna { get; set; }
    }

    public class Isd
    {
        public int noaction { get; set; }
        public int accept { get; set; }
        public int reject { get; set; }
        public int pending { get; set; }
    }

    public class Isda
    {
        public int noaction { get; set; }
        public int accept { get; set; }
        public int reject { get; set; }
        public int pending { get; set; }
    }

    public class Isdcn
    {
        public int noaction { get; set; }
        public int accept { get; set; }
        public int reject { get; set; }
        public int pending { get; set; }
    }

    public class Isdcna
    {
        public int noaction { get; set; }
        public int accept { get; set; }
        public int reject { get; set; }
        public int pending { get; set; }
    }
}
