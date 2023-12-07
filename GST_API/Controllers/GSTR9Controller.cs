using GST_API.APIModels;
using GST_API.Services;
using GST_API_Library.Models;
using GST_API_Library.Models.GSTR9;
using GST_API_Library.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace GST_API.Controllers
{
    [Route("api/gstr9")]
    [ApiController]
    [Authorize]
    public class GSTR9Controller : BaseController
    {
        private readonly ILogger<AuthenticationController> _logger;
        public GSTR9Controller(ILogger<AuthenticationController> logger)
        {
            _logger = logger;
        }
       
        [HttpGet("Get8ADetails")]
        public async Task<ResponseModel> Get8ADetails([FromQuery] APIRequestParamtersGSTR9 model)
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
                GSTR9ApiClient client2 = new GSTR9ApiClient(client, gstin, model.ret_period, Constants.GSTR9_Get9_URL);
                var info = await client2.Get8ADetails(model);
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

        [HttpGet("GetAutocalculatedDetails")]
        public async Task<ResponseModel> GetAutocalculatedDetails([FromQuery] APIRequestParamtersGSTR9 model)
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
                GSTR9ApiClient client2 = new GSTR9ApiClient(client, gstin, model.ret_period, Constants.GSTR9_Get9_URL);
                var info = await client2.GetAutoCalDetails(model);
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

        [HttpGet("GetDetails")]
        public async Task<ResponseModel> GetDetails([FromQuery] APIRequestParamtersGSTR9 model)
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
                GSTR9ApiClient client2 = new GSTR9ApiClient(client, gstin, model.ret_period, Constants.GSTR9_GetDetails_URL);
                var info = await client2.GetDetails(model);
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

        [HttpGet("GetAutocalculatedDetailsGSTR9A")]
        public async Task<ResponseModel> GetAutocalculatedDetailsGSTR9A([FromQuery] APIRequestParamtersGSTR9 model)
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
                GSTR9ApiClient client2 = new GSTR9ApiClient(client, gstin, model.ret_period, Constants.GSTR9A_URL);
                var info = await client2.GetAutoCalDetails9A(model);
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

        [HttpGet("GetDetailsGSTR9A")]
        public async Task<ResponseModel> GetDetailsGSTR9A([FromQuery] APIRequestParamtersGSTR9 model)
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
                GSTR9ApiClient client2 = new GSTR9ApiClient(client, gstin, model.ret_period, Constants.GSTR9A_URL);
                var info = await client2.GetDetails9A(model);
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

        [HttpPut("SaveGSTR9")]
        public async Task<ResponseModel> save9([FromBody] GSTR9Total data)
        {
            GSTNAuthClient client = new GSTNAuthClient(gstin, this.gstinUsername, appKey)
            {
                AuthToken = this.GSTINToken,
                DecryptedKey = EncryptionUtils.AesDecrypt(this.GSTINSek, appKey)
            };
            GSTR9ApiClient client2 = new GSTR9ApiClient(client, data.gstin, data.fp, Constants.GSTR9_SAVE_URL);
            var info = await client2.Save9(data);
            return new ResponseModel
            {
                data = info,
                isSuccess = true,
                message = "success"
            };
        }

        [HttpPut("SaveGSTR9A")]
        public async Task<ResponseModel> save9A([FromBody] GSTR9Total data)
        {
            GSTNAuthClient client = new GSTNAuthClient(gstin, this.gstinUsername, appKey)
            {
                AuthToken = this.GSTINToken,
                DecryptedKey = EncryptionUtils.AesDecrypt(this.GSTINSek, appKey)
            };
            GSTR9ApiClient client2 = new GSTR9ApiClient(client, data.gstin, data.fp, Constants.GSTR9A_SAVE_URL);
            var info = await client2.Save9A(data);
            return new ResponseModel
            {
                data = info,
                isSuccess = true,
                message = "success"
            };
        }

        [HttpGet("Get9RecordsFor9C")]
        public async Task<ResponseModel> Get9RecordsFor9C([FromQuery] APIRequestParamtersGSTR9 model)
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
                GSTR9ApiClient client2 = new GSTR9ApiClient(client, gstin, model.ret_period, Constants.GSTR9C_9Records_URL);
                var info = await client2.GetGstr9ToGstr9c(model);
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

        [HttpGet("Get9CSummary")]
        public async Task<ResponseModel> Get9CSummary([FromQuery] APIRequestParamtersGSTR9 model)
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
                GSTR9ApiClient client2 = new GSTR9ApiClient(client, gstin, model.ret_period, Constants.GSTR9C_GetSummary_URL);
                var info = await client2.GetGstr9CSummary(model);
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

        [HttpPut("GSTR9CHashGenerate")]
        public async Task<ResponseModel> GSTR9CHashGenerate([FromBody] GSTR9CHashGeneratorRequest data)
        {
            GSTNAuthClient client = new GSTNAuthClient(gstin, this.gstinUsername, appKey)
            {
                AuthToken = this.GSTINToken,
                DecryptedKey = EncryptionUtils.AesDecrypt(this.GSTINSek, appKey)
            };
            GSTR9ApiClient client2 = new GSTR9ApiClient(client, data.gstin, data.fp, Constants.GSTR9C_HashGenerate_URL);
            var info = await client2.GSTR9CHashGenerate(data);
            return new ResponseModel
            {
                data = info,
                isSuccess = true,
                message = "success"
            };
        }

        [HttpPut("SaveGSTR9C")]
        public async Task<ResponseModel> save9C([FromBody] GSTR9CSaveRequest data)
        {
            GSTNAuthClient client = new GSTNAuthClient(gstin, this.gstinUsername, appKey)
            {
                AuthToken = this.GSTINToken,
                DecryptedKey = EncryptionUtils.AesDecrypt(this.GSTINSek, appKey)
            };
            GSTR9ApiClient client2 = new GSTR9ApiClient(client, data.gstin, data.fp, Constants.GSTR9C_Save_URL);
            var info = await client2.Save9C(data);
            return new ResponseModel
            {
                data = info,
                isSuccess = true,
                message = "success"
            };
        }

        [HttpPut("GSTR9CGenerateCertificate")]
        public async Task<ResponseModel> GSTR9CGenCerti([FromBody] GSTR9CGenCertiRequest data)
        {
            GSTNAuthClient client = new GSTNAuthClient(gstin, this.gstinUsername, appKey)
            {
                AuthToken = this.GSTINToken,
                DecryptedKey = EncryptionUtils.AesDecrypt(this.GSTINSek, appKey)
            };
            GSTR9ApiClient client2 = new GSTR9ApiClient(client, data.gstin, data.fp, Constants.GSTR9C_GenCerti_URL);
            var info = await client2.GSTR9CGenCerti(data);
            return new ResponseModel
            {
                data = info,
                isSuccess = true,
                message = "success"
            };
        }

    }
}
