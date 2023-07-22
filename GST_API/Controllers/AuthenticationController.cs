using GST_API.APIModels;
using GST_API.Services;
using GST_API_DAL.Models;
using GST_API_Library.Models;
using GST_API_Library.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GST_API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    [Authorize]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILogger<AuthenticationController> _logger;
        private readonly UserManager<User> _userManager;
        private readonly TokenService _tokenService;
        private readonly IConfiguration _configuration;
        private readonly string basePath;
        public AuthenticationController(ILogger<AuthenticationController> logger,
            UserManager<User> userManager,
            IConfiguration configuration,
            TokenService tokenService)
        {
            _logger = logger;
            _userManager = userManager;
            _tokenService = tokenService;
            _configuration = configuration;
            var baseProjectPath = _configuration.GetValue<string>(WebHostDefaults.ContentRootKey);
            if (string.IsNullOrEmpty(baseProjectPath))
            {
                basePath = "";
            }
            else
            {
                basePath = baseProjectPath.Substring(0, baseProjectPath.LastIndexOf('\\'));
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<object> Authenticate([FromBody] AuthenticateModel model)
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
            GSTNAuthClient client = new GSTNAuthClient(user.GSTNNo, user.GSTINUsername, basePath);
            var (result,appKey) = await client.RequestOTP();
            if (result.Data?.status_cd == "1" && !string.IsNullOrEmpty(appKey))
            {
                return new ResponseModel
                {
                    isSuccess = true,
                    message = "success",
                    data = new
                    {
                        token = _tokenService.CreateToken(user,appKey)
                    }
                };
            } else
            {
                return result;
            }
        }

        //[HttpPost("request-otp")]
        //public async Task<GSTNResult<OTPResponseModel>> RequestOTP()
        //{
        //    var gstnUsername = this.User.Claims.FirstOrDefault(z => z.Type == "GSTNUsername")?.Value;
        //    var gstin = this.User.Claims.FirstOrDefault(z => z.Type == "GSTN")?.Value;

        
        //    _logger.LogInformation(JsonConvert.SerializeObject(result));
        //    return result;
        //}

        [HttpPost("{otp}/request-token")]
        public async Task<GSTNResult<TokenResponseModel>> RequestToken(string otp)
        {
            var userId = this.User.Claims.FirstOrDefault(z => z.Type == "GSTNUsername")?.Value;
            var gstin = this.User.Claims.FirstOrDefault(z => z.Type == "GSTN")?.Value;
            var appKey = this.User.Claims.FirstOrDefault(z => z.Type == "AppKey")?.Value;
            GSTNAuthClient client = new GSTNAuthClient(gstin, userId, basePath);
            var result = await client.RequestToken(otp,appKey);
            _logger.LogInformation(JsonConvert.SerializeObject(result));
            return result;
        }

        [HttpPost("refresh-token")]
        public async Task<GSTNResult<TokenResponseModel>> RefreshToken()
        {
            var userId = this.User.Claims.FirstOrDefault(z => z.Type == "GSTNUsername")?.Value;
            var gstin = this.User.Claims.FirstOrDefault(z => z.Type == "GSTN")?.Value;
            GSTNAuthClient client = new GSTNAuthClient(gstin, userId, basePath);
            var result = await client.RefreshToken();
            _logger.LogInformation(JsonConvert.SerializeObject(result));
            return result;
        }

        [Authorize]
        [HttpPost("logout")]
        public async Task<GSTNResult<LogoutResponseModel>> Logout()
        {
            var userId = this.User.Claims.FirstOrDefault(z => z.Type == "GSTNUsername")?.Value;
            var gstin = this.User.Claims.FirstOrDefault(z => z.Type == "GSTN")?.Value;
            GSTNAuthClient client = new GSTNAuthClient(gstin, userId, basePath);
            var result = await client.RequestLogout();
            _logger.LogInformation(JsonConvert.SerializeObject(result));
            return result;
        }

    }
}
