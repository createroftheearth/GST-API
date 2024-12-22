using GST_API.APIModels;
using GST_API_Library.Services;
using GST_API_Library.Models.PublicAPI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using GST_API.Services;
using GST_API_DAL.Models;
using Microsoft.AspNetCore.Identity;

namespace GST_API.Controllers
{
    [Route("api/public")]
    [ApiController]
    [Authorize(Roles = "APIUser")]

    //public class PublicAPIController : Controller
    public class PublicAPIController : BaseController      //Garima change Controller to BaseController on 19 April 2024
    {
        private readonly ILogger<AuthenticationController> _logger;
        private readonly UserManager<User> _userManager;

        public PublicAPIController(ILogger<AuthenticationController> logger, UserManager<User> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }
        //Garima Public APIs 19 April 2024

        [HttpGet("GetViewTrackRet")]
        public async Task<ResponseModel> GetViewTrackRet([FromQuery] APIRequestParameters model)
        {
            if (string.IsNullOrEmpty(this.GSTINToken) || string.IsNullOrEmpty(this.GSTINSek))
            {
                return new ResponseModel
                {
                    isSuccess = false,
                    message = "Please send 'GSTIN-Token' or 'GSTIN-Sek' in headers"
                };
            }
            GSTNAuthClient client = new GSTNAuthClient(gstin, this.gstinUsername, this.appKey)
            {
                AuthToken = this.GSTINToken,
                DecryptedKey = EncryptionUtils.AesDecrypt(this.GSTINSek, this.appKey)

            };
            try
            {
                PublicApiClient client2 = new PublicApiClient(client, gstin, model.ret_period, Constants.CommomAPIDocDownload_URL);
                var info = await client2.GetViewTrackRet(model);
                return new ResponseModel
                {
                    data = info,
                    isSuccess = true,
                    message = "success"
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel
                {
                    isSuccess = false,
                    message = ex.Message
                };
            }
        }

        [HttpGet("GetupdatedVeriGSTIN")]
        public async Task<ResponseModel> GetupdatedVeriGSTIN([FromQuery] APIRequestParameters model)
        {
            if (string.IsNullOrEmpty(this.GSTINToken) || string.IsNullOrEmpty(this.GSTINSek))
            {
                return new ResponseModel
                {
                    isSuccess = false,
                    message = "Please send 'GSTIN-Token' or 'GSTIN-Sek' in headers"
                };
            }
            GSTNAuthClient client = new GSTNAuthClient(gstin, this.gstinUsername, this.appKey)
            {
                AuthToken = this.GSTINToken,
                DecryptedKey = EncryptionUtils.AesDecrypt(this.GSTINSek, this.appKey)

            };
            try
            {
                PublicApiClient client2 = new PublicApiClient(client, gstin, model.ret_period, Constants.CommomAPIDocDownload_URL);
                var info = await client2.GetupdatedVerificationGSTIN(model);
                return new ResponseModel
                {
                    data = info,
                    isSuccess = true,
                    message = "success"
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel
                {
                    isSuccess = false,
                    message = ex.Message
                };
            }
        }

        [HttpGet("UnregApplicants")]
        public async Task<ResponseModel> UnregApplicants([FromQuery] APIRequestParameters model)
        {
            if (string.IsNullOrEmpty(this.GSTINToken) || string.IsNullOrEmpty(this.GSTINSek))
            {
                return new ResponseModel
                {
                    isSuccess = false,
                    message = "Please send 'GSTIN-Token' or 'GSTIN-Sek' in headers"
                };
            }
            GSTNAuthClient client = new GSTNAuthClient(gstin, this.gstinUsername, this.appKey)
            {
                AuthToken = this.GSTINToken,
                DecryptedKey = EncryptionUtils.AesDecrypt(this.GSTINSek, this.appKey)

            };
            try
            {
                PublicApiClient client2 = new PublicApiClient(client, gstin, model.ret_period, Constants.Public_UnregApplicants);
                var info = await client2.GetUnregApplicants(model);
                return new ResponseModel
                {
                    data = info,
                    isSuccess = true,
                    message = "success"
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel
                {
                    isSuccess = false,
                    message = ex.Message
                };
            }
        }

        [HttpGet("UnregApplicantsValidation")]
        public async Task<ResponseModel> UnregApplicantsValidation([FromQuery] APIRequestParameters model)
        {
            if (string.IsNullOrEmpty(this.GSTINToken) || string.IsNullOrEmpty(this.GSTINSek))
            {
                return new ResponseModel
                {
                    isSuccess = false,
                    message = "Please send 'GSTIN-Token' or 'GSTIN-Sek' in headers"
                };
            }
            GSTNAuthClient client = new GSTNAuthClient(gstin, this.gstinUsername, this.appKey)
            {
                AuthToken = this.GSTINToken,
                DecryptedKey = EncryptionUtils.AesDecrypt(this.GSTINSek, this.appKey)

            };
            try
            {
                PublicApiClient client2 = new PublicApiClient(client, gstin, model.ret_period, Constants.Public_UnregApplicantsVali);
                var info = await client2.GetUnregApplicants(model);
                return new ResponseModel
                {
                    data = info,
                    isSuccess = true,
                    message = "success"
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel
                {
                    isSuccess = false,
                    message = ex.Message
                };
            }
        }

    }
}
