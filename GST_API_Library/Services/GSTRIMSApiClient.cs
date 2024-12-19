using GST_API_Library.Models;
using GST_API_Library.Models.GSTRIMS;
using GST_API_Library.Models.GSTRIMSTotal;
using Integrated.API.GSTN.GSTRIMS;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GST_API_Library.Services
{
    public class GSTRIMSApiClient : GSTNReturnsClient
    {
        public GSTRIMSApiClient(IGSTNAuthProvider provider, string gstin, string ret_period, string URL)
            : base(provider, URL, gstin, ret_period)
        {
        }

        private Dictionary<string, string> prepareInvoiceCountDictionary(APIRequestParameters apiRequestParameters)
        {
            if (apiRequestParameters == null || string.IsNullOrEmpty(apiRequestParameters.gstin))
            {
                throw new Exception("gstin is required");
            }
            var dic = new Dictionary<string, string>
            {
                { "gstin", apiRequestParameters.gstin },
                { "goods_typ", apiRequestParameters.goods_typ },
                { "action", "GETCNT" }
            };
           
            return dic;
        }

        public async Task<GSTNResult<List<GetIMSInvoiceCountResp>>> GetIMSInvoiceCount(APIRequestParameters apiRequestParameters)
        {
            Dictionary<string, string> dic = this.prepareInvoiceCountDictionary(apiRequestParameters);
            this.PrepareQueryString(dic);
            var info = await this.GetAsync<ResponseDataInfo>();
            var output = this.Decrypt<GSTRIMSTotal>(info.Data);
            var model = this.BuildResult<List<GetIMSInvoiceCountResp>>(info,output.invoicecount);
            return model;

        }

        private Dictionary<string, string> prepareFileDetailDictionary(APIRequestParameters apiRequestParameters)
        {
            if (apiRequestParameters == null || string.IsNullOrEmpty(apiRequestParameters.gstin))
            {
                throw new Exception("gstin is required");
            }
            var dic = new Dictionary<string, string>
            {
                { "gstin", apiRequestParameters.gstin },
                { "token", apiRequestParameters.token },
                { "action", "FILEDET" }
            };

            return dic;
        }

        public async Task<GSTNResult<List<GetIMSFileDetailResp>>> GetIMSFileDetail(APIRequestParameters apiRequestParameters)
        {
            Dictionary<string, string> dic = this.prepareFileDetailDictionary(apiRequestParameters);
            this.PrepareQueryString(dic);
            var info = await this.GetAsync<ResponseDataInfo>();
            var output = this.Decrypt<GetIMSFileDetailResp>(info.Data);
            var model = this.BuildResult<List<GetIMSFileDetailResp>>(info, null);
            return model;

        }


    }
}
