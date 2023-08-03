using GST_API.APIModels;
using GST_API.Services;
using GST_API_Library.Models.GSTR1;
using GST_API_Library.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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


        /// <summary>
        /// To get the status of the Returns submitted
        /// </summary>
        /// <param name="ret_prd"></param>
        /// <param name="reference_id"></param>
        /// <returns></returns>
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
            GSTNAuthClient client = new GSTNAuthClient(gstin, this.gstinUsername,appKey)
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

        /// <summary>
        /// call for getting all B2B invoices for a return period.
        /// </summary>
        /// <param name="action_required"></param>
        /// <param name="ret_period"></param>
        /// <returns></returns>
        [HttpGet("{ret_period}/{action_required}/GetB2BInvoices")]
        public async Task<ResponseModel> GetB2BInvoices(string action_required,string ret_period)
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
            GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin,ret_period, Constants.GSTR1_GetB2B_URL);
            var info = await client2.GetB2B(action_required);
            return new ResponseModel
            {
                data = info,

                isSuccess = true,
                message = "success"
            };
        }

        /// <summary>
        /// call for getting all B2B amended invoices for a return period.
        /// </summary>
        /// <param name="action_required"></param>
        /// <param name="ret_period"></param>
        /// <returns></returns>
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

        /// <summary>
        /// call for getting all B2C Large invoices for a return period.
        /// </summary>
        /// <param name="state_cd"></param>
        /// <param name="ret_period"></param>
        /// <returns></returns>
        [HttpGet("{ret_prd}/{state_cd}/GetB2CLInvoices")]
        public async Task<ResponseModel> GetB2CLInvoices(string state_cd,string ret_prd)
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

