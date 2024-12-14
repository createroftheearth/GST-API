using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GST_API_Library.Models;
using GST_API_Library.Models.GSTR3B;


namespace GST_API_Library.Services
{
    public class GSTR3BApiClient : GSTNReturnsClient
    {
        public GSTR3BApiClient(IGSTNAuthProvider provider, string gstin, string ret_period, string URL)
          : base(provider, URL, gstin, ret_period)
        {
        }

        //This API call to get system calculated interest
        private Dictionary<string, string> prepareGSTR3BCalculatedInterestDictionary(APIRequestParameters apiRequestParameters)
        {
            if (apiRequestParameters == null || string.IsNullOrEmpty(apiRequestParameters.gstin) || string.IsNullOrEmpty(apiRequestParameters.ret_period))
            {
                throw new Exception("gstin and ret_period is required");
            }
            var dic = new Dictionary<string, string>
            {
                { "gstin", apiRequestParameters.gstin },
                { "ret_period", apiRequestParameters.ret_period },
                { "action", "RETINT" }
            };
            return dic;
        }
        public async Task<GSTNResult<List<GetSysCalculatedInterest>>> GetSystemCalculatedInterest(APIRequestParameters apiRequestParameters)
        {
            Dictionary<string, string> dic = this.prepareGSTR3BCalculatedInterestDictionary(apiRequestParameters);
            this.PrepareQueryString(dic);
            var info = await this.GetAsync<ResponseDataInfo>();
            var output = this.Decrypt<GetSysCalculatedInterest>(info.Data);
            var model = this.BuildResult<List<GetSysCalculatedInterest>>(info, null);
            return model;

        }

        //This API call for generating GSTR3B Details
        private Dictionary<string, string> prepareGSTR3BDetailsDictionary(APIRequestParameters apiRequestParameters)
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
        public async Task<GSTNResult<List<GetGSTR3BDetails>>> GetGSTR3BDetails(APIRequestParameters apiRequestParameters)
        {
            Dictionary<string, string> dic = this.prepareGSTR3BDetailsDictionary(apiRequestParameters);
            this.PrepareQueryString(dic);
            var info = await this.GetAsync<ResponseDataInfo>();
            var output = this.Decrypt<GetGSTR3BDetails>(info.Data);
            var model = this.BuildResult<List<GetGSTR3BDetails>>(info, null);
            return model;

        }


        //This API call to get autocalculated liability and ITC details for monthly and quarterly taxpayers.
        private Dictionary<string, string> prepareGSTR3BITCLiabilityDetailsDictionary(APIRequestParameters apiRequestParameters)
        {
            if (apiRequestParameters == null || string.IsNullOrEmpty(apiRequestParameters.gstin) || string.IsNullOrEmpty(apiRequestParameters.ret_period))
            {
                throw new Exception("gstin and ret_period is required");
            }
            var dic = new Dictionary<string, string>
            {
                { "gstin", apiRequestParameters.gstin },
                { "ret_period", apiRequestParameters.ret_period },
                { "action", "AUTOLIAB" }
            };
            return dic;
        }
        public async Task<GSTNResult<List<GetITCLiabilityDetails>>> GetITCLiabilityDetails(APIRequestParameters apiRequestParameters)
        {
            Dictionary<string, string> dic = this.prepareGSTR3BITCLiabilityDetailsDictionary(apiRequestParameters);
            this.PrepareQueryString(dic);
            var info = await this.GetAsync<ResponseDataInfo>();
            var output = this.Decrypt<GetITCLiabilityDetails>(info.Data);
            var model = this.BuildResult<List<GetITCLiabilityDetails>>(info, null);
            return model;

        }

        //This API is to get latest closing balance of Electronic Credit Reversal and Re-claimed Statement.
        private Dictionary<string, string> prepareGSTR3BITCReversalBalanceDictionary(APIRequestParameters apiRequestParameters)
        {
            if (apiRequestParameters == null || string.IsNullOrEmpty(apiRequestParameters.gstin))//|| string.IsNullOrEmpty(apiRequestParameters.ret_period))
            {
                throw new Exception("gstin and ret_period is required");
            }
            var dic = new Dictionary<string, string>
            {
                { "gstin", apiRequestParameters.gstin },
               // { "ret_period", apiRequestParameters.ret_period },
                { "action", "CLOSINGBAL" }
            };
            return dic;
        }
        public async Task<GSTNResult<List<GetITCReversalBalance>>> GetGetITCReversalBalance(APIRequestParameters apiRequestParameters)
        {
            Dictionary<string, string> dic = this.prepareGSTR3BITCReversalBalanceDictionary(apiRequestParameters);
            this.PrepareQueryString(dic);
            var info = await this.GetAsync<ResponseDataInfo>();
            var output = this.Decrypt<GetITCReversalBalance>(info.Data);
            var model = this.BuildResult<List<GetITCReversalBalance>>(info, null);
            return model;

        }

        //This API is to get latest closing balance of Electronic Credit Reversal and Re-claimed Statement.
        private Dictionary<string, string> prepareGSTR3BGetOpeningBalanceReclaimDetailsDictionary(APIRequestParameters apiRequestParameters)
        {
            if (apiRequestParameters == null || string.IsNullOrEmpty(apiRequestParameters.gstin))//|| string.IsNullOrEmpty(apiRequestParameters.ret_period))
            {
                throw new Exception("gstin and ret_period is required");
            }
            var dic = new Dictionary<string, string>
            {
                { "gstin", apiRequestParameters.gstin },
               // { "ret_period", apiRequestParameters.ret_period },
                { "action", "OPENINGBAL" }
            };
            return dic;
        }
        public async Task<GSTNResult<List<GetOpeningBalanceReclaimDetails>>> GetOpeningBalanceReclaimDetails(APIRequestParameters apiRequestParameters)
        {
            Dictionary<string, string> dic = this.prepareGSTR3BGetOpeningBalanceReclaimDetailsDictionary(apiRequestParameters);
            this.PrepareQueryString(dic);
            var info = await this.GetAsync<ResponseDataInfo>();
            var output = this.Decrypt<GetOpeningBalanceReclaimDetails>(info.Data);
            var model = this.BuildResult<List<GetOpeningBalanceReclaimDetails>>(info, null);
            return model;

        }
    }
}
