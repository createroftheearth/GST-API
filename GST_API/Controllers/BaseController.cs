using GST_API.APIModels;
using GST_API.Services;
using GST_API_DAL.Models;
using GST_API_Library.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;

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
