using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GST_API_Library.Models.PublicAPI
{
    public class GetPreference
    {
        public List<Response> response { get; set; }
    }
    public class Response
    {
        public string quarter { get; set; }
        public string preference { get; set; }
    }
}
