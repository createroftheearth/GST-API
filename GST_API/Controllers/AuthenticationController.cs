using GST_API.APIModels;
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
    [Authorize]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILogger<AuthenticationController> _logger;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        public AuthenticationController(ILogger<AuthenticationController> logger,
            UserManager<User> userManager,
            IConfiguration configuration)
        {
            _logger = logger;
            _userManager = userManager;
            _configuration = configuration;

        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ResponseModel> Authenticate([FromBody] AuthenticateModel model)
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
            var authSignInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: new Claim[]
                {
                        new Claim("Id",user.Id),
                        new Claim("GSTN",user.GSTNNo),
                        new Claim("GSTNUsername",user.GSTINUsername)
                },
                expires: DateTime.Now.AddHours(1),
                signingCredentials: new SigningCredentials(authSignInKey, SecurityAlgorithms.HmacSha256)
                );
            return new ResponseModel
            {
                isSuccess = true,
                message = "success",
                data = new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiresIn = token.ValidTo,
                }
            };
        }

        [HttpPost("request-otp")]
        public async Task<GSTNResult<OTPResponseModel>> RequestOTP()
        {
            var gstnUsername = this.User.Claims.FirstOrDefault(z => z.Type == "GSTNUsername")?.Value;
            var gstin = this.User.Claims.FirstOrDefault(z => z.Type == "GSTN")?.Value;
            GSTNAuthClient client = new GSTNAuthClient(gstin, gstnUsername);
            var result = await client.RequestOTP();
            _logger.LogInformation(JsonConvert.SerializeObject(result));
            return result;
        }

        [HttpGet("request-token")]
        public async Task<GSTNResult<TokenResponseModel>> RequestToken([FromQuery] string otp)
        {
            var userId = this.User.Claims.FirstOrDefault(z => z.Type == "GSTNUsername")?.Value;
            var gstin = this.User.Claims.FirstOrDefault(z => z.Type == "GSTN")?.Value;
            GSTNAuthClient client = new GSTNAuthClient(gstin, userId);
            var result = await client.RequestToken(otp);
            _logger.LogInformation(JsonConvert.SerializeObject(result));
            return result;
        }

    }
}
