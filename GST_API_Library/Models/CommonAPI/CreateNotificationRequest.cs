using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GST_API_Library.Models.CommonAPI
{
    public class GetATGSTR1AResp
    {
        public string cptype { get; set; }
        public string cpgstin { get; set; }
        public string subject { get; set; }
        public string sremarks { get; set; }
        public List<Document1> documents { get; set; }
        public List<Reminder> reminders { get; set; }
        public List<Attachment> attachments { get; set; }
        //public string ret_period { get; set; }

    }
    public class Attachment
    {
        public string atta_type { get; set; }
        public string atta_ref_no { get; set; }
        public string atta_name { get; set; }
    }

    public class Document1
    {
        public string doctype { get; set; }
        public string docnum { get; set; }
        public int docvalue { get; set; }
        public string docdate { get; set; }
        public int actionreq { get; set; }
        public string pos { get; set; }
        public string inv_typ { get; set; }
        public string rchrg { get; set; }
        public List<Item1> items { get; set; }
    }

    public class Item1
    {
        public int taxvalue { get; set; }
        public int rate { get; set; }
        public int sgst { get; set; }
        public int cgst { get; set; }
        public int cess { get; set; }
    }

    public class Reminder
    {
        public string fy { get; set; }
        public string rtnprd { get; set; }
        public string rtntyp { get; set; }
    }
}
