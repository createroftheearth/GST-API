using GST_API_Library.Models;
using GST_API_Library.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILogger<AuthenticationController> _logger;
        public AuthenticationController(ILogger<AuthenticationController> logger)
        {
            this._logger = logger;
        }

        //[HttpGet("RequestOTP")]
        //[Route("request-otp")]
        //public async Task<GSTNResult<OTPResponseModel>> RequestOTP()
        //{
        //    GSTNAuthClient client = new GSTNAuthClient(gstin,userId);
        //    var result = await client.RequestOTP();
        //    this._logger.LogInformation(JsonConvert.SerializeObject(result));
        //    return result;
        //}

        //[HttpGet("RequestToken")]
        //[Route("request-token")]
        //public async Task<GSTNResult<TokenResponseModel>> RequestToken()
        //{
        //    GSTNAuthClient client = new GSTNAuthClient(gstin, userId);
        //    var result = await client.RequestToken(otp);
        //    this._logger.LogInformation(JsonConvert.SerializeObject(result));
        //    return result;
        //}

    }
}
