using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GST_API_Library.Models
{
    public class ErrorModel
    {
        public string message { get; set; }
        public string error_cd { get; set; }
    }

    public class BaseResponseModel
    {
        public string status_cd { get; set; }
        public ErrorModel error { get; set; }
    }

    public class OTPRequestModel
    {
        public string action { get; set; }
        public string app_key { get; set; }
        public string username { get; set; }
    }
    public class TokenRequestModel : OTPRequestModel
    {
        public string otp { get; set; }
    }

    public class OTPResponseModel: BaseResponseModel
    {

    }
    public class LogoutRequestModel
    {
        public string action { get; set; }
        public string app_key { get; set; }
        public string username { get; set; }
        public string auth_token { get; set; }

    }

    public class LogoutResponseModel: BaseResponseModel
    {
    }
    public class TokenResponseModel : OTPResponseModel
    {
        public string auth_token { get; set; }
        public int expiry { get; set; }
        public string sek { get; set; }
    }
    public class RefreshTokenModel : OTPRequestModel
    {
        public string auth_token { get; set; }
    }

    public class RegisterDSCModel
    {
        public string data { get; set; }
        public string sign { get; set; }
    }

    public class EVCAuthenticationModel
    {
        [Required(ErrorMessage = "GSTIN is required")]
        public string gstin { get; set; }
        [Required(ErrorMessage = "PAN is required")]
        public string pan { get; set; }
        [Required(ErrorMessage = "Form Type is required")]
        public string form_type { get; set; }
    }
}
