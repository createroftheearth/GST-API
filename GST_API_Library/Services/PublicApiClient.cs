using GST_API_Library.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GST_API_Library.Models.PublicAPI;

namespace GST_API_Library.Services
{
    public class PublicApiClient : GSTNReturnsClient
    {
        public PublicApiClient(IGSTNAuthProvider provider, string gstin, string ret_period, string URL)
           : base(provider, URL, gstin, ret_period)
        {
        }

        //API call for searching IRN details
        private Dictionary<string, string> prepareSearchIRNDictionary(APIRequestParameters apiRequestParameters)
        {
            if (apiRequestParameters == null || string.IsNullOrEmpty(apiRequestParameters.gstin) || string.IsNullOrEmpty(apiRequestParameters.ret_period))
            {
                throw new Exception("gstin and ret_period is required");
            }
            var dic = new Dictionary<string, string>
            {
                { "action", "EINV" }
            };
            if (!string.IsNullOrEmpty(apiRequestParameters.action_required))
            {
                dic.Add("action_required", apiRequestParameters.action_required);
            }
            if (!string.IsNullOrEmpty(apiRequestParameters.irn))
            {
                dic.Add("irn", apiRequestParameters.irn);
            }
            return dic;
        }
        public async Task<GSTNResult<List<EinvSearchIRNDetails>>> SearchIRNDetails(APIRequestParameters apiRequestParameters)
        {
            Dictionary<string, string> dic = this.prepareSearchIRNDictionary(apiRequestParameters);
            this.PrepareQueryString(dic);
            var info = await this.GetAsync<ResponseDataInfo>();
            var output = this.Decrypt<PublicAPITotal>(info.Data);
            //var output = this.Decrypt<ReturnStatusInfo>(info.Data);
            var model = this.BuildResult<List<EinvSearchIRNDetails>>(info, output.searchirndetails);
            return model;
        }

        //API call for getting list API Access details
        private Dictionary<string, string> prepareApiPermissionDictionary(APIRequestParameters apiRequestParameters)
        {
            if (apiRequestParameters == null || string.IsNullOrEmpty(apiRequestParameters.gstin) || string.IsNullOrEmpty(apiRequestParameters.ret_period))
            {
                throw new Exception("gstin and ret_period is required");
            }
            var dic = new Dictionary<string, string>
            {
                { "action", "ACCDTL" }
            };
            if (!string.IsNullOrEmpty(apiRequestParameters.action_required))
            {
                dic.Add("action_required", apiRequestParameters.action_required);
            }
            if (!string.IsNullOrEmpty(apiRequestParameters.gstin))
            {
                dic.Add("irn", apiRequestParameters.gstin);
            }
            return dic;
        }
        public async Task<GSTNResult<List<GetAPIPermissiondetails>>> GetApiPermissionDetails(APIRequestParameters apiRequestParameters)
        {
            Dictionary<string, string> dic = this.prepareApiPermissionDictionary(apiRequestParameters);
            this.PrepareQueryString(dic);
            var info = await this.GetAsync<ResponseDataInfo>();
            var output = this.Decrypt<PublicAPITotal>(info.Data);
            //var output = this.Decrypt<ReturnStatusInfo>(info.Data);
            var model = this.BuildResult<List<GetAPIPermissiondetails>>(info, output.apipermissiondetails);
            return model;
        }

        //API call for getting list API Access details
        private Dictionary<string, string> prepareDayWiseListDictionary(APIRequestParameters apiRequestParameters)
        {
            if (apiRequestParameters == null || string.IsNullOrEmpty(apiRequestParameters.gstin) || string.IsNullOrEmpty(apiRequestParameters.ret_period))
            {
                throw new Exception("gstin and ret_period is required");
            }
            var dic = new Dictionary<string, string>
            {
                { "action", "INCLIST" }
            };
            if (!string.IsNullOrEmpty(apiRequestParameters.action))
            {
                dic.Add("action_required", apiRequestParameters.action);
            }
            if (!string.IsNullOrEmpty(apiRequestParameters.state_cd))
            {
                dic.Add("state", apiRequestParameters.state_cd);
            }
            if (!string.IsNullOrEmpty(apiRequestParameters.date))
            {
                if (!DateTime.TryParseExact(apiRequestParameters.from_time, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                {
                    throw new Exception("Date Should be provided in dd-MM-yyyy format only");
                }
                dic.Add("date", apiRequestParameters.date);
            }
            if (!string.IsNullOrEmpty(apiRequestParameters.pgnum))
            {
                dic.Add("Page/FileNumber", apiRequestParameters.pgnum);
            }
            return dic;
        }
        public async Task<GSTNResult<List<GetDayWiseChangedListofGSTINs>>> GetDayWiseListDetails(APIRequestParameters apiRequestParameters)
        {
            Dictionary<string, string> dic = this.prepareDayWiseListDictionary(apiRequestParameters);
            this.PrepareQueryString(dic);
            var info = await this.GetAsync<ResponseDataInfo>();
            var output = this.Decrypt<PublicAPITotal>(info.Data);
            var model = this.BuildResult<List<GetDayWiseChangedListofGSTINs>>(info, output.daywisechangedlistgstin);
            return model;
        }


        //Garima Public APIs 19 April 2024


        //This API is to view and track Returns status for public
        private Dictionary<string, string> prepareViewTrackRetListDictionary(APIRequestParameters apiRequestParameters)
        {
            if (apiRequestParameters == null || string.IsNullOrEmpty(apiRequestParameters.gstin) || string.IsNullOrEmpty(apiRequestParameters.ret_period))
            {
                throw new Exception("gstin and ret_period is required");
            }
            var dic = new Dictionary<string, string>
            {
                { "gstin", apiRequestParameters.gstin },
                { "ret_period", apiRequestParameters.ret_period },
                {"type",apiRequestParameters.type },
                { "action", "RETTRACK" }
            };
            if (!string.IsNullOrEmpty(apiRequestParameters.action))
            {
                dic.Add("action_required", apiRequestParameters.action);
            }
            if (!string.IsNullOrEmpty(apiRequestParameters.state_cd))
            {
                dic.Add("type", apiRequestParameters.state_cd);
            }
            return dic;
        }
        public async Task<GSTNResult<List<ViewandTrackReturns>>> GetViewTrackRet(APIRequestParameters apiRequestParameters)
        {
            Dictionary<string, string> dic = this.prepareViewTrackRetListDictionary(apiRequestParameters);
            this.PrepareQueryString(dic);
            var info = await this.GetAsync<ResponseDataInfo>();
            var output = this.Decrypt<PublicAPITotal>(info.Data);
            var model = this.BuildResult<List<ViewandTrackReturns>>(info, output.viewandtrackreturn);
            return model;
        }

        //API Service is used to validate GSTIN and send back required additional details in the response.
        private Dictionary<string, string> prepareupdatedVerificationGSTINDictionary(APIRequestParameters apiRequestParameters)
        {
            if (apiRequestParameters == null || string.IsNullOrEmpty(apiRequestParameters.gstin))
            {
                throw new Exception("gstin is required");
            }
            var dic = new Dictionary<string, string>
            {
                { "action", "TP" }
            };
            //if (!string.IsNullOrEmpty(apiRequestParameters.action))
            //{
            //    dic.Add("action_required", apiRequestParameters.action);
            //}
            return dic;
        }
        public async Task<GSTNResult<List<UpdatedOnlineVerificationofGSTIN>>> GetupdatedVerificationGSTIN(APIRequestParameters apiRequestParameters)
        {
            Dictionary<string, string> dic = this.prepareupdatedVerificationGSTINDictionary(apiRequestParameters);
            this.PrepareQueryString(dic);
            var info = await this.GetAsync<ResponseDataInfo>();
            var output = this.Decrypt<PublicAPITotal>(info.Data);
            var model = this.BuildResult<List<UpdatedOnlineVerificationofGSTIN>>(info, output.updateonlineverificationofgstin);
            return model;
        }

        private Dictionary<string, string> prepareUnregApplicantsDictionary(APIRequestParameters apiRequestParameters)
        {
            if (apiRequestParameters == null || string.IsNullOrEmpty(apiRequestParameters.gstin))
            {
                throw new Exception("gstin is required");
            }
            var dic = new Dictionary<string, string>
            {
                { "action", "TP" }
            };
            if (!string.IsNullOrEmpty(apiRequestParameters.action))
            {
                dic.Add("uid", apiRequestParameters.uid);
            }

            if (!string.IsNullOrEmpty(apiRequestParameters.action))
            {
                dic.Add("action_required", apiRequestParameters.action);
            }
            return dic;
        }
        public async Task<GSTNResult<List<UnregApplicantsResponse>>> GetUnregApplicants(APIRequestParameters apiRequestParameters)
        {
            Dictionary<string, string> dic = this.prepareUnregApplicantsDictionary(apiRequestParameters);
            this.PrepareQueryString(dic);
            var info = await this.GetAsync<ResponseDataInfo>();
            var output = this.Decrypt<PublicAPITotal>(info.Data);
            var model = this.BuildResult<List<UnregApplicantsResponse>>(info, output.unregapp);
            return model;
        }

        private Dictionary<string, string> prepareUnregApplicantsValiDictionary(APIRequestParameters apiRequestParameters)
        {
            if (apiRequestParameters == null || string.IsNullOrEmpty(apiRequestParameters.gstin))
            {
                throw new Exception("gstin is required");
            }
            var dic = new Dictionary<string, string>
            {
                { "action", "TP" }
            };
            if (!string.IsNullOrEmpty(apiRequestParameters.action))
            {
                dic.Add("uid", apiRequestParameters.uid);
            }
            if (!string.IsNullOrEmpty(apiRequestParameters.action))
            {
                dic.Add("email", apiRequestParameters.email);
            }
            if (!string.IsNullOrEmpty(apiRequestParameters.action))
            {
                dic.Add("mobile", apiRequestParameters.mobile);
            }

            if (!string.IsNullOrEmpty(apiRequestParameters.action))
            {
                dic.Add("action_required", apiRequestParameters.action);
            }
            return dic;
        }
        public async Task<GSTNResult<List<UnregApplicantsValidationResponse>>> GetUnregApplicantsValidation(APIRequestParameters apiRequestParameters)
        {
            Dictionary<string, string> dic = this.prepareUnregApplicantsValiDictionary(apiRequestParameters);
            this.PrepareQueryString(dic);
            var info = await this.GetAsync<ResponseDataInfo>();
            var output = this.Decrypt<PublicAPITotal>(info.Data);
            var model = this.BuildResult<List<UnregApplicantsValidationResponse>>(info, output.unregappvalidation);
            return model;
        }


    }
}
