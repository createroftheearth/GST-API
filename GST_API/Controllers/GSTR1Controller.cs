using GST_API.APIModels;
using GST_API.Services;
using GST_API_Library.Models;
using GST_API_Library.Models.GSTR1;
using GST_API_Library.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Asn1.Crmf;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        //Chnage by amit
        [HttpPut("save")]
        public async Task<ResponseModel> save([FromBody] GSTR1Total data)
        {
            //if (string.IsNullOrEmpty(this.GSTINToken) || string.IsNullOrEmpty(this.GSTINSek))
            //{
            //    return new ResponseModel
            //    {
            //        isSuccess = false,
            //        message = "Please send 'GSTIN-Token' or 'GSTIN-Sek' in headers"
            //    };
            //}
            GSTNAuthClient client = new GSTNAuthClient(gstin, this.gstinUsername)
            {
                AuthToken = this.GSTINToken,
                DecryptedKey = EncryptionUtils.AesDecrypt(this.GSTINSek, GSTNConstants.GetAppKeyBytes())

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
            GSTNAuthClient client = new GSTNAuthClient(gstin, this.gstinUsername)
            {
                AuthToken = this.GSTINToken,
                DecryptedKey = EncryptionUtils.AesDecrypt(this.GSTINSek, GSTNConstants.GetAppKeyBytes())

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
