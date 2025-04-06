using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace GST_API_Library.Models.GSTR1
{
    public class GetSUPECO
    {
        public Supeco supeco { get; set; }
    }

    public class Clttx
    {
        public string etin { get; set; }
        public int suppval { get; set; }
        public int igst { get; set; }
        public int cgst { get; set; }
        public int sgst { get; set; }
        public int cess { get; set; }
        public string flag { get; set; }
    }

    public class Paytx
    {
        public string etin { get; set; }
        public int suppval { get; set; }
        public int igst { get; set; }
        public int cgst { get; set; }
        public int sgst { get; set; }
        public int cess { get; set; }
        public string flag { get; set; }
    }
    public class Supeco
    {
        public List<Clttx> clttx { get; set; }
        public List<Paytx> paytx { get; set; }
    }



}