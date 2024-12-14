using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace GST_API.Controllers
{
    [Route("api/public")]
    [ApiController]
    [Authorize(Roles = "APIUser")]
    public class PublicAPIController : Controller
    {
        private readonly ILogger<AuthenticationController> _logger;
        public PublicAPIController(ILogger<AuthenticationController> logger)
        {
            _logger = logger;
        }
        [NonAction]
        public IActionResult Index()
        {
            return View();
        }
    }
}
