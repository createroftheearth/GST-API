using GST_API_Library.Models;
using GST_API_Library.Models.GSTR9;
using System.Globalization;

namespace GST_API_Library.Services
{
    public class GSTR9ApiClient : GSTNReturnsClient
    {
        //"/taxpayerapi/v2.1/returns/GSTR9"
        //action_required=“Y|N“
        public GSTR9ApiClient(IGSTNAuthProvider provider, string gstin, string ret_period, string URL)
            : base(provider, URL, gstin, ret_period)
        {
        }

       
        public async Task<GSTNResult<List<Get8A_Details>>> Get8ADetails(APIRequestParamtersGSTR9 apiRequestParameters)
        {
            Dictionary<string, string> dic = this.prepareGstr8ADtlDictionary(apiRequestParameters);
            this.PrepareQueryString(dic);
            var info = await this.GetAsync<ResponseDataInfo>();
            var output = this.Decrypt<GSTR9Total>(info.Data);
            var model = this.BuildResult<List<Get8A_Details>>(info, output.get8ADetails);
            return model;
        }
        private Dictionary<string, string> prepareGstr8ADtlDictionary(APIRequestParamtersGSTR9 apiRequestParameters)
        {
            if (apiRequestParameters == null || string.IsNullOrEmpty(apiRequestParameters.gstin) || string.IsNullOrEmpty(apiRequestParameters.ret_period))
            {
                throw new Exception("gstin and ret_period is required");
            }
            var dic = new Dictionary<string, string>
            {
                { "gstin", apiRequestParameters.gstin },
                { "fy", apiRequestParameters.fy },
                { "action", "FILEDETL8A" }
            };
            if (!string.IsNullOrEmpty(apiRequestParameters.docid))
            {
                dic.Add("docid", apiRequestParameters.docid);
            }
            return dic;
        }

        public async Task<GSTNResult<List<GetAutocalculatedDetails>>> GetAutoCalDetails(APIRequestParamtersGSTR9 apiRequestParameters)
        {
            Dictionary<string, string> dic = this.prepareGstrAutoCalDtlDictionary(apiRequestParameters);
            this.PrepareQueryString(dic);
            var info = await this.GetAsync<ResponseDataInfo>();
            var output = this.Decrypt<GSTR9Total>(info.Data);
            var model = this.BuildResult<List<GetAutocalculatedDetails>>(info, output.getAutocalculatedDetails);
            return model;
        }
        private Dictionary<string, string> prepareGstrAutoCalDtlDictionary(APIRequestParamtersGSTR9 apiRequestParameters)
        {
            if (apiRequestParameters == null || string.IsNullOrEmpty(apiRequestParameters.gstin) || string.IsNullOrEmpty(apiRequestParameters.ret_period))
            {
                throw new Exception("gstin and ret_period is required");
            }
            var dic = new Dictionary<string, string>
            {
                { "gstin", apiRequestParameters.gstin },
                { "ret_period", apiRequestParameters.ret_period },
                { "action", "CALRCDS" }
            };
            return dic;
        }

        public async Task<GSTNResult<List<GetDetails>>> GetDetails(APIRequestParamtersGSTR9 apiRequestParameters)
        {
            Dictionary<string, string> dic = this.prepareGstrGetDetailslDictionary(apiRequestParameters);
            this.PrepareQueryString(dic);
            var info = await this.GetAsync<ResponseDataInfo>();
            var output = this.Decrypt<GSTR9Total>(info.Data);
            var model = this.BuildResult<List<GetDetails>>(info, output.getDetails);
            return model;
        }
        private Dictionary<string, string> prepareGstrGetDetailslDictionary(APIRequestParamtersGSTR9 apiRequestParameters)
        {
            if (apiRequestParameters == null || string.IsNullOrEmpty(apiRequestParameters.gstin) || string.IsNullOrEmpty(apiRequestParameters.ret_period))
            {
                throw new Exception("gstin and ret_period is required");
            }
            var dic = new Dictionary<string, string>
            {
                { "gstin", apiRequestParameters.gstin },
                { "ret_period", apiRequestParameters.ret_period },
                { "action", "RECORDS" }
            };
            return dic;
        }

        public async Task<GSTNResult<List<GetAutocalculatedDetailsGSTR9A>>> GetAutoCalDetails9A(APIRequestParamtersGSTR9 apiRequestParameters)
        {
            Dictionary<string, string> dic = this.prepareGstrAutoCalDtl9ADictionary(apiRequestParameters);
            this.PrepareQueryString(dic);
            var info = await this.GetAsync<ResponseDataInfo>();
            var output = this.Decrypt<GSTR9Total>(info.Data);
            var model = this.BuildResult<List<GetAutocalculatedDetailsGSTR9A>>(info, output.getAutocalculatedDetails9A);
            return model;
        }
        private Dictionary<string, string> prepareGstrAutoCalDtl9ADictionary(APIRequestParamtersGSTR9 apiRequestParameters)
        {
            if (apiRequestParameters == null || string.IsNullOrEmpty(apiRequestParameters.gstin) || string.IsNullOrEmpty(apiRequestParameters.ret_period))
            {
                throw new Exception("gstin and ret_period is required");
            }
            var dic = new Dictionary<string, string>
            {
                { "gstin", apiRequestParameters.gstin },
                { "ret_period", apiRequestParameters.ret_period },
                { "action", "CALRCDS" }
            };
            return dic;
        }

        public async Task<GSTNResult<List<GetDetailsGSTR9A>>> GetDetails9A(APIRequestParamtersGSTR9 apiRequestParameters)
        {
            Dictionary<string, string> dic = this.prepareGstrGetDetails9ADictionary(apiRequestParameters);
            this.PrepareQueryString(dic);
            var info = await this.GetAsync<ResponseDataInfo>();
            var output = this.Decrypt<GSTR9Total>(info.Data);
            var model = this.BuildResult<List<GetDetailsGSTR9A>>(info, output.getDetails9A);
            return model;
        }
        private Dictionary<string, string> prepareGstrGetDetails9ADictionary(APIRequestParamtersGSTR9 apiRequestParameters)
        {
            if (apiRequestParameters == null || string.IsNullOrEmpty(apiRequestParameters.gstin) || string.IsNullOrEmpty(apiRequestParameters.ret_period))
            {
                throw new Exception("gstin and ret_period is required");
            }
            var dic = new Dictionary<string, string>
            {
                { "gstin", apiRequestParameters.gstin },
                { "ret_period", apiRequestParameters.ret_period },
                { "action", "RECORDS" }
            };
            return dic;
        }

        public async Task<GSTNResult<SaveInfo>> Save9(GSTR9Total data)
        {
            var model = this.Encrypt(data);
            model.action = "RETSAVE";
            var info = await this.PutAsync<UnsignedDataInfo, ResponseDataInfo>(model);
            if (info == null)
            {
                throw new Exception("Unable to get the details from server");
            }
            var output = this.Decrypt<SaveInfo>(info.Data);
            var model2 = this.BuildResult<SaveInfo>(info, output);
            return model2;
        }

        public async Task<GSTNResult<SaveInfo>> Save9A(GSTR9Total data)
        {
            var model = this.Encrypt(data);
            model.action = "RETSAVE";
            var info = await this.PutAsync<UnsignedDataInfo, ResponseDataInfo>(model);
            if (info == null)
            {
                throw new Exception("Unable to get the details from server");
            }
            var output = this.Decrypt<SaveInfo>(info.Data);
            var model2 = this.BuildResult<SaveInfo>(info, output);
            return model2;
        }

        public async Task<GSTNResult<List<Get9RecordsFor9C>>> GetGstr9ToGstr9c(APIRequestParamtersGSTR9 apiRequestParameters)
        {
            Dictionary<string, string> dic = this.prepareGstrGetGstr9ToGstr9c(apiRequestParameters);
            this.PrepareQueryString(dic);
            var info = await this.GetAsync<ResponseDataInfo>();
            var output = this.Decrypt<GSTR9Total>(info.Data);
            var model = this.BuildResult<List<Get9RecordsFor9C>>(info, output.get9RecordsFor9C);
            return model;
        }
        private Dictionary<string, string> prepareGstrGetGstr9ToGstr9c(APIRequestParamtersGSTR9 apiRequestParameters)
        {
            if (apiRequestParameters == null || string.IsNullOrEmpty(apiRequestParameters.gstin) || string.IsNullOrEmpty(apiRequestParameters.ret_period))
            {
                throw new Exception("gstin and ret_period is required");
            }
            var dic = new Dictionary<string, string>
            {
                { "gstin", apiRequestParameters.gstin },
                { "ret_period", apiRequestParameters.ret_period },
                { "action", "RECDS" }
            };
            return dic;
        }

        public async Task<GSTNResult<List<GSTR9CGetSummary>>> GetGstr9CSummary(APIRequestParamtersGSTR9 apiRequestParameters)
        {
            Dictionary<string, string> dic = this.prepareGstrGetGstr9CSummary(apiRequestParameters);
            this.PrepareQueryString(dic);
            var info = await this.GetAsync<ResponseDataInfo>();
            var output = this.Decrypt<GSTR9Total>(info.Data);
            var model = this.BuildResult<List<GSTR9CGetSummary>>(info, output.get9CSummary);
            return model;
        }
        private Dictionary<string, string> prepareGstrGetGstr9CSummary(APIRequestParamtersGSTR9 apiRequestParameters)
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

        public async Task<GSTNResult<GSTR9CHashGenerate>> GSTR9CHashGenerate(GSTR9CHashGeneratorRequest data)
        {
            var model = this.Encrypt(data);
            model.action = "RETGENHASH";
            var info = await this.PutAsync<UnsignedDataInfo, ResponseDataInfo>(model);
            if (info == null)
            {
                throw new Exception("Unable to get the details from server");
            }
            var output = this.Decrypt<GSTR9CHashGenerate>(info.Data);
            var model2 = this.BuildResult<GSTR9CHashGenerate>(info, output);
            return model2;
        }

        public async Task<GSTNResult<SaveInfo>> Save9C(GSTR9CSaveRequest data)
        {
            var model = this.Encrypt(data);
            model.action = "RETSAVE";
            var info = await this.PutAsync<UnsignedDataInfo, ResponseDataInfo>(model);
            if (info == null)
            {
                throw new Exception("Unable to get the details from server");
            }
            var output = this.Decrypt<SaveInfo>(info.Data);
            var model2 = this.BuildResult<SaveInfo>(info, output);
            return model2;
        }

        public async Task<GSTNResult<GSTR9CGenCertiResponse>> GSTR9CGenCerti(GSTR9CGenCertiRequest data)
        {
            var model = this.Encrypt(data);
            model.action = "RETGENCERT";
            var info = await this.PutAsync<UnsignedDataInfo, ResponseDataInfo>(model);
            if (info == null)
            {
                throw new Exception("Unable to get the details from server");
            }
            var output = this.Decrypt<GSTR9CGenCertiResponse>(info.Data);
            var model2 = this.BuildResult<GSTR9CGenCertiResponse>(info, output);
            return model2;
        }
    }
}
