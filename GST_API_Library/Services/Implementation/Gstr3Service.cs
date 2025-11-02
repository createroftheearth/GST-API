using AutoMapper;
using AutoMapper;
using GST_API_DAL.Models;
using GST_API_DAL.Repository.Interfaces;
using GST_API_Library.Models;
using GST_API_Library.Models.GSTR1DTO;
using GST_API_Library.Models.GSTR3B;
using GST_API_Library.Models.GSTR3DTO;
using GST_API_Library.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace GST_API_Library.Services.Implementation
{
    enum GSTR3Status
    {
        DbSave = -1,
        save = 0,
        proceedTofile = 1,
        otpSent = 2,
        filed = 3,
    }
    public class Gstr3Service : BaseService, IGstr3Service
    {
        private readonly IGSTR3Repository _gSTR3Repository;
        private readonly UserManager<User> _userManager;
        public Gstr3Service(IGSTR3Repository gSTR3Repository,
            IHttpContextAccessor httpContextAccessor,
            UserManager<User> userManager
            ) : base(httpContextAccessor)
        {
            _gSTR3Repository = gSTR3Repository;
            _userManager = userManager;
        }

        public async Task<(bool IsSucess, string Message, GetGSTR3BDetails data)> GetGstr3BDataByGSTIN(GSTR3BASPRequest request, string url)
        {
            if (string.IsNullOrEmpty(request.gstin) && string.IsNullOrEmpty(request.ret_period))
            {
                return (false, "Empty GSTIN or Financial Year", null);
            }

            GSTNAuthClient client = new GSTNAuthClient(gstin, this.gstinUsername, this.appKey)
            {
                AuthToken = this.GSTINToken,
                DecryptedKey = EncryptionUtils.AesDecrypt(this.GSTINSek, this.appKey)
            };

            GSTR3BApiClient client2 = new GSTR3BApiClient(client, gstin, request.ret_period, url);

            APIRequestParameters gstr3Request = new()
            {
                gstin = gstin,
                ret_period = request.ret_period
            };

            var info = await client2.GetGSTR3BDetails(gstr3Request);

            if (info == null || info?.Data == null)
            {
                return (IsSucess: false, Message: "Empty Record", null);
            }
            else
            {
                // Map GST_API_Library.Models.GSTR3B.GetGSTR3BDetails to GST_API_DAL.Models.Gstr3BDetails
                //var config = new MapperConfiguration(cfg =>
                //{
                //    cfg.AddProfile<Gstr3BMappingProfile>();
                //});

                //var mapper = config.CreateMapper();
             //   Gstr3BDetails mappedData = mapper.Map<Gstr3BDetails>(info.Data);
                //Gstr3BDetails mappedData = MapToGstr3BDetails(info.Data);
                 return (true, "Success", info.Data);
            }
        }

        public async Task<(bool IsSuccess, string Message)> SaveGSTR3Async(Gstr3Dto gstr3SaveDto)
        {
            // Check if an entry with the same GSTINNo and FinancialPeriod exists
            //var existingEntry = await _gSTR3Repository.FindAsync(
            //    x => x.GSTINNo == gstr3SaveDto.GSTINNo &&
            //         x.FinancialPeriod.Year == gstr3SaveDto.FinancialPeriod.Year && x.FinancialPeriod.Month == gstr3SaveDto.FinancialPeriod.Month);

            //if (existingEntry != null)
            //{
            //    return (false, "An entry with the same GSTIN and Financial Period already exists.");
            //}

            // Map Gstr1Dto to Gstr1 entity
            // Replace this line in SaveGSTR3Async:
            // FinancialPeriod = gstr3SaveDto.FinancialPeriod,

           
            var newGstr3 = new Gstr3
            {
                GSTINNo = gstr3SaveDto.GSTINNo,
                FinancialPeriod =  gstr3SaveDto.FinancialPeriod,
                Gstr3SaveRequest = gstr3SaveDto.GSTINNo + " " + gstr3SaveDto.FinancialPeriod,
                GetGSTR3Request = gstr3SaveDto.GSTINNo + " " + gstr3SaveDto.FinancialPeriod,
                GetGSTR3Response =  gstr3SaveDto.GetGstr3Response,
            };

            // Add the new entry to the database
            await _gSTR3Repository.AddAsyn(newGstr3);
            return (true, "GSTR3 entry saved successfully.");
        }

        private Gstr3BDetails MapToGstr3BDetails(GetGSTR3BDetails source)
        {
            if (source == null) return null;

            return new Gstr3BDetails
            {
                gstin = source.gstin,
                ret_period = source.ret_period,
                // Use helper mappers for nested structures (they handle nulls)
                sup_details = MapSupDetails(source.sup_details),
                inter_sup = MapInterSup(source.inter_sup),
                eco_dtls = MapEcoDtls(source.eco_dtls),
                itc_elg = MapItcElg(source.itc_elg),
                inward_sup = MapInwardSup(source.inward_sup),
                tx_pmt = MapTxPmt(source.tx_pmt),
                intr_ltfee = MapIntrLtfee(source.intr_ltfee),
                liab_breakup = MapLiabBreakupList(source.liab_breakup)
            };
        }

        // Replace the MapSupDetails method with a mapping from GST_API_Library.Models.GSTR3B.SupDetails to GST_API_DAL.Models.SupDetails
        private GST_API_DAL.Models.SupDetails44 MapSupDetails(GST_API_Library.Models.GSTR3B.SupDetails44 src)
        {
            if (src == null) return null;

#pragma warning disable CS8601 // Possible null reference assignment.
            return new GST_API_DAL.Models.SupDetails44
            {
                osup_det = src.osup_det == null ? null : new GST_API_DAL.Models.OsupDet44
                {
                    // Map properties as needed, e.g.:
                    // prop1 = src.osup_det.prop1,
                    // prop2 = src.osup_det.prop2,
                },
                osup_zero = src.osup_zero == null ? null : new GST_API_DAL.Models.OsupZero44
                {
                    // Map properties as needed
                },
                osup_nil_exmp = src.osup_nil_exmp == null ? null : new GST_API_DAL.Models.OsupNilExmp44
                {
                    // Map properties as needed
                },
                isup_rev = src.isup_rev == null ? null : new GST_API_DAL.Models.IsupRev44
                {
                    // Map properties as needed
                },
                osup_nongst = src.osup_nongst == null ? null : new GST_API_DAL.Models.OsupNongst44
                {
                }
            };
#pragma warning restore CS8601 // Possible null reference assignment.
        }

        private GST_API_DAL.Models.InterSup44 MapInterSup(GST_API_Library.Models.GSTR3B.InterSup44 src)
        {
            if (src == null) return null;

            return new GST_API_DAL.Models.InterSup44
            {
                unreg_details = src.unreg_details == null ? null : new List<GST_API_DAL.Models.UnregDetail44>(),
                comp_details = src.comp_details == null ? null : new List<GST_API_DAL.Models.CompDetail44>(),
                uin_details = src.uin_details == null ? null : new List<GST_API_DAL.Models.UinDetail44>()
            };
        }

        private GST_API_DAL.Models.EcoDtls44 MapEcoDtls(GST_API_Library.Models.GSTR3B.EcoDtls44 src)
        {
            if (src == null) return null;

#pragma warning disable CS8601 // Possible null reference assignment.
            return new GST_API_DAL.Models.EcoDtls44
            {
                eco_sup = src.eco_sup == null ? null : new GST_API_DAL.Models.EcoSup44
                {
                    txval = src.eco_sup.txval,
                    iamt = src.eco_sup.iamt,
                    camt = src.eco_sup.camt,
                    samt = src.eco_sup.samt,
                    csamt = src.eco_sup.csamt
                },
                eco_reg_sup = src.eco_reg_sup == null ? null : new GST_API_DAL.Models.EcoRegSup44
                {
                    txval = src.eco_reg_sup.txval
                }
            };
#pragma warning restore CS8601 // Possible null reference assignment.
        }

        private GST_API_DAL.Models.ItcElg44 MapItcElg(GST_API_Library.Models.GSTR3B.ItcElg44 src)
        {
            if (src == null) return null;

#pragma warning disable CS8601 // Possible null reference assignment.
            return new GST_API_DAL.Models.ItcElg44
            {
                itc_avl = src.itc_avl == null ? null : new List<GST_API_DAL.Models.ItcAvl44>(),
                itc_rev = src.itc_rev == null ? null : new List<GST_API_DAL.Models.ItcRev44>(),
                itc_net = src.itc_net == null ? null : new GST_API_DAL.Models.ItcNet44
                {
                },
                itc_inelg = src.itc_inelg == null ? null : new List<GST_API_DAL.Models.ItcInelg44>()
            };
#pragma warning restore CS8601 // Possible null reference assignment.
        }

        private GST_API_DAL.Models.InwardSup44 MapInwardSup(GST_API_Library.Models.GSTR3B.InwardSup44 src)
        {
            if (src == null) return null;

            return new GST_API_DAL.Models.InwardSup44
            {
                isup_details = src.isup_details == null ? null : []
            };
        }

        private GST_API_DAL.Models.TxPmt44 MapTxPmt(GST_API_Library.Models.GSTR3B.TxPmt44 src)
        {
            if (src == null) return null;

#pragma warning disable CS8601 // Possible null reference assignment.
            return new GST_API_DAL.Models.TxPmt44
            {
                tx_py = src.tx_py == null ? null : [],
                adjnegliab = src.adjnegliab == null ? null : new List<GST_API_DAL.Models.Adjnegliab44>(),
                nettaxpay = src.nettaxpay == null ? null : new List<GST_API_DAL.Models.Nettaxpay44>(),
                pdcash = src.pdcash == null ? null : new List<GST_API_DAL.Models.Pdcash44>(),
                pditc = src.pditc == null ? null : null, // Map if needed
                pdnls = src.pdnls == null ? null : new List<GST_API_DAL.Models.Pdnl44>()
            };
#pragma warning restore CS8601 // Possible null reference assignment.
        }

        private GST_API_DAL.Models.IntrLtfee44 MapIntrLtfee(GST_API_Library.Models.GSTR3B.IntrLtfee44 src)
        {
            if (src == null) return null;

#pragma warning disable CS8601 // Possible null reference assignment.
            return new GST_API_DAL.Models.IntrLtfee44
            {
                intr_details = src.intr_details == null ? null : new GST_API_DAL.Models.IntrDetails44
                {
                    iamt = src.intr_details.iamt,
                    camt = src.intr_details.camt,
                    samt = src.intr_details.samt,
                    csamt = src.intr_details.csamt
                },
                ltfee_details = src.ltfee_details == null ? null : new GST_API_DAL.Models.LtfeeDetails44
                {
                    // Copy properties if present on LtfeeDetails; adjust if structure differs
                }
            };
#pragma warning restore CS8601 // Possible null reference assignment.
        }

        private List<GST_API_DAL.Models.LiabBreakup44> MapLiabBreakupList(List<GST_API_Library.Models.GSTR3B.LiabBreakup44> src)
        {
            if (src == null) return null;
            var result = new List<GST_API_DAL.Models.LiabBreakup44>();
            foreach (var item in src)
            {
#pragma warning disable CS8601 // Possible null reference assignment.
                result.Add(new GST_API_DAL.Models.LiabBreakup44
                {
                    ret_period = item.ret_period,
                    liability = item.liability == null ? null : new GST_API_DAL.Models.Liability44
                    {
                        iamt = item.liability.iamt,
                        camt = item.liability.camt,
                        samt = item.liability.samt,
                        csamt = item.liability.csamt
                    }
                });
#pragma warning restore CS8601 // Possible null reference assignment.
            }
            return result;
        }

    }
}