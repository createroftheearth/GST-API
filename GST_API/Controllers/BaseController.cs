using Microsoft.AspNetCore.Mvc;

namespace GST_API.Controllers
{
    public class BaseController : ControllerBase
    {
        public string gstin;
        public string gstinUsername;
        public string baseAppKey;
        public string GSTINToken;
        public string GSTINSek;
        public byte[] appKey;
    }
}
