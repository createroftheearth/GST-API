using GST_API_Library.Models.GSTR1;
using GST_API_Library.Models.PublicAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GST_API_Library.Models.PublicAPI
{
    public class PublicAPITotal
    {
        public List<EinvSearchIRNDetails> searchirndetails { get; set; }
        public List<GetAPIPermissiondetails> apipermissiondetails { get; set; }
        public List<GetDayWiseChangedListofGSTINs> daywisechangedlistgstin { get; set; }
        public List<GetPreference> preferences { get; set; }
        public List<OnlineVerificationofGSTIN> onlineverificationofgstin { get; set; }
        public List<PANtoGSTIN> pantogstin { get; set; }
        public List<SearchTaxpayer> searchtaxpayers { get; set; }
        public List<UpdatedOnlineVerificationofGSTIN> updateonlineverificationofgstin { get; set; }
        public List<ViewandTrackReturns> viewandtrackreturn { get; set; }

    }
}
