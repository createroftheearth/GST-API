using GST_API_Library.Models;
using GST_API_Library.Models.GSTR1;
using GST_API_Library.Models.GSTR1A;
using Integrated.API.GSTN.GSTR1;
using Integrated.API.GSTN.GSTR1A;
using Newtonsoft.Json;
using System.Globalization;
using System.Text;
using FileInfo = GST_API_Library.Models.FileInfo;

namespace GST_API_Library.Services
{
    public class GSTR1aApiClient : GSTNReturnsClient
    {
        //"/taxpayerapi/v2.1/returns/gstr1"
        //action_required=“Y|N“
        public GSTR1aApiClient(IGSTNAuthProvider provider, string gstin, string ret_period, string URL)
            : base(provider, URL, gstin, ret_period)
        {
        }

        public async Task<GSTNResult<SaveInfo>> Save1A(GSTR1ATotal data)
        {
            var model = this.Encrypt(data);
            model.action = "R1ARETSAVE";
            var info = await this.PutAsync<UnsignedDataInfo, ResponseDataInfo>(model);
            if (info == null)
            {
                throw new Exception("Unable to get the details from server");
            }
            var output = this.Decrypt<SaveInfo>(info.Data);
            var model2 = this.BuildResult<SaveInfo>(info, output);
            return model2;
        }

        private Dictionary<string, string> prepareATDictionary(APIRequestParameters1A apiRequestParameters)
        {
            if (apiRequestParameters == null || string.IsNullOrEmpty(apiRequestParameters.gstin) || string.IsNullOrEmpty(apiRequestParameters.ret_period))
            {
                throw new Exception("gstin and ret_period is required");
            }
            var dic = new Dictionary<string, string>
            {
                { "gstin", apiRequestParameters.gstin },
                { "ret_period", apiRequestParameters.ret_period },
                { "action", "ATR1A" }
            };
            if (!string.IsNullOrEmpty(apiRequestParameters.action_required))
            {
                dic.Add("action_required", apiRequestParameters.action_required);
            }
            if (!string.IsNullOrEmpty(apiRequestParameters.ctin))
            {
                dic.Add("ctin", apiRequestParameters.ctin);
            }
            if (!string.IsNullOrEmpty(apiRequestParameters.from_time))
            {
                if (!DateTime.TryParseExact(apiRequestParameters.from_time, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                {
                    throw new Exception("Date Should be provided in dd-MM-yyyy format only");
                }
                dic.Add("action_required", apiRequestParameters.from_time);
            }
            return dic;
        }
        public async Task<GSTNResult<List<GetATGSTR1AResp>>> GetATGSTR1a(APIRequestParameters1A apiRequestParameters)
        {
            Dictionary<string, string> dic = this.prepareATDictionary(apiRequestParameters);
            this.PrepareQueryString(dic);
            var info = await this.GetAsync<ResponseDataInfo>();
            var output = this.Decrypt<GSTR1ATotal>(info.Data);
            var model = this.BuildResult<List<GetATGSTR1AResp>>(info, output.at);
            return model;

        }

        private Dictionary<string, string> prepareATADictionary(APIRequestParameters1A apiRequestParameters)
        {
            if (apiRequestParameters == null || string.IsNullOrEmpty(apiRequestParameters.gstin) || string.IsNullOrEmpty(apiRequestParameters.ret_period))
            {
                throw new Exception("gstin and ret_period is required");
            }
            var dic = new Dictionary<string, string>
            {
                { "gstin", apiRequestParameters.gstin },
                { "ret_period", apiRequestParameters.ret_period },
                { "action", "ATAR1A" }
            };
            if (!string.IsNullOrEmpty(apiRequestParameters.action_required))
            {
                dic.Add("action_required", apiRequestParameters.action_required);
            }
            if (!string.IsNullOrEmpty(apiRequestParameters.ctin))
            {
                dic.Add("ctin", apiRequestParameters.ctin);
            }
            if (!string.IsNullOrEmpty(apiRequestParameters.from_time))
            {
                if (!DateTime.TryParseExact(apiRequestParameters.from_time, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                {
                    throw new Exception("Date Should be provided in dd-MM-yyyy format only");
                }
                dic.Add("action_required", apiRequestParameters.from_time);
            }
            return dic;
        }
        public async Task<GSTNResult<List<GetATAGSTR1AResp>>> GetATAGSTR1a(APIRequestParameters1A apiRequestParameters)
        {
            Dictionary<string, string> dic = this.prepareATADictionary(apiRequestParameters);
            this.PrepareQueryString(dic);
            var info = await this.GetAsync<ResponseDataInfo>();
            var output = this.Decrypt<GSTR1ATotal>(info.Data);
            var model = this.BuildResult<List<GetATAGSTR1AResp>>(info, output.ata);
            return model;

        }

        private Dictionary<string, string> prepareB2BGSTR1ADictionary(APIRequestParameters1A apiRequestParameters)
        {
            if (apiRequestParameters == null || string.IsNullOrEmpty(apiRequestParameters.gstin) || string.IsNullOrEmpty(apiRequestParameters.ret_period))
            {
                throw new Exception("gstin and ret_period is required");
            }
            var dic = new Dictionary<string, string>
            {
                { "gstin", apiRequestParameters.gstin },
                { "ret_period", apiRequestParameters.ret_period },
                {"from_time", apiRequestParameters.from_time },
                { "action", "R1AB2B" }
            };
            if (!string.IsNullOrEmpty(apiRequestParameters.action_required))
            {
                dic.Add("action_required", apiRequestParameters.action_required);
            }
            if (!string.IsNullOrEmpty(apiRequestParameters.ctin))
            {
                dic.Add("ctin", apiRequestParameters.ctin);
            }
            if (!string.IsNullOrEmpty(apiRequestParameters.from_time))
            {
                if (!DateTime.TryParseExact(apiRequestParameters.from_time, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                {
                    throw new Exception("Date Should be provided in dd-MM-yyyy format only");
                }
                dic.Add("action_required", apiRequestParameters.from_time);
            }
            return dic;
        }
        public async Task<GSTNResult<List<GetB2BGSTR1AResp>>> GetB2BGSTR1A(APIRequestParameters1A apiRequestParameters)
        {
            Dictionary<string, string> dic = this.prepareB2BGSTR1ADictionary(apiRequestParameters);
            this.PrepareQueryString(dic);
            var info = await this.GetAsync<ResponseDataInfo>();
            var output = this.Decrypt<GSTR1ATotal>(info.Data);
            var model = this.BuildResult<List<GetB2BGSTR1AResp>>(info, output.b2b);
            return model;
        }

        private Dictionary<string, string> prepareB2BAGSTR1ADictionary(APIRequestParameters1A apiRequestParameters)
        {
            if (apiRequestParameters == null || string.IsNullOrEmpty(apiRequestParameters.gstin) || string.IsNullOrEmpty(apiRequestParameters.ret_period))
            {
                throw new Exception("gstin and ret_period is required");
            }
            var dic = new Dictionary<string, string>
            {
                { "gstin", apiRequestParameters.gstin },
                { "ret_period", apiRequestParameters.ret_period },
                {"from_time", apiRequestParameters.from_time },
                { "action", "R1AB2BA" }
            };
            if (!string.IsNullOrEmpty(apiRequestParameters.action_required))
            {
                dic.Add("action_required", apiRequestParameters.action_required);
            }
            if (!string.IsNullOrEmpty(apiRequestParameters.ctin))
            {
                dic.Add("ctin", apiRequestParameters.ctin);
            }
            if (!string.IsNullOrEmpty(apiRequestParameters.from_time))
            {
                if (!DateTime.TryParseExact(apiRequestParameters.from_time, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                {
                    throw new Exception("Date Should be provided in dd-MM-yyyy format only");
                }
                dic.Add("action_required", apiRequestParameters.from_time);
            }
            return dic;
        }
        public async Task<GSTNResult<List<GetB2BAGSTR1AResp>>> GetB2BAGSTR1A(APIRequestParameters1A apiRequestParameters)
        {
            Dictionary<string, string> dic = this.prepareB2BGSTR1ADictionary(apiRequestParameters);
            this.PrepareQueryString(dic);
            var info = await this.GetAsync<ResponseDataInfo>();
            var output = this.Decrypt<GSTR1ATotal>(info.Data);
            var model = this.BuildResult<List<GetB2BAGSTR1AResp>>(info, output.b2ba);
            return model;
        }

        private Dictionary<string, string> prepareB2CLGSTR1ADictionary(APIRequestParameters1A apiRequestParameters)
        {
            if (apiRequestParameters == null || string.IsNullOrEmpty(apiRequestParameters.gstin) || string.IsNullOrEmpty(apiRequestParameters.ret_period))
            {
                throw new Exception("gstin and ret_period is required");
            }
            var dic = new Dictionary<string, string>
            {
                { "gstin", apiRequestParameters.gstin },
                { "ret_period", apiRequestParameters.ret_period },
                { "action", "R1AB2CL" }
            };
            if (!string.IsNullOrEmpty(apiRequestParameters.action_required))
            {
                dic.Add("action_required", apiRequestParameters.action_required);
            }
            if (!string.IsNullOrEmpty(apiRequestParameters.ctin))
            {
                dic.Add("ctin", apiRequestParameters.ctin);
            }
            if (!string.IsNullOrEmpty(apiRequestParameters.from_time))
            {
                if (!DateTime.TryParseExact(apiRequestParameters.from_time, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                {
                    throw new Exception("Date Should be provided in dd-MM-yyyy format only");
                }
                dic.Add("action_required", apiRequestParameters.from_time);
            }
            return dic;
        }
        public async Task<GSTNResult<List<GetB2CLGSTR1AResp>>> GetB2CLGSTR1A(APIRequestParameters1A apiRequestParameters)
        {
            Dictionary<string, string> dic = this.prepareB2CLGSTR1ADictionary(apiRequestParameters);
            this.PrepareQueryString(dic);
            var info = await this.GetAsync<ResponseDataInfo>();
            var output = this.Decrypt<GSTR1ATotal>(info.Data);
            var model = this.BuildResult<List<GetB2CLGSTR1AResp>>(info, output.b2cl);
            return model;
        }

        private Dictionary<string, string> prepareB2CLAGSTR1ADictionary(APIRequestParameters1A apiRequestParameters)
        {
            if (apiRequestParameters == null || string.IsNullOrEmpty(apiRequestParameters.gstin) || string.IsNullOrEmpty(apiRequestParameters.ret_period))
            {
                throw new Exception("gstin and ret_period is required");
            }
            var dic = new Dictionary<string, string>
            {
                { "gstin", apiRequestParameters.gstin },
                { "ret_period", apiRequestParameters.ret_period },
                { "action", "R1AB2CLA" }
            };
            if (!string.IsNullOrEmpty(apiRequestParameters.action_required))
            {
                dic.Add("action_required", apiRequestParameters.action_required);
            }
            if (!string.IsNullOrEmpty(apiRequestParameters.ctin))
            {
                dic.Add("ctin", apiRequestParameters.ctin);
            }
            if (!string.IsNullOrEmpty(apiRequestParameters.from_time))
            {
                if (!DateTime.TryParseExact(apiRequestParameters.from_time, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                {
                    throw new Exception("Date Should be provided in dd-MM-yyyy format only");
                }
                dic.Add("action_required", apiRequestParameters.from_time);
            }
            return dic;
        }
        public async Task<GSTNResult<List<GetB2CLAGSTR1AResp>>> GetB2CLAGSTR1A(APIRequestParameters1A apiRequestParameters)
        {
            Dictionary<string, string> dic = this.prepareB2CLAGSTR1ADictionary(apiRequestParameters);
            this.PrepareQueryString(dic);
            var info = await this.GetAsync<ResponseDataInfo>();
            var output = this.Decrypt<GSTR1ATotal>(info.Data);
            var model = this.BuildResult<List<GetB2CLAGSTR1AResp>>(info, output.b2cla);
            return model;
        }

        private Dictionary<string, string> prepareB2CSGSTR1ADictionary(APIRequestParameters1A apiRequestParameters)
        {
            if (apiRequestParameters == null || string.IsNullOrEmpty(apiRequestParameters.gstin) || string.IsNullOrEmpty(apiRequestParameters.ret_period))
            {
                throw new Exception("gstin and ret_period is required");
            }
            var dic = new Dictionary<string, string>
            {
                { "gstin", apiRequestParameters.gstin },
                { "ret_period", apiRequestParameters.ret_period },
                { "action", "R1AB2CS" }
            };
            if (!string.IsNullOrEmpty(apiRequestParameters.action_required))
            {
                dic.Add("action_required", apiRequestParameters.action_required);
            }
            if (!string.IsNullOrEmpty(apiRequestParameters.ctin))
            {
                dic.Add("ctin", apiRequestParameters.ctin);
            }
            if (!string.IsNullOrEmpty(apiRequestParameters.from_time))
            {
                if (!DateTime.TryParseExact(apiRequestParameters.from_time, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                {
                    throw new Exception("Date Should be provided in dd-MM-yyyy format only");
                }
                dic.Add("action_required", apiRequestParameters.from_time);
            }
            return dic;
        }
        public async Task<GSTNResult<List<GetB2CSGSTR1AResp>>> GetB2CSGSTR1A(APIRequestParameters1A apiRequestParameters)
        {
            Dictionary<string, string> dic = this.prepareB2CSGSTR1ADictionary(apiRequestParameters);
            this.PrepareQueryString(dic);
            var info = await this.GetAsync<ResponseDataInfo>();
            var output = this.Decrypt<GSTR1ATotal>(info.Data);
            var model = this.BuildResult<List<GetB2CSGSTR1AResp>>(info, output.b2cs);
            return model;
        }

        private Dictionary<string, string> prepareB2CSAGSTR1ADictionary(APIRequestParameters1A apiRequestParameters)
        {
            if (apiRequestParameters == null || string.IsNullOrEmpty(apiRequestParameters.gstin) || string.IsNullOrEmpty(apiRequestParameters.ret_period))
            {
                throw new Exception("gstin and ret_period is required");
            }
            var dic = new Dictionary<string, string>
            {
                { "gstin", apiRequestParameters.gstin },
                { "ret_period", apiRequestParameters.ret_period },
                { "action", "R1AB2CSA" }
            };
            if (!string.IsNullOrEmpty(apiRequestParameters.action_required))
            {
                dic.Add("action_required", apiRequestParameters.action_required);
            }
            if (!string.IsNullOrEmpty(apiRequestParameters.ctin))
            {
                dic.Add("ctin", apiRequestParameters.ctin);
            }
            if (!string.IsNullOrEmpty(apiRequestParameters.from_time))
            {
                if (!DateTime.TryParseExact(apiRequestParameters.from_time, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                {
                    throw new Exception("Date Should be provided in dd-MM-yyyy format only");
                }
                dic.Add("action_required", apiRequestParameters.from_time);
            }
            return dic;
        }
        public async Task<GSTNResult<List<GetB2CSAGSTR1AResp>>> GetB2CSAGSTR1A(APIRequestParameters1A apiRequestParameters)
        {
            Dictionary<string, string> dic = this.prepareB2CSAGSTR1ADictionary(apiRequestParameters);
            this.PrepareQueryString(dic);
            var info = await this.GetAsync<ResponseDataInfo>();
            var output = this.Decrypt<GSTR1ATotal>(info.Data);
            var model = this.BuildResult<List<GetB2CSAGSTR1AResp>>(info, output.b2csa);
            return model;
        }

        private Dictionary<string, string> prepareTXPGSTR1ADictionary(APIRequestParameters1A apiRequestParameters)
        {
            if (apiRequestParameters == null || string.IsNullOrEmpty(apiRequestParameters.gstin) || string.IsNullOrEmpty(apiRequestParameters.ret_period))
            {
                throw new Exception("gstin and ret_period is required");
            }
            var dic = new Dictionary<string, string>
            {
                { "gstin", apiRequestParameters.gstin },
                { "ret_period", apiRequestParameters.ret_period },
                { "action", "R1ATXP" }
            };
            if (!string.IsNullOrEmpty(apiRequestParameters.action_required))
            {
                dic.Add("action_required", apiRequestParameters.action_required);
            }
            if (!string.IsNullOrEmpty(apiRequestParameters.ctin))
            {
                dic.Add("ctin", apiRequestParameters.ctin);
            }
            if (!string.IsNullOrEmpty(apiRequestParameters.from_time))
            {
                if (!DateTime.TryParseExact(apiRequestParameters.from_time, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                {
                    throw new Exception("Date Should be provided in dd-MM-yyyy format only");
                }
                dic.Add("action_required", apiRequestParameters.from_time);
            }
            return dic;
        }
        public async Task<GSTNResult<List<GetTXPGSTR1AResp>>> GetTXPGSTR1A(APIRequestParameters1A apiRequestParameters)
        {
            Dictionary<string, string> dic = this.prepareTXPGSTR1ADictionary(apiRequestParameters);
            this.PrepareQueryString(dic);
            var info = await this.GetAsync<ResponseDataInfo>();
            var output = this.Decrypt<GSTR1ATotal>(info.Data);
            var model = this.BuildResult<List<GetTXPGSTR1AResp>>(info, output.txp);
            return model;
        }

        private Dictionary<string, string> prepareHSNGSTR1ADictionary(APIRequestParameters1A apiRequestParameters)
        {
            if (apiRequestParameters == null || string.IsNullOrEmpty(apiRequestParameters.gstin) || string.IsNullOrEmpty(apiRequestParameters.ret_period))
            {
                throw new Exception("gstin and ret_period is required");
            }
            var dic = new Dictionary<string, string>
            {
                { "gstin", apiRequestParameters.gstin },
                { "ret_period", apiRequestParameters.ret_period },
                { "action", "R1AHSNSUM" }
            };
            if (!string.IsNullOrEmpty(apiRequestParameters.action_required))
            {
                dic.Add("action_required", apiRequestParameters.action_required);
            }
            if (!string.IsNullOrEmpty(apiRequestParameters.ctin))
            {
                dic.Add("ctin", apiRequestParameters.ctin);
            }
            if (!string.IsNullOrEmpty(apiRequestParameters.from_time))
            {
                if (!DateTime.TryParseExact(apiRequestParameters.from_time, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                {
                    throw new Exception("Date Should be provided in dd-MM-yyyy format only");
                }
                dic.Add("action_required", apiRequestParameters.from_time);
            }
            return dic;
        }
        public async Task<GSTNResult<List<GetHSNSMRYGSTR1AResp>>> GetHSNGSTR1A(APIRequestParameters1A apiRequestParameters)
        {
            Dictionary<string, string> dic = this.prepareHSNGSTR1ADictionary(apiRequestParameters);
            this.PrepareQueryString(dic);
            var info = await this.GetAsync<ResponseDataInfo>();
            var output = this.Decrypt<GSTR1ATotal>(info.Data);
            var model = this.BuildResult<List<GetHSNSMRYGSTR1AResp>>(info, output.hsn);
            return model;
        }

        private Dictionary<string, string> prepareNILGSTR1ADictionary(APIRequestParameters1A apiRequestParameters)
        {
            if (apiRequestParameters == null || string.IsNullOrEmpty(apiRequestParameters.gstin) || string.IsNullOrEmpty(apiRequestParameters.ret_period))
            {
                throw new Exception("gstin and ret_period is required");
            }
            var dic = new Dictionary<string, string>
            {
                { "gstin", apiRequestParameters.gstin },
                { "ret_period", apiRequestParameters.ret_period },
                { "action", "R1ANIL" }
            };
            if (!string.IsNullOrEmpty(apiRequestParameters.action_required))
            {
                dic.Add("action_required", apiRequestParameters.action_required);
            }
            if (!string.IsNullOrEmpty(apiRequestParameters.ctin))
            {
                dic.Add("ctin", apiRequestParameters.ctin);
            }
            if (!string.IsNullOrEmpty(apiRequestParameters.from_time))
            {
                if (!DateTime.TryParseExact(apiRequestParameters.from_time, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                {
                    throw new Exception("Date Should be provided in dd-MM-yyyy format only");
                }
                dic.Add("action_required", apiRequestParameters.from_time);
            }
            return dic;
        }
        public async Task<GSTNResult<List<GetNILGSTR1AResp>>> GetNILGSTR1A(APIRequestParameters1A apiRequestParameters)
        {
            Dictionary<string, string> dic = this.prepareNILGSTR1ADictionary(apiRequestParameters);
            this.PrepareQueryString(dic);
            var info = await this.GetAsync<ResponseDataInfo>();
            var output = this.Decrypt<GSTR1ATotal>(info.Data);
            var model = this.BuildResult<List<GetNILGSTR1AResp>>(info, output.nil);
            return model;
        }

        private Dictionary<string, string> prepareGSTR1ASummaryDictionary(APIRequestParameters1A apiRequestParameters)
        {
            if (apiRequestParameters == null || string.IsNullOrEmpty(apiRequestParameters.gstin) || string.IsNullOrEmpty(apiRequestParameters.ret_period))
            {
                throw new Exception("gstin and ret_period is required");
            }
            var dic = new Dictionary<string, string>
            {
                { "gstin", apiRequestParameters.gstin },
                { "ret_period", apiRequestParameters.ret_period },
                { "action", "RETSUM" }
            };
            return dic;
        }

        public async Task<GSTNResult<List<GetGSTR1ASummaryResp>>> GetGSTR1ASummary1(APIRequestParameters1A apiRequestParameters)
        {
            Dictionary<string, string> dic = this.prepareGSTR1ASummaryDictionary(apiRequestParameters);
            this.PrepareQueryString(dic);
            var info = await this.GetAsync<ResponseDataInfo>();
            var output = this.Decrypt<GSTR1ATotal>(info.Data);
            var model = this.BuildResult<List<GetGSTR1ASummaryResp>>(info, output.smry);
            return model;
        }

    }
}
