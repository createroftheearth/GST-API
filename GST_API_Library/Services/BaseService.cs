using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GST_API_Library.Services
{
    public class BaseService
    {
        protected string gstin;
        protected string gstinUsername;
        protected string baseAppKey;
        protected string GSTINToken;
        protected string GSTINSek;
        protected byte[] appKey;

        private readonly IHttpContextAccessor _httpContextAccessor;
        public BaseService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected void resolveValues()
        {
            gstin = _httpContextAccessor.HttpContext.Items["gstin"] as string;
            gstinUsername = _httpContextAccessor.HttpContext.Items["gstinUsername"] as string;
            GSTINToken = _httpContextAccessor.HttpContext.Items["GSTINToken"] as string;
            GSTINSek = _httpContextAccessor.HttpContext.Items["GSTINSek"] as string;
            appKey = _httpContextAccessor.HttpContext.Items["appKey"] as byte[];
            baseAppKey = _httpContextAccessor.HttpContext.Items["baseAppKey"] as string;
        }
        protected string UserId
        {
            get
            {
                return _httpContextAccessor?.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            }
        }

    }
}
