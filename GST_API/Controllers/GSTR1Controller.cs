using GST_API.APIModels;
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

        [HttpPut("save")]
        public async Task<ResponseModel> save([FromBody] GSTR1Total data)
        {
            GSTNAuthClient client = new GSTNAuthClient(gstin, this.gstinUsername, appKey)
            { 
                AuthToken = this.GSTINToken,
                DecryptedKey = EncryptionUtils.AesDecrypt(this.GSTINSek, appKey)
            };
            GSTR1ApiClient client2 = new GSTR1ApiClient(client, data.gstin, data.fp);
            var info = await client2.Save(data);
            return new ResponseModel
            {
                data = info,
                isSuccess = true,
                message = "success"
            };
        }

        [HttpPost("{fp}/ProceeToFile")]
        public async Task<ResponseModel> ProceeToFile(string fp)
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
            GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, fp);
            var info = await client2.NewProceedtoFile(fp);
            _logger.LogInformation(JsonConvert.SerializeObject(info));
            return new ResponseModel
            {
                data = info,
                isSuccess = true,
                message = "success"
            };
        }



        //[HttpGet("GetReturnStatus")]
        //public async Task<ResponseModel> GetReturnStatus(string ret_prd, string reference_id)
        //{
        //    if (string.IsNullOrEmpty(this.GSTINToken) || string.IsNullOrEmpty(this.GSTINSek))
        //    {
        //        return new ResponseModel
        //        {
        //            isSuccess = false,
        //            message = "Please send 'GSTIN-Token' or 'GSTIN-Sek' in headers"
        //        };
        //    }
        //    GSTNAuthClient client = new GSTNAuthClient(gstin, this.gstinUsername)
        //    {
        //        AuthToken = this.GSTINToken,
        //        DecryptedKey = EncryptionUtils.AesDecrypt(this.GSTINSek, GSTNConstants.GetAppKeyBytes())
        //    };

        //}

    }
}
