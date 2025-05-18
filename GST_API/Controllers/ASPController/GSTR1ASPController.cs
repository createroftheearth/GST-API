using GST_API.APIModels;
using GST_API.Middlewares;
using GST_API.Services;
using GST_API_DAL.Models;
using GST_API_Library.Models.GSTR1DTO;
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
    public class GSTR1ASPController : BaseController
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

        [HttpPost("save-gstr1")]
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

        [HttpGet("get-all-gstr1")]
        public async Task<IActionResult> GetAllGstr1Data([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var gstr1Data = _gstr1Service.GetAllGstr1Data(page, pageSize, out int totalRecords);
            return Ok(new { totalRecords, gstr1Data });
        }

        [HttpPost("submit")]
        public async Task<IActionResult> Submit([FromBody] request data)
        {
            var (isSuccess, message) = await _gstr1Service.SubmitGSTR1(data.id, Constants.GSTR1_SAVE_URL);
            return Ok(new ResponseModel
            {
                isSuccess = isSuccess,
                message = message,
                data = isSuccess
            });
        }

        [HttpPost("proceed-to-file")]
        public async Task<IActionResult> ProceedToFile([FromBody] request data)
        {
            var (isSuccess, message) = await _gstr1Service.ProceedToFile(data.id, Constants.GSTR1_NewProceedToFile_URL);
            return Ok(new ResponseModel
            {
                isSuccess = isSuccess,
                message = message,
                data = isSuccess
            });
        }


        [HttpPost("generate-evc-otp")]
        public async Task<IActionResult> GenerateEVCOTP()
        {

            var (isSuccess, message) = await _gstr1Service.GenerateEVCOTP();
            return Ok(new ResponseModel
            {
                isSuccess = isSuccess,
                message = message,
                data = isSuccess
            });
        }

    }

    public class request
    {
        public int id { get; set; }
    }
}
