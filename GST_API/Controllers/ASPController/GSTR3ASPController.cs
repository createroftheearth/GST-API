using GST_API.APIModels;
using GST_API.Middlewares;
using GST_API.Services;
using GST_API_DAL.Models;
using GST_API_Library.Models;
using GST_API_Library.Models.GSTR1;
using GST_API_Library.Models.GSTR1DTO;
using GST_API_Library.Models.GSTR2B;
using GST_API_Library.Models.GSTR3DTO;
using GST_API_Library.Services;
using GST_API_Library.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Dynamic;

namespace GST_API.Controllers.ASPController
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "ASPUser")]
    public class GSTR3ASPController : BaseController
    {
        private readonly ILogger<GSTR3ASPController> _logger;
        private readonly UserManager<User> _userManager;
        private readonly IGstr3Service _gstr3Service;

        public GSTR3ASPController(ILogger<GSTR3ASPController> logger, UserManager<User> userManager, IGstr3Service gstr3Service)
        {
            _logger = logger;
            _userManager = userManager;
            _gstr3Service = gstr3Service;
        }


        [HttpGet("get-gstr3b")]
        public async Task<IActionResult> GetGSTR3BDetails([FromQuery] string gstin, [FromQuery] string ret_period)
        {
            var request = new GSTR3BASPRequest { gstin = gstin, ret_period = ret_period };
            var (isSuccess, message, res) = await _gstr3Service.GetGstr3BDataByGSTIN(request, Constants.GSTR3B_Get3B_URL);

            return Ok(new ResponseModel
            {
                isSuccess = isSuccess,
                message = message,
                data = res
            });
        }

        [HttpPost("save-gstr3")]
        public async Task<IActionResult> SaveGSTR1([FromBody] Gstr3Dto gstr3SaveRequestData)
        {
            // Call the service method and capture the result
            var (isSuccess, message) = await _gstr3Service.SaveGSTR3Async(gstr3SaveRequestData);

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
