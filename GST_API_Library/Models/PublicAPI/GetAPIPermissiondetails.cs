using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GST_API_Library.Models.PublicAPI
{
    public class GetAPIPermissiondetails
    {
        public string fbloptin { get; set; }
        public int duration { get; set; }
        public List<string> apilist { get; set; }
    }
}
