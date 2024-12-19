using GST_API_Library.Models.CommonAPI;
using Integrated.API.GSTN.CommonAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GST_API_Library.Models.CommonAPI
{
    public class CommonAPITotal
    {

        public List<GetSignedPDFResponse> signed { get; set; }

        public List<GetAddLateFeeBrkup> AddLtFeeBrk { get; set; }

        public List<GetFileDetails> FileDetails { get; set; }


    }
}
