using GST_API.APIModels;
using GST_API.Services;
using GST_API_Library.Models;
using GST_API_Library.Models.GSTR2A;
using GST_API_Library.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace GST_API.Controllers
{
    [Route("api/gstr2a")]
    [ApiController]
    [Authorize(Roles = "APIUser")]
    public class GSTR2AController : BaseController
    {
        private readonly ILogger<AuthenticationController> _logger;
        public GSTR2AController(ILogger<AuthenticationController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetECOMAgstr2A")]
        public async Task<ResponseModel> GetECOMAgstr2A([FromQuery] APIRequestParameters model)
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
                GSTR2AApiClient client2 = new GSTR2AApiClient(client, gstin, model.ret_period, Constants.GSTR2A);
                var info = await client2.GetECOMA2A(model);
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

        [HttpGet("GetIMPGgstr2A")]
        public async Task<ResponseModel> GetIMPGgstr2A([FromQuery] APIRequestParameters model)
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
                GSTR2AApiClient client2 = new GSTR2AApiClient(client, gstin, model.ret_period, Constants.GSTR2A_OTH);
                var info = await client2.GetIMPG2A(model);
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

        [HttpGet("GetIMPGSEZgstr2A")]
        public async Task<ResponseModel> GetIMPGSEZgstr2A([FromQuery] APIRequestParameters model)
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
                GSTR2AApiClient client2 = new GSTR2AApiClient(client, gstin, model.ret_period, Constants.GSTR2A_OTH);
                var info = await client2.GetIMPGSEZ2A(model);
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

        [HttpGet("GetISDCREDITgstr2A")]
        public async Task<ResponseModel> GetISDCREDITgstr2A([FromQuery] APIRequestParameters model)
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
                GSTR2AApiClient client2 = new GSTR2AApiClient(client, gstin, model.ret_period, Constants.GSTR2A_OTH);
                var info = await client2.GetISD2A(model);
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

        [HttpGet("GetTCSCREDITgstr2A")]
        public async Task<ResponseModel> GetTCSCREDITgstr2A([FromQuery] APIRequestParameters model)
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
                GSTR2AApiClient client2 = new GSTR2AApiClient(client, gstin, model.ret_period, Constants.GSTR2A_OTH);
                var info = await client2.GetTCS2A(model);
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

        [HttpGet("GetTDSCREDITgstr2A")]
        public async Task<ResponseModel> GetTDSCREDITgstr2A([FromQuery] APIRequestParameters model)
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
                GSTR2AApiClient client2 = new GSTR2AApiClient(client, gstin, model.ret_period, Constants.GSTR2A_OTH);
                var info = await client2.GetTDS2A(model);
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
