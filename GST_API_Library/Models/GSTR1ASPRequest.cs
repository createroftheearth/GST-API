using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GST_API_Library.Models
{
    public class Request
    {
        public int id { get; set; }
    }
    public class PanRequest : Request
    {
        public string panNo { get; set; }
    }
}
