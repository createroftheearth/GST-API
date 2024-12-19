using AutoMapper;
using GST_API.APIModels;
using GST_API_DAL.Models;
using GST_API_DAL.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GST_API.Controllers
{
    [Route("api/registration")]
    [ApiController]
    [AllowAnonymous]
    //[ApiExplorerSettings(IgnoreApi = true)]// Hide from Swagger UI
    public class RegistrationController : ControllerBase
    {

        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly ILogger<RegistrationController> _logger;

        public RegistrationController(UserManager<User> userManger, IMapper mapper, IUserRepository userRepository, ILogger<RegistrationController> logger)
        {
            _userManager = userManger;
            _mapper = mapper;
            _userRepository = userRepository;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ResponseModel> Register([FromBody] RegistrationModel model)
        {
            if (!ModelState.IsValid)
            {
                ResponseModel res = new ResponseModel
                {
                    isSuccess = false,
                    message = string.Join(",", ModelState.Values.SelectMany(z => z.Errors).Select(z => z.ErrorMessage))
                };
                return res;
            }
            User user = _mapper.Map<User>(model);
            user.CancelledChequeString = model.CancelledChequePhoto;
            user.LargeImageString = model.ProfilePicture;
            user.verificationEmailLink = "";
            //TODO: Move this code into service
            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                return new ResponseModel
                {
                    isSuccess = false,
                    message = string.Join(",", result.Errors.Select(z => z.Description + ": " + z.Code))
                };
            }
            await _userManager.AddToRoleAsync(user, "APIUser");
            return new ResponseModel
            {
                isSuccess = true,
                message = "success"
            };
        }

        [HttpPost("public")]
        public async Task<ResponseModel> PublicRegister([FromBody] PublicRegistrationModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ResponseModel res = new ResponseModel
                    {
                        isSuccess = false,
                        message = string.Join(",", ModelState.Values.SelectMany(z => z.Errors).Select(z => z.ErrorMessage))
                    };
                    return res;
                }
                User user = _mapper.Map<User>(model);
                user.verificationEmailLink = "";
                //TODO: Move this code into service
                var result = await _userManager.CreateAsync(user, model.Password);

                if (!result.Succeeded)
                {
                    return new ResponseModel
                    {
                        isSuccess = false,
                        message = string.Join(",", result.Errors.Select(z => z.Description + ": " + z.Code))
                    };
                }
                await _userManager.AddToRoleAsync(user, "PublicUser");
                return new ResponseModel
                {
                    isSuccess = true,
                    message = "success"
                };
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("gstn-username-exists")]
        public async Task<ResponseModel> GSTNUserNameExists([FromQuery] string gstnUsername)
        {
            var data = await _userRepository.IsGSTNUsernameExists(gstnUsername);
            return new ResponseModel
            {
                isSuccess = true,
                message = "success",
                data = data
            };
        }

        [HttpGet("username-exists")]
        public async Task<ResponseModel> UserNameExists([FromQuery] string username)
        {
            var data = await _userRepository.IsUsernameExists(username);
            return new ResponseModel
            {
                isSuccess = true,
                message = "success",
                data = data
            };
        }

        [HttpGet("gstn-exists")]
        public async Task<ResponseModel> GSTNExists([FromQuery] string GSTIN)
        {
            _logger.LogInformation("GSTN exists started");
            try
            {
                var data = await _userRepository.IsGSTINExists(GSTIN);
                return new ResponseModel
                {
                    isSuccess = true,
                    message = "success",
                    data = data
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return new ResponseModel
                {
                    isSuccess = false,
                    message = ex.Message,
                };
            }
        }
    }
}
