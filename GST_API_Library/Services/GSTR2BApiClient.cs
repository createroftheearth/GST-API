using GST_API_Library.Models;
using GST_API_Library.Models.GSTR1A;
using GST_API_Library.Models.GSTR2B;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GST_API_Library.Services
{
    public class GSTR2BApiClient : GSTNReturnsClient
    {
        public GSTR2BApiClient(IGSTNAuthProvider provider, string gstin, string ret_period, string URL)
            : base(provider, URL, gstin, ret_period)
        {
        }

        //This API will be used to fetch the GSTR2B details for given GSTIN, Return Period
        private Dictionary<string, string> prepareGSTR2BDictionary(APIRequestParameters apiRequestParameters)
        {
            if (apiRequestParameters == null || string.IsNullOrEmpty(apiRequestParameters.gstin) || string.IsNullOrEmpty(apiRequestParameters.ret_period))
            {
                throw new Exception("gstin and ret_period is required");
            }
            var dic = new Dictionary<string, string>
            {
                { "gstin", apiRequestParameters.gstin },
                { "rtnprd", apiRequestParameters.ret_period },
                { "action", "GET2B" }
            };
           
            if (!string.IsNullOrEmpty(apiRequestParameters.file_num))
            {
                dic.Add("file_num", apiRequestParameters.file_num);
            }
           
            return dic;
        }

        public async Task<GSTNResult<List<GetGSTR2B>>> GetGSTR2B(APIRequestParameters apiRequestParameters)
        {
            Dictionary<string, string> dic = this.prepareGSTR2BDictionary(apiRequestParameters);
            this.PrepareQueryString(dic);
            var info = await this.GetAsync<ResponseDataInfo>();
            var output = this.Decrypt<GetGSTR2B>(info.Data);
            var model = this.BuildResult<List<GetGSTR2B>>(info,null);
            return model;

        }

        public async Task<GSTNResult<Gen2BonDemandResp>> Gen2BonDemand(Gen2BonDemand data)
        {
            var model = this.Encrypt(data);
            model.action = "GEN2B";
            var info = await this.PutAsync<UnsignedDataInfo, ResponseDataInfo>(model);
            if (info == null)
            {
                throw new Exception("Unable to get the details from server");
            }
            var output = this.Decrypt<Gen2BonDemandResp>(info.Data);
            var model2 = this.BuildResult<Gen2BonDemandResp>(info, output);
            return model2;
        }

        private Dictionary<string, string> prepareGSTR2BGenstatusDictionary(APIRequestParameters apiRequestParameters)
        {
            if (apiRequestParameters == null || string.IsNullOrEmpty(apiRequestParameters.gstin))
            {
                throw new Exception("gstin and ret_period is required");
            }
            var dic = new Dictionary<string, string>
            {
                { "gstin", apiRequestParameters.gstin },
                { "int_tran_id", apiRequestParameters.int_tran_id },
                { "action", "GENSTS2B" }
            };

            if (!string.IsNullOrEmpty(apiRequestParameters.file_num))
            {
                dic.Add("file_num", apiRequestParameters.file_num);
            }

            return dic;
        }

        public async Task<GSTNResult<List<GetGSTR2BGenStatus>>> GetGSTR2BGenStatus(APIRequestParameters apiRequestParameters)
        {
            Dictionary<string, string> dic = this.prepareGSTR2BGenstatusDictionary(apiRequestParameters);
            this.PrepareQueryString(dic);
            var info = await this.GetAsync<ResponseDataInfo>();
            var output = this.Decrypt<GSTR2BTotal>(info.Data);
            var model = this.BuildResult<List<GetGSTR2BGenStatus>>(info, output.GetGSTR2BGenStatus);
            return model;

        }
    }
}
