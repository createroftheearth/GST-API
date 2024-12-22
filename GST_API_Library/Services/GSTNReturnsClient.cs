using GST_API_Library.Models;
using GST_API_Library.Models.CommonAPI;
using GST_API_Library.Models.GSTR1;
using GST_API_Library.Models.GSTR1A;
using GST_API_Library.Models.GSTRIMS;
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

        protected internal override void BuildHeaders(HttpClient client, string? returnType = null, string? apiVersion = null)
        {
            client.DefaultRequestHeaders.Add("clientid", GSTNConstants.client_id);
            client.DefaultRequestHeaders.Add("client-secret", GSTNConstants.client_secret);
            client.DefaultRequestHeaders.Add("ip-usr", GSTNConstants.publicip);
            client.DefaultRequestHeaders.Add("state-cd", this.gstin.Substring(0, 2));
            client.DefaultRequestHeaders.Add("gstin", this.gstin);
            if (!string.IsNullOrEmpty(this.ret_period)) client.DefaultRequestHeaders.Add("ret_period", this.ret_period);
            client.DefaultRequestHeaders.Add("txn", GSTNConstants.txn);
            client.DefaultRequestHeaders.Add("username", provider.Username);
            client.DefaultRequestHeaders.Add("auth-token", provider.AuthToken);
            if (!string.IsNullOrEmpty(returnType))
            {
                client.DefaultRequestHeaders.Add("rtn_typ", returnType);
                client.DefaultRequestHeaders.Add("userrole", returnType);
            }
            if (!string.IsNullOrEmpty(apiVersion))
            {
                client.DefaultRequestHeaders.Add("api_version", apiVersion);
            }
        }

        protected internal T Decrypt<T>(ResponseDataInfo output)
        {
            T model = default(T);
            if (output == null)
            {
                return model;
            }
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
            else
            {
                string finalJson = JsonConvert.SerializeObject(output);
                model = JsonConvert.DeserializeObject<T>(finalJson);
            }
            return model;
        }

        protected internal SignedDataInfo Encrypt2<T>(T input)
        {
            SignedDataInfo info = new SignedDataInfo();
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
                //info.hmac = EncryptionUtils.GenerateHMAC(jsonData, provider.DecryptedKey);
            }
            return info;
        }

        protected internal UnsignedDataInfo Encrypt<T>(T input)
        {
            UnsignedDataInfo info = new UnsignedDataInfo();
            if (input != null)
            {
                string finalJson = JsonConvert.SerializeObject(input,
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

        protected internal UnsignedDataInfo1 Encrypt1<T>(T input)
        {
            UnsignedDataInfo1 info = new UnsignedDataInfo1();
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
                //info.hmac = EncryptionUtils.GenerateHMAC(jsonData, provider.DecryptedKey);
            }
            return info;
        }

        protected internal UnsignedDataInfo2 Encrypt3<T>(T input)
        {
            UnsignedDataInfo2 info = new UnsignedDataInfo2();
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

        protected virtual GSTNResult1<TOutput> BuildResult1<TOutput>(GSTNResult1<ResponseDataInfo> response, TOutput data)
        {
            //This function can be used to convert simple API result to ResultInfo based API result
            GSTNResult1<TOutput> resultInfo = new GSTNResult1<TOutput>();
            //resultInfo.HttpStatusCode = response.HttpStatusCode;
            //if (resultInfo.HttpStatusCode == (int)HttpStatusCode.OK)
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

        public async Task<GSTNResult<NewProceedToFile>> NewProceedToFile_GSTR1(GenerateRequestInfo model)
        {
            HeaderData hdrdata = new HeaderData
            {
                clientid = GSTNConstants.client_id,
                username = provider.Username,
                state_cd = this.gstin.Substring(0, 2),
                txn = GSTNConstants.txn,//System.Guid.NewGuid().ToString().Replace("-", "");
                auth_token = provider.AuthToken,
                gstin = this.gstin,
                ret_period = this.ret_period,
                ip_usr = GSTNConstants.publicip,
                rtn_typ = "GSTR1",
                api_version = "1.1",
                userrole = "GSTR1",
            };


            var data = this.Encrypt(model);
            data.hdr = hdrdata;
            data.action = "RETNEWPTF";
            string jsonData = JsonConvert.SerializeObject(data);
            var info = await this.PostAsync<string, ResponseDataInfo>(jsonData, "GSTR1", "1.1");
            if (info == null)
            {
                throw new Exception("Unable to get the details from server");
            }
            var output = this.Decrypt<NewProceedToFile>(info.Data);
            var result = this.BuildResult(info, output);
            return result;
        }

        public async Task<GSTNResult<FileInfo>> filegstr1(File1 data, string OTP, string? PAN) //File1 - Summaryoutward
        {
            string finalJson = JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented,
                          new JsonSerializerSettings
                          {
                              NullValueHandling = NullValueHandling.Ignore
                          });
            byte[] encodeJson = UTF8Encoding.UTF8.GetBytes(finalJson);
            string base64Payload = Convert.ToBase64String(encodeJson);
            
            var data1 = this.Encrypt2(data);
            data1.action = "RETFILE";
            data1.st = "EVC";
            data1.sign = EncryptionUtils.GenerateHMAC(base64Payload, PAN + "|" + OTP);
            data1.sid = PAN + "|" + OTP;

            string jsonData = JsonConvert.SerializeObject(data1);
            var info = await this.PostAsync<string, ResponseDataInfo>(jsonData);

            if (info == null)
            {
                throw new Exception("Unable to get the details from server");
            }
            var output = this.Decrypt<FileInfo>(info.Data);
            var model2 = this.BuildResult(info, output);
            return model2;
        }

        public async Task<GSTNResult<FileInfo>> filegstr1A(GetGSTR1ASummaryResp data, string OTP, string? PAN)
        {
            string finalJson = JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented,
                          new JsonSerializerSettings
                          {
                              NullValueHandling = NullValueHandling.Ignore
                          });
            byte[] encodeJson = UTF8Encoding.UTF8.GetBytes(finalJson);
            string base64Payload = Convert.ToBase64String(encodeJson);

            var data1 = this.Encrypt2(data);
            data1.action = "RETFILER1A";
            data1.st = "EVC";
            data1.sign = EncryptionUtils.GenerateHMAC(base64Payload, PAN + "|" + OTP);
            data1.sid = PAN + "|" + OTP;

            string jsonData = JsonConvert.SerializeObject(data1);
            var info = await this.PostAsync<string, ResponseDataInfo>(jsonData);

            if (info == null)
            {
                throw new Exception("Unable to get the details from server");
            }
            var output = this.Decrypt<FileInfo>(info.Data);
            var model2 = this.BuildResult(info, output);
            return model2;
        }


        //public async Task<GSTNResult<FileInfo>> filegstr1(SummaryOutward data, string OTP, string? PAN)
        //{
        //    //var encryptedData = this.Encrypt(data);

        //    string finalJson = JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented,
        //                  new JsonSerializerSettings
        //                  {
        //                      NullValueHandling = NullValueHandling.Ignore
        //                  });
        //    byte[] encodeJson = UTF8Encoding.UTF8.GetBytes(finalJson);
        //    string base64Payload = Convert.ToBase64String(encodeJson);
        //    //HeaderData hdrdata = new HeaderData
        //    //{
        //    //    clientid = GSTNConstants.client_id,
        //    //    username = provider.Username,
        //    //    state_cd = this.gstin.Substring(0, 2),
        //    //    txn = GSTNConstants.txn,//System.Guid.NewGuid().ToString().Replace("-", "");
        //    //    auth_token = provider.AuthToken,
        //    //    gstin = this.gstin,
        //    //    ret_period = this.ret_period,
        //    //    ip_usr = GSTNConstants.publicip,
        //    //    rtn_typ = "GSTR1",
        //    //    api_version = "4.0",
        //    //    userrole = "GSTR1",
        //    //};
        //    var data1 = this.Encrypt2(data);

        //    //var model1 = this.Encrypt(data),
        //    data1.action = "RETFILE";
        //    data1.st = "EVC";
        //    data1.sign = EncryptionUtils.GenerateHMAC(base64Payload, PAN + "|" + OTP);
        //    data1.sid = PAN + "|" + OTP;
        //    //data1.hdr = hdrdata;



        //    string jsonData = JsonConvert.SerializeObject(data1);
        //    var info = await this.PostAsync<string, ResponseDataInfo>(jsonData);

        //    //var info = await this.PostAsync<string, ResponseDataInfo>(jsonData, "GSTR1", "4.0");


        //    if (info == null)
        //    {
        //        throw new Exception("Unable to get the details from server");
        //    }
        //    var output = this.Decrypt<FileInfo>(info.Data);
        //    var model2 = this.BuildResult(info, output);
        //    return model2;
        //}

        public async Task<GSTNResult<UploadDocumentResponse>> UploadDocument_Common(UploadDocumentRequest model)
        {
            HeaderData1 hdrdata1 = new HeaderData1
            {
                clientid = GSTNConstants.client_id,
                username = provider.Username,
                state_cd = this.gstin.Substring(0, 2),
                txn = GSTNConstants.txn,//System.Guid.NewGuid().ToString().Replace("-", "");
                auth_token = provider.AuthToken,
                gstin = this.gstin,
                ret_period = this.ret_period,
                ip_usr = GSTNConstants.publicip,
                rtn_typ = "GSTR1",
                api_version = "1.1",
                userrole = "GSTR1",
                form_typ= "GSTR1",
            };
            var data = this.Encrypt3(model);
            data.action = "DOCUPLOAD";
            data.hdr = hdrdata1;

            string jsonData = JsonConvert.SerializeObject(data);
            var info = await this.PostAsync<string, ResponseDataInfo>(jsonData);
            if (info == null)
            {
                throw new Exception("Unable to get the details from server");
            }
            var output = this.Decrypt<UploadDocumentResponse>(info.Data);
            var result = this.BuildResult(info, output);
            return result;
        }

        //public async Task<GSTNResult<FileInfo>> filegstr1(SummaryOutward data, string OTP, string? PAN)
        //{
        //    var encryptedData = this.Encrypt1(data);

        //    string finalJson = JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented,
        //                  new JsonSerializerSettings
        //                  {
        //                      NullValueHandling = NullValueHandling.Ignore
        //                  });
        //    byte[] encodeJson = UTF8Encoding.UTF8.GetBytes(finalJson);
        //    string base64Payload = Convert.ToBase64String(encodeJson);
        //    HeaderData hdrdata = new HeaderData
        //    {
        //        clientid = GSTNConstants.client_id,
        //        username = provider.Username,
        //        state_cd = this.gstin.Substring(0, 2),
        //        txn = GSTNConstants.txn,//System.Guid.NewGuid().ToString().Replace("-", "");
        //        auth_token = provider.AuthToken,
        //        gstin = this.gstin,
        //        ret_period = this.ret_period,
        //        ip_usr = GSTNConstants.publicip,
        //        rtn_typ = "GSTR1",
        //        api_version = "1.1",
        //        userrole = "GSTR1",
        //    };
        //    var model = new
        //    {
        //        data = encryptedData,
        //        action = "RETFILE",
        //        st = "EVC",
        //        sign = EncryptionUtils.GetHash(base64Payload, PAN + "|" + OTP),
        //        sid = PAN + "|" + OTP,
        //        //hdr = hdrdata


        //    };

        //    var info = await this.PutAsync<object, ResponseDataInfo>(model);
        //    if (info == null)
        //    {
        //        throw new Exception("Unable to get the details from server");
        //    }
        //    var output = this.Decrypt<FileInfo>(info.Data);
        //    var model2 = this.BuildResult(info, output);
        //    return model2;
        //}
        public async Task<GSTNResult<dynamic>> GenerateSummary()
        {
            var data =
            new
            {
                action = "GENSUM"
            };
            var info = await this.PostAsync<object, dynamic>(data);
            if (info == null)
            {
                throw new Exception("Unable to get the details from server");
            }
            //var output = this.Decrypt<NewProceedToFile>(info.Data);
            //var result = this.BuildResult(info, output);
            return info;
        }

        //Garima 19 March 2024
        public async Task<GSTNResult<SaveInfo>> Reset_GSTR1(GenerateRequestInfo model)
        {
            var data = this.Encrypt(model);
            data.action = "RESET";
            string jsonData = JsonConvert.SerializeObject(data);
            var info = await this.PostAsync<string, ResponseDataInfo>(jsonData, "GSTR1", "1.1");
            if (info == null)
            {
                throw new Exception("Unable to get the details from server");
            }
            var output = this.Decrypt<SaveInfo>(info.Data);
            var result = this.BuildResult(info, output);
            return result;
        }

        //Garima Common API Code April 2024

        public async Task<GSTNResult<UploadDocumentResponse>> UploadDocument_Common1(UploadDocumentRequest model)
        {
            var data = this.Encrypt(model);
            data.action = "DOCUPLOAD";
            string jsonData = JsonConvert.SerializeObject(data);
            var info = await this.PostAsync<string, ResponseDataInfo>(jsonData);
            if (info == null)
            {
                throw new Exception("Unable to get the details from server");
            }
            var output = this.Decrypt<UploadDocumentResponse>(info.Data);
            var result = this.BuildResult(info, output);
            return result;
        }

        public async Task<GSTNResult<SaveUserMastersResponse>> SaveUserMaster_Common(SaveUserMastersRequest model)
        {
            var data = this.Encrypt(model);
            data.action = "SAVEMASTERS";
            string jsonData = JsonConvert.SerializeObject(data);
            var info = await this.PostAsync<string, ResponseDataInfo>(jsonData);
            if (info == null)
            {
                throw new Exception("Unable to get the details from server");
            }
            var output = this.Decrypt<SaveUserMastersResponse>(info.Data);
            var result = this.BuildResult(info, output);
            return result;
        }

        public async Task<GSTNResult<CreateNotificationResponse>> CreateNotification_Common(GetATGSTR1AResp model)
        {
            HeaderData hdrdata = new HeaderData
            {
                clientid = GSTNConstants.client_id,
                username = provider.Username,
                state_cd = this.gstin.Substring(0, 2),
                txn = GSTNConstants.txn,//System.Guid.NewGuid().ToString().Replace("-", "");
                auth_token = provider.AuthToken,
                gstin = this.gstin,
                ret_period = this.ret_period,
                ip_usr = GSTNConstants.publicip,
                rtn_typ = "CC",
                api_version = "1.0",
                userrole = "CC",
            };
            var data = this.Encrypt(model);
            data.action = "CCCREATE";
            data.hdr = hdrdata;
            string jsonData = JsonConvert.SerializeObject(data);
            var info = await this.PostAsync<string, ResponseDataInfo>(jsonData,"CC","1.0");
            if (info == null)
            {
                throw new Exception("Unable to get the details from server");
            }
            var output = this.Decrypt<CreateNotificationResponse>(info.Data);
            var result = this.BuildResult(info, output);
            return result;
        }

        public async Task<GSTNResult<DeleteNotiByIDsResponse>> DeleteNotiByIDs_Common(DeleteNotiByIDsRequest model)
        {
            HeaderData hdrdata = new HeaderData
            {
                clientid = GSTNConstants.client_id,
                username = provider.Username,
                state_cd = this.gstin.Substring(0, 2),
                txn = GSTNConstants.txn,//System.Guid.NewGuid().ToString().Replace("-", "");
                auth_token = provider.AuthToken,
                gstin = this.gstin,
                ret_period = this.ret_period,
                ip_usr = GSTNConstants.publicip,
                rtn_typ = "CC",
                api_version = "1.0",
                userrole = "CC",
            };
            var data = this.Encrypt(model);
            data.action = "CCDELNOTIF";
            data.hdr = hdrdata;
            string jsonData = JsonConvert.SerializeObject(data);
            var info = await this.PostAsync<string, ResponseDataInfo>(jsonData, "CC", "1.0");
            if (info == null)
            {
                throw new Exception("Unable to get the details from server");
            }
            var output = this.Decrypt<DeleteNotiByIDsResponse>(info.Data);
            var result = this.BuildResult(info, output);
            return result;
        }

        public async Task<GSTNResult<ProceedToFile>> ProceedToFile(GenerateRequestInfo1 model)
        {
            HeaderData hdrdata = new HeaderData
            {
                clientid = GSTNConstants.client_id,
                username = provider.Username,
                state_cd = this.gstin.Substring(0, 2),
                txn = GSTNConstants.txn,//System.Guid.NewGuid().ToString().Replace("-", "");
                auth_token = provider.AuthToken,
                gstin = this.gstin,
                ret_period = this.ret_period,
                ip_usr = GSTNConstants.publicip,
                rtn_typ = "GSTR1",
                api_version = "1.1",
                userrole = "GSTR1",
            };


            var data = this.Encrypt(model);
            data.hdr = hdrdata;
            data.action = "PROCEEDFILE";
            string jsonData = JsonConvert.SerializeObject(data);
            var info = await this.PostAsync<string, ResponseDataInfo>(jsonData, "CC", "1.1");
            if (info == null)
            {
                throw new Exception("Unable to get the details from server");
            }
            var output = this.Decrypt<ProceedToFile>(info.Data);
            var result = this.BuildResult(info, output);
            return result;
        }

        public async Task<GSTNResult<SavePreferenceResponse>> SavePreference1(SavePrefernceRequest data)
        {

            HeaderData hdrdata = new HeaderData
            {
                clientid = GSTNConstants.client_id,
                username = provider.Username,
                state_cd = this.gstin.Substring(0, 2),
                txn = GSTNConstants.txn,//System.Guid.NewGuid().ToString().Replace("-", "");
                auth_token = provider.AuthToken,
                gstin = this.gstin,
                ret_period = this.ret_period,
                ip_usr = GSTNConstants.publicip,
                rtn_typ = "GSTR1",
                api_version = "1.0",
                userrole = "GSTR1",
            };
            var model = this.Encrypt(data);
            model.action = "SAVEPREF";
            model.hdr = hdrdata;

            string jsonData = JsonConvert.SerializeObject(model);
            var info = await this.PostAsync<string, ResponseDataInfo>(jsonData, "GSTR1", "1.0");
            if (info == null)
            {
                throw new Exception("Unable to get the details from server");
            }
            var output = this.Decrypt<SavePreferenceResponse>(info.Data);
            var model2 = this.BuildResult<SavePreferenceResponse>(info, output);
            return model2;
        }

        public async Task<GSTNResult<SaveInfo>> Reset_GSTR1A(GenerateRequestInfo model)
        {
            var data = this.Encrypt(model);
            data.action = "R1ARESET";
            string jsonData = JsonConvert.SerializeObject(data);
            var info = await this.PostAsync<string, ResponseDataInfo>(jsonData, "GSTR1A", "1.0");
            if (info == null)
            {
                throw new Exception("Unable to get the details from server");
            }
            var output = this.Decrypt<SaveInfo>(info.Data);
            var result = this.BuildResult(info, output);
            return result;
        }

        public async Task<GSTNResult<ProceedToFileGSTR1A>> ProceedToFile_GSTR1A(GenerateRequestInfo model)
        {
            HeaderData hdrdata = new HeaderData
            {
                clientid = GSTNConstants.client_id,
                username = provider.Username,
                state_cd = this.gstin.Substring(0, 2),
                txn = GSTNConstants.txn,//System.Guid.NewGuid().ToString().Replace("-", "");
                auth_token = provider.AuthToken,
                gstin = this.gstin,
                ret_period = this.ret_period,
                ip_usr = GSTNConstants.publicip,
                rtn_typ = "GSTR1A",
                api_version = "1.0",
                userrole = "GSTR1A",
            };


            var data = this.Encrypt(model);
            data.hdr = hdrdata;
            data.action = "R1ARETNEWPTF";
            string jsonData = JsonConvert.SerializeObject(data);
            var info = await this.PostAsync<string, ResponseDataInfo>(jsonData, "GSTR1A", "1.0");
            if (info == null)
            {
                throw new Exception("Unable to get the details from server");
            }
            var output = this.Decrypt<ProceedToFileGSTR1A>(info.Data);
            var result = this.BuildResult(info, output);
            return result;
        }

        //public async Task<GSTNResult<FileInfo>> filegstr1A(GetGSTR1ASummaryResp data, string OTP, string? PAN)
        //{
        //    string finalJson = JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented,
        //                  new JsonSerializerSettings
        //                  {
        //                      NullValueHandling = NullValueHandling.Ignore
        //                  });
        //    byte[] encodeJson = UTF8Encoding.UTF8.GetBytes(finalJson);
        //    string base64Payload = Convert.ToBase64String(encodeJson);

        //    var data1 = this.Encrypt2(data);
        //    data1.action = "RETFILER1A";
        //    data1.st = "EVC";
        //    data1.sign = EncryptionUtils.GenerateHMAC(base64Payload, PAN + "|" + OTP);
        //    data1.sid = PAN + "|" + OTP;

        //    string jsonData = JsonConvert.SerializeObject(data1);
        //    var info = await this.PostAsync<string, ResponseDataInfo>(jsonData);

        //    if (info == null)
        //    {
        //        throw new Exception("Unable to get the details from server");
        //    }
        //    var output = this.Decrypt<FileInfo>(info.Data);
        //    var model2 = this.BuildResult(info, output);
        //    return model2;
        //}

        public async Task<GSTNResult<GSTRIMS_Reset_Response>> Reset_GSTRIMS(ResetRequest model)
        {
            var data = this.Encrypt(model);
            data.action = "RESETIMS";
            string jsonData = JsonConvert.SerializeObject(data);
            var info = await this.PostAsync<string, ResponseDataInfo>(jsonData, "GSTRIMS", "1.0");
            if (info == null)
            {
                throw new Exception("Unable to get the details from server");
            }
            var output = this.Decrypt<GSTRIMS_Reset_Response>(info.Data);
            var result = this.BuildResult(info, output);
            return result;
        }
    }
}
