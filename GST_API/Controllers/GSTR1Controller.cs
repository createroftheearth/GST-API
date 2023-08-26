using GST_API.APIModels;
using GST_API.Services;
using GST_API_Library.Models.GSTR1;
using GST_API_Library.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel;

namespace GST_API.Controllers
{
    [Route("api/gstr1")]
    [ApiController]
    [Authorize]
    public class GSTR1Controller : BaseController
    {
        private readonly ILogger<AuthenticationController> _logger;
        public GSTR1Controller(ILogger<AuthenticationController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// To save entire GSTR1 invoices.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPut("save")]
        public async Task<ResponseModel> save([FromBody] GSTR1Total data)
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

        [HttpGet("{ret_period}/{action_required}/GetB2BInvoices")]
        public async Task<ResponseModel> GetB2BInvoices(string action_required, string ret_period)
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
            GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, ret_period, Constants.GSTR1_GetB2B_URL);
            var info = await client2.GetB2B(action_required);
            return new ResponseModel
            {
                data = info,

                isSuccess = true,
                message = "success"
            };
        }

        [HttpGet("{ret_period}/{action_required}/GetB2BAInvoices")]
        public async Task<ResponseModel> GetB2BAInvoices(string action_required, string ret_period)
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
            GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, ret_period, Constants.GSTR1_GetB2B_URL);
            var info = await client2.GetB2BA(action_required);
            return new ResponseModel
            {
                data = info,

                isSuccess = true,
                message = "success"
            };
        }

        [HttpGet("{ret_prd}/{state_cd}/GetB2CLInvoices")]
        public async Task<ResponseModel> GetB2CLInvoices(string state_cd, string ret_prd)
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
            GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, ret_prd, Constants.GSTR1_GetB2B_URL);
            var info = await client2.GetB2CL(state_cd);
            return new ResponseModel
            {
                data = info,

                isSuccess = true,
                message = "success"
            };
        }

        [HttpGet("{ret_prd}/{state_cd}/GetB2CLAInvoices")]
        public async Task<ResponseModel> GetB2CLAInvoices(string state_cd, string ret_prd)
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
            GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, ret_prd, Constants.GSTR1_GetB2B_URL);
            var info = await client2.GetB2CLA(state_cd);
            return new ResponseModel
            {
                data = info,

                isSuccess = true,
                message = "success"
            };
        }

        [HttpGet("{ret_prd}/{state_cd}/GetB2CSInvoices")]
        public async Task<ResponseModel> GetB2CSInvoices(string state_cd, string ret_prd)
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
            GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, ret_prd, Constants.GSTR1_GetB2B_URL);
            var info = await client2.GetB2Cs(state_cd);
            return new ResponseModel
            {
                data = info,

                isSuccess = true,
                message = "success"
            };
        }
        [HttpGet("{ret_prd}/{state_cd}/GetB2CsAInvoices")]
        public async Task<ResponseModel> GetB2CsAInvoices(string state_cd, string ret_prd)
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
            GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, ret_prd, Constants.GSTR1_GetB2B_URL);
            var info = await client2.GetB2CsA(state_cd);
            return new ResponseModel
            {
                data = info,

                isSuccess = true,
                message = "success"
            };
        }

        [HttpGet("{ret_prd}/{action_required}/GetCDNRInvoices")]
        public async Task<ResponseModel> GetCDNRInvoices(string action_required, string ret_prd)
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
            GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, ret_prd, Constants.GSTR1_GetB2B_URL);
            var info = await client2.GetCDN(action_required);
            return new ResponseModel
            {
                data = info,

                isSuccess = true,
                message = "success"
            };
        }
        
        [HttpGet("{ret_prd}/{action_required}/GetCDNRAInvoices")]
        public async Task<ResponseModel> GetCDNRAInvoices(string action_required, string ret_prd)
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
            GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, ret_prd, Constants.GSTR1_GetB2B_URL);
            var info = await client2.GetCDNA(action_required);
            return new ResponseModel
            {
                data = info,

                isSuccess = true,
                message = "success"
            };
        }

        [HttpGet("{ret_prd}/GetNilRatedInvoices")]
        public async Task<ResponseModel> GetNilRatedInvoices(string ret_prd)
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
            GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, ret_prd, Constants.GSTR1_GetB2B_URL);
            var info = await client2.GetNilRated(ret_prd);
            return new ResponseModel
            {
                data = info,

                isSuccess = true,
                message = "success"
            };
        }

        [HttpGet("{ret_prd}/GetExpInvoices")]
        public async Task<ResponseModel> GetExpInvoices(string ret_prd)
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
            GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, ret_prd, Constants.GSTR1_GetB2B_URL);
            var info = await client2.GetExp(ret_prd);
            return new ResponseModel
            {
                data = info,

                isSuccess = true,
                message = "success"
            };
        }

        [HttpGet("{ret_prd}/GetExpAInvoices")]
        public async Task<ResponseModel> GetExpAInvoices(string ret_prd)
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
            GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, ret_prd, Constants.GSTR1_GetB2B_URL);
            var info = await client2.GetExpA(ret_prd);
            return new ResponseModel
            {
                data = info,

                isSuccess = true,
                message = "success"
            };
        }

        [HttpGet("{ret_prd}/GetATInvoices")]
        public async Task<ResponseModel> GetATInvoices(string ret_prd)
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
            GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, ret_prd, Constants.GSTR1_GetB2B_URL);
            var info = await client2.GetAT(ret_prd);
            return new ResponseModel
            {
                data = info,

                isSuccess = true,
                message = "success"
            };
        }

        [HttpGet("{ret_prd}/GetATAInvoices")]
        public async Task<ResponseModel> GetATAInvoices(string ret_prd)
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
            GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, ret_prd, Constants.GSTR1_GetB2B_URL);
            var info = await client2.GetATA(ret_prd);
            return new ResponseModel
            {
                data = info,

                isSuccess = true,
                message = "success"
            };
        }

        [HttpGet("{ret_prd}/GetTXPDInvoices")]
        public async Task<ResponseModel> GetTXPDInvoices(string ret_prd)
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
            GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, ret_prd, Constants.GSTR1_GetB2B_URL);
            var info = await client2.GetTXPD(ret_prd);
            return new ResponseModel
            {
                data = info,

                isSuccess = true,
                message = "success"
            };
        }

        [HttpGet("{ret_prd}/GetEcomInvoices")]
        public async Task<ResponseModel> GetEcomInvoices(string ret_prd)
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
            GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, ret_prd, Constants.GSTR1_GetB2B_URL);
            var info = await client2.GetECOM(ret_prd);
            return new ResponseModel
            {
                data = info,

                isSuccess = true,
                message = "success"
            };
        }

        [HttpGet("{ret_prd}/GetSummary")]
        public async Task<ResponseModel> GetGSTR1Summary(string ret_prd)
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
            GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, ret_prd, Constants.GSTR1_GetB2B_URL);
            var info = await client2.GetGSTR1Summary(ret_prd);
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
        [HttpPost("{ret_prd}/NewProceedToFile")]
        public async Task<ResponseModel> NewProceedToFile(string ret_prd)
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
            GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, ret_prd, Constants.GSTR1_NewProceedToFile_URL);
            var info = await client2.NewProceedToFile_GSTR1(ret_prd);
            return new ResponseModel
            {
                data = info,

                isSuccess = true,
                message = "success"
            };
        }

    }
}

