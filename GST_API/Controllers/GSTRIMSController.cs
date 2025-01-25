using GST_API.APIModels;
using GST_API.Services;
using GST_API_Library.Models;
using GST_API_Library.Models.GSTRIMS;
using GST_API_Library.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace GST_API.Controllers
{
    [Route("api/gstrims")]
    [ApiController]
    [Authorize(Roles = "APIUser")]
    public class GSTRIMSController : BaseController
    {
        private readonly ILogger<AuthenticationController> _logger;
        public GSTRIMSController(ILogger<AuthenticationController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetInvoiceCount")]
        public async Task<ResponseModel> GetInvoiceCount([FromQuery] APIRequestParameters model)
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
                GSTRIMSApiClient client2 = new GSTRIMSApiClient(client, gstin, model.ret_period, Constants.GSTRIMS_InvoiceCount_URL);
                var info = await client2.GetIMSInvoiceCount(model);
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

        [HttpGet("GetFileDetail")]
        public async Task<ResponseModel> GetFileDetail([FromQuery] APIRequestParameters model)
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
                GSTRIMSApiClient client2 = new GSTRIMSApiClient(client, gstin, model.ret_period, Constants.GSTRIMS_InvoiceCount_URL);
                var info = await client2.GetIMSInvoiceCount(model);
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

        //[HttpPost("ResetGSTRIMS")]
        //public async Task<ResponseModel> ResetGSTRIMS([FromBody] ResetRequest model)
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
        //    GSTRIMSApiClient client2 = new GSTRIMSApiClient(client, gstin, "", Constants.GSTRIMS_Reset_URL);
        //    var info = await client2.Reset_GSTRIMS(model);
        //    return new ResponseModel
        //    {
        //        data = info,
        //        isSuccess = true,
        //        message = "success"
        //    };
        //}

    }
}
