using GST_API.APIModels;
using GST_API.Services;
using GST_API_DAL.Models;
using GST_API_Library.Models.GSTR1DTO;
using GST_API_Library.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GST_API.Controllers.ASPController
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "ASPUser")]
    public class GSTR1ASPController : ControllerBase
    {
        private readonly ILogger<GSTR1ASPController> _logger;
        private readonly UserManager<User> _userManager;
        private readonly IGstr1Service _gstr1Service;

        public GSTR1ASPController(ILogger<GSTR1ASPController> logger, UserManager<User> userManager, IGstr1Service gstr1Service)
        {
            _logger = logger;
            _userManager = userManager;
            _gstr1Service = gstr1Service;
        }

        [HttpPost("savegstr1")]
        public async Task<IActionResult> SaveGSTR1([FromBody] Gstr1Dto gstr1SaveRequestData)
        {
            // Call the service method and capture the result
            var (isSuccess, message) = await _gstr1Service.SaveGSTR1Async(gstr1SaveRequestData);

            // Build the response model
            var response = new ResponseModel
            {
                isSuccess = isSuccess,
                message = message,
                data = isSuccess
            };

            // Return appropriate HTTP status code based on the result
            if (isSuccess)
            {
                return Ok(response); // HTTP 200
            }
            else
            {
                return BadRequest(response); // HTTP 400
            }
        }

    }
}
