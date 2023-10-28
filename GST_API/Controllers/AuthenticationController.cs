using GST_API.APIModels;
using GST_API.Services;
using GST_API_DAL.Models;
using GST_API_Library.Models;
using GST_API_Library.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GST_API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    [Authorize(Roles ="APIUser")]
    public class AuthenticationController : BaseController
    {
        private readonly ILogger<AuthenticationController> _logger;
        private readonly UserManager<User> _userManager;
        private readonly TokenService _tokenService;
        private readonly IConfiguration _configuration;
        public AuthenticationController(ILogger<AuthenticationController> logger,
            UserManager<User> userManager,
            TokenService tokenService)
        {
            _logger = logger;
            _userManager = userManager;
            _tokenService = tokenService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<object> Authenticate([FromBody] AuthenticateModel model)
        {
            _logger.LogInformation("BasePath->>>>>"+GSTNConstants.base_path+ @"\GST_API\Resource\GSTN_G2B_SANDBOX_UAT_public.cer");
            var user = await _userManager.FindByNameAsync(model.username);
            if (user == null)
            {
                return new ResponseModel
                {
                    isSuccess = false,
                    message = "Invalid username"
                };
            }
            if (!await _userManager.CheckPasswordAsync(user, model.password))
            {
                return new ResponseModel
                {
                    isSuccess = false,
                    message = "Invalid password"
                };
            }
            byte[] appKey = GSTNConstants.GetAppKeyBytes();
            GSTNAuthClient client = new GSTNAuthClient(user.GSTNNo, user.GSTINUsername,appKey);
            var result = await client.RequestOTP();
            if (result.Data?.status_cd == "1")
            {
                return new ResponseModel
                {
                    isSuccess = true,
                    message = "OTP Sent, Please use request-token API to get 'GSTIN-Token'",
                    data = new
                    {
                        token = _tokenService.CreateToken(user,Convert.ToBase64String(appKey))
                    }
                };
            } else
            {
                return result;
            }
        }


        [HttpPost("public")]
        [AllowAnonymous]
        public async Task<object> PublicAuthentication([FromBody] PublicAuthenticateModel model)
        {
            var user = await _userManager.FindByNameAsync(model.username);
            if (user == null)
            {
                return new ResponseModel
                {
                    isSuccess = false,
                    message = "Invalid username"
                };
            }
            if (!await _userManager.CheckPasswordAsync(user, model.password))
            {
                return new ResponseModel
                {
                    isSuccess = false,
                    message = "Invalid password"
                };
            }
            byte[] appKey = GSTNConstants.GetAppKeyBytes();
            GSTNPublicAuthClient client = new GSTNPublicAuthClient(appKey);
            var result = await client.RequestToken(model.gstnUsername,model.gstnPassword);
            if (result.Data?.status_cd == "1")
            {
                return new ResponseModel
                {
                    isSuccess = true,
                    message = "OTP Sent, Please use request-token API to get 'GSTIN-Token'",
                    data = new
                    {
                        token = _tokenService.CreateToken(user, Convert.ToBase64String(appKey))
                    }
                };
            }
            else
            {
                return result;
            }
        }

        [HttpPost("{otp}/request-token")]
        public async Task<GSTNResult<TokenResponseModel>> RequestToken(string otp)
        {
            GSTNAuthClient client = new GSTNAuthClient(gstin, gstinUsername,appKey);
             //GSTNAuthClient client = new GSTNAuthClient(gstin, gstinUsername, GSTNConstants.GetAppKeyBytes());
            var result = await client.RequestToken(otp);
            _logger.LogInformation(JsonConvert.SerializeObject(result));
            return result;
        }

        [HttpPost("refresh-token")]
        public async Task<GSTNResult<TokenResponseModel>> RefreshToken()
        {
            GSTNAuthClient client = new GSTNAuthClient(gstin, gstinUsername,appKey);
            var result = await client.RefreshToken(GSTINToken);
            _logger.LogInformation(JsonConvert.SerializeObject(result));
            return result;
        }

        [Authorize]
        [HttpPost("logout")]
        public async Task<GSTNResult<LogoutResponseModel>> Logout()
        {
            GSTNAuthClient client = new GSTNAuthClient(gstin, gstinUsername, appKey);
            var result = await client.RequestLogout(GSTINToken);
            _logger.LogInformation(JsonConvert.SerializeObject(result));
            return result;
        }

    }
}
