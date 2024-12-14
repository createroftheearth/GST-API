using GST_API_Library.Models;
using GST_API_Library.Models.GSTR1;
using Org.BouncyCastle.Crypto.Tls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GST_API_Library.Services
{
    public class GSTNAuthClient : GSTNApiClientBase, IGSTNAuthProvider
    {

        TokenResponseModel token;
        public string AuthToken { get; set; }
        public byte[] DecryptedKey { get; set; }
        public string userid { get; set; }
        private string gstin { get; set; }

        private byte[] appKey;

        string IGSTNAuthProvider.Username
        {
            get { return userid; }
            set { userid = value; }
        }
        public GSTNAuthClient(string gstin, string userid, byte[] appKey) : base("/taxpayerapi/v1.0/authenticate", gstin)
        {
            this.userid = userid;
            this.appKey = appKey;
            this.gstin = gstin; 
        }
        protected internal override void BuildHeaders(HttpClient client, string? returnType = null, string? apiVersion = null)
        {
            client.DefaultRequestHeaders.Add("clientid", GSTNConstants.client_id);
            client.DefaultRequestHeaders.Add("client-secret", GSTNConstants.client_secret);
            client.DefaultRequestHeaders.Add("ip-usr", GSTNConstants.publicip);
            client.DefaultRequestHeaders.Add("state-cd", this.gstin.Substring(0, 2));
            client.DefaultRequestHeaders.Add("txn", GSTNConstants.txn);
        }
        public async Task<GSTNResult<LogoutResponseModel>> RequestLogout(string authToken)
        {
            LogoutRequestModel model = new LogoutRequestModel
            {
                action = "LOGOUT",
                username = userid,
                app_key = EncryptionUtils.RsaEncrypt(this.appKey),
                auth_token = authToken

            };
            return await PostAsync<LogoutRequestModel, LogoutResponseModel>(model);
        }

        public async Task<GSTNResult<OTPResponseModel>> RequestOTP()
        {
            var appKey = EncryptionUtils.RsaEncrypt(this.appKey);
            OTPRequestModel model = new OTPRequestModel
            {
                action = "OTPREQUEST",
                username = userid,
                app_key = appKey
            };
            return await PostAsync<OTPRequestModel, OTPResponseModel>(model);
        }

        public async Task<GSTNResult<TokenResponseModel>> RequestToken(string otp)
        {
            TokenRequestModel model = new TokenRequestModel
            {
                action = "AUTHTOKEN",
                username = userid,
                app_key = EncryptionUtils.RsaEncrypt(this.appKey)
            };
            byte[] dataToEncrypt = UTF8Encoding.UTF8.GetBytes(otp);
            model.otp = EncryptionUtils.AesEncrypt(dataToEncrypt, this.appKey);
            return await PostAsync<TokenRequestModel, TokenResponseModel>(model);
        }

        public async Task<GSTNResult<TokenResponseModel>> RefreshToken(string authToken)
        {
            RefreshTokenModel model = new RefreshTokenModel
            {
                action = "REFRESHTOKEN",
                username = userid,
                auth_token = authToken
            };
            model.app_key = EncryptionUtils.AesEncrypt(this.appKey, this.DecryptedKey);
            return await PostAsync<RefreshTokenModel, TokenResponseModel>(model);
        }

        public async Task<GSTNResult<BaseResponseModel>> RequestOTPForEVC(EVCAuthenticationModel model,string gstinToken)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>
            {
                {"gstin",model.gstin },
                { "pan",model.pan},
                { "form_type",model.form_type},
                {"action","EVCOTP" }
            };
            this.PrepareQueryString(dic);
            using (var client = GetHttpClient())
            {
                client.DefaultRequestHeaders.Add("auth-token",gstinToken );
                client.DefaultRequestHeaders.Add("username", userid);
                client.DefaultRequestHeaders.Add("gstin", gstin);
                //url2 to url3 amit
                System.Console.WriteLine("GET:" + url2);
                HttpResponseMessage response = await client.GetAsync(url2);
                return BuildResponse<BaseResponseModel>(response);
            }
        }

        //need to ask with himanshu
        //public async Task<(GSTNResult<OTPResponseModel>, string)> InitiateOTP_EVC()
        //{
        //    var baseAppKey = this.appKey;
        //    var appKey = EncryptionUtils.RsaEncrypt(baseAppKey);
        //    OTPRequestModel model = new OTPRequestModel
        //    {
        //        action = "EVCOTP",
        //        username = userid,
        //        app_key = appKey
        //    };
        //    return (await PostAsync<OTPRequestModel, OTPResponseModel>(model), Convert.ToBase64String(baseAppKey));
        //}

    }
    public interface IGSTNAuthProvider
    {
        string Username { get; set; }
        string AuthToken { get; set; }
        byte[] DecryptedKey { get; set; }
    }
}

