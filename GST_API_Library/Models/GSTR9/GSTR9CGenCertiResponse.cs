using GST_API_Library.Models.GSTR9;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GST_API_Library.Models.GSTR9
{
    public class GSTR9CGenCertiResponse
    {
        public CertText_GenCertiRes cert_text { get; set; }
    }

    public class CertText_GenCertiRes
    {
        public CertTextPartb1 cert_text_partb1 { get; set; }
    }

    public class CertTextPartb1
    {
        public Section1_GenCertiRes section1 { get; set; }
        public Section2_GenCertiRes section2 { get; set; }
        public Section3_GenCertiRes section3 { get; set; }
        public Section4_GenCertiRes section4 { get; set; }
        public Section5_GenCertiRes section5 { get; set; }
        public List<Qualification_GenCertiRes> qualifications { get; set; }
        public Signature_GenCertiRes signature { get; set; }
    }

    public class Qualification_GenCertiRes
    {
        public string qual_type { get; set; }
        public string value { get; set; }
    }
    public class Sec3a_GenCertiRes
    {
        public string line0 { get; set; }
    }

    public class Sec3b_GenCertiRes
    {
        public string line0 { get; set; }
        public string line1 { get; set; }
        public string line2 { get; set; }
        public string line3 { get; set; }
    }

    public class Section1_GenCertiRes
    {
        public string line0 { get; set; }
        public string line1 { get; set; }
        public string line2 { get; set; }
        public string line3 { get; set; }
    }

    public class Section2_GenCertiRes
    {
        public string line0 { get; set; }
        public string line1 { get; set; }
    }

    public class Section3_GenCertiRes
    {
        public Sec3a_GenCertiRes sec_3a { get; set; }
        public Sec3b_GenCertiRes sec_3b { get; set; }
    }

    public class Section4_GenCertiRes
    {
        public string line0 { get; set; }
    }

    public class Section5_GenCertiRes
    {
        public string line0 { get; set; }
    }

    public class Signature_GenCertiRes
    {
        public string line0 { get; set; }
        public string place { get; set; }
        public string nameOfTheSignatory { get; set; }
        public string membershipNo { get; set; }
        public string date { get; set; }
        public string fullAddress { get; set; }
    }



}
