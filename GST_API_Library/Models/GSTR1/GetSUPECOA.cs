using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace GST_API_Library.Models.GSTR1
{
    public class GetSUPECOA
    {
        public Supecoa supecoa { get; set; }
    }
    public class Clttxa
    {
        public string oetin { get; set; }
        public string etin { get; set; }
        public int suppval { get; set; }
        public int igst { get; set; }
        public int cgst { get; set; }
        public int sgst { get; set; }
        public int cess { get; set; }
        public string flag { get; set; }
        public string omon { get; set; }
    }

    public class Paytxa
    {
        public string oetin { get; set; }
        public string etin { get; set; }
        public int suppval { get; set; }
        public int igst { get; set; }
        public int cgst { get; set; }
        public int sgst { get; set; }
        public int cess { get; set; }
        public string flag { get; set; }
        public string omon { get; set; }
    }
    public class Supecoa
    {
        public List<Clttxa> clttxa { get; set; }
        public List<Paytxa> paytxa { get; set; }
    }



}