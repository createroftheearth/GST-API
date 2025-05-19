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

        public async Task<GSTNResult<SaveInfo>> SaveIMS(SaveRequestIMS data)
        {
            var model = this.Encrypt(data);
            model.action = "SAVE";
            var info = await this.PutAsync<UnsignedDataInfo, ResponseDataInfo>(model);
            if (info == null)
            {
                throw new Exception("Unable to get the details from server");
            }
            var output = this.Decrypt<SaveInfo>(info.Data);
            var model2 = this.BuildResult<SaveInfo>(info, output);
            return model2;
        }

        public async Task<GSTNResult<SaveInfo>> ResetIMS(SaveRequestIMS data)
        {
            var model = this.Encrypt(data);
            model.action = "RESETIMS";
            var info = await this.PutAsync<UnsignedDataInfo, ResponseDataInfo>(model);
            if (info == null)
            {
                throw new Exception("Unable to get the details from server");
            }
            var output = this.Decrypt<SaveInfo>(info.Data);
            var model2 = this.BuildResult<SaveInfo>(info, output);
            return model2;
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

        private Dictionary<string, string> prepareSupInvoiceDictionary(APIRequestParameters apiRequestParameters)
        {
            if (apiRequestParameters == null || string.IsNullOrEmpty(apiRequestParameters.gstin))
            {
                throw new Exception("gstin is required");
            }
            var dic = new Dictionary<string, string>
            {
                { "gstin", apiRequestParameters.gstin },
                { "ret_period", apiRequestParameters.ret_period },
                { "section", apiRequestParameters.section },
                { "rtn_typ", apiRequestParameters.rtn_typ },
                { "action", "SUPVIEW" }
            };

            return dic;
        }

        public async Task<GSTNResult<List<GetIMSSUPInvoices>>> GetIMSSupInvoice(APIRequestParameters apiRequestParameters)
        {
            Dictionary<string, string> dic = this.prepareSupInvoiceDictionary(apiRequestParameters);
            this.PrepareQueryString(dic);
            var info = await this.GetAsync<ResponseDataInfo>();
            var output = this.Decrypt<GSTRIMSTotal>(info.Data);
            var model = this.BuildResult<List<GetIMSSUPInvoices>>(info, output.IMSSUPInvoices);
            return model;

        }

        private Dictionary<string, string> prepareInvoicesDictionary(APIRequestParameters apiRequestParameters)
        {
            if (apiRequestParameters == null || string.IsNullOrEmpty(apiRequestParameters.gstin))
            {
                throw new Exception("gstin is required");
            }
            var dic = new Dictionary<string, string>
            {
                { "gstin", apiRequestParameters.gstin },
                { "section", apiRequestParameters.section },
                { "status", apiRequestParameters.status },
                { "action", "GETINV" }
            };

            return dic;
        }

        public async Task<GSTNResult<List<GetIMSInvoices>>> GetIMSInvoices(APIRequestParameters apiRequestParameters)
        {
            Dictionary<string, string> dic = this.prepareInvoicesDictionary(apiRequestParameters);
            this.PrepareQueryString(dic);
            var info = await this.GetAsync<ResponseDataInfo>();
            var output = this.Decrypt<GSTRIMSTotal>(info.Data);
            var model = this.BuildResult<List<GetIMSInvoices>>(info, output.invoices);
            return model;

        }

        private Dictionary<string, string> prepareIMSRequestStatusDictionary(APIRequestParameters apiRequestParameters)
        {
            if (apiRequestParameters == null || string.IsNullOrEmpty(apiRequestParameters.gstin))
            {
                throw new Exception("gstin is required");
            }
            var dic = new Dictionary<string, string>
            {
                { "gstin", apiRequestParameters.gstin },
                { "int_tran_id", apiRequestParameters.int_tran_id },
                { "action", "REQSTS" }
            };

            return dic;
        }

        public async Task<GSTNResult<List<GetIMSRequestStatus>>> GetIMSRequestStatus(APIRequestParameters apiRequestParameters)
        {
            Dictionary<string, string> dic = this.prepareIMSRequestStatusDictionary(apiRequestParameters);
            this.PrepareQueryString(dic);
            var info = await this.GetAsync<ResponseDataInfo>();
            var output = this.Decrypt<GSTRIMSTotal>(info.Data);
            var model = this.BuildResult<List<GetIMSRequestStatus>>(info, output.imsrequeststatus);
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
