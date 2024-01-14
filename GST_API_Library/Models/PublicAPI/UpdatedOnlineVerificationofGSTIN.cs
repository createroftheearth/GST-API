using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GST_API_Library.Models.PublicAPI
{
    public class UpdatedOnlineVerificationofGSTIN
    {
        public string gstin { get; set; }
        public string stateCode { get; set; }
        public string stateName { get; set; }
        public string status { get; set; }
        public bool validGstin { get; set; }
        public string pan { get; set; }
        public string bussNature { get; set; }
        public string regStartDate { get; set; }
        public string legalName { get; set; }
    }
}
