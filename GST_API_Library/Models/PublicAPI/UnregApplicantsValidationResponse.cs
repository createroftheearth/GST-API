using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GST_API_Library.Models.PublicAPI
{
    public class UnregApplicantsValidationResponse
    {      
            [JsonProperty("Enrolment Number")]
            public string EnrolmentNumber { get; set; }

            [JsonProperty("Mobile Number")]
            public string MobileNumber { get; set; }

            [JsonProperty("Email Address")]
            public string EmailAddress { get; set; }
    }
 }
