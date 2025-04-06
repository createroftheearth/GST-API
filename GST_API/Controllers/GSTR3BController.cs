using GST_API.APIModels;
using GST_API.Services;
using GST_API_DAL.Models;
using GST_API_Library.Models;
//using GST_API_Library.Models.GSTR2B;
using GST_API_Library.Models.GSTR3B;
using GST_API_Library.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GST_API.Controllers
{
    [Route("api/gstr3b")]
    [ApiController]
    [Authorize(Roles = "APIUser")]
    public class GSTR3BController : BaseController
    {
        private readonly ILogger<AuthenticationController> _logger;
        private readonly UserManager<User> _userManager;
        public GSTR3BController(ILogger<AuthenticationController> logger, UserManager<User> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        // START AMIT 10FEB2025 SAVE GSTR3B

        /// <summary>
        /// To save entire GSTR3B invoices.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPut("save")]
        public async Task<ResponseModel> save([FromBody] SaveGSTR3BDetails data)
        {
            GSTNAuthClient client = new GSTNAuthClient(gstin, this.gstinUsername, appKey)
            {
                AuthToken = this.GSTINToken,
                DecryptedKey = EncryptionUtils.AesDecrypt(this.GSTINSek, appKey)
            };
            GSTR3BApiClient client2 = new GSTR3BApiClient(client, data.gstin, data.ret_period, Constants.GSTR3B_Get3B_URL);
            var info = await client2.Save(data);


            return new ResponseModel
            {

                data = info,
                isSuccess = true,
                message = "success"
            };
        }

        //[HttpPost("{otp}/file3b")]
        //public async Task<ResponseModel> file3b([FromBody] GetGSTR3BDetails data, string otp)
        //{
        //    GSTNAuthClient client = new GSTNAuthClient(gstin, this.gstinUsername, appKey)
        //    {
        //        AuthToken = this.GSTINToken,
        //        DecryptedKey = EncryptionUtils.AesDecrypt(this.GSTINSek, appKey)
        //    };
        //    GSTR3BApiClient client2 = new GSTR3BApiClient(client, data.gstin, data.ret_period, Constants.GSTR3B_Get3B_URL);
        //    string userId = User.Claims.FirstOrDefault(z => z.Type == "Id")?.Value;
        //    if (string.IsNullOrEmpty(userId))
        //    {
        //        return new ResponseModel
        //        {
        //            isSuccess = false,
        //            message = "Invalid user Request"
        //        };
        //    }
        //    string PAN = (await _userManager.FindByIdAsync(userId))?.Organization_PAN;
        //    var info = await client2.filegstr3b(data, otp, PAN);
        //    return new ResponseModel
        //    {
        //        data = info,
        //        isSuccess = true,
        //        message = "success"
        //    };
        //}

        // END AMIT 10FEB2025 SAVE GSTR3B

        [HttpGet("GetGSTR3BDetails")]
        public async Task<ResponseModel> GetGSTR3BDetails([FromQuery] APIRequestParameters model)
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
                GSTR3BApiClient client2 = new GSTR3BApiClient(client, gstin, model.ret_period, Constants.GSTR3B_Get3B_URL);
                var info = await client2.GetGSTR3BDetails(model);
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

        //[HttpGet("GetGSTR3BDetails")]
        //public async Task<GetGSTR3BDetails> GetGSTR3BDetails([FromQuery] APIRequestParameters model)
        //{
        //    if (string.IsNullOrEmpty(this.GSTINToken) || string.IsNullOrEmpty(this.GSTINSek))
        //    {
        //        throw new InvalidOperationException("Please send 'GSTIN-Token' or 'GSTIN-Sek' in headers");
        //    }

        //    GSTNAuthClient client = new GSTNAuthClient(gstin, this.gstinUsername, this.appKey)
        //    {
        //        AuthToken = this.GSTINToken,
        //        DecryptedKey = EncryptionUtils.AesDecrypt(this.GSTINSek, this.appKey)
        //    };

        //    GSTR3BApiClient client2 = new GSTR3BApiClient(client, gstin, model.ret_period, Constants.GSTR3B_Get3B_URL);
        //    var info = await client2.GetGSTR3BDetails(model);
        //    return info.Data;
        //}

        [HttpGet("GetITCReversalBalance")]
        public async Task<ResponseModel> GetITCReversalBalance([FromQuery] APIRequestParameters model)
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
                GSTR3BApiClient client2 = new GSTR3BApiClient(client, gstin, model.ret_period, Constants.GSTR3B_Get3B_URL);
                var info = await client2.GetGetITCReversalBalance(model);
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


        [HttpGet("GetITCLiabilityDetails")]
        public async Task<ResponseModel> GetITCLiabilityDetails([FromQuery] APIRequestParameters model)
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
                GSTR3BApiClient client2 = new GSTR3BApiClient(client, gstin, model.ret_period, Constants.GSTR3B_Get3B_URL);
                var info = await client2.GetITCLiabilityDetails(model);
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

        [HttpGet("GetOpeningBalanceReclaimDetails")]
        public async Task<ResponseModel> GetOpeningBalanceReclaimDetails([FromQuery] APIRequestParameters model)
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
                GSTR3BApiClient client2 = new GSTR3BApiClient(client, gstin, model.ret_period, Constants.GSTR3B_Get3B_URL);
                var info = await client2.GetOpeningBalanceReclaimDetails(model);
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

        [HttpGet("GetSystemCalculatedInterest")]
        public async Task<ResponseModel> GetSystemCalculatedInterest([FromQuery] APIRequestParameters model)
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
                GSTR3BApiClient client2 = new GSTR3BApiClient(client, gstin, model.ret_period, Constants.GSTR3B_Get3B_URL);
                var info = await client2.GetSystemCalculatedInterest(model);
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

        [HttpGet("GetLatestRCMBal3B")]
        public async Task<ResponseModel> GetLatestRCMBal3B([FromQuery] APIRequestParameters model)
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
                GSTR3BApiClient client2 = new GSTR3BApiClient(client, gstin, model.ret_period, Constants.GSTR3B_RCM_URL);
                var info = await client2.GetLatestRCMBal3B(model);
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

        [HttpGet("GetOpeningRCMBal3B")]
        public async Task<ResponseModel> GetOpeningRCMBal3B([FromQuery] APIRequestParameters model)
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
                GSTR3BApiClient client2 = new GSTR3BApiClient(client, gstin, model.ret_period, Constants.GSTR3B_RCM_URL);
                var info = await client2.GetOpeningRCMBal3B(model);
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

        [HttpPut("OffsetLiabilityGSTR3B")]
        public async Task<ResponseModel> OffsetLiabilityGSTR3B([FromBody] OffsetLiabilityGSTR3Bdata model)
        {
            GSTNAuthClient client = new GSTNAuthClient(gstin, this.gstinUsername, appKey)
            {
                AuthToken = this.GSTINToken,
                DecryptedKey = EncryptionUtils.AesDecrypt(this.GSTINSek, appKey)
            };
            GSTR3BApiClient client2 = new GSTR3BApiClient(client, gstin, "052024", Constants.GSTR3B_Get3B_URL);
            var info = await client2.offsetliab(model);


            return new ResponseModel
            {

                data = info,
                isSuccess = true,
                message = "success"
            };

        }

        [HttpPost("RecomputeinterestGSTR3B")]
        public async Task<ResponseModel> RecomputeinterestGSTR3B([FromBody] ReComputeInterest model)
        {
            GSTNAuthClient client = new GSTNAuthClient(gstin, this.gstinUsername, appKey)
            {
                AuthToken = this.GSTINToken,
                DecryptedKey = EncryptionUtils.AesDecrypt(this.GSTINSek, appKey)
            };
            GSTR3BApiClient client2 = new GSTR3BApiClient(client, model.gstin, model.ret_period, Constants.GSTR3B_Get3B_URL);
            var info = await client2.RecomputeInterest(model);


            return new ResponseModel
            {

                data = info,
                isSuccess = true,
                message = "success"
            };

        }

        [HttpPost("saveopeningbal")]
        public async Task<ResponseModel> saveopeningbal([FromBody] SaveOpeningBalRequest data)
        {
            GSTNAuthClient client = new GSTNAuthClient(gstin, this.gstinUsername, appKey)
            {
                AuthToken = this.GSTINToken,
                DecryptedKey = EncryptionUtils.AesDecrypt(this.GSTINSek, appKey)
            };
            GSTR3BApiClient client2 = new GSTR3BApiClient(client, data.gstin, "042024", Constants.GSTR3B_Get3B_URL);
            var info = await client2.saveopening(data);


            return new ResponseModel
            {

                data = info,
                isSuccess = true,
                message = "success"
            };
        }

        [HttpPut("savepastliabbrk")]
        public async Task<ResponseModel> savepastliabbrk([FromBody] Savepastliabbrk model)
        {
            GSTNAuthClient client = new GSTNAuthClient(gstin, this.gstinUsername, appKey)
            {
                AuthToken = this.GSTINToken,
                DecryptedKey = EncryptionUtils.AesDecrypt(this.GSTINSek, appKey)
            };
            GSTR3BApiClient client2 = new GSTR3BApiClient(client, gstin,model.ret_period, Constants.GSTR3B_Get3B_URL);
            var info = await client2.savepalibrk(model);


            return new ResponseModel
            {

                data = info,
                isSuccess = true,
                message = "success"
            };

        }

        [HttpPost("validategstr3b")]
        public async Task<ResponseModel> validategstr3b([FromBody] ValidateGSTR3BRequest data)
        {
            GSTNAuthClient client = new GSTNAuthClient(gstin, this.gstinUsername, appKey)
            {
                AuthToken = this.GSTINToken,
                DecryptedKey = EncryptionUtils.AesDecrypt(this.GSTINSek, appKey)
            };
            GSTR3BApiClient client2 = new GSTR3BApiClient(client, data.gstin, data.ret_period, Constants.GSTR3B_Get3B_URL);
            var info = await client2.validategstr3bauto(data);


            return new ResponseModel
            {

                data = info,
                isSuccess = true,
                message = "success"
            };
        }

        [HttpPost("SubmitRCMOpnBal")]
        public async Task<ResponseModel> SubmitRCMOpnBal([FromBody] SubmitRCMOpeningBalance_Request data)
        {
            GSTNAuthClient client = new GSTNAuthClient(gstin, this.gstinUsername, appKey)
            {
                AuthToken = this.GSTINToken,
                DecryptedKey = EncryptionUtils.AesDecrypt(this.GSTINSek, appKey)
            };
            GSTR3BApiClient client2 = new GSTR3BApiClient(client, data.gstin, "", Constants.GSTR3B_Get3B_URL);
            var info = await client2.SubmitRCMOpnBalGSTR3B(data);


            return new ResponseModel
            {

                data = info,
                isSuccess = true,
                message = "success"
            };
        }

    }
}
