using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GST_API_Library.Services
{
    public class GSTNConstants
    {
        public static string base_url = "https://devapi.gst.gov.in";
        public static string base_path = ".";
        public static string client_id = "l7xx5edefdd923ad438eb5b332a73269f812";
        public static string client_secret = "383dc1f4835f43ad80f80f6cf284cd7b";
        public static string publicip = "192.168.1.25";
        public static string gstin = "33GSPTN0231G1ZM";
        public static string userid = "balaji.tn.1";
        public static string fp = "062023";
        public static string filename = "";
        public static string ctin = "27GSPMH0231G1ZZ";
        public static string etin = "33GSPTN0231G1ZM";

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
