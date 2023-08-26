using GST_API_Library.Models;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using FileInfo = GST_API_Library.Models.FileInfo;

namespace GST_API_Library.Services
{
    public class GSTNReturnsClient : GSTNApiClientBase
    {
        IGSTNAuthProvider provider;
        public string LastJson;
        protected internal string ret_period;


        //action_required=“Y|N“
        public GSTNReturnsClient(IGSTNAuthProvider AuthProvider, string path, string gstin, string ret_period) : base(path, gstin)
        {
            this.ret_period = ret_period;
            provider = AuthProvider;
        }

        protected internal override void BuildHeaders(HttpClient client)
        {
            client.DefaultRequestHeaders.Add("clientid", GSTNConstants.client_id);
            client.DefaultRequestHeaders.Add("client-secret", GSTNConstants.client_secret);
            client.DefaultRequestHeaders.Add("ip-usr", GSTNConstants.publicip);
            client.DefaultRequestHeaders.Add("state-cd", this.gstin.Substring(0, 2));
            client.DefaultRequestHeaders.Add("gstin", this.gstin);
            if (!string.IsNullOrEmpty(this.ret_period)) client.DefaultRequestHeaders.Add("ret_period", this.ret_period);
            client.DefaultRequestHeaders.Add("txn", System.Guid.NewGuid().ToString().Replace("-", ""));
            client.DefaultRequestHeaders.Add("username", provider.Username);
            client.DefaultRequestHeaders.Add("auth-token", provider.AuthToken);
        }

        protected internal T Decrypt<T>(ResponseDataInfo output)
        {
            T model = default(T);
            if (output.status_cd != "0")
            {
                byte[] decryptREK = EncryptionUtils.AesDecrypt(output.rek, provider.DecryptedKey);
                byte[] jsonData = EncryptionUtils.AesDecrypt(output.data, decryptREK);
                string testHmac = EncryptionUtils.GenerateHMAC(jsonData, decryptREK);
                System.Console.WriteLine("HMAC Match:" + (output.hmac == testHmac));
                string base64Payload = UTF8Encoding.UTF8.GetString(jsonData);
                byte[] decodeJson = Convert.FromBase64String(base64Payload);
                string finalJson = Encoding.UTF8.GetString(decodeJson);
                model = JsonConvert.DeserializeObject<T>(finalJson);
                LastJson = finalJson;
            }
            return model;
        }

        protected internal UnsignedDataInfo Encrypt<T>(T input)
        {
            UnsignedDataInfo info = new UnsignedDataInfo();
            if (input != null)
            {
                string finalJson = JsonConvert.SerializeObject(input, Newtonsoft.Json.Formatting.Indented,
                            new JsonSerializerSettings
                            {
                                NullValueHandling = NullValueHandling.Ignore
                            });
                byte[] encodeJson = UTF8Encoding.UTF8.GetBytes(finalJson);
                string base64Payload = Convert.ToBase64String(encodeJson);
                byte[] jsonData = UTF8Encoding.UTF8.GetBytes(base64Payload);
                info.data = EncryptionUtils.AesEncrypt(jsonData, provider.DecryptedKey);
                info.hmac = EncryptionUtils.GenerateHMAC(jsonData, provider.DecryptedKey);
            }
            return info;
        }

        protected virtual GSTNResult<TOutput> BuildResult<TOutput>(GSTNResult<ResponseDataInfo> response, TOutput data)
        {
            //This function can be used to convert simple API result to ResultInfo based API result
            GSTNResult<TOutput> resultInfo = new GSTNResult<TOutput>();
            resultInfo.HttpStatusCode = response.HttpStatusCode;
            if (resultInfo.HttpStatusCode == (int)HttpStatusCode.OK)
            {
                resultInfo.Data = data;
            }
            return resultInfo;
        }

        //protected internal virtual GSTNResult<FileInfo> SignFile(UnsignedDataInfo unsignedDataInfo, string sign, string st, string sid, string ret_prd)
        //{
        //    this.url2 = this.url2.Split('?')[0];
        //    SignedDataInfo model = new SignedDataInfo
        //    {
        //        action = "RETFILE",
        //        sign = sign,
        //        st = st,
        //        sid = sid,
        //        data = unsignedDataInfo.data
        //    };

        //    var info = this.Post<SignedDataInfo, ResponseDataInfo>(model);
        //    var output = this.Decrypt<FileInfo>(info.Data);
        //    var model2 = this.BuildResult<FileInfo>(info, output);
        //    System.Console.WriteLine("Obtained Result:" + info.Data.ack_num + System.Environment.NewLine);
        //    return model2;

        //}
        //public GSTNResult<SaveInfo> Submit(string ret_prd)
        //{
        //    GenerateRequestInfo model = new GenerateRequestInfo()
        //    {
        //        gstin = gstin,
        //        ret_period = ret_prd,
        //        //generate_summary = "Y"
        //    };
        //    var data = this.Encrypt(model);
        //    data.action = "RETSUBMIT";
        //    var info = this.Post<UnsignedDataInfo, ResponseDataInfo>(data);
        //    var output = this.Decrypt<SaveInfo>(info.Data);
        //    var model2 = this.BuildResult<SaveInfo>(info, output);
        //    System.Console.WriteLine("Obtained Result:" + model2.Data.reference_id + System.Environment.NewLine);
        //    return model2;

        //}
        //This API Is To Get status of return
        public async Task<GSTNResult<ReturnStatusInfo>> GetStatus(string ret_prd, string reference_id)
        {
            this.PrepareQueryStringGSTR(new Dictionary<string, string> {
            {"gstin",gstin},
            {"action","RETSTATUS"},
            {"ret_period",ret_prd},
            {"ref_id" ,reference_id}
            });//trans_id--ref_id
            var info = await this.GetAsync<ResponseDataInfo>();
            var output = this.Decrypt<ReturnStatusInfo>(info.Data);
            var model = this.BuildResult<ReturnStatusInfo>(info, output);
            return model;
        }

        public async Task<GSTNResult<NewProceedToFile>> NewProceedToFile_GSTR1(string ret_prd)
        {

            GenerateRequestInfo model = new GenerateRequestInfo()
            {
                gstin = gstin,
                ret_period = ret_prd,
                isnil = "N"

            };
            //This Json is send by GST
            //Request payload:-
            //{
            //"action": "RETNEWPTF",
            //"data": "xxXdH8NnDgzNkWiBEcHpIlAY+aR9gakQmavQgOtocBg54X0X8cNcGWeqeqQ9VtgEKxHKIOPJoJ2Kk0Qp6tso33ou+xC3BXdbymDDYanhehNIjjJiKFq1UU0QtT8QPvPb",
            //"hmac": "gG61JgBtW/QMKorEPPA2r680bk2W9Yysmv6AakjD/eQ=",
            //"hdr": {
            //            "state-cd": "33",
            //            "txn": "4285433270",
            //            "username": "balaji.tn.1",
            //            "auth-token": "34eacc5ff534b03ae36462c9b3216c2",
            //            "gstin": "33GSPTN0231G1ZM",
            //            "ret_period": "082017",
            //            "clientid": "l7xx0f3fb7ee24624626ab7bxxxxxxxxxx",
            //            "ip-usr": "127.0.2.x",
            //            "rtn_typ": "GSTR1",
            //            "api_version": "1.1",
            //            "userrole": "GSTR1"
            //        }
            //}


  //          {
  //              "action": "RETNEWPTF",
  //"data": "uhOvGVTnibcqiRY6zV5hczZRj106F8soL5MP8RY57KMxfUXE0a8DedFzjNK1vEOygcjlX9izEKqsfYvOLvW4OZoX/V8PtgfLLk1T5jSOlUk=",
  //"hmac": "lkvBUqMju0yi8oifySvNiO+PLrkhLNozJN55vI84mj4=",
  //"hdr": {
  //                  "clientid": "<client id>",
  //  "username": "<user>",
  //  "state-cd": "27",
  //  "ip-usr": "14.97.69.62",
  //  "txn": "LAPN24235325556",
  //  "api_version": "1.0",
  //  "userrole": "GSTR1",
  //  "rtn_typ": "GSTR1",
  //  "ret_period": "022019",
  //  "gstin": "27GSPMH0122G1Z1",
  //  "auth-token": "7090df1a03ad440d9a8954f93cb14c36",
  //}
  //          }
            HeaderData hdrdata = new HeaderData
            {
                state_cd = this.gstin.Substring(0, 2),
                txn = "LAPN24235325555",//System.Guid.NewGuid().ToString().Replace("-", "");
                username = provider.Username,
                auth_token = provider.AuthToken,
                gstin = this.gstin, 
                ret_period = this.ret_period,
                clientid = GSTNConstants.client_id,
                ip_usr = GSTNConstants.publicip,
                rtn_typ = "GSTR1",
                api_version = "1.1",
                userrole = "GSTR1",
            };

            string finalJson = JsonConvert.SerializeObject(hdrdata);

            var data = this.Encrypt(model);
            data.hdr = finalJson;
            data.hmac = "pzu1iuHCSgQ2BjcZiwSw5t1b1O8Iu/UZgiigOhWXRTE=";
            data.action = "RETNEWPTF";
            var info = await this.PostAsync<UnsignedDataInfo, ResponseDataInfo>(data);
            if (info == null)
            {
                throw new Exception("Unable to get the details from server");
            }
            //var output = this.Decrypt<NewProceedToFile>(info..reference_id);
            //var model1 = this.BuildResult<NewProceedToFile>(info, output);
            return null;
        }

    }
}
