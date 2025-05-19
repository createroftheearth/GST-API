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
        protected string gstin => _httpContextAccessor.HttpContext.Items["gstin"] as string;
        protected string gstinUsername => _httpContextAccessor.HttpContext.Items["gstinUsername"] as string;
        protected string baseAppKey => _httpContextAccessor.HttpContext.Items["baseAppKey"] as string;
        protected string GSTINToken => _httpContextAccessor.HttpContext.Items["GSTINToken"] as string;
        protected string GSTINSek => _httpContextAccessor.HttpContext.Items["GSTINSek"] as string;
        protected byte[] appKey => _httpContextAccessor.HttpContext.Items["appKey"] as byte[];

        private readonly IHttpContextAccessor _httpContextAccessor;
        public BaseService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected string UserId
        {
            get
            {
                return _httpContextAccessor?.HttpContext?.User?.Claims.FirstOrDefault(x => x.Type == "Id")?.Value;
            }
        }

    }
}
