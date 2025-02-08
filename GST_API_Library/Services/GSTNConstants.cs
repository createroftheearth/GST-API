using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GST_API_Library.Services
{
    public class GSTNConstants
    {
        public static string base_url = EncryptionUtils.isProduction? "https://api.gst.gov.in" : "https://devapi.gst.gov.in";
        public static string base_path = ".";
        public static string client_id = EncryptionUtils.isProduction ? "AABCB29GSPA4ZAR" : "l7xx5edefdd923ad438eb5b332a73269f812";
        public static string client_secret = EncryptionUtils.isProduction ? "2RFf6t0ZNnbHVvjxDdr7" : "383dc1f4835f43ad80f80f6cf284cd7b";
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
