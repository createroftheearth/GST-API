using GST_API.APIModels;
using GST_API_Library.Models.GSTR1;
using GST_API_Library.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GST_API.Controllers
{
    [Route("api/gstr1")]
    [ApiController]
    [Authorize]
    public class GSTR1Controller : ControllerBase
    {
        private readonly ILogger<AuthenticationController> _logger;
        private readonly IConfiguration _configuration;
        private readonly string basePath;
        public GSTR1Controller(ILogger<AuthenticationController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            var baseProjectPath = _configuration.GetValue<string>(WebHostDefaults.ContentRootKey);
            if (string.IsNullOrEmpty(baseProjectPath))
            {
                basePath = "";
            }
            else
            {
                basePath = baseProjectPath.Substring(0, baseProjectPath.LastIndexOf('\\'));
            }
        }

        [HttpPut("save")]
        public async Task<ResponseModel> save([FromBody]GSTR1Total data)
        {
            var gstnUsername = this.User.Claims.FirstOrDefault(z => z.Type == "GSTNUsername")?.Value;
            var gstin = this.User.Claims.FirstOrDefault(z => z.Type == "GSTN")?.Value;
            GSTNAuthClient client = new GSTNAuthClient(gstin, gstnUsername,basePath);
            GSTR1ApiClient client2 = new GSTR1ApiClient(client, data.gstin, data.fp);
            var info = await client2.Save(data);
            return new ResponseModel
            {
                data = info,
                isSuccess = true,
                message = "success"
            };
        }
    }
}
