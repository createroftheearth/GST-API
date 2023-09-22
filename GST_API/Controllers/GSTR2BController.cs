using GST_API.APIModels;
using GST_API.Services;
using GST_API_Library.Models.GSTR2B;
using GST_API_Library.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace GST_API.Controllers
{
    [Route("api/gstr2b")]
    [ApiController]
    [Authorize]
    public class GSTR2BController : BaseController
    {
        private readonly ILogger<AuthenticationController> _logger;
        public GSTR2BController(ILogger<AuthenticationController> logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// This API will be used to fetch the GSTR2B details for given GSTIN, Return Period
        /// </summary>
        /// <param name="">gstin={}, ret_period={}, file_num={}</param>
        [HttpGet("GetGSTR2BDetails")]
        public async Task<ResponseModel> GetGSTR2BDetails([FromQuery] APIRequestParameters model)
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
                GSTR2BApiClient client2 = new GSTR2BApiClient(client, gstin, model.ret_period, Constants.GSTR2B_Get2BDetails_URL);
                var info = await client2.GetGSTR2B(model);
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
