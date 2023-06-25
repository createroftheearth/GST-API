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

        public RegistrationController(UserManager<User> userManger)
        {
            _userManager = userManger;
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
            //TODO: Move this code into 
            var result = await _userManager.CreateAsync(user, userModel.Password);


        }
    }
}
