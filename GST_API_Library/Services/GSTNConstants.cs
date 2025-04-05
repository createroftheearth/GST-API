using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GST_API_Library.Services
{
    public class GSTNConstants
    {
        public static string base_url = EncryptionUtils.isProduction? "http://104.211.98.97:8002" : "https://devapi.gst.gov.in";
        public static string base_path = ".";
        public static string client_id = EncryptionUtils.isProduction ? "l7xx2f78b2f6f8bb4c5da3fec6e121cce1b5" : "l7xx5edefdd923ad438eb5b332a73269f812";
        public static string client_secret = EncryptionUtils.isProduction ? "c4e3dd6d243b4b7f84d8351975c06e7a" : "383dc1f4835f43ad80f80f6cf284cd7b";
        public static string publicip = "192.168.1.25";
        public static string fp = "062023";
        public static string filename = "";
        public static string txn = "LAPN24235325555";

        public static byte[] GetAppKeyBytes()
        {
            return EncryptionUtils.CreateAesKeyBC();
        }
        //public static string GetAppKeyEncoded()
        //{
        //    if (appKey == null)
        //    {
        //        appKey = EncryptionUtils.CreateAesKeyBC();
        //    }
        //    return Convert.ToBase64String(appKey);

        //}

    }

}
