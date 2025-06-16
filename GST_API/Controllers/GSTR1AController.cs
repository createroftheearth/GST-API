using GST_API.APIModels;
using GST_API.Services;
using GST_API_DAL.Models;
using GST_API_Library.Models;
using GST_API_Library.Models.GSTR1;
//using GST_API_Library.Models.GSTR1;
using GST_API_Library.Models.GSTR1A;
using GST_API_Library.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GST_API.Controllers
{
    [Route("api/gstr1A")]
    [ApiController]
    [Authorize(Roles = "APIUser")]
    public class GSTR1AController : BaseController
    {
        private readonly ILogger<AuthenticationController> _logger;
        private readonly UserManager<User> _userManager;

        public GSTR1AController(ILogger<AuthenticationController> logger, UserManager<User> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }


        //[HttpPut("saveGSTR1A")]
        //public async Task<ResponseModel> saveGSTR1A([FromBody] GSTR1ATotal data)
        //{
        //    if (string.IsNullOrEmpty(this.GSTINToken) || string.IsNullOrEmpty(this.GSTINSek))
        //    {
        //        return new ResponseModel
        //        {
        //            isSuccess = false,
        //            message = "Please send 'GSTIN-Token' or 'GSTIN-Sek' in headers"
        //        };
        //    }
        //    GSTNAuthClient client = new GSTNAuthClient(gstin, this.gstinUsername, appKey)
        //    {
        //        AuthToken = this.GSTINToken,
        //        DecryptedKey = EncryptionUtils.AesDecrypt(this.GSTINSek, appKey)
        //    };
        //    GSTR1aApiClient client2 = new GSTR1aApiClient(client, gstin, data.fp, Constants.GSTR1A_URL);
        //    var info = await client2.Save1A(data);


        //    return new ResponseModel
        //    {

        //        data = info,
        //        isSuccess = true,
        //        message = "success"
        //    };
        //}

        //[HttpPost("{otp}/fileGSTR1A")]
        //public async Task<ResponseModel> fileGSTR1A([FromBody] GetGSTR1ASummaryResp data, string otp)
        //{
        //    if (string.IsNullOrEmpty(this.GSTINToken) || string.IsNullOrEmpty(this.GSTINSek))
        //    {
        //        return new ResponseModel
        //        {
        //            isSuccess = false,
        //            message = "Please send 'GSTIN-Token' or 'GSTIN-Sek' in headers"
        //        };
        //    }
        //    GSTNAuthClient client = new GSTNAuthClient(gstin, this.gstinUsername, appKey)
        //    {
        //        AuthToken = this.GSTINToken,
        //        DecryptedKey = EncryptionUtils.AesDecrypt(this.GSTINSek, appKey)
        //    };
        //    GSTR1aApiClient client2 = new GSTR1aApiClient(client, gstin, data.ret_period, Constants.GSTR1A_URL);
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
        //    var info = await client2.filegstr1A(data, otp, PAN);
        //    return new ResponseModel
        //    {
        //        data = info,
        //        isSuccess = true,
        //        message = "success"
        //    };
        //}

        [HttpPost("ResetGSTR1A")]
        public async Task<ResponseModel> ResetGSTR1A([FromBody] GenerateRequestInfo model)
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
            GSTR1aApiClient client2 = new GSTR1aApiClient(client, gstin, model.ret_period, Constants.GSTR1A_URL);
            var info = await client2.Reset_GSTR1A(model);
            return new ResponseModel
            {
                data = info,
                isSuccess = true,
                message = "success"
            };
        }

        /// <summary>
        /// ProceedToFileGSTR1A
        /// </summary>
        /// <param name="ret_prd"></param>
        /// <returns></returns>
        [HttpPost("ProceedToFileGSTR1A")]
        public async Task<ResponseModel> ProceedToFileGSTR1A([FromBody] GenerateRequestInfo model)
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
            GSTR1aApiClient client2 = new GSTR1aApiClient(client, gstin, model.ret_period, Constants.GSTR1A_URL);
            var info = await client2.ProceedToFile_GSTR1A(model);
            return new ResponseModel
            {
                data = info,
                isSuccess = true,
                message = "success"
            };
        }

        [HttpPost("{otp}/file1A")]
        public async Task<ResponseModel> file1A([FromBody] GetGSTR1ASummaryResp data, string otp)
        {
            GSTNAuthClient client = new GSTNAuthClient(gstin, this.gstinUsername, appKey)
            {
                AuthToken = this.GSTINToken,
                DecryptedKey = EncryptionUtils.AesDecrypt(this.GSTINSek, appKey)
            };
            GSTR1ApiClient client2 = new GSTR1ApiClient(client, data.gstin, data.ret_period, Constants.GSTR1_V4_RETURN_URL);
            string userId = User.Claims.FirstOrDefault(z => z.Type == "Id")?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return new ResponseModel
                {
                    isSuccess = false,
                    message = "Invalid user Request"
                };
            }
            string PAN = (await _userManager.FindByIdAsync(userId))?.Organization_PAN;
            var info = await client2.filegstr1A(data, otp, PAN);
            return new ResponseModel
            {
                data = info,
                isSuccess = true,
                message = "success"
            };
        }

        [HttpGet("GetAT")]
        public async Task<ResponseModel> GetAT([FromQuery] APIRequestParameters1A model)
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
            GSTR1aApiClient client2 = new GSTR1aApiClient(client, gstin, model.ret_period, Constants.GSTR1A_URL);
            var info = await client2.GetATGSTR1a(model);
            return new ResponseModel
            {
                data = info,

                isSuccess = true,
                message = "success"
            };
        }

        [HttpGet("GetATA")]
        public async Task<ResponseModel> GetATA([FromQuery] APIRequestParameters1A model)
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
            GSTR1aApiClient client2 = new GSTR1aApiClient(client, gstin, model.ret_period, Constants.GSTR1A_URL);
            var info = await client2.GetATAGSTR1a(model);
            return new ResponseModel
            {
                data = info,

                isSuccess = true,
                message = "success"
            };
        }

        [HttpGet("GetB2BInvoicesGSTR1A")]
        public async Task<ResponseModel> GetB2BInvoicesGSTR1A([FromQuery] APIRequestParameters1A model)
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
                GSTR1aApiClient client2 = new GSTR1aApiClient(client, gstin, model.ret_period, Constants.GSTR1A_URL);
                var info = await client2.GetB2BGSTR1A(model);
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

        [HttpGet("GetB2BAInvoicesGSTR1A")]
        public async Task<ResponseModel> GetB2BAInvoicesGSTR1A([FromQuery] APIRequestParameters1A model)
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
                GSTR1aApiClient client2 = new GSTR1aApiClient(client, gstin, model.ret_period, Constants.GSTR1A_URL);
                var info = await client2.GetB2BAGSTR1A(model);
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

        [HttpGet("GetB2CLInvoicesGSTR1A")]
        public async Task<ResponseModel> GetB2CLInvoicesGSTR1A([FromQuery] APIRequestParameters1A model)
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
                GSTR1aApiClient client2 = new GSTR1aApiClient(client, gstin, model.ret_period, Constants.GSTR1A_URL);
                var info = await client2.GetB2CLGSTR1A(model);
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

        [HttpGet("GetB2CLAInvoicesGSTR1A")]
        public async Task<ResponseModel> GetB2CLAInvoicesGSTR1A([FromQuery] APIRequestParameters1A model)
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
                GSTR1aApiClient client2 = new GSTR1aApiClient(client, gstin, model.ret_period, Constants.GSTR1A_URL);
                var info = await client2.GetB2CLAGSTR1A(model);
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

        [HttpGet("GetB2CSInvoicesGSTR1A")]
        public async Task<ResponseModel> GetB2CSInvoicesGSTR1A([FromQuery] APIRequestParameters1A model)
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
                GSTR1aApiClient client2 = new GSTR1aApiClient(client, gstin, model.ret_period, Constants.GSTR1A_URL);
                var info = await client2.GetB2CSGSTR1A(model);
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

        [HttpGet("GetB2CSAInvoicesGSTR1A")]
        public async Task<ResponseModel> GetB2CSAInvoicesGSTR1A([FromQuery] APIRequestParameters1A model)
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
                GSTR1aApiClient client2 = new GSTR1aApiClient(client, gstin, model.ret_period, Constants.GSTR1A_URL);
                var info = await client2.GetB2CSAGSTR1A(model);
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

        [HttpGet("GetHSNInvoicesGSTR1A")]
        public async Task<ResponseModel> GetHSNInvoicesGSTR1A([FromQuery] APIRequestParameters1A model)
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
                GSTR1aApiClient client2 = new GSTR1aApiClient(client, gstin, model.ret_period, Constants.GSTR1A_URL);
                var info = await client2.GetHSNGSTR1A(model);
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

        [HttpGet("GetNILInvoicesGSTR1A")]
        public async Task<ResponseModel> GetNILInvoicesGSTR1A([FromQuery] APIRequestParameters1A model)
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
                GSTR1aApiClient client2 = new GSTR1aApiClient(client, gstin, model.ret_period, Constants.GSTR1A_URL);
                var info = await client2.GetNILGSTR1A(model);
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

        [HttpGet("GetTXPInvoicesGSTR1A")]
        public async Task<ResponseModel> GetTXPInvoicesGSTR1A([FromQuery] APIRequestParameters1A model)
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
                GSTR1aApiClient client2 = new GSTR1aApiClient(client, gstin, model.ret_period, Constants.GSTR1A_URL);
                var info = await client2.GetTXPGSTR1A(model);
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

        [HttpGet("GetSummaryGSTR1A")]
        public async Task<ResponseModel> GetGSTR1ASummary([FromQuery] APIRequestParameters1A model)
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
            GSTR1aApiClient client2 = new GSTR1aApiClient(client, gstin, model.ret_period, Constants.GSTR1A_URL);
            var info = await client2.GetGSTR1ASummary1(model);
            //return info.Data;

            return new ResponseModel
            {
                data = info,

                isSuccess = true,
                message = "success"
            };
        }

        //[HttpGet("{ret_prd}/{reference_id}/ReturnStatus")]
        //public async Task<ResponseModel> ReturnStatus(string ret_prd, string reference_id)
        //{
        //    if (string.IsNullOrEmpty(this.GSTINToken) || string.IsNullOrEmpty(this.GSTINSek))
        //    {
        //        return new ResponseModel
        //        {
        //            isSuccess = false,
        //            message = "Please send 'GSTIN-Token' or 'GSTIN-Sek' in headers"
        //        };
        //    }
        //    GSTNAuthClient client = new GSTNAuthClient(gstin, this.gstinUsername, appKey)
        //    {
        //        AuthToken = this.GSTINToken,
        //        DecryptedKey = EncryptionUtils.AesDecrypt(this.GSTINSek, appKey)
        //    };
        //    GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, ret_prd, Constants.GSTR1_ReturnStatus_URL);
        //    var info = await client2.GetStatus(ret_prd, reference_id);
        //    return new ResponseModel
        //    {
        //        data = info,
        //        isSuccess = true,
        //        message = "success"
        //    };
        //}

        //[HttpGet("GetB2BInvoices")]
        //public async Task<ResponseModel> GetB2BInvoices([FromQuery] APIRequestParameters model)
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
        //    try
        //    {
        //        GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, model.ret_period, Constants.GSTR1_V4_RETURN_URL);
        //        var info = await client2.GetB2B(model);
        //        return new ResponseModel
        //        {
        //            data = info,
        //            isSuccess = true,
        //            message = "success"
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        return new ResponseModel
        //        {
        //            isSuccess = false,
        //            message = ex.Message
        //        };
        //    }
        //}

        //[HttpGet("GetB2BAInvoices")]
        //public async Task<ResponseModel> GetB2BAInvoices([FromQuery] APIRequestParameters model)
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
        //    GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, model.ret_period, Constants.GSTR1_V4_RETURN_URL);
        //    var info = await client2.GetB2BA(model);
        //    return new ResponseModel
        //    {
        //        data = info,

        //        isSuccess = true,
        //        message = "success"
        //    };
        //}

        //[HttpGet("GetB2CLInvoices")]
        //public async Task<ResponseModel> GetB2CLInvoices([FromQuery] APIRequestParameters model)
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
        //    GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, model.ret_period, Constants.GSTR1_V4_RETURN_URL);
        //    var info = await client2.GetB2CL(model);
        //    return new ResponseModel
        //    {
        //        data = info,

        //        isSuccess = true,
        //        message = "success"
        //    };
        //}

        //[HttpGet("GetB2CLAInvoices")]
        //public async Task<ResponseModel> GetB2CLAInvoices([FromQuery] APIRequestParameters model)
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
        //    GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, model.ret_period, Constants.GSTR1_V4_RETURN_URL);
        //    var info = await client2.GetB2CLA(model);
        //    return new ResponseModel
        //    {
        //        data = info,

        //        isSuccess = true,
        //        message = "success"
        //    };
        //}

        //[HttpGet("GetB2CSInvoices")]
        //public async Task<ResponseModel> GetB2CSInvoices([FromQuery] APIRequestParameters model)
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
        //    GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, model.ret_period, Constants.GSTR1_V4_RETURN_URL);
        //    var info = await client2.GetB2Cs(model);
        //    return new ResponseModel
        //    {
        //        data = info,

        //        isSuccess = true,
        //        message = "success"
        //    };
        //}
        //[HttpGet("GetB2CsAInvoices")]
        //public async Task<ResponseModel> GetB2CsAInvoices([FromQuery] APIRequestParameters model)
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
        //    GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, model.ret_period, Constants.GSTR1_V4_RETURN_URL);
        //    var info = await client2.GetB2CsA(model);
        //    return new ResponseModel
        //    {
        //        data = info,

        //        isSuccess = true,
        //        message = "success"
        //    };
        //}

        //[HttpGet("GetCDNRInvoices")]
        //public async Task<ResponseModel> GetCDNRInvoices([FromQuery] APIRequestParameters model)
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
        //    GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, model.ret_period, Constants.GSTR1_V4_RETURN_URL);
        //    var info = await client2.GetCDNR(model);
        //    return new ResponseModel
        //    {
        //        data = info,

        //        isSuccess = true,
        //        message = "success"
        //    };
        //}

        //[HttpGet("GetCDNRAInvoices")]
        //public async Task<ResponseModel> GetCDNRAInvoices([FromQuery] APIRequestParameters model)
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
        //    GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, model.ret_period, Constants.GSTR1_V4_RETURN_URL);
        //    var info = await client2.GetCDNA(model);
        //    return new ResponseModel
        //    {
        //        data = info,

        //        isSuccess = true,
        //        message = "success"
        //    };
        //}

        ////
        //[HttpGet("GetCDNURInvoices")]
        //public async Task<ResponseModel> GetCDNURInvoices([FromQuery] APIRequestParameters model)
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
        //    GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, model.ret_period, Constants.GSTR1_V4_RETURN_URL);
        //    var info = await client2.GetCDNUR(model);
        //    return new ResponseModel
        //    {
        //        data = info,

        //        isSuccess = true,
        //        message = "success"
        //    };
        //}

        //[HttpGet("GetCDNURAInvoices")]
        //public async Task<ResponseModel> GetCDNURAInvoices([FromQuery] APIRequestParameters model)
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
        //    GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, model.ret_period, Constants.GSTR1_V4_RETURN_URL);
        //    var info = await client2.GetCDNURA(model);
        //    return new ResponseModel
        //    {
        //        data = info,

        //        isSuccess = true,
        //        message = "success"
        //    };
        //}


        //[HttpGet("GetNilRatedInvoices")]
        //public async Task<ResponseModel> GetNilRatedInvoices([FromQuery] APIRequestParameters model)
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
        //    GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, model.ret_period, Constants.GSTR1_V4_RETURN_URL);
        //    var info = await client2.GetNilRated(model);
        //    return new ResponseModel
        //    {
        //        data = info,

        //        isSuccess = true,
        //        message = "success"
        //    };
        //}

        //[HttpGet("GetExpInvoices")]
        //public async Task<ResponseModel> GetExpInvoices([FromQuery] APIRequestParameters model)
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
        //    GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, model.ret_period, Constants.GSTR1_V4_RETURN_URL);
        //    var info = await client2.GetExp(model);
        //    return new ResponseModel
        //    {
        //        data = info,

        //        isSuccess = true,
        //        message = "success"
        //    };
        //}

        //[HttpGet("GetExpAInvoices")]
        //public async Task<ResponseModel> GetExpAInvoices([FromQuery] APIRequestParameters model)
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
        //    GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, model.ret_period, Constants.GSTR1_V4_RETURN_URL);
        //    var info = await client2.GetExpA(model);
        //    return new ResponseModel
        //    {
        //        data = info,

        //        isSuccess = true,
        //        message = "success"
        //    };
        //}



        //[HttpGet("GetATAInvoices")]
        //public async Task<ResponseModel> GetATAInvoices([FromQuery] APIRequestParameters model)
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
        //    GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, model.ret_period, Constants.GSTR1_V4_RETURN_URL);
        //    var info = await client2.GetATA(model);
        //    return new ResponseModel
        //    {
        //        data = info,

        //        isSuccess = true,
        //        message = "success"
        //    };
        //}

        //[HttpGet("GetDocIssued")]
        //public async Task<ResponseModel> GetDocIssued([FromQuery] APIRequestParameters model)
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
        //    GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, model.ret_period, Constants.GSTR1_V4_RETURN_URL);
        //    var info = await client2.GetDocIssued(model);
        //    return new ResponseModel
        //    {
        //        data = info,

        //        isSuccess = true,
        //        message = "success"
        //    };
        //}

        ////Pending
        ////[HttpGet("{ret_prd}/GetTXPDInvoices")]
        ////public async Task<ResponseModel> GetTXPDInvoices(string ret_prd)
        ////{
        ////    if (string.IsNullOrEmpty(this.GSTINToken) || string.IsNullOrEmpty(this.GSTINSek))
        ////    {
        ////        return new ResponseModel
        ////        {
        ////            isSuccess = false,
        ////            message = "Please send 'GSTIN-Token' or 'GSTIN-Sek' in headers"
        ////        };
        ////    }
        ////    GSTNAuthClient client = new GSTNAuthClient(gstin, this.gstinUsername, this.appKey)
        ////    {
        ////        AuthToken = this.GSTINToken,
        ////        DecryptedKey = EncryptionUtils.AesDecrypt(this.GSTINSek, this.appKey)

        ////    };
        ////    GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, ret_prd, Constants.GSTR1_V4_RETURN_URL);
        ////    var info = await client2.GetTXPD(ret_prd);
        ////    return new ResponseModel
        ////    {
        ////        data = info,

        ////        isSuccess = true,
        ////        message = "success"
        ////    };
        ////}

        //[HttpGet("GetEcomInvoices")]
        //public async Task<ResponseModel> GetEcomInvoices([FromQuery] APIRequestParameters model)
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
        //    GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, model.ret_period, Constants.GSTR1_V4_RETURN_URL);
        //    var info = await client2.GetECOM(model);
        //    return new ResponseModel
        //    {
        //        data = info,

        //        isSuccess = true,
        //        message = "success"
        //    };
        //}

        ////[HttpGet("GetSummary")]
        ////public async Task<ResponseModel> GetGSTR1Summary([FromQuery] APIRequestParameters model)
        ////{
        ////    if (string.IsNullOrEmpty(this.GSTINToken) || string.IsNullOrEmpty(this.GSTINSek))
        ////    {
        ////        return new ResponseModel
        ////        {
        ////            isSuccess = false,
        ////            message = "Please send 'GSTIN-Token' or 'GSTIN-Sek' in headers"
        ////        };
        ////    }
        ////    GSTNAuthClient client = new GSTNAuthClient(gstin, this.gstinUsername, this.appKey)
        ////    {
        ////        AuthToken = this.GSTINToken,
        ////        DecryptedKey = EncryptionUtils.AesDecrypt(this.GSTINSek, this.appKey)

        ////    };
        ////    GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, "092017", Constants.GSTR1_V4_RETURN_URL);
        ////    var info = await client2.GetGSTR1Summary(model);
        ////    return new ResponseModel
        ////    {
        ////        data = info,
        ////        isSuccess = true,
        ////        message = "success"
        ////    };
        ////}

        //[HttpGet("GetSummary")]
        //public async Task<SummaryOutward> GetGSTR1Summary([FromQuery] APIRequestParameters model)
        //{
        //    if (string.IsNullOrEmpty(this.GSTINToken) || string.IsNullOrEmpty(this.GSTINSek))
        //    {
        //        //return new ResponseModel1
        //        //{
        //        //    isSuccess = false,
        //        //    message = "Please send 'GSTIN-Token' or 'GSTIN-Sek' in headers"
        //        //};
        //    }
        //    GSTNAuthClient client = new GSTNAuthClient(gstin, this.gstinUsername, this.appKey)
        //    {
        //        AuthToken = this.GSTINToken,
        //        DecryptedKey = EncryptionUtils.AesDecrypt(this.GSTINSek, this.appKey)

        //    };
        //    GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, model.ret_period, Constants.GSTR1_V4_RETURN_URL);
        //    var info = await client2.GetGSTR1Summary1(model);
        //    return info.Data;

        //    //return new ResponseModel1
        //    //{
        //    //    dataR = info.Data

        //    //    //isSuccess = true,
        //    //    //message = "success"
        //    //};
        //}



        ///// <summary>
        ///// NewProceedToFile
        ///// </summary>
        ///// <param name="ret_prd"></param>
        ///// <returns></returns>
        //[HttpPost("NewProceedToFile")]
        //public async Task<ResponseModel> NewProceedToFile([FromBody] GenerateRequestInfo model)
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
        //    GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, model.ret_period, Constants.GSTR1_NewProceedToFile_URL);
        //    var info = await client2.NewProceedToFile_GSTR1(model);
        //    return new ResponseModel
        //    {
        //        data = info,
        //        isSuccess = true,
        //        message = "success"
        //    };
        //}

        ///// <summary>
        ///// ProceedToFile
        ///// </summary>
        ///// <param name="ret_prd"></param>
        ///// <returns></returns>
        //[HttpPost("ProceedToFile")]
        //public async Task<ResponseModel> ProceedToFile([FromBody] GenerateRequestInfo1 model)
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
        //    GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, model.ret_period, Constants.CommoonAPIProceedToFile_URL);
        //    var info = await client2.ProceedToFile(model);
        //    return new ResponseModel
        //    {
        //        data = info,
        //        isSuccess = true,
        //        message = "success"
        //    };
        //}


        ///// <summary>
        ///// Generate Summary
        ///// </summary>
        ///// <param name="ret_prd"></param>
        ///// <returns></returns>
        //[HttpPost("GenerateSummary")]
        //public async Task<ResponseModel> GenerateSummary()
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
        //    GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, "", Constants.CommomAPISavePreference_URL + "/gstr1");
        //    var info = await client2.GenerateSummary();
        //    return new ResponseModel
        //    {
        //        data = info,
        //        isSuccess = true,
        //        message = "success"
        //    };
        //}
        ////Garima 19 March 2024

        //[HttpPost("ResetGSTR1")]
        //public async Task<ResponseModel> ResetGSTR1([FromBody] GenerateRequestInfo model)
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
        //    GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, model.ret_period, Constants.GSTR1_V4_RETURN_URL);
        //    var info = await client2.Reset_GSTR1(model);
        //    return new ResponseModel
        //    {
        //        data = info,
        //        isSuccess = true,
        //        message = "success"
        //    };
        //}

        //[HttpGet("GetValidateHSNSummary")]
        //public async Task<ResponseModel> GetValidateHSNSummary([FromQuery] APIRequestParameters model)
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
        //    GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, model.ret_period, Constants.GSTR1_V4_RETURN_URL);
        //    var info = await client2.GetValidateHSNSummary(model);
        //    return new ResponseModel
        //    {
        //        data = info,

        //        isSuccess = true,
        //        message = "success"
        //    };
        //}

        //[HttpGet("GetSUPECO")]
        //public async Task<ResponseModel> GetSUPECO([FromQuery] APIRequestParameters model)
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
        //    GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, model.ret_period, Constants.GSTR1_V4_RETURN_URL);
        //    var info = await client2.GetSUPECO(model);
        //    return new ResponseModel
        //    {
        //        data = info,

        //        isSuccess = true,
        //        message = "success"
        //    };
        //}

        //[HttpGet("GetSUPECOA")]
        //public async Task<ResponseModel> GetSUPECOA([FromQuery] APIRequestParameters model)
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
        //    GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, model.ret_period, Constants.GSTR1_V4_RETURN_URL);
        //    var info = await client2.GetSUPECOA(model);
        //    return new ResponseModel
        //    {
        //        data = info,

        //        isSuccess = true,
        //        message = "success"
        //    };
        //}

        //[HttpGet("GetHSNDetails")]
        //public async Task<ResponseModel> GetHSNDetails([FromQuery] APIRequestParameters model)
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
        //    GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, model.ret_period, Constants.GSTR1_V4_RETURN_URL);
        //    var info = await client2.GetHSNDtl(model);
        //    return new ResponseModel
        //    {
        //        data = info,

        //        isSuccess = true,
        //        message = "success"
        //    };
        //}

        //[HttpGet("GetEcomA")]
        //public async Task<ResponseModel> GetEcomA([FromQuery] APIRequestParameters model)
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
        //    GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, model.ret_period, Constants.GSTR1_V4_RETURN_URL);
        //    var info = await client2.GetECOMA(model);
        //    return new ResponseModel
        //    {
        //        data = info,

        //        isSuccess = true,
        //        message = "success"
        //    };
        //}

        //[HttpGet("GetEinvoice")]
        //public async Task<ResponseModel> GetEinvoice([FromQuery] APIRequestParameters model)
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
        //    GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, model.ret_period, Constants.GSTR1_Einvoice);
        //    var info = await client2.GetEinvoice(model);
        //    return new ResponseModel
        //    {
        //        data = info,

        //        isSuccess = true,
        //        message = "success"
        //    };
        //}

        //[HttpGet("GetTXP")]
        //public async Task<ResponseModel> GetTXP([FromQuery] APIRequestParameters model)
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
        //    GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, model.ret_period, Constants.GSTR1_V4_RETURN_URL);
        //    var info = await client2.GetTXP(model);
        //    return new ResponseModel
        //    {
        //        data = info,

        //        isSuccess = true,
        //        message = "success"
        //    };
        //}

        //[HttpGet("GetTXPA")]
        //public async Task<ResponseModel> GetTXPA([FromQuery] APIRequestParameters model)
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
        //    GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, model.ret_period, Constants.GSTR1_V4_RETURN_URL);
        //    var info = await client2.GetTXPA(model);
        //    return new ResponseModel
        //    {
        //        data = info,

        //        isSuccess = true,
        //        message = "success"
        //    };
        //}

    }
}

