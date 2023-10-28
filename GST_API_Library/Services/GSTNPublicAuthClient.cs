using GST_API_Library.Models;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;
using System.Text;

namespace GST_API_Library.Services
{
    public class GSTNPublicAuthClient
    {

        TokenResponseModel token;
        public string AuthToken { get; set; }
        public byte[] DecryptedKey { get; set; }
        private byte[] appKey;

    
        public GSTNPublicAuthClient( byte[] appKey)
        {
            this.appKey = appKey;
        }
        //public async Task<GSTNResult<LogoutResponseModel>> RequestLogout(string authToken)
        //{
        //    LogoutRequestModel model = new LogoutRequestModel
        //    {
        //        action = "LOGOUT",
        //        username = userid,
        //        app_key = EncryptionUtils.RsaEncrypt(this.appKey),
        //        auth_token = authToken

        //    };
        //    return await PostAsync<LogoutRequestModel, LogoutResponseModel>(model);
        //}


        public async Task<GSTNResult<TokenResponseModel>> RequestToken(string gstnUsername,string gstnPassword)
        {
            byte[] dataToEncrypt = UTF8Encoding.UTF8.GetBytes(gstnPassword);
            object model = new
            {
                action = "ACCESSTOKEN",
                username =  gstnUsername,
                password = EncryptionUtils.RsaEncrypt(dataToEncrypt),
                app_key = EncryptionUtils.RsaEncrypt(this.appKey)
            };
            return await this.PostAsync<object, TokenResponseModel>(model, "/commonapi/v0.2/authenticate");
        }

        //public async Task<GSTNResult<TokenResponseModel>> RefreshToken(string authToken)
        //{
        //    RefreshTokenModel model = new RefreshTokenModel
        //    {
        //        action = "REFRESHTOKEN",
        //        username = userid,
        //        auth_token = authToken
        //    };
        //    model.app_key = EncryptionUtils.AesEncrypt(this.appKey, this.DecryptedKey);
        //    return await PostAsync<RefreshTokenModel, TokenResponseModel>(model);
        //}


        public async Task<GSTNResult<TOutput>> PostAsync<TInput, TOutput>(TInput data,string path)
        {
            string url= GSTNConstants.base_url + path;
            using (var client = GetHttpClient())
            {
                HttpResponseMessage response;
                if (typeof(TInput) == typeof(string))
                {
                    var content = new StringContent((string)(object)data, System.Text.Encoding.UTF8, "text/plain");
                    response = await client.PostAsync(url, content);
                }
                else
                {
                    response = await client.PostAsJsonAsync(url, data);
                }
                return BuildResponse<TOutput>(response);
            }
        }

        protected HttpClient GetHttpClient()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("clientid", GSTNConstants.client_id);
            client.DefaultRequestHeaders.Add("client-secret", GSTNConstants.client_secret);
            client.Timeout = TimeSpan.FromSeconds(100);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

        protected virtual GSTNResult<TOutput> BuildResponse<TOutput>(HttpResponseMessage response)
        {
            //This function can be used to convert simple API result to ResultInfo based API result
            GSTNResult<TOutput> resultInfo = new GSTNResult<TOutput>
            {
                HttpStatusCode = Convert.ToInt32(response.StatusCode.ToString("D"))
            };
            var str1 = response.Content.ReadAsStringAsync().Result;
            System.Console.WriteLine("Obtained Result:" + str1 + System.Environment.NewLine);
            if (resultInfo.HttpStatusCode == (int)HttpStatusCode.OK)
            {
                if (typeof(TOutput) == typeof(String))
                {
                    var result = (TOutput)(Object)str1;
                    resultInfo.Data = result;
                }
                else
                {
                    resultInfo.Data = JsonConvert.DeserializeObject<TOutput>(str1);
                }
            }
            return resultInfo;
        }

    }
}

