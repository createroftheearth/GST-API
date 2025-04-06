using GST_API_Library.Models.CommonAPI;
using GST_API_Library.Models;
using Integrated.API.GSTN.CommonAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
//using GST_API_Library.Models.GSTR1;

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

        //Garima Common API Code April 2024 

        public async Task<GSTNResult<SavePreferenceResponse>> SavePreference(SavePrefernceRequest data)
        {
            var model = this.Encrypt(data);
            model.action = "SAVEPREF";

            var info = await this.PutAsync<UnsignedDataInfo, ResponseDataInfo>(model);
            if (info == null)
            {
                throw new Exception("Unable to get the details from server");
            }
            var output = this.Decrypt<SavePreferenceResponse>(info.Data);
            var model2 = this.BuildResult<SavePreferenceResponse>(info, output);
            return model2;
        }
        //private Dictionary<string, string> prepareSignedPDFDictionary(APIRequestParameters apiRequestParameters)
        //{
        //    if (apiRequestParameters == null || string.IsNullOrEmpty(apiRequestParameters.gstin) || string.IsNullOrEmpty(apiRequestParameters.ret_period) || string.IsNullOrEmpty(apiRequestParameters.ret_type))
        //    {
        //        throw new Exception("Doc id is required");
        //    }
        //    var dic = new Dictionary<string, string>
        //    {
        //        { "gstin", apiRequestParameters.gstin },
        //        { "ret_period", apiRequestParameters.ret_period },
        //        { "ret_type", apiRequestParameters.ret_type },
        //        { "action", "SIGNEDPDF" }
        //    };
        //    return dic;
        //}

        private Dictionary<string, string> prepareSignedPDFDictionary(APIRequestParameters apiRequestParameters)
        {
            if (apiRequestParameters == null || string.IsNullOrEmpty(apiRequestParameters.gstin) || string.IsNullOrEmpty(apiRequestParameters.ret_period))
            {
                throw new Exception("gstin and ret_period is required");
            }
            var dic = new Dictionary<string, string>
            {
                { "gstin", apiRequestParameters.gstin },
                { "ret_period", apiRequestParameters.ret_period },
                { "ret_type", apiRequestParameters.ret_type },
                { "action", "SIGNEDPDF" }
            };
            return dic;
        }

        public async Task<GSTNResult<List<GetSignedPDFResponse>>> GetSignedPDF(APIRequestParameters apiRequestParameters)
        {
            Dictionary<string, string> dic = this.prepareSignedPDFDictionary(apiRequestParameters);
            this.PrepareQueryString(dic);
            var info = await this.GetAsync<ResponseDataInfo>();
            var output = this.Decrypt<CommonAPITotal>(info.Data);
            var model = this.BuildResult<List<GetSignedPDFResponse>>(info, output.signed);
            return model;

        }

        private Dictionary<string, string> prepareAddLtFeeBrkDictionary(APIRequestParameters apiRequestParameters)
        {
            if (apiRequestParameters == null || string.IsNullOrEmpty(apiRequestParameters.gstin) || string.IsNullOrEmpty(apiRequestParameters.ret_period))
            {
                throw new Exception("gstin and ret_period is required");
            }
            var dic = new Dictionary<string, string>
            {
                { "gstin", apiRequestParameters.gstin },
                { "ret_period", apiRequestParameters.ret_period },
                { "rtn_typ", "R3B" },
                { "action", "LATEFEEBREAKUP" }
            };
            return dic;
        }

        public async Task<GSTNResult<List<GetAddLateFeeBrkup>>> GetAddLtFeeBrk(APIRequestParameters apiRequestParameters)
        {
            Dictionary<string, string> dic = this.prepareAddLtFeeBrkDictionary(apiRequestParameters);
            this.PrepareQueryString(dic);
            var info = await this.GetAsync<ResponseDataInfo>();
            var output = this.Decrypt<CommonAPITotal>(info.Data);
            var model = this.BuildResult<List<GetAddLateFeeBrkup>>(info, output.AddLtFeeBrk);
            return model;

        }

        private Dictionary<string, string> prepareFileDetailDictionary(APIRequestParameters apiRequestParameters)
        {
            if (apiRequestParameters == null || string.IsNullOrEmpty(apiRequestParameters.gstin) || string.IsNullOrEmpty(apiRequestParameters.ret_period))
            {
                throw new Exception("gstin and ret_period is required");
            }
            var dic = new Dictionary<string, string>
            {
                { "gstin", apiRequestParameters.gstin },
                { "ret_period", apiRequestParameters.ret_period },
                { "token", apiRequestParameters.token },
                { "action", "FILEDET" }
            };
            return dic;
        }

        public async Task<GSTNResult<List<GetFileDetails>>> GetFileDetails(APIRequestParameters apiRequestParameters)
        {
            Dictionary<string, string> dic = this.prepareFileDetailDictionary(apiRequestParameters);
            this.PrepareQueryString(dic);
            var info = await this.GetAsync<ResponseDataInfo>();
            var output = this.Decrypt<CommonAPITotal>(info.Data);
            var model = this.BuildResult<List<GetFileDetails>>(info, output.FileDetails);
            return model;

        }

    }
}
