using GST_API.APIModels;
using GST_API.Services;
using GST_API_Library.Models.CommonAPI;
using GST_API_Library.Services;
using Microsoft.AspNetCore.Mvc;

namespace GST_API.Controllers
{
    public class CommonAPIController : BaseController
    {
        private readonly ILogger<AuthenticationController> _logger;
        public CommonAPIController(ILogger<AuthenticationController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetAllDownloadDoc")]
        public async Task<ResponseModel> GetAllDownloadDoc([FromQuery] APIRequestParameters model)
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
                CommonApiClient client2 = new CommonApiClient(client, gstin, model.ret_period, Constants.CommomAPIDocDownload_URL);
                var info = await client2.GetAllDownloadDoc(model);
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
