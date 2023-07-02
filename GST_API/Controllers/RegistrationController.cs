using AutoMapper;
using GST_API.APIModels;
using GST_API_DAL.Models;
using GST_API_DAL.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GST_API.Controllers
{
    [Route("api/registration")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {

        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public RegistrationController(UserManager<User> userManger,IMapper mapper, IUserRepository userRepository)
        {
            _userManager = userManger;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        [HttpPost]
        public async Task<ResponseModel> Register([FromBody]RegistrationModel model)
        {
            if (!ModelState.IsValid)
            {
                ResponseModel res  = new ResponseModel
                {
                    isSuccess = false,
                    message = string.Join(",", ModelState.Values.SelectMany(z => z.Errors).Select(z => z.ErrorMessage))
                };
                return res;
            }
            User user = _mapper.Map<User>(model);
            user.CancelledChequeString = model.CancelledChequePhoto;
            user.LargeImageString = model.ProfilePicture ;
            user.verificationEmailLink = "";
            //TODO: Move this code into service
            var result = await _userManager.CreateAsync(user, model.Password);

            if(!result.Succeeded)
            {
                return new ResponseModel
                {
                    isSuccess = false,
                    message = string.Join(",", result.Errors.Select(z=>z.Description + ": "+ z.Code))
                };
            }
            await _userManager.AddToRoleAsync(user, "APIUser");
            return new ResponseModel
            {
                isSuccess = true,
                message = "success"
            };
        }

        [HttpGet("gstn-username-exists")]
        public async Task<bool> GSTNUserNameExists([FromQuery]string gstnUsername)
        {
            return await _userRepository.IsGSTNUsernameExists(gstnUsername);
        }

        [HttpGet("username-exists")]
        public async Task<bool> UserNameExists([FromQuery] string username)
        {
            return await _userRepository.IsUsernameExists(username);
        }

        [HttpGet("gstn-exists")]
        public async Task<bool> GSTNExists([FromQuery] string GSTIN)
        {
            return await _userRepository.IsGSTINExists(GSTIN);
        }
    }
}
