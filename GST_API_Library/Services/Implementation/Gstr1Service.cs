using GST_API_DAL.Repository.Interfaces;
using GST_API_Library.Models.GSTR1DTO;
using GST_API_DAL.Models;
using Newtonsoft.Json;
using Microsoft.VisualBasic;
using Microsoft.AspNetCore.Http;
using GST_API_Library.Models.GSTR1;
using GST_API_Library.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using GST_API_Library.Models;
using Newtonsoft.Json.Linq;

namespace GST_API_Library.Services.Implementation
{
    enum GSTR1Status
    {
        DbSave = -1,
        save = 0,
        proceedTofile = 1,
        otpSent = 2,
        filed = 3,
    }
    public class Gstr1Service : BaseService, IGstr1Service
    {
        private readonly IGSTR1Repository _gSTR1Repository;
        private readonly UserManager<User> _userManager;
        public Gstr1Service(IGSTR1Repository gSTR1Repository,
            IHttpContextAccessor httpContextAccessor,
            UserManager<User> userManager
            ) : base(httpContextAccessor)
        {
            _gSTR1Repository = gSTR1Repository;
            _userManager = userManager;
        }

        public async Task<(bool IsSuccess, string Message)> SaveGSTR1Async(Gstr1Dto gstr1SaveDto)
        {
            // Check if an entry with the same GSTINNo and FinancialPeriod exists
            var existingEntry = await _gSTR1Repository.FindAsync(
                x => x.GSTINNo == gstr1SaveDto.GSTINNo &&
                     x.FinancialPeriod.Year == gstr1SaveDto.FinancialPeriod.Year && x.FinancialPeriod.Month == gstr1SaveDto.FinancialPeriod.Month);

            if (existingEntry != null)
            {
                return (false, "An entry with the same GSTIN and Financial Period already exists.");
            }

            // Map Gstr1Dto to Gstr1 entity
            var newGstr1 = new Gstr1
            {
                GSTINNo = gstr1SaveDto.GSTINNo,
                FinancialPeriod = gstr1SaveDto.FinancialPeriod,
                Gstr1SaveRequest = gstr1SaveDto.RequestBody,
                SaveGstr1Status = (int)GSTR1Status.DbSave
            };

            // Add the new entry to the database
            await _gSTR1Repository.AddAsyn(newGstr1);
            return (true, "GSTR1 entry saved successfully.");
        }

        public List<Gstr1> GetAllGstr1Data(int page, int pageSize, out int totalRecords)
        {
            return _gSTR1Repository.Filter(null, out totalRecords, page - 1, pageSize).ToList();
        }

        public async Task<(bool IsSucess, string Message)> SubmitGSTR1(int id, string url)
        {
            try
            {
                var gstr1Data = await _gSTR1Repository.FindAsync(match => match.Id == id);
                if (gstr1Data == null)
                {
                    return (false, "Data does not exists");
                }
                string json = gstr1Data.Gstr1SaveRequest;
                // dynamic gstr1Payload = JsonConvert.DeserializeObject<dynamic>(json);
                JObject gstr1Payload = JObject.Parse(json);
                string gstin = gstr1Payload["gstin"].ToString();
                string fp = gstr1Payload["fp"].ToString();

                GSTNAuthClient client = new GSTNAuthClient(gstin, this.gstinUsername, appKey)
                {
                    AuthToken = this.GSTINToken,
                    DecryptedKey = EncryptionUtils.AesDecrypt(this.GSTINSek, appKey)
                };
                GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, fp, url);
                var info = await client2.Save(gstr1Payload);
                if (string.IsNullOrEmpty(info?.Data?.reference_id))
                {
                    var errorMessage = (info?.error?.error_cd ?? "") + " :: " + (info?.error?.message ?? "");
                    return (false, string.IsNullOrEmpty(errorMessage) ? "Failed to save on GSTR1 server" : errorMessage);
                }
                gstr1Data.SaveGstr1Status = (int)GSTR1Status.save;
                gstr1Data.SaveGstr1Reponse = JsonConvert.SerializeObject(info.Data);
                await _gSTR1Repository.UpdateAsyn(gstr1Data, gstr1Data.Id);
                return (true, "Successfully saved on GSTR1 server");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<(bool IsSucess, string Message)> ProceedToFile(int id, string url)
        {
            var gstr1Data = await _gSTR1Repository.FindAsync(match => match.Id == id);
            if (gstr1Data == null)
            {
                return (false, "Data does not exists");
            }
            dynamic gstr1Payload = JsonConvert.DeserializeObject<dynamic>(gstr1Data.Gstr1SaveRequest);
            GSTNAuthClient client = new GSTNAuthClient(gstin, this.gstinUsername, appKey)
            {
                AuthToken = this.GSTINToken,
                DecryptedKey = EncryptionUtils.AesDecrypt(this.GSTINSek, appKey)
            };
            GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstr1Payload.gstin, gstr1Payload.fp, url);
            var newProceedToFileRequest = new Models.GenerateRequestInfo
            {
                gstin = gstr1Payload.gstin,
                ret_period = gstr1Payload.fp,
            };
            var info = await client2.NewProceedToFile_GSTR1(newProceedToFileRequest);
            if (string.IsNullOrEmpty(info?.Data?.reference_id))
            {
                var errorMessage = (info?.error?.error_cd ?? "") + " :: " + (info?.error?.message ?? "");
                return (false, string.IsNullOrEmpty(errorMessage) ? "Failed to save on GSTR1 server" : errorMessage);
            }
            gstr1Data.SaveGstr1Status = (int)GSTR1Status.proceedTofile;
            gstr1Data.NewProceedToFileGstr1Request = JsonConvert.SerializeObject(newProceedToFileRequest);
            gstr1Data.NewProceedToFileGstr1Reponse = JsonConvert.SerializeObject(info.Data);
            await _gSTR1Repository.UpdateAsyn(gstr1Data, gstr1Data.Id);
            return (true, "Proceed to File Successfully on GSTR1 server");
        }

        public async Task<(bool? isSuccess, string message, GetGSTR1SummaryRes? data)> GenerateEVCOTP(PanRequest request, string getSumURL)
        {
            var gstr1Data = await _gSTR1Repository.FindAsync(match => match.Id == request.id);
            if (gstr1Data == null)
            {
                return (false, "Data does not exists",null);
            }
            var ret_period = gstr1Data.FinancialPeriod.ToString("MMyyyy");
            GSTNAuthClient client = new GSTNAuthClient(gstin, gstinUsername, appKey);
            GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin,ret_period , getSumURL);
            var info = await client2.GetGSTR1Summary1(new APIRequestParameters
            {
                gstin = gstr1Data.GSTINNo,
                ret_period = ret_period,
            });
            if(info?.Data == null)
            {
                return (false, "Unable to Get Summary", null);
            }
            var data = new EVCAuthenticationModel
            {
                form_type = "R1",
                gstin = gstr1Data.GSTINNo,
                pan = request.panNo
            };
            GSTNResult<BaseResponseModel> result = await client.RequestOTPForEVC(data, GSTINToken);
            if (result?.Data?.error?.error_cd == "OTP0010")
            {
                return (false, message: result?.Data?.error?.message,null);
            }

            else if (result?.Data.status_cd == "1")
            {
                return (true, message: "Success",info.Data);
            }
            else
            {
                return (false, message: result?.error?.message,null);
            }

        }
    }
}
