﻿using GST_API_Library.Models;
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
        string IGSTNAuthProvider.Username
        {
            get { return userid; }
            set { userid = value; }
        }
        public GSTNAuthClient(string gstin, string userid) : base("/taxpayerapi/v1.0/authenticate", gstin)
        {
            this.userid = userid;
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
                app_key = EncryptionUtils.RsaEncrypt(GSTNConstants.GetAppKeyBytes()),
                auth_token = token.auth_token

            };
            return await Post<LogoutRequestModel, LogoutResponseModel>(model);
        }

        public async Task<GSTNResult<OTPResponseModel>> RequestOTP()
        {
            OTPRequestModel model = new OTPRequestModel
            {
                action = "OTPREQUEST",
                username = userid,
                app_key = EncryptionUtils.RsaEncrypt(GSTNConstants.GetAppKeyBytes())
            };
            return await Post<OTPRequestModel, OTPResponseModel>(model);
        }

        public async Task<GSTNResult<TokenResponseModel>> RequestToken(string otp)
        {
            TokenRequestModel model = new TokenRequestModel
            {
                action = "AUTHTOKEN",
                username = userid
            };
            model.app_key = EncryptionUtils.RsaEncrypt(GSTNConstants.GetAppKeyBytes());
            byte[] dataToEncrypt = UTF8Encoding.UTF8.GetBytes(otp);
            model.otp = EncryptionUtils.AesEncrypt(dataToEncrypt, GSTNConstants.GetAppKeyBytes());
            return await Post<TokenRequestModel, TokenResponseModel>(model);
        }

        public async Task<GSTNResult<TokenResponseModel>> RefreshToken()
        {
            RefreshTokenModel model = new RefreshTokenModel
            {
                action = "REFRESHTOKEN",
                username = userid
            };
            model.app_key = EncryptionUtils.AesEncrypt(GSTNConstants.GetAppKeyBytes(), this.DecryptedKey);
            return await Post<RefreshTokenModel, TokenResponseModel>(model);
        }

    }
    public interface IGSTNAuthProvider
    {
        string Username { get; set; }
        string AuthToken { get; set; }
        byte[] DecryptedKey { get; set; }
    }
}
