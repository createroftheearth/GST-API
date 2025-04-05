using GST_API_DAL.Repository.Interfaces;
using GST_API_Library.Models.GSTR1DTO;
using GST_API_DAL.Models;
using Newtonsoft.Json;
using Microsoft.VisualBasic;
using Microsoft.AspNetCore.Http;
using GST_API_Library.Models.GSTR1;

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

        public Gstr1Service(IGSTR1Repository gSTR1Repository, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _gSTR1Repository = gSTR1Repository;
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
            return _gSTR1Repository.Filter(filter => true, out totalRecords, page - 1, pageSize).ToList();
        }

        public async Task<(bool IsSucess, string Message)> SubmitGSTR1(int id, string url)
        {
            resolveValues();
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
            var info = await client2.Save(gstr1Payload);
            if (string.IsNullOrEmpty(info?.Data?.reference_id))
            {
                var errorMessage = (info?.error?.error_cd ?? "") + " :: " + (info?.error?.message ?? "");
                return (false, string.IsNullOrEmpty(errorMessage)?"Failed to save on GSTR1 server":errorMessage);
            }
            gstr1Data.SaveGstr1Status = (int)GSTR1Status.save;
            gstr1Data.SaveGstr1Reponse = JsonConvert.SerializeObject(info.Data);
            await _gSTR1Repository.UpdateAsyn(gstr1Data, gstr1Data.Id);
            return (true, "Successfully saved on GSTR1 server");
        }

        public async Task<(bool IsSucess, string Message)> ProceedToFile(int id, string url)
        {
            resolveValues();
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



    }
}
