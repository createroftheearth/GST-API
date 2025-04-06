using GST_API.APIModels;
using GST_API.Services;
using GST_API_Library.Models;
using GST_API_Library.Models.CommonAPI;
//using GST_API_Library.Models.GSTR1;
using GST_API_Library.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace GST_API.Controllers
{
    [Route("api/common")]
    [ApiController]
    [Authorize(Roles = "APIUser")]
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

        [HttpPost("SavePreference")]
        public async Task<ResponseModel> SavePreference([FromBody] SavePrefernceRequest data)
        {
            GSTNAuthClient client = new GSTNAuthClient(gstin, this.gstinUsername, appKey)
            {
                AuthToken = this.GSTINToken,
                DecryptedKey = EncryptionUtils.AesDecrypt(this.GSTINSek, appKey)
            };
            CommonApiClient client2 = new CommonApiClient(client, data.gstin, "052017", Constants.CommomAPISavePreference_URL);
            //GSTNReturnsClient client2 = new GSTNReturnsClient(client, data.gstin, "", Constants.CommomAPISavePreference_URL);

            var info = await client2.SavePreference1(data);
            return new ResponseModel
            {
                data = info,
                isSuccess = true,
                message = "success"
            };
        }

        [HttpPost("SaveUserMaster")]
        public async Task<ResponseModel> SaveUserMaster([FromBody] SaveUserMastersRequest model)
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
                CommonApiClient client2 = new CommonApiClient(client, gstin, "", Constants.CommonAPISaveUserMaster_URL);
                var info = await client2.SaveUserMaster_Common(model);
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

        [HttpGet("GetSignedPDF")]
        public async Task<ResponseModel> GetSignedPDF([FromQuery] APIRequestParameters model)
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
                CommonApiClient client2 = new CommonApiClient(client, gstin, model.ret_period, Constants.CommomAPISignedPDF_URL);
                var info = await client2.GetSignedPDF(model);
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

        [HttpPost("UploadDocument")]
        public async Task<ResponseModel> UploadDocument([FromBody] UploadDocumentRequest model)
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
                CommonApiClient client2 = new CommonApiClient(client, gstin, "082017", Constants.CommomAPIUploadDoc_URL);
                var info = await client2.UploadDocument_Common(model);
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

        [HttpPost("CreateNotification")]
        public async Task<ResponseModel> CreateNotification([FromBody] GetATGSTR1AResp model)
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
                CommonApiClient client2 = new CommonApiClient(client, gstin, "052017", Constants.CommomAPINoti_URL);
                var info = await client2.CreateNotification_Common(model);
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


        [HttpPost("DeleteNotificationByIDs")]
        public async Task<ResponseModel> DeleteNotiByIDs([FromBody] DeleteNotiByIDsRequest model)
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
                CommonApiClient client2 = new CommonApiClient(client, gstin, "052017", Constants.CommomAPINoti_URL);
                    var info = await client2.DeleteNotiByIDs_Common(model);
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

        [HttpGet("GetAdditionalLateFeeBreakup")]
        public async Task<ResponseModel> GetAddLtFeeBrk([FromQuery] APIRequestParameters model)
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
                CommonApiClient client2 = new CommonApiClient(client, gstin, model.ret_period, Constants.CommoonAPIAddLtFeeBrk_URL);
                var info = await client2.GetAddLtFeeBrk(model);
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

        [HttpGet("GetFileDetails")]
        public async Task<ResponseModel> GetFileDetails ([FromQuery] APIRequestParameters model)
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
                CommonApiClient client2 = new CommonApiClient(client, gstin, model.ret_period, Constants.CommoonAPIAddLtFeeBrk_URL);
                var info = await client2.GetFileDetails(model);
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




        ///// <summary>
        ///// ProceedToFile
        ///// </summary>
        ///// <param name="ret_prd"></param>
        ///// <returns></returns>
        //[HttpPost("ProceedToFile")]
        //public async Task<ResponseModel> ProceedToFile([FromBody] GenerateRequestInfo model)
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
        //    CommonApiClient client2 = new CommonApiClient(client, gstin, model.ret_period, Constants.CommoonAPIProceedToFile_URL);
        //    var info = await client2.ProceedToFile(model);
        //    return new ResponseModel
        //    {
        //        data = info,
        //        isSuccess = true,
        //        message = "success"
        //    };
        //}

    }
}
