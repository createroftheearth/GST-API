using GST_API.Controllers;
using GST_API_DAL.Models;
using GST_API_Library.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using Microsoft.Identity.Client;
using Org.BouncyCastle.Bcpg;
using System.Reflection.PortableExecutable;
using System.Security.Claims;

namespace GST_API.Filters
{
    public class ControllerActionFilter : IAsyncActionFilter
    {

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            getBaseControllerData(context);
            await next();
        }

        private string getHeaderValues(ActionExecutingContext context,string key) {
            StringValues value="";
            IHeaderDictionary headers = context.HttpContext.Request?.Headers;
            try
            {
                if (headers != null)
                {
                    headers.TryGetValue(key, out value);
                }
            }
            finally
            {
                if (string.IsNullOrEmpty(value))
                {
                    value= "";
                }
            }
            return value;
        }

        private void getBaseControllerData(ActionExecutingContext context)
        {
            string gstinToken = getHeaderValues(context,"GSTIN-Token");
            string sek = getHeaderValues(context, "GSTIN-Sek");
            ClaimsPrincipal User = context.HttpContext.User;
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
        }
    }

}
