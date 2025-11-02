using GST_API_DAL.Models;
using GST_API_DAL.Repository.Interfaces;
using GST_API_Library.Models;
using GST_API_Library.Models.GSTR1;
using GST_API_Library.Models.GSTR1DTO;
using GST_API_Library.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Globalization;

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

        public async Task<(bool IsSucess, string Message)> SubmitGSTR1(int? id, string url)
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<(bool IsSucess, string Message)> ProceedToFile(Request request, string url)
        {
            string? gstin = string.Empty;
            string? fp = string.Empty;
            string? isnil = string.Empty;
            Gstr1? gstr1Data = null;

            if (request?.isnil == "N")
            {
                gstr1Data = await _gSTR1Repository.FindAsync(match => match.Id == request.id);
            }

            if (gstr1Data != null)
            {
                string json = gstr1Data.Gstr1SaveRequest;
                JObject gstr1Payload = JObject.Parse(json);
                gstin = gstr1Payload["gstin"]?.ToString();
                fp = gstr1Payload["fp"]?.ToString();
            }
            else
            {
                gstin = request?.gstin;
                fp = request?.ret_period;
                isnil = request?.isnil;
            }

            GSTNAuthClient client = new GSTNAuthClient(gstin, this.gstinUsername, appKey)
            {
                AuthToken = this.GSTINToken,
                DecryptedKey = EncryptionUtils.AesDecrypt(this.GSTINSek, appKey)
            };
            GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, fp, url);
            GenerateRequestInfo newProceedToFileRequest = null;

            if (request?.isnil == "N")
            {
                newProceedToFileRequest = new Models.GenerateRequestInfo
                {
                    gstin = gstin,
                    ret_period = fp
                };
            }
            else
            {
                newProceedToFileRequest = new Models.GenerateRequestInfo
                {
                    gstin = gstin,
                    ret_period = fp,
                    isnil = "Y"
                };
            }

            var info = await client2.NewProceedToFile_GSTR1(newProceedToFileRequest);
            if (string.IsNullOrEmpty(info?.Data?.reference_id))
            {
                var errorMessage = (info?.error?.error_cd ?? "") + " :: " + (info?.error?.message ?? "");
                return (false, string.IsNullOrEmpty(errorMessage) || errorMessage == " :: " ? "Failed to save on GSTR1 server" : errorMessage);
            }
            if (request?.isnil == "N" && gstr1Data != null)
            {
                gstr1Data.SaveGstr1Status = (int)GSTR1Status.proceedTofile;
                gstr1Data.NewProceedToFileGstr1Request = JsonConvert.SerializeObject(newProceedToFileRequest);
                gstr1Data.NewProceedToFileGstr1Reponse = JsonConvert.SerializeObject(info.Data);
                await _gSTR1Repository.UpdateAsyn(gstr1Data, gstr1Data.Id);
            }
            else
            {
                string fullDate = "01" + fp;
                if (!DateTime.TryParseExact(fullDate, "ddMMyyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime customDateValue))
                {
                    throw new FormatException($"Invalid date format: '{fullDate}'");
                }

                var newGstr1 = new Gstr1
                {
                    GSTINNo = gstin,
                    FinancialPeriod = customDateValue,
                    SaveGstr1Status = (int)GSTR1Status.DbSave,
                    NewProceedToFileGstr1Request = JsonConvert.SerializeObject(newProceedToFileRequest),
                    Gstr1SaveRequest = "NIL",
                    NewProceedToFileGstr1Reponse = JsonConvert.SerializeObject(info.Data)
                };
                await _gSTR1Repository.AddAsyn(newGstr1);
            }
            return (true, "Proceed to File Successfully on GSTR1 server");
        }

        public async Task<(bool IsSucess, string Message)> GSTR1File(Gstr1Request request, string getFileURL)
        {
            var gstr1Data = await _gSTR1Repository.FindAsync(match => match.Id == request.id);
            string gstin = string.Empty;
            string fp = string.Empty;
            string getSummaryJson = string.Empty;
            GetGSTR1SummaryRes summaryObject = new();
            var info = new GSTNResult<GST_API_Library.Models.FileInfo>();
            if (gstr1Data != null)
            {
                string json = gstr1Data.Gstr1SaveRequest;
                JObject gstr1Payload = JObject.Parse(json);
                gstin = gstr1Payload["gstin"].ToString();
                fp = gstr1Payload["fp"].ToString();
                getSummaryJson = gstr1Data.GetSummaryResponse;
            }
            else
            {
                gstin = request.Data.gstin;
                fp = request.Data.ret_period;
            }

            GSTNAuthClient client = new GSTNAuthClient(gstin, gstinUsername, appKey)
            {
                AuthToken = this.GSTINToken,
                DecryptedKey = EncryptionUtils.AesDecrypt(this.GSTINSek, appKey)
            };
            GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, fp, getFileURL);

            if (!string.IsNullOrEmpty(getSummaryJson))
            {
                summaryObject = JsonConvert.DeserializeObject<GetGSTR1SummaryRes>(getSummaryJson);
                info = await client2.filegstr1(summaryObject, request.OTP, request.PAN);
            }
            else
            {
               info = await client2.filegstr1(new GetGSTR1SummaryRes
                {
                    gstin = request.Data.gstin,
                    ret_period = request.Data.ret_period,
                    chksum = request.Data.chksum,
                    //smryTyp = request.Data.smryTyp,
                    newSumFlag = request.Data.newSumFlag,
                    sec_sum = request.Data.sec_sum?.Select(dto => new SecSum
                    {
                        sec_nm = dto.sec_nm,
                        chksum = dto.chksum,
                        ttl_rec = dto.ttl_rec,
                        ttl_tax = dto.ttl_tax,
                        ttl_igst = dto.ttl_igst,
                        ttl_sgst = dto.ttl_sgst,
                        ttl_cgst = dto.ttl_cgst,
                        ttl_val = dto.ttl_val,
                        ttl_cess = dto.ttl_cess,
                        act_tax = dto.act_tax,
                        act_igst = dto.act_igst,
                        act_sgst = dto.act_sgst,
                        act_cgst = dto.act_cgst,
                        act_val = dto.act_val,
                        act_cess = dto.act_cess,
                        cpty_sum = dto.cpty_sum?.Select(cs => new CptySum
                        {
                            ctin = cs.ctin,
                            chksum = cs.chksum,
                            ttl_rec = cs.ttl_rec,
                            ttl_tax = cs.ttl_tax,
                            ttl_igst = cs.ttl_igst,
                            ttl_sgst = cs.ttl_sgst,
                            ttl_cgst = cs.ttl_cgst,
                            ttl_val = cs.ttl_val,
                            ttl_cess = cs.ttl_cess
                        }).ToList() ?? new List<CptySum>(),
                        sub_sections = dto.sub_sections?.Select(ss => new SubSection
                        {
                            sec_nm = ss.sec_nm,
                            chksum = ss.chksum,
                            ttl_rec = ss.ttl_rec,
                            ttl_tax = ss.ttl_tax,
                            ttl_igst = ss.ttl_igst,
                            ttl_sgst = ss.ttl_sgst,
                            ttl_cgst = ss.ttl_cgst,
                            ttl_val = ss.ttl_val,
                            ttl_cess = ss.ttl_cess,
                            act_tax = ss.act_tax,
                            act_igst = ss.act_igst,
                            act_sgst = ss.act_sgst,
                            act_cgst = ss.act_cgst,
                            act_val = ss.act_val,
                            act_cess = ss.act_cess,
                            typ = ss.typ,
                        }).ToList() ?? new List<SubSection>(),
                    }).ToList() ?? new List<SecSum>()
                }, request.OTP, request.PAN);
            }
            if (info == null || info?.Data == null || info?.Data.error != null)
            {
                return (IsSucess: false, Message: info?.Data.error.message);
            }
            else
            {
                //TODO : Will needs to update ack number and status
                gstr1Data.ReferenceId = info?.Data.ack_num;//Needs to be check Reference ID
                await _gSTR1Repository.UpdateAsyn(gstr1Data, gstr1Data.Id);
                return (IsSucess: true, Message: info?.Data?.ack_num);
            }
        }

        public async Task<(bool IsSucess, string Message)> GSTR1NilFile(Gstr1NilRequest request, string getFileURL)
        {
            string gstin = string.Empty;
            string fp = string.Empty;

            if (request == null)
            {
                return (IsSucess: false, Message: "Request data is null");
            }
            GSTNAuthClient client = new GSTNAuthClient(gstin, gstinUsername, appKey)
            {
                AuthToken = this.GSTINToken,
                DecryptedKey = EncryptionUtils.AesDecrypt(this.GSTINSek, appKey)
            };
            GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, fp, getFileURL);

            var info = await client2.filegstr1(new GetGSTR1SummaryRes
            {
                gstin = request.Data.gstin,
                ret_period = request.Data.ret_period,
                chksum = request.Data.chksum,
                //smryTyp = request.Data.smryTyp,
                newSumFlag = request.Data.newSumFlag,
                sec_sum = request.Data.sec_sum?.Select(dto => new SecSum
                {
                    sec_nm = dto.sec_nm,
                    chksum = dto.chksum,
                    ttl_rec = dto.ttl_rec,
                    ttl_tax = dto.ttl_tax,
                    ttl_igst = dto.ttl_igst,
                    ttl_sgst = dto.ttl_sgst,
                    ttl_cgst = dto.ttl_cgst,
                    ttl_val = dto.ttl_val,
                    ttl_cess = dto.ttl_cess,
                    act_tax = dto.act_tax,
                    act_igst = dto.act_igst,
                    act_sgst = dto.act_sgst,
                    act_cgst = dto.act_cgst,
                    act_val = dto.act_val,
                    act_cess = dto.act_cess,
                    cpty_sum = dto.cpty_sum?.Select(cs => new CptySum
                    {
                        ctin = cs.ctin,
                        chksum = cs.chksum,
                        ttl_rec = cs.ttl_rec,
                        ttl_tax = cs.ttl_tax,
                        ttl_igst = cs.ttl_igst,
                        ttl_sgst = cs.ttl_sgst,
                        ttl_cgst = cs.ttl_cgst,
                        ttl_val = cs.ttl_val,
                        ttl_cess = cs.ttl_cess
                    }).ToList() ?? new List<CptySum>(),
                    sub_sections = dto.sub_sections?.Select(ss => new SubSection
                    {
                        sec_nm = ss.sec_nm,
                        chksum = ss.chksum,
                        ttl_rec = ss.ttl_rec,
                        ttl_tax = ss.ttl_tax,
                        ttl_igst = ss.ttl_igst,
                        ttl_sgst = ss.ttl_sgst,
                        ttl_cgst = ss.ttl_cgst,
                        ttl_val = ss.ttl_val,
                        ttl_cess = ss.ttl_cess,
                        act_tax = ss.act_tax,
                        act_igst = ss.act_igst,
                        act_sgst = ss.act_sgst,
                        act_cgst = ss.act_cgst,
                        act_val = ss.act_val,
                        act_cess = ss.act_cess,
                        typ = ss.typ,
                    }).ToList() ?? new List<SubSection>(),
                }).ToList() ?? new List<SecSum>()
            }, request.OTP, request.PAN);

            if (info == null || info?.Data == null || info?.Data.error != null)
            {
                return (IsSucess: false, Message: info?.Data.error.message);
            }
            else
            {
                return (IsSucess: true, Message: info?.Data?.ack_num);
            }
        }

        public async Task<(bool IsSucess, string Message, GetGSTR1SummaryRes? data)> GenerateEVCOTP(PanRequest request, string getSumURL)
        {
            string gstin = string.Empty;
            string ret_period = string.Empty;

            var gstr1Data = await _gSTR1Repository.FindAsync(match => match.Id == request.id);

            if (gstr1Data != null)
            {
                string json = gstr1Data.Gstr1SaveRequest;
                JObject gstr1Payload = JObject.Parse(json);

                gstin = gstr1Payload["gstin"].ToString();
                ret_period = gstr1Payload["fp"].ToString();

            }
            else
            {
                ret_period = request.ret_period;
                gstin = request.gstin;
            }

            GSTNAuthClient client = new GSTNAuthClient(gstin, this.gstinUsername, appKey)
            {
                AuthToken = this.GSTINToken,
                DecryptedKey = EncryptionUtils.AesDecrypt(this.GSTINSek, appKey)
            };

            GSTR1ApiClient client2 = new GSTR1ApiClient(client, gstin, ret_period, getSumURL);
            var info = await client2.GetGSTR1Summary1(new APIRequestParameters
            {
                gstin = gstin,
                ret_period = ret_period,
                action_required = null,
                ctin = null,
                from_time = null,
                state_cd = null,
                file_num = null,
                smrytyp = null,
                sub_section = null,
                rtin = null,
                sec = null
            });
            if (info?.Data?.gstin == null && info?.Data?.chksum == null && info?.Data?.ret_period == null)
            {
                return (false, "Unable to Get Summary", null);
            }
            var data = new EVCAuthenticationModel
            {
                form_type = "R1",
                gstin = gstin,
                pan = request.panNo
            };
            GSTNResult<BaseResponseModel> result = await client.RequestOTPForEVC(data, GSTINToken);
            if (result?.Data?.error?.error_cd == "OTP0010")
            {
                return (false, Message: result?.Data?.error?.message, null);
            }
            else if (result?.HttpStatusCode == 504)
            {
                return (false, "Please try sometimes.", null);
            }
            else if (result?.Data.status_cd == "1")
            {
                gstr1Data.GetSummaryResponse = JsonConvert.SerializeObject(info.Data);
                //gstr1Data.ReferenceId = result.Data.status_cd;//Needs to be check Reference ID
                await _gSTR1Repository.UpdateAsyn(gstr1Data, gstr1Data.Id);
                return (true, Message: "Success", info.Data);
            }
            else
            {
                return (false, Message: result?.error?.message, null);
            }

        }
    }
}
