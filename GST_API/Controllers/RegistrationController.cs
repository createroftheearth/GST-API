using AutoMapper;
using GST_API.APIModels;
using GST_API_DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {

        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public RegistrationController(UserManager<User> userManger,IMapper mapper)
        {
            _userManager = userManger;
            _mapper = mapper;
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
            //TODO: Move this code into service
            var result = await _userManager.CreateAsync(user, model.PasswordHash);
            if(!result.Succeeded)
            {
                return new ResponseModel
                {
                    isSuccess = false,
                    message = string.Join(",", result.Errors.Select(z=>z.Description + ": "+ z.Code))
                };
            }
            return new ResponseModel
            {
                isSuccess = true,
                message = "success"
            };
        }
    }
}
