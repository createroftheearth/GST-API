using GST_API.APIModels;
using GST_API.Services;
using GST_API_DAL.Models;
using GST_API_Library.Models;
using GST_API_Library.Models.GSTR1;
using GST_API_Library.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GST_API.Controllers
{
    [Route("api/gstr1")]
    [ApiController]
    [Authorize(Roles = "APIUser")]
    public class GSTR1Controller : BaseController
    {
        private readonly ILogger<AuthenticationController> _logger;
        private readonly UserManager<User> _userManager;

        public GSTR1Controller(ILogger<AuthenticationController> logger, UserManager<User> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        /// <summary>
        /// To save entire GSTR1 invoices.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPut("save")]
        public async Task<ResponseModel> save([FromBody]GSTR1Total data)
        {
            GSTNAuthClient client = new GSTNAuthClient(gstin, this.gstinUsername, appKey)
            {
                AuthToken = this.GSTINToken,
                DecryptedKey = EncryptionUtils.AesDecrypt(this.GSTINSek, appKey)
            };
            GSTR1ApiClient client2 = new GSTR1ApiClient(client, data.gstin, data.fp, Constants.GSTR1_SAVE_URL);
            var info = await client2.Save(data);
            return new ResponseModel
            {
                data = info,
                isSuccess = true,
                message = "success"
            };
        }

        [HttpPut("{otp}/file")]
        public async Task<ResponseModel> file([FromBody] SummaryOutward data, string otp)
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
            var info = await client2.file(data, otp, PAN);
            return new ResponseModel
            {
                data = info,
                isSuccess = true,
                message = "success"
            };
        }


        [HttpGet("{ret_prd}/{reference_id}/ReturnStatus")]
        public async Task<ResponseModel> ReturnStatus(string ret_prd, string reference_id)
        {
            if (string.IsNullOrEmpty(this.GSTINToken) || string.IsNullOrEmpty(this.GSTINSek))
            {
                return new ResponseModel
                {
                    isSuccess = false,
                    message = "Please send 'GSTIN-Token' or 'GSTIN-Sek' in headers"
                };
            }
            GSTNAuthClient client = new GSTNAuthClient(gstin, this.gstinUsername, appKey)
            {
                AuthToken = this.GSTINToken,
                DecryptedKey = EncryptionUtils.AesDecrypt(this.GSTINSek, appKey)
            };
            GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, ret_prd, Constants.GSTR1_ReturnStatus_URL);
            var info = await client2.GetStatus(ret_prd, reference_id);
            return new ResponseModel
            {
                data = info,
                isSuccess = true,
                message = "success"
            };
        }

        [HttpGet("GetB2BInvoices")]
        public async Task<ResponseModel> GetB2BInvoices([FromQuery] APIRequestParameters model)
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
                GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, model.ret_period, Constants.GSTR1_V4_RETURN_URL);
                var info = await client2.GetB2B(model);
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

        [HttpGet("GetB2BAInvoices")]
        public async Task<ResponseModel> GetB2BAInvoices([FromQuery] APIRequestParameters model)
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
            GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, model.ret_period, Constants.GSTR1_V4_RETURN_URL);
            var info = await client2.GetB2BA(model);
            return new ResponseModel
            {
                data = info,

                isSuccess = true,
                message = "success"
            };
        }

        [HttpGet("GetB2CLInvoices")]
        public async Task<ResponseModel> GetB2CLInvoices([FromQuery] APIRequestParameters model)
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
            GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, model.ret_period, Constants.GSTR1_V4_RETURN_URL);
            var info = await client2.GetB2CL(model);
            return new ResponseModel
            {
                data = info,

                isSuccess = true,
                message = "success"
            };
        }

        [HttpGet("GetB2CLAInvoices")]
        public async Task<ResponseModel> GetB2CLAInvoices([FromQuery] APIRequestParameters model)
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
            GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, model.ret_period, Constants.GSTR1_V4_RETURN_URL);
            var info = await client2.GetB2CLA(model);
            return new ResponseModel
            {
                data = info,

                isSuccess = true,
                message = "success"
            };
        }

        [HttpGet("GetB2CSInvoices")]
        public async Task<ResponseModel> GetB2CSInvoices([FromQuery] APIRequestParameters model)
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
            GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, model.ret_period, Constants.GSTR1_V4_RETURN_URL);
            var info = await client2.GetB2Cs(model);
            return new ResponseModel
            {
                data = info,

                isSuccess = true,
                message = "success"
            };
        }
        [HttpGet("GetB2CsAInvoices")]
        public async Task<ResponseModel> GetB2CsAInvoices([FromQuery] APIRequestParameters model)
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
            GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, model.ret_period, Constants.GSTR1_V4_RETURN_URL);
            var info = await client2.GetB2CsA(model);
            return new ResponseModel
            {
                data = info,

                isSuccess = true,
                message = "success"
            };
        }

        [HttpGet("GetCDNRInvoices")]
        public async Task<ResponseModel> GetCDNRInvoices([FromQuery] APIRequestParameters model)
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
            GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, model.ret_period, Constants.GSTR1_V4_RETURN_URL);
            var info = await client2.GetCDNR(model);
            return new ResponseModel
            {
                data = info,

                isSuccess = true,
                message = "success"
            };
        }

        [HttpGet("GetCDNRAInvoices")]
        public async Task<ResponseModel> GetCDNRAInvoices([FromQuery] APIRequestParameters model)
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
            GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, model.ret_period, Constants.GSTR1_V4_RETURN_URL);
            var info = await client2.GetCDNA(model);
            return new ResponseModel
            {
                data = info,

                isSuccess = true,
                message = "success"
            };
        }

        //
        [HttpGet("GetCDNURInvoices")]
        public async Task<ResponseModel> GetCDNURInvoices([FromQuery] APIRequestParameters model)
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
            GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, model.ret_period, Constants.GSTR1_V4_RETURN_URL);
            var info = await client2.GetCDNUR(model);
            return new ResponseModel
            {
                data = info,

                isSuccess = true,
                message = "success"
            };
        }

        [HttpGet("GetCDNURAInvoices")]
        public async Task<ResponseModel> GetCDNURAInvoices([FromQuery] APIRequestParameters model)
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
            GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, model.ret_period, Constants.GSTR1_V4_RETURN_URL);
            var info = await client2.GetCDNURA(model);
            return new ResponseModel
            {
                data = info,

                isSuccess = true,
                message = "success"
            };
        }


        [HttpGet("GetNilRatedInvoices")]
        public async Task<ResponseModel> GetNilRatedInvoices([FromQuery] APIRequestParameters model)
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
            GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, model.ret_period, Constants.GSTR1_V4_RETURN_URL);
            var info = await client2.GetNilRated(model);
            return new ResponseModel
            {
                data = info,

                isSuccess = true,
                message = "success"
            };
        }

        [HttpGet("GetExpInvoices")]
        public async Task<ResponseModel> GetExpInvoices([FromQuery] APIRequestParameters model)
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
            GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, model.ret_period, Constants.GSTR1_V4_RETURN_URL);
            var info = await client2.GetExp(model);
            return new ResponseModel
            {
                data = info,

                isSuccess = true,
                message = "success"
            };
        }

        [HttpGet("GetExpAInvoices")]
        public async Task<ResponseModel> GetExpAInvoices([FromQuery] APIRequestParameters model)
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
            GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, model.ret_period, Constants.GSTR1_V4_RETURN_URL);
            var info = await client2.GetExpA(model);
            return new ResponseModel
            {
                data = info,

                isSuccess = true,
                message = "success"
            };
        }

        [HttpGet("GetATInvoices")]
        public async Task<ResponseModel> GetATInvoices([FromQuery] APIRequestParameters model)
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
            GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, model.ret_period, Constants.GSTR1_V4_RETURN_URL);
            var info = await client2.GetAT(model);
            return new ResponseModel
            {
                data = info,

                isSuccess = true,
                message = "success"
            };
        }

        [HttpGet("GetATAInvoices")]
        public async Task<ResponseModel> GetATAInvoices([FromQuery] APIRequestParameters model)
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
            GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, model.ret_period, Constants.GSTR1_V4_RETURN_URL);
            var info = await client2.GetATA(model);
            return new ResponseModel
            {
                data = info,

                isSuccess = true,
                message = "success"
            };
        }

        [HttpGet("GetDocIssued")]
        public async Task<ResponseModel> GetDocIssued([FromQuery] APIRequestParameters model)
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
            GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, model.ret_period, Constants.GSTR1_V4_RETURN_URL);
            var info = await client2.GetDocIssued(model);
            return new ResponseModel
            {
                data = info,

                isSuccess = true,
                message = "success"
            };
        }

        //Pending
        //[HttpGet("{ret_prd}/GetTXPDInvoices")]
        //public async Task<ResponseModel> GetTXPDInvoices(string ret_prd)
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
        //    GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, ret_prd, Constants.GSTR1_V4_RETURN_URL);
        //    var info = await client2.GetTXPD(ret_prd);
        //    return new ResponseModel
        //    {
        //        data = info,

        //        isSuccess = true,
        //        message = "success"
        //    };
        //}

        [HttpGet("GetEcomInvoices")]
        public async Task<ResponseModel> GetEcomInvoices([FromQuery] APIRequestParameters model)
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
            GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, model.ret_period, Constants.GSTR1_V4_RETURN_URL);
            var info = await client2.GetECOM(model);
            return new ResponseModel
            {
                data = info,

                isSuccess = true,
                message = "success"
            };
        }

        [HttpGet("GetSummary")]
        public async Task<ResponseModel> GetGSTR1Summary([FromQuery] APIRequestParameters model)
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
            GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, model.ret_period, Constants.GSTR1_V4_RETURN_URL);
            var info = await client2.GetGSTR1Summary1(model);
            return new ResponseModel
            {
                data = info,
                isSuccess = true,
                message = "success"
            };
        }



        /// <summary>
        /// NewProceedToFile
        /// </summary>
        /// <param name="ret_prd"></param>
        /// <returns></returns>
        [HttpPost("NewProceedToFile")]
        public async Task<ResponseModel> NewProceedToFile([FromBody] GenerateRequestInfo model)
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
            GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, model.ret_period, Constants.GSTR1_NewProceedToFile_URL);
            var info = await client2.NewProceedToFile_GSTR1(model);
            return new ResponseModel
            {
                data = info,
                isSuccess = true,
                message = "success"
            };
        }
        /// <summary>
        /// Generate Summary
        /// </summary>
        /// <param name="ret_prd"></param>
        /// <returns></returns>
        [HttpPost("GenerateSummary")]
        public async Task<ResponseModel> GenerateSummary()
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
            GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, "", Constants.CommomAPISavePreference_URL + "/gstr1");
            var info = await client2.GenerateSummary();
            return new ResponseModel
            {
                data = info,
                isSuccess = true,
                message = "success"
            };
        }
        //Garima 19 March 2024

        [HttpPost("ResetGSTR1")]
        public async Task<ResponseModel> ResetGSTR1([FromBody] GenerateRequestInfo model)
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
            GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, model.ret_period, Constants.GSTR1_V4_RETURN_URL);
            var info = await client2.Reset_GSTR1(model);
            return new ResponseModel
            {
                data = info,
                isSuccess = true,
                message = "success"
            };
        }

        [HttpGet("GetValidateHSNSummary")]
        public async Task<ResponseModel> GetValidateHSNSummary([FromQuery] APIRequestParameters model)
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
            GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, model.ret_period, Constants.GSTR1_V4_RETURN_URL);
            var info = await client2.GetValidateHSNSummary(model);
            return new ResponseModel
            {
                data = info,

                isSuccess = true,
                message = "success"
            };
        }

        [HttpGet("GetSUPECO")]
        public async Task<ResponseModel> GetSUPECO([FromQuery] APIRequestParameters model)
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
            GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, model.ret_period, Constants.GSTR1_V4_RETURN_URL);
            var info = await client2.GetSUPECO(model);
            return new ResponseModel
            {
                data = info,

                isSuccess = true,
                message = "success"
            };
        }

        [HttpGet("GetSUPECOA")]
        public async Task<ResponseModel> GetSUPECOA([FromQuery] APIRequestParameters model)
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
            GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, model.ret_period, Constants.GSTR1_V4_RETURN_URL);
            var info = await client2.GetSUPECOA(model);
            return new ResponseModel
            {
                data = info,

                isSuccess = true,
                message = "success"
            };
        }

        [HttpGet("GetHSNDetails")]
        public async Task<ResponseModel> GetHSNDetails([FromQuery] APIRequestParameters model)
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
            GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, model.ret_period, Constants.GSTR1_V4_RETURN_URL);
            var info = await client2.GetHSNDtl(model);
            return new ResponseModel
            {
                data = info,

                isSuccess = true,
                message = "success"
            };
        }

        [HttpGet("GetEcomA")]
        public async Task<ResponseModel> GetEcomA([FromQuery] APIRequestParameters model)
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
            GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, model.ret_period, Constants.GSTR1_V4_RETURN_URL);
            var info = await client2.GetECOMA(model);
            return new ResponseModel
            {
                data = info,

                isSuccess = true,
                message = "success"
            };
        }

        [HttpGet("GetEinvoice")]
        public async Task<ResponseModel> GetEinvoice([FromQuery] APIRequestParameters model)
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
            GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, model.ret_period, Constants.GSTR1_Einvoice);
            var info = await client2.GetEinvoice(model);
            return new ResponseModel
            {
                data = info,

                isSuccess = true,
                message = "success"
            };
        }

        [HttpGet("GetTXP")]
        public async Task<ResponseModel> GetTXP([FromQuery] APIRequestParameters model)
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
            GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, model.ret_period, Constants.GSTR1_V4_RETURN_URL);
            var info = await client2.GetTXP(model);
            return new ResponseModel
            {
                data = info,

                isSuccess = true,
                message = "success"
            };
        }

        [HttpGet("GetTXPA")]
        public async Task<ResponseModel> GetTXPA([FromQuery] APIRequestParameters model)
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
            GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, model.ret_period, Constants.GSTR1_V4_RETURN_URL);
            var info = await client2.GetTXPA(model);
            return new ResponseModel
            {
                data = info,

                isSuccess = true,
                message = "success"
            };
        }

    }
}

