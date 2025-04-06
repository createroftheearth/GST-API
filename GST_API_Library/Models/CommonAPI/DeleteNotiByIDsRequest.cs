using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GST_API_Library.Models.CommonAPI
{
    public class DeleteNotiByIDsRequest
    {
        public List<Notifid> notifids { get; set; }
        //public string ret_period { get; set; }
    }
    public class Notifid
    {
        public string notify_id { get; set; }
    }
}
