﻿using GST_API.APIModels;
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
    [Authorize(Roles = "APIUser, ASPUser")]
    [ApiController]
    [Route("api/auth")]
    public class AuthenticationController : BaseController
    {
        private readonly ILogger<AuthenticationController> _logger;
        private readonly UserManager<User> _userManager;
        private readonly TokenService _tokenService;
        private readonly EncryptDecryptService _encryptDecryptService;

        private readonly IConfiguration _configuration;
        public AuthenticationController(ILogger<AuthenticationController> logger,
            UserManager<User> userManager,
            TokenService tokenService,
            EncryptDecryptService encryptDecryptService)
        {
            _logger = logger;
            _userManager = userManager;
            _tokenService = tokenService;
            _encryptDecryptService = encryptDecryptService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<object> Authenticate([FromBody] AuthenticateModel model)
        {
            _logger.LogInformation("Is Production"+EncryptionUtils.isProduction);
            var user = await _userManager.FindByNameAsync(model.username);
            if (user == null)
            {
                return new ResponseModel
                {
                    isSuccess = false,
                    message = "Invalid username"
                };
            }
            if (model.isASPUser &&
                !await _userManager.IsInRoleAsync(user, "ASPUser"))
            {
                return new ResponseModel
                {
                    isSuccess = false,
                    message = "Invalid username or password"
                };
            }
            else if(!model.isASPUser && !await _userManager.IsInRoleAsync(user, "APIUser"))
            {
                return new ResponseModel
                {
                    isSuccess = false,
                    message = "Invalid username or password"
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
                        token = _tokenService.CreateToken(user,Convert.ToBase64String(appKey),model.isASPUser?["ASPUser"]:["APIUser"]),
                        gstin = user.GSTNNo,
                        organizationName = user.OrganizationName
                    }
                };
            } else
            {
                return new ResponseModel
                {
                    isSuccess = false,
                    message = "Otp failed to generate",
                    data = result
                };
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
                var roles = await _userManager.GetRolesAsync(user);
                return new ResponseModel
                {
                    isSuccess = true,
                    message = "OTP Sent, Please use request-token API to get 'GSTIN-Token'",
                    data = new
                    {
                        token = _tokenService.CreateToken(user, Convert.ToBase64String(appKey), roles),
                        gstin = user.GSTNNo,
                        organizationName = user.OrganizationName
                    }
                };
            }
            else
            {
                return new ResponseModel
                {
                    isSuccess = false,
                    message = "Otp failed to generate",
                    data = result
                };
            }
        }

        [HttpPost("request-token")]
        public async Task<ResponseModel> RequestToken([FromQuery]string otp)
        {
            GSTNAuthClient client = new GSTNAuthClient(gstin, gstinUsername, appKey);
            var decryptedOtp = _encryptDecryptService.DecryptText(otp);
            //GSTNAuthClient client = new GSTNAuthClient(gstin, gstinUsername, GSTNConstants.GetAppKeyBytes());

            var result = await client.RequestToken(decryptedOtp);
            _logger.LogInformation(JsonConvert.SerializeObject(result)); 
            if (result.Data?.status_cd == "1")
            {
                return new ResponseModel
                {
                    isSuccess = true,
                    message = "GSTN Token generation successfully",
                    data = result
                };
            }
            else
            {
                return new ResponseModel
                {
                    isSuccess = false,
                    message = "Failed to generate token on GST",
                    data = result
                };
            }
        }

        [HttpPost("refresh-token")]
        public async Task<GSTNResult<TokenResponseModel>> RefreshToken()
        {
            GSTNAuthClient client = new GSTNAuthClient(gstin, gstinUsername,appKey);
            var result = await client.RefreshToken(GSTINToken);
            _logger.LogInformation(JsonConvert.SerializeObject(result));
            return result;
        }

        [HttpPost("logout")]
        public async Task<GSTNResult<LogoutResponseModel>> Logout()
        {
            GSTNAuthClient client = new GSTNAuthClient(gstin, gstinUsername, appKey);
            var result = await client.RequestLogout(GSTINToken);
            _logger.LogInformation(JsonConvert.SerializeObject(result));
            return result;
        }

        [HttpGet("otp-evc-request")]
        public async Task<ResponseModel> InitiateRequestOTPForEVC([FromQuery]EVCAuthenticationModel model)
        {
            if (ModelState.IsValid)
            {
                GSTNAuthClient client = new GSTNAuthClient(gstin, gstinUsername, appKey);
                var result = await client.RequestOTPForEVC(model,GSTINToken);
                _logger.LogInformation(JsonConvert.SerializeObject(result));
                return new ResponseModel
                {
                    isSuccess = true,
                    data = result,
                    message = "Success"
                };
            }
            else
            {
                return new ResponseModel
                {
                    data = null,
                    isSuccess = false,
                    message = string.Join(", ", ModelState.Values.SelectMany(v => v.Errors))
                };
            }

        }
    }
}
