using GST_API_Library.Models;
using GST_API_Library.Models.GSTR2A;
using Integrated.API.GSTN.GSTR1;
using Newtonsoft.Json;
using System.Globalization;
using System.Text;
using FileInfo = GST_API_Library.Models.FileInfo;

namespace GST_API_Library.Services
{
    public class GSTR2AApiClient : GSTNReturnsClient
    {
        //"/taxpayerapi/v2.1/returns/gstr1"
        //action_required=“Y|N“
        public GSTR2AApiClient(IGSTNAuthProvider provider, string gstin, string ret_period, string URL)
            : base(provider, URL, gstin, ret_period)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiRequestParameters"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        /// 



        private Dictionary<string, string> prepareB2B2ADictionary(APIRequestParameters apiRequestParameters)
        {

            var dic = new Dictionary<string, string>
            {
                { "gstin", apiRequestParameters.gstin },
                { "ret_period", apiRequestParameters.ret_period },
                {"ctin",apiRequestParameters.ctin },
                { "action", "B2B" }
            };

            return dic;
        }
        public async Task<GSTNResult<List<GetB2BGSTR2A>>> GetB2B2A(APIRequestParameters apiRequestParameters)
        {
            Dictionary<string, string> dic = this.prepareB2B2ADictionary(apiRequestParameters);
            this.PrepareQueryString(dic);
            var info = await this.GetAsync<ResponseDataInfo>();
            var output = this.Decrypt<GSTR2ATotal>(info.Data);
            var model = this.BuildResult<List<GetB2BGSTR2A>>(info, output.GetB2BGSTR2A);
            return model;
        }

        private Dictionary<string, string> prepareECOM2ADictionary(APIRequestParameters apiRequestParameters)
        {

            var dic = new Dictionary<string, string>
            {
                { "gstin", apiRequestParameters.gstin },
                { "ret_period", apiRequestParameters.ret_period },
                {"ctin",apiRequestParameters.ctin },
                { "action", "ECOM" }
            };

            return dic;
        }
        public async Task<GSTNResult<List<GetECOMGSTR2A>>> GetECOM2A(APIRequestParameters apiRequestParameters)
        {
            Dictionary<string, string> dic = this.prepareECOM2ADictionary(apiRequestParameters);
            this.PrepareQueryString(dic);
            var info = await this.GetAsync<ResponseDataInfo>();
            var output = this.Decrypt<GSTR2ATotal>(info.Data);
            var model = this.BuildResult<List<GetECOMGSTR2A>>(info, output.GetECOMGSTR2A);
            return model;
        }

        private Dictionary<string, string> prepareECOMA2ADictionary(APIRequestParameters apiRequestParameters)
        {
            
            var dic = new Dictionary<string, string>
            {
                { "gstin", apiRequestParameters.gstin },
                { "ret_period", apiRequestParameters.ret_period },
                {"ctin",apiRequestParameters.ctin },
                { "action", "ECOMA" }
            };
           
            return dic;
        }
        public async Task<GSTNResult<List<GetECOMAGSTR2A>>> GetECOMA2A(APIRequestParameters apiRequestParameters)
        {
            Dictionary<string, string> dic = this.prepareECOMA2ADictionary(apiRequestParameters);
            this.PrepareQueryString(dic);
            var info = await this.GetAsync<ResponseDataInfo>();
            var output = this.Decrypt<GSTR2ATotal>(info.Data);
            var model = this.BuildResult<List<GetECOMAGSTR2A>>(info, output.GetECOMAGSTR2A);
            return model;
        }

        private Dictionary<string, string> prepareIMPG2ADictionary(APIRequestParameters apiRequestParameters)
        {

            var dic = new Dictionary<string, string>
            {
                { "gstin", apiRequestParameters.gstin },
                { "ret_period", apiRequestParameters.ret_period },
                {"from_time",apiRequestParameters.from_time },
                { "action", "IMPG" }
            };

            return dic;
        }
        public async Task<GSTNResult<List<GetIMPGGSTR2A>>> GetIMPG2A(APIRequestParameters apiRequestParameters)
        {
            Dictionary<string, string> dic = this.prepareIMPG2ADictionary(apiRequestParameters);
            this.PrepareQueryString(dic);
            var info = await this.GetAsync<ResponseDataInfo>();
            var output = this.Decrypt<GSTR2ATotal>(info.Data);
            var model = this.BuildResult<List<GetIMPGGSTR2A>>(info, output.GetIMPGGSTR2A);
            return model;
        }

        private Dictionary<string, string> prepareIMPGSEZ2ADictionary(APIRequestParameters apiRequestParameters)
        {

            var dic = new Dictionary<string, string>
            {
                { "gstin", apiRequestParameters.gstin },
                { "ret_period", apiRequestParameters.ret_period },
                {"from_time",apiRequestParameters.from_time },
                { "action", "IMPGSEZ" }
            };

            return dic;
        }
        public async Task<GSTNResult<List<GetIMPGSEZGSTR2A>>> GetIMPGSEZ2A(APIRequestParameters apiRequestParameters)
        {
            Dictionary<string, string> dic = this.prepareIMPGSEZ2ADictionary(apiRequestParameters);
            this.PrepareQueryString(dic);
            var info = await this.GetAsync<ResponseDataInfo>();
            var output = this.Decrypt<GSTR2ATotal>(info.Data);
            var model = this.BuildResult<List<GetIMPGSEZGSTR2A>>(info, output.GetIMPGSEZGSTR2A);
            return model;
        }

        private Dictionary<string, string> prepareISD2ADictionary(APIRequestParameters apiRequestParameters)
        {

            var dic = new Dictionary<string, string>
            {
                { "gstin", apiRequestParameters.gstin },
                { "ret_period", apiRequestParameters.ret_period },
                {"ctin",apiRequestParameters.ctin },
                { "action", "ISD" }
            };

            return dic;
        }
        public async Task<GSTNResult<List<GetISDCreditGSTR2A>>> GetISD2A(APIRequestParameters apiRequestParameters)
        {
            Dictionary<string, string> dic = this.prepareISD2ADictionary(apiRequestParameters);
            this.PrepareQueryString(dic);
            var info = await this.GetAsync<ResponseDataInfo>();
            var output = this.Decrypt<GSTR2ATotal>(info.Data);
            var model = this.BuildResult<List<GetISDCreditGSTR2A>>(info, output.GetISDCreditGSTR2A);
            return model;
        }

        private Dictionary<string, string> prepareTCS2ADictionary(APIRequestParameters apiRequestParameters)
        {

            var dic = new Dictionary<string, string>
            {
                { "gstin", apiRequestParameters.gstin },
                { "ret_period", apiRequestParameters.ret_period },
                { "action", "TCS" }
            };

            return dic;
        }
        public async Task<GSTNResult<List<GetTCSCreditGSTR2A>>> GetTCS2A(APIRequestParameters apiRequestParameters)
        {
            Dictionary<string, string> dic = this.prepareISD2ADictionary(apiRequestParameters);
            this.PrepareQueryString(dic);
            var info = await this.GetAsync<ResponseDataInfo>();
            var output = this.Decrypt<GSTR2ATotal>(info.Data);
            var model = this.BuildResult<List<GetTCSCreditGSTR2A>>(info, output.GetTCSCreditGSTR2A);
            return model;
        }

        private Dictionary<string, string> prepareTDS2ADictionary(APIRequestParameters apiRequestParameters)
        {

            var dic = new Dictionary<string, string>
            {
                { "gstin", apiRequestParameters.gstin },
                { "ret_period", apiRequestParameters.ret_period },
                { "action", "TDS" }
            };

            return dic;
        }
        public async Task<GSTNResult<List<GetTDSCreditGSTR2A>>> GetTDS2A(APIRequestParameters apiRequestParameters)
        {
            Dictionary<string, string> dic = this.prepareISD2ADictionary(apiRequestParameters);
            this.PrepareQueryString(dic);
            var info = await this.GetAsync<ResponseDataInfo>();
            var output = this.Decrypt<GSTR2ATotal>(info.Data);
            var model = this.BuildResult<List<GetTDSCreditGSTR2A>>(info, output.GetTDSCreditGSTR2A);
            return model;
        }
    }
}
