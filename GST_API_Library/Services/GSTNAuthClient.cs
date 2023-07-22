using GST_API_Library.Models;
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
        public string basePath { get; set; }
        string IGSTNAuthProvider.Username
        {
            get { return userid; }
            set { userid = value; }
        }
        public GSTNAuthClient(string gstin, string userid,string basePath) : base("/taxpayerapi/v1.0/authenticate", gstin)
        {
            this.userid = userid;
            this.basePath = basePath;
        }
        protected internal override void BuildHeaders(HttpClient client)
        {
            client.DefaultRequestHeaders.Add("clientid", GSTNConstants.client_id);
            client.DefaultRequestHeaders.Add("client-secret", GSTNConstants.client_secret);
            client.DefaultRequestHeaders.Add("ip-usr", GSTNConstants.publicip);
            client.DefaultRequestHeaders.Add("state-cd", this.gstin.Substring(0, 2));
            client.DefaultRequestHeaders.Add("txn", "LAPN24235325555");
        }
        public async Task<GSTNResult<LogoutResponseModel>> RequestLogout()
        {
            LogoutRequestModel model = new LogoutRequestModel
            {
                action = "LOGOUT",
                username = userid,
                app_key = EncryptionUtils.RsaEncrypt(GSTNConstants.GetAppKeyBytes(),basePath),
                auth_token = token.auth_token

            };
            return await PostAsync<LogoutRequestModel, LogoutResponseModel>(model);
        }

        public async Task<(GSTNResult<OTPResponseModel>,string)> RequestOTP()
        {
            var appKey = EncryptionUtils.RsaEncrypt(GSTNConstants.GetAppKeyBytes(), basePath);
            OTPRequestModel model = new OTPRequestModel
            {
                action = "OTPREQUEST",
                username = userid,
                app_key = appKey
            };
            return (await PostAsync<OTPRequestModel, OTPResponseModel>(model), appKey);
        }

        public async Task<GSTNResult<TokenResponseModel>> RequestToken(string otp,string appKey)
        {
            TokenRequestModel model = new TokenRequestModel
            {
                action = "AUTHTOKEN",
                username = userid,
                app_key = appKey
            };
            byte[] dataToEncrypt = UTF8Encoding.UTF8.GetBytes(otp);
            model.otp = EncryptionUtils.AesEncrypt(dataToEncrypt, GSTNConstants.GetAppKeyBytes());
            return await PostAsync<TokenRequestModel, TokenResponseModel>(model);
        }

        public async Task<GSTNResult<TokenResponseModel>> RefreshToken()
        {
            RefreshTokenModel model = new RefreshTokenModel
            {
                action = "REFRESHTOKEN",
                username = userid
            };
            model.app_key = EncryptionUtils.AesEncrypt(GSTNConstants.GetAppKeyBytes(), this.DecryptedKey);
            return await PostAsync<RefreshTokenModel, TokenResponseModel>(model);
        }

    }
    public interface IGSTNAuthProvider
    {
        string Username { get; set; }
        string AuthToken { get; set; }
        byte[] DecryptedKey { get; set; }
    }
}

