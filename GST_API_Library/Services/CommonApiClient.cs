using GST_API_Library.Models.CommonAPI;
using GST_API_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GST_API_Library.Services
{
    public class CommonApiClient : GSTNReturnsClient
    {
        public CommonApiClient(IGSTNAuthProvider provider, string gstin, string ret_period, string URL)
         : base(provider, URL, gstin, ret_period)
        {
        }

        //This is a common API that can be used to Download Document
        private Dictionary<string, string> prepareAllDownloadDocDictionary(APIRequestParameters apiRequestParameters)
        {
            if (apiRequestParameters == null || string.IsNullOrEmpty(apiRequestParameters.doc_id))
            {
                throw new Exception("Doc id is required");
            }
            var dic = new Dictionary<string, string>
            {
                { "doc_id", apiRequestParameters.doc_id },
                { "action", "DOCDOWNLOAD" }
            };
            return dic;
        }
        public async Task<GSTNResult<List<AllDownloadDoc>>> GetAllDownloadDoc(APIRequestParameters apiRequestParameters)
        {
            Dictionary<string, string> dic = this.prepareAllDownloadDocDictionary(apiRequestParameters);
            this.PrepareQueryString(dic);
            var info = await this.GetAsync<ResponseDataInfo>();
            var output = this.Decrypt<AllDownloadDoc>(info.Data);
            var model = this.BuildResult<List<AllDownloadDoc>>(info, null);
            return model;

        }

    }
}
