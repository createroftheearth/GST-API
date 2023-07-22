using GST_API.Controllers;
using GST_API_Library.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using Microsoft.Identity.Client;
using System.Security.Claims;

namespace GST_API.Filters
{
    public class ControllerActionFilter : IAsyncActionFilter
    {

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {

            StringValues sek = "", gstinToken = "";
            HttpRequest Request = context.HttpContext.Request;
            ClaimsPrincipal User = context.HttpContext.User;
            try
            {
                if (Request != null)
                {
                    Request.Headers.TryGetValue("GSTIN-Sek", out sek);
                    Request.Headers.TryGetValue("GSTIN-Token", out gstinToken);
                }
            }
            finally
            {
                if (string.IsNullOrEmpty(sek) || string.IsNullOrEmpty(gstinToken))
                {
                    sek = "";
                    gstinToken = "";
                }
            }
            if (User != null)
            {
                var baseAppKey = User.Claims.FirstOrDefault(z => z.Type == "BaseAppKey")?.Value;
                if (baseAppKey != null)
                {
                    GSTNConstants.appKey = Convert.FromBase64String(baseAppKey);
                }
                var baseController = (BaseController)context.Controller;
                baseController.gstinUsername = User.Claims.FirstOrDefault(z => z.Type == "GSTNUsername")?.Value;
                baseController.gstin = User.Claims.FirstOrDefault(z => z.Type == "GSTN")?.Value;
                baseController.baseAppKey = baseAppKey;
                baseController.GSTINSek = sek;
                baseController.GSTINToken = gstinToken;
            }
            await next();
        }
    }

}
