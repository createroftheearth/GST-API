using GST_API_DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GST_API.Controllers.ASPController
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "ASPUser")]
    public class GSTR1ASPController : ControllerBase
    {
        private readonly ILogger<GSTR1ASPController> _logger;
        private readonly UserManager<User> _userManager;

        public GSTR1ASPController(ILogger<GSTR1ASPController> logger, UserManager<User> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        

    }
}
