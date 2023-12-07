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
    public class GSTR9CGenCertiRequest
    {
        public string gstin { get; set; }
        public string fp { get; set; }
        public string isauditor { get; set; }
        public CertData_GenCerti cert_data { get; set; }
    }
    public class AddAddr_GenCerti
    {
        public string bno { get; set; }
        public string fno { get; set; }
        public string building { get; set; }
        public string road { get; set; }
        public string city { get; set; }
        public string district { get; set; }
        public string state { get; set; }
        public int pin_code { get; set; }
    }

    public class Addr_GenCerti
    {
        public string bno { get; set; }
        public string fno { get; set; }
        public string building { get; set; }
        public string road { get; set; }
        public string city { get; set; }
        public string district { get; set; }
        public string state { get; set; }
        public int pin_code { get; set; }
    }

    public class AuditAddr_GenCerti
    {
        public string bno { get; set; }
        public string fno { get; set; }
        public string building { get; set; }
        public string road { get; set; }
        public string city { get; set; }
        public string district { get; set; }
        public string state { get; set; }
        public int pin_code { get; set; }
    }

    public class CertData_GenCerti
    {
        public string pronoun { get; set; }
        public string bal_sheet_date { get; set; }
        public string acc_typ { get; set; }
        public string beg_date { get; set; }
        public string end_date { get; set; }
        public string cash_from_date { get; set; }
        public string cash_to_date { get; set; }
        public string taxpayer_name { get; set; }
        public Addr_GenCerti addr { get; set; }
        public string doc_stat { get; set; }
        public string place { get; set; }
        public string signatory { get; set; }
        public string mem_no { get; set; }
        public string date { get; set; }
        public AuditAddr_GenCerti audit_addr { get; set; }
        public CertTextpartb1_GenCerti cert_textpartb1 { get; set; }
    }

    public class CertTextpartb1_GenCerti
    {
        public List<Qualification_GenCerti> qualifications { get; set; }
        public string gstin { get; set; }
        public PrincipalAddr_GenCerti principal_addr { get; set; }
        public AddAddr_GenCerti add_addr { get; set; }
        public string ishave { get; set; }
        public string isagree { get; set; }
        public string info_stat { get; set; }
    }

    public class PrincipalAddr_GenCerti
    {
        public string bno { get; set; }
        public string fno { get; set; }
        public string building { get; set; }
        public string road { get; set; }
        public string city { get; set; }
        public string district { get; set; }
        public string state { get; set; }
        public int pin_code { get; set; }
    }

    public class Qualification_GenCerti
    {
        public string qual_type { get; set; }
        public string value { get; set; }
    }

}
