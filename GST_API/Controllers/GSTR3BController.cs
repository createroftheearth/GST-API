using GST_API.APIModels;
using GST_API.Services;
using GST_API_Library.Models.GSTR3B;
using GST_API_Library.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace GST_API.Controllers
{
    [Route("api/gstr3b")]
    [ApiController]
    [Authorize(Roles = "APIUser")]
    public class GSTR3BController : BaseController
    {
        private readonly ILogger<AuthenticationController> _logger;
        public GSTR3BController(ILogger<AuthenticationController> logger)
        {
            _logger = logger;
        }
        [HttpGet("GetGSTR3Details")]
        public async Task<ResponseModel> GetGSTR3Details([FromQuery] APIRequestParameters model)
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

        //[HttpPut("OffsetLiabilityGSTR3B")]
        //public async Task<ResponseModel> OffsetLiabilityGSTR3B([FromBody] OffsetLiabilityGSTR3Bdata model)
        //{
        //    if (string.IsNullOrEmpty(this.GSTINToken) || string.IsNullOrEmpty(this.GSTINSek))
        //    {
        //        return new ResponseModel
        //        {
        //            isSuccess = false,
        //            message = "Please send 'GSTIN-Token' or 'GSTIN-Sek' in headers"
        //        };
        //    }
        //    GSTNAuthClient client = new GSTNAuthClient(gstin, this.gstinUsername, this.appKey)
        //    {
        //        AuthToken = this.GSTINToken,
        //        DecryptedKey = EncryptionUtils.AesDecrypt(this.GSTINSek, this.appKey)

        //    };

        //}

    }
}
