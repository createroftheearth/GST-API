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
            Dictionary<string, string> dic = this.prepareECOMA2ADictionary(apiRequestParameters);
            this.PrepareQueryString(dic);
            var info = await this.GetAsync<ResponseDataInfo>();
            var output = this.Decrypt<GSTR2ATotal>(info.Data);
            var model = this.BuildResult<List<GetIMPGGSTR2A>>(info, output.GetIMPGGSTR2A);
            return model;
        }


    }
}
