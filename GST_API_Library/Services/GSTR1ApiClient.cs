using GST_API_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using GST_API_Library.Models.GSTR1;
using GST_API_Library.Models.GSTR1;
using System.Globalization;
using Integrated.API.GSTN.GSTR1;

namespace GST_API_Library.Services
{
    public class GSTR1ApiClient : GSTNReturnsClient
    {
        //"/taxpayerapi/v2.1/returns/gstr1"
        //action_required=“Y|N“
        public GSTR1ApiClient(IGSTNAuthProvider provider, string gstin, string ret_period, string URL)
            : base(provider, URL, gstin, ret_period)
        {
        }

        public async Task<GSTNResult<SaveInfo>> Save(GSTR1Total data)
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
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiRequestParameters"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        /// 

        //API call  for getting advance tax details for a return period.
        private Dictionary<string, string> prepareATDictionary(APIRequestParameters apiRequestParameters)
        {
            if (apiRequestParameters == null || string.IsNullOrEmpty(apiRequestParameters.gstin) || string.IsNullOrEmpty(apiRequestParameters.ret_period))
            {
                throw new Exception("gstin and ret_period is required");
            }
            var dic = new Dictionary<string, string>
            {
                { "gstin", apiRequestParameters.gstin },
                { "ret_period", apiRequestParameters.ret_period },
                { "action", "AT" }
            };
            if (!string.IsNullOrEmpty(apiRequestParameters.action_required))
            {
                dic.Add("action_required", apiRequestParameters.action_required);
            }
            if (!string.IsNullOrEmpty(apiRequestParameters.ctin))
            {
                dic.Add("ctin", apiRequestParameters.ctin);
            }
            if (!string.IsNullOrEmpty(apiRequestParameters.from_time))
            {
                if (!DateTime.TryParseExact(apiRequestParameters.from_time, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                {
                    throw new Exception("Date Should be provided in dd-MM-yyyy format only");
                }
                dic.Add("action_required", apiRequestParameters.from_time);
            }
            return dic;
        }
        public async Task<GSTNResult<List<AtOutward>>> GetAT(APIRequestParameters apiRequestParameters)
        {
            Dictionary<string, string> dic = this.prepareATDictionary(apiRequestParameters);
            this.PrepareQueryString(dic);
            var info = await this.GetAsync<ResponseDataInfo>();
            var output = this.Decrypt<GSTR1Total>(info.Data);
            var model = this.BuildResult<List<AtOutward>>(info, output.at);
            return model;

        }

        //API call  for getting amended advance tax details for a return period.
        private Dictionary<string, string> prepareATADictionary(APIRequestParameters apiRequestParameters)
        {
            if (apiRequestParameters == null || string.IsNullOrEmpty(apiRequestParameters.gstin) || string.IsNullOrEmpty(apiRequestParameters.ret_period))
            {
                throw new Exception("gstin and ret_period is required");
            }
            var dic = new Dictionary<string, string>
            {
                { "gstin", apiRequestParameters.gstin },
                { "ret_period", apiRequestParameters.ret_period },
                { "action", "ATA" }
            };
            if (!string.IsNullOrEmpty(apiRequestParameters.action_required))
            {
                dic.Add("action_required", apiRequestParameters.action_required);
            }
            if (!string.IsNullOrEmpty(apiRequestParameters.ctin))
            {
                dic.Add("ctin", apiRequestParameters.ctin);
            }
            if (!string.IsNullOrEmpty(apiRequestParameters.from_time))
            {
                if (!DateTime.TryParseExact(apiRequestParameters.from_time, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                {
                    throw new Exception("Date Should be provided in dd-MM-yyyy format only");
                }
                dic.Add("action_required", apiRequestParameters.from_time);
            }
            return dic;
        }
        public async Task<GSTNResult<List<AtAOutward>>> GetATA(APIRequestParameters apiRequestParameters)
        {
            
            Dictionary<string, string> dic = this.prepareATADictionary(apiRequestParameters);
            this.PrepareQueryString(dic);
            var info = await this.GetAsync<ResponseDataInfo>();
            var output = this.Decrypt<GSTR1Total>(info.Data);
            var model = this.BuildResult<List<AtAOutward>>(info, output.ata);
            return model;

        }

        //API call for getting all B2B invoices for a return period.
        private Dictionary<string, string> prepareB2BDictionary(APIRequestParameters apiRequestParameters)
        {
            if (apiRequestParameters == null || string.IsNullOrEmpty(apiRequestParameters.gstin) || string.IsNullOrEmpty(apiRequestParameters.ret_period))
            {
                throw new Exception("gstin and ret_period is required");
            }
            var dic = new Dictionary<string, string>
            {
                { "gstin", apiRequestParameters.gstin },
                { "ret_period", apiRequestParameters.ret_period },
                { "action", "B2B" }
            };
            if (!string.IsNullOrEmpty(apiRequestParameters.action_required))
            {
                dic.Add("action_required", apiRequestParameters.action_required);
            }
            if (!string.IsNullOrEmpty(apiRequestParameters.ctin))
            {
                dic.Add("ctin", apiRequestParameters.ctin);
            }
            if (!string.IsNullOrEmpty(apiRequestParameters.from_time))
            {
                if (!DateTime.TryParseExact(apiRequestParameters.from_time, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                {
                    throw new Exception("Date Should be provided in dd-MM-yyyy format only");
                }
                dic.Add("action_required", apiRequestParameters.from_time);
            }
            return dic;
        }
        public async Task<GSTNResult<List<B2bOutward>>> GetB2B(APIRequestParameters apiRequestParameters)
        {
            Dictionary<string, string> dic = this.prepareB2BDictionary(apiRequestParameters);            
            this.PrepareQueryString(dic);
            var info = await this.GetAsync<ResponseDataInfo>();
            var output = this.Decrypt<GSTR1Total>(info.Data);
            //var output = this.Decrypt<ReturnStatusInfo>(info.Data);
            var model = this.BuildResult<List<B2bOutward>>(info, output.b2b);
            return model;
        }

        //API call  for getting all B2B amended invoices for a return period.
        private Dictionary<string, string> prepareB2BADictionary(APIRequestParameters apiRequestParameters)
        {
            if (apiRequestParameters == null || string.IsNullOrEmpty(apiRequestParameters.gstin) || string.IsNullOrEmpty(apiRequestParameters.ret_period))
            {
                throw new Exception("gstin and ret_period is required");
            }
            var dic = new Dictionary<string, string>
            {
                { "gstin", apiRequestParameters.gstin },
                { "ret_period", apiRequestParameters.ret_period },
                { "action", "B2BA" }
            };
            if (!string.IsNullOrEmpty(apiRequestParameters.action_required))
            {
                dic.Add("action_required", apiRequestParameters.action_required);
            }
            if (!string.IsNullOrEmpty(apiRequestParameters.ctin))
            {
                dic.Add("ctin", apiRequestParameters.ctin);
            }
            if (!string.IsNullOrEmpty(apiRequestParameters.from_time))
            {
                if (!DateTime.TryParseExact(apiRequestParameters.from_time, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                {
                    throw new Exception("Date Should be provided in dd-MM-yyyy format only");
                }
                dic.Add("action_required", apiRequestParameters.from_time);
            }
            return dic;
        }
        public async Task<GSTNResult<List<B2bAOutward>>> GetB2BA(APIRequestParameters apiRequestParameters)
        {
            Dictionary<string, string> dic = this.prepareB2BADictionary(apiRequestParameters);
            this.PrepareQueryString(dic);
            var info = await this.GetAsync<ResponseDataInfo>();
            var output = this.Decrypt<GSTR1Total>(info.Data);
            var model = this.BuildResult<List<B2bAOutward>>(info, output.b2ba);
            return model;

        }

        //API call  for getting all B2C Large invoices for a return period.
        private Dictionary<string, string> prepareB2CLDictionary(APIRequestParameters apiRequestParameters)
        {
            if (apiRequestParameters == null || string.IsNullOrEmpty(apiRequestParameters.gstin) || string.IsNullOrEmpty(apiRequestParameters.ret_period))
            {
                throw new Exception("gstin and ret_period is required");
            }
            var dic = new Dictionary<string, string>
            {
                { "gstin", apiRequestParameters.gstin },
                { "ret_period", apiRequestParameters.ret_period },
                { "action", "B2CL" }
            };
            if (!string.IsNullOrEmpty(apiRequestParameters.action_required))
            {
                dic.Add("action_required", apiRequestParameters.action_required);
            }
            if (!string.IsNullOrEmpty(apiRequestParameters.ctin))
            {
                dic.Add("ctin", apiRequestParameters.ctin);
            }
            if (!string.IsNullOrEmpty(apiRequestParameters.from_time))
            {
                if (!DateTime.TryParseExact(apiRequestParameters.from_time, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                {
                    throw new Exception("Date Should be provided in dd-MM-yyyy format only");
                }
                dic.Add("action_required", apiRequestParameters.from_time);
            }
            return dic;
        }
        public async Task<GSTNResult<List<B2clOutward>>> GetB2CL(APIRequestParameters apiRequestParameters)
        {
            Dictionary<string, string> dic = this.prepareB2CLDictionary(apiRequestParameters);
            this.PrepareQueryString(dic);
            var info = await this.GetAsync<ResponseDataInfo>();
            var output = this.Decrypt<GSTR1Total>(info.Data);
            var model = this.BuildResult<List<B2clOutward>>(info, output.b2cl);
            return model;

        }

        //API call  for getting all B2C Large invoices with amendments for a return period.
        private Dictionary<string, string> prepareB2CLADictionary(APIRequestParameters apiRequestParameters)
        {
            if (apiRequestParameters == null || string.IsNullOrEmpty(apiRequestParameters.gstin) || string.IsNullOrEmpty(apiRequestParameters.ret_period))
            {
                throw new Exception("gstin and ret_period is required");
            }
            var dic = new Dictionary<string, string>
            {
                { "gstin", apiRequestParameters.gstin },
                { "ret_period", apiRequestParameters.ret_period },
                { "action", "B2CLA" }
            };
            if (!string.IsNullOrEmpty(apiRequestParameters.action_required))
            {
                dic.Add("action_required", apiRequestParameters.action_required);
            }
            if (!string.IsNullOrEmpty(apiRequestParameters.ctin))
            {
                dic.Add("ctin", apiRequestParameters.ctin);
            }
            if (!string.IsNullOrEmpty(apiRequestParameters.from_time))
            {
                if (!DateTime.TryParseExact(apiRequestParameters.from_time, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                {
                    throw new Exception("Date Should be provided in dd-MM-yyyy format only");
                }
                dic.Add("action_required", apiRequestParameters.from_time);
            }
            return dic;
        }
        public async Task<GSTNResult<List<B2clAOutward>>> GetB2CLA(APIRequestParameters apiRequestParameters)
        {
            Dictionary<string, string> dic = this.prepareB2CLADictionary(apiRequestParameters);
            this.PrepareQueryString(dic);
            var info = await this.GetAsync<ResponseDataInfo>();
            var output = this.Decrypt<GSTR1Total>(info.Data);
            var model = this.BuildResult<List<B2clAOutward>>(info, output.b2cla);
            return model;

        }

        //API call for getting all B2C HSN data for a return period.
        private Dictionary<string, string> prepareB2CSDictionary(APIRequestParameters apiRequestParameters)
        {
            if (apiRequestParameters == null || string.IsNullOrEmpty(apiRequestParameters.gstin) || string.IsNullOrEmpty(apiRequestParameters.ret_period))
            {
                throw new Exception("gstin and ret_period is required");
            }
            var dic = new Dictionary<string, string>
            {
                { "gstin", apiRequestParameters.gstin },
                { "ret_period", apiRequestParameters.ret_period },
                { "action", "B2CS" }
            };
            if (!string.IsNullOrEmpty(apiRequestParameters.action_required))
            {
                dic.Add("action_required", apiRequestParameters.action_required);
            }
            if (!string.IsNullOrEmpty(apiRequestParameters.ctin))
            {
                dic.Add("ctin", apiRequestParameters.ctin);
            }
            if (!string.IsNullOrEmpty(apiRequestParameters.from_time))
            {
                if (!DateTime.TryParseExact(apiRequestParameters.from_time, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                {
                    throw new Exception("Date Should be provided in dd-MM-yyyy format only");
                }
                dic.Add("action_required", apiRequestParameters.from_time);
            }
            return dic;
        }
        public async Task<GSTNResult<List<B2csOutward>>> GetB2Cs(APIRequestParameters apiRequestParameters)
        {
            Dictionary<string, string> dic = this.prepareB2CSDictionary(apiRequestParameters);
            this.PrepareQueryString(dic);
            var info = await this.GetAsync<ResponseDataInfo>();
            var output = this.Decrypt<GSTR1Total>(info.Data);
            var model = this.BuildResult<List<B2csOutward>>(info, output.b2cs);
            return model;

        }

        //API call for getting all B2CSA HSN data for a return period.
        private Dictionary<string, string> prepareB2CSADictionary(APIRequestParameters apiRequestParameters)
        {
            if (apiRequestParameters == null || string.IsNullOrEmpty(apiRequestParameters.gstin) || string.IsNullOrEmpty(apiRequestParameters.ret_period))
            {
                throw new Exception("gstin and ret_period is required");
            }
            var dic = new Dictionary<string, string>
            {
                { "gstin", apiRequestParameters.gstin },
                { "ret_period", apiRequestParameters.ret_period },
                { "action", "B2CSA" }
            };
            if (!string.IsNullOrEmpty(apiRequestParameters.action_required))
            {
                dic.Add("action_required", apiRequestParameters.action_required);
            }
            if (!string.IsNullOrEmpty(apiRequestParameters.ctin))
            {
                dic.Add("ctin", apiRequestParameters.ctin);
            }
            if (!string.IsNullOrEmpty(apiRequestParameters.from_time))
            {
                if (!DateTime.TryParseExact(apiRequestParameters.from_time, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                {
                    throw new Exception("Date Should be provided in dd-MM-yyyy format only");
                }
                dic.Add("action_required", apiRequestParameters.from_time);
            }
            return dic;
        }
        public async Task<GSTNResult<List<B2CSAOutward>>> GetB2CsA(APIRequestParameters apiRequestParameters)
        {

            Dictionary<string, string> dic = this.prepareB2CSADictionary(apiRequestParameters);
            this.PrepareQueryString(dic);
            var info = await this.GetAsync<ResponseDataInfo>();
            var output = this.Decrypt<GSTR1Total>(info.Data);
            var model = this.BuildResult<List<B2CSAOutward>>(info, output.b2csa);
            return model;

        }

        //API call  CDN for getting all Credit/Debit notes for a return period.
        private Dictionary<string, string> prepareCDNRDictionary(APIRequestParameters apiRequestParameters)
        {
            if (apiRequestParameters == null || string.IsNullOrEmpty(apiRequestParameters.gstin) || string.IsNullOrEmpty(apiRequestParameters.ret_period))
            {
                throw new Exception("gstin and ret_period is required");
            }
            var dic = new Dictionary<string, string>
            {
                { "gstin", apiRequestParameters.gstin },
                { "ret_period", apiRequestParameters.ret_period },
                { "action", "CDNR" }
            };
            if (!string.IsNullOrEmpty(apiRequestParameters.action_required))
            {
                dic.Add("action_required", apiRequestParameters.action_required);
            }
            if (!string.IsNullOrEmpty(apiRequestParameters.ctin))
            {
                dic.Add("ctin", apiRequestParameters.ctin);
            }
            if (!string.IsNullOrEmpty(apiRequestParameters.from_time))
            {
                if (!DateTime.TryParseExact(apiRequestParameters.from_time, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                {
                    throw new Exception("Date Should be provided in dd-MM-yyyy format only");
                }
                dic.Add("action_required", apiRequestParameters.from_time);
            }
            return dic;
        }
        public async Task<GSTNResult<List<CdnOutward>>> GetCDNR(APIRequestParameters apiRequestParameters)
        {
            Dictionary<string, string> dic = this.prepareCDNRDictionary(apiRequestParameters);
            this.PrepareQueryString(dic);
            var info = await this.GetAsync<ResponseDataInfo>();
            var output = this.Decrypt<GSTR1Total>(info.Data);
            var model = this.BuildResult<List<CdnOutward>>(info, output.cdn);
            return model;

        }

        //API call  CDNA for getting all amended Credit/Debit notes for a return period.
        private Dictionary<string, string> prepareCDNRADictionary(APIRequestParameters apiRequestParameters)
        {
            if (apiRequestParameters == null || string.IsNullOrEmpty(apiRequestParameters.gstin) || string.IsNullOrEmpty(apiRequestParameters.ret_period))
            {
                throw new Exception("gstin and ret_period is required");
            }
            var dic = new Dictionary<string, string>
            {
                { "gstin", apiRequestParameters.gstin },
                { "ret_period", apiRequestParameters.ret_period },
                { "action", "CDNRA" }
            };
            if (!string.IsNullOrEmpty(apiRequestParameters.action_required))
            {
                dic.Add("action_required", apiRequestParameters.action_required);
            }
            if (!string.IsNullOrEmpty(apiRequestParameters.ctin))
            {
                dic.Add("ctin", apiRequestParameters.ctin);
            }
            if (!string.IsNullOrEmpty(apiRequestParameters.from_time))
            {
                if (!DateTime.TryParseExact(apiRequestParameters.from_time, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                {
                    throw new Exception("Date Should be provided in dd-MM-yyyy format only");
                }
                dic.Add("action_required", apiRequestParameters.from_time);
            }
            return dic;
        }
        public async Task<GSTNResult<List<CDNAOutward>>> GetCDNA(APIRequestParameters apiRequestParameters)
        {
            Dictionary<string, string> dic = this.prepareCDNRADictionary(apiRequestParameters);
            this.PrepareQueryString(dic);
            var info = await this.GetAsync<ResponseDataInfo>();
            var output = this.Decrypt<GSTR1Total>(info.Data);
            var model = this.BuildResult<List<CDNAOutward>>(info, output.cdna);
            return model;

        }

        //This API will call CDNUR for getting all Credit/Debit notes for Unregistered Users.
        private Dictionary<string, string> prepareCDNURDictionary(APIRequestParameters apiRequestParameters)
        {
            if (apiRequestParameters == null || string.IsNullOrEmpty(apiRequestParameters.gstin) || string.IsNullOrEmpty(apiRequestParameters.ret_period))
            {
                throw new Exception("gstin and ret_period is required");
            }
            var dic = new Dictionary<string, string>
            {
                { "gstin", apiRequestParameters.gstin },
                { "ret_period", apiRequestParameters.ret_period },
                { "action", "CDNUR" }
            };
            if (!string.IsNullOrEmpty(apiRequestParameters.action_required))
            {
                dic.Add("action_required", apiRequestParameters.action_required);
            }
            if (!string.IsNullOrEmpty(apiRequestParameters.ctin))
            {
                dic.Add("ctin", apiRequestParameters.ctin);
            }
            if (!string.IsNullOrEmpty(apiRequestParameters.from_time))
            {
                if (!DateTime.TryParseExact(apiRequestParameters.from_time, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                {
                    throw new Exception("Date Should be provided in dd-MM-yyyy format only");
                }
                dic.Add("action_required", apiRequestParameters.from_time);
            }
            return dic;
        }
        public async Task<GSTNResult<List<CDNUR>>> GetCDNUR(APIRequestParameters apiRequestParameters)
        {
            Dictionary<string, string> dic = this.prepareCDNURDictionary(apiRequestParameters);
            this.PrepareQueryString(dic);
            var info = await this.GetAsync<ResponseDataInfo>();
            var output = this.Decrypt<GSTR1Total>(info.Data);
            var model = this.BuildResult<List<CDNUR>>(info, output.cdnur);
            return model;

        }

        //This API will call CDNURA for getting all Credit/Debit notes for Unregistered Users.
        private Dictionary<string, string> prepareCDNURADictionary(APIRequestParameters apiRequestParameters)
        {
            if (apiRequestParameters == null || string.IsNullOrEmpty(apiRequestParameters.gstin) || string.IsNullOrEmpty(apiRequestParameters.ret_period))
            {
                throw new Exception("gstin and ret_period is required");
            }
            var dic = new Dictionary<string, string>
            {
                { "gstin", apiRequestParameters.gstin },
                { "ret_period", apiRequestParameters.ret_period },
                { "action", "CDNURA" }
            };
            if (!string.IsNullOrEmpty(apiRequestParameters.action_required))
            {
                dic.Add("action_required", apiRequestParameters.action_required);
            }
            if (!string.IsNullOrEmpty(apiRequestParameters.ctin))
            {
                dic.Add("ctin", apiRequestParameters.ctin);
            }
            if (!string.IsNullOrEmpty(apiRequestParameters.from_time))
            {
                if (!DateTime.TryParseExact(apiRequestParameters.from_time, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                {
                    throw new Exception("Date Should be provided in dd-MM-yyyy format only");
                }
                dic.Add("action_required", apiRequestParameters.from_time);
            }
            return dic;
        }
        public async Task<GSTNResult<List<CDNURA>>> GetCDNURA(APIRequestParameters apiRequestParameters)
        {
            Dictionary<string, string> dic = this.prepareCDNURADictionary(apiRequestParameters);
            this.PrepareQueryString(dic);
            var info = await this.GetAsync<ResponseDataInfo>();
            var output = this.Decrypt<GSTR1Total>(info.Data);
            var model = this.BuildResult<List<CDNURA>>(info, output.cdnura);
            return model;

        }

        //API call  for getting details of e-commerce supply for a return period
        private Dictionary<string, string> prepareECOMDictionary(APIRequestParameters apiRequestParameters)
        {
            if (apiRequestParameters == null || string.IsNullOrEmpty(apiRequestParameters.gstin) || string.IsNullOrEmpty(apiRequestParameters.ret_period))
            {
                throw new Exception("gstin and ret_period is required");
            }
            var dic = new Dictionary<string, string>
            {
                { "gstin", apiRequestParameters.gstin },
                { "ret_period", apiRequestParameters.ret_period },
                { "action", "ECOM" }
            };
            if (!string.IsNullOrEmpty(apiRequestParameters.action_required))
            {
                dic.Add("action_required", apiRequestParameters.action_required);
            }
            if (!string.IsNullOrEmpty(apiRequestParameters.ctin))
            {
                dic.Add("ctin", apiRequestParameters.ctin);
            }
            if (!string.IsNullOrEmpty(apiRequestParameters.from_time))
            {
                if (!DateTime.TryParseExact(apiRequestParameters.from_time, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                {
                    throw new Exception("Date Should be provided in dd-MM-yyyy format only");
                }
                dic.Add("action_required", apiRequestParameters.from_time);
            }
            return dic;
        }
        public async Task<GSTNResult<List<EComOutward>>> GetECOM(APIRequestParameters apiRequestParameters)
        {
            Dictionary<string, string> dic = this.prepareECOMDictionary(apiRequestParameters);
            this.PrepareQueryString(dic);
            var info = await this.GetAsync<ResponseDataInfo>();
            var output = this.Decrypt<GSTR1Total>(info.Data);
            var model = this.BuildResult<List<EComOutward>>(info, output.ecom_invocies);
            return model;

        }

        //API call  for getting invoices related to supplies exported  for a return period.
        private Dictionary<string, string> prepareEXPDictionary(APIRequestParameters apiRequestParameters)
        {
            if (apiRequestParameters == null || string.IsNullOrEmpty(apiRequestParameters.gstin) || string.IsNullOrEmpty(apiRequestParameters.ret_period))
            {
                throw new Exception("gstin and ret_period is required");
            }
            var dic = new Dictionary<string, string>
            {
                { "gstin", apiRequestParameters.gstin },
                { "ret_period", apiRequestParameters.ret_period },
                { "action", "EXP" }
            };
            if (!string.IsNullOrEmpty(apiRequestParameters.action_required))
            {
                dic.Add("action_required", apiRequestParameters.action_required);
            }
            if (!string.IsNullOrEmpty(apiRequestParameters.ctin))
            {
                dic.Add("ctin", apiRequestParameters.ctin);
            }
            if (!string.IsNullOrEmpty(apiRequestParameters.from_time))
            {
                if (!DateTime.TryParseExact(apiRequestParameters.from_time, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                {
                    throw new Exception("Date Should be provided in dd-MM-yyyy format only");
                }
                dic.Add("action_required", apiRequestParameters.from_time);
            }
            return dic;
        }
        public async Task<GSTNResult<List<Exp>>> GetExp(APIRequestParameters apiRequestParameters)
        {
            Dictionary<string, string> dic = this.prepareEXPDictionary(apiRequestParameters);
            this.PrepareQueryString(dic);
            var info = await this.GetAsync<ResponseDataInfo>();
            var output = this.Decrypt<GSTR1Total>(info.Data);
            var model = this.BuildResult<List<Exp>>(info, output.exp);
            return model;

        }

        //API call  for getting amended invoices related to supplies exported  for a return period.
        private Dictionary<string, string> prepareEXPADictionary(APIRequestParameters apiRequestParameters)
        {
            if (apiRequestParameters == null || string.IsNullOrEmpty(apiRequestParameters.gstin) || string.IsNullOrEmpty(apiRequestParameters.ret_period))
            {
                throw new Exception("gstin and ret_period is required");
            }
            var dic = new Dictionary<string, string>
            {
                { "gstin", apiRequestParameters.gstin },
                { "ret_period", apiRequestParameters.ret_period },
                { "action", "EXPA" }
            };
            if (!string.IsNullOrEmpty(apiRequestParameters.action_required))
            {
                dic.Add("action_required", apiRequestParameters.action_required);
            }
            if (!string.IsNullOrEmpty(apiRequestParameters.ctin))
            {
                dic.Add("ctin", apiRequestParameters.ctin);
            }
            if (!string.IsNullOrEmpty(apiRequestParameters.from_time))
            {
                if (!DateTime.TryParseExact(apiRequestParameters.from_time, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                {
                    throw new Exception("Date Should be provided in dd-MM-yyyy format only");
                }
                dic.Add("action_required", apiRequestParameters.from_time);
            }
            return dic;
        }
        public async Task<GSTNResult<List<ExpA>>> GetExpA(APIRequestParameters apiRequestParameters)
        {
            Dictionary<string, string> dic = this.prepareEXPADictionary(apiRequestParameters);
            this.PrepareQueryString(dic);
            var info = await this.GetAsync<ResponseDataInfo>();
            var output = this.Decrypt<GSTR1Total>(info.Data);
            var model = this.BuildResult<List<ExpA>>(info, output.expa);
            return model;

        }

        //This API Is To Get the table wise summary Of GSTR1 data
        private Dictionary<string, string> prepareGSTR1SummaryDictionary(APIRequestParameters apiRequestParameters)
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
            if (!string.IsNullOrEmpty(apiRequestParameters.action_required))
            {
                dic.Add("action_required", apiRequestParameters.action_required);
            }
            if (!string.IsNullOrEmpty(apiRequestParameters.ctin))
            {
                dic.Add("ctin", apiRequestParameters.ctin);
            }
            if (!string.IsNullOrEmpty(apiRequestParameters.from_time))
            {
                if (!DateTime.TryParseExact(apiRequestParameters.from_time, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                {
                    throw new Exception("Date Should be provided in dd-MM-yyyy format only");
                }
                dic.Add("action_required", apiRequestParameters.from_time);
            }
            return dic;
        }
        public async Task<GSTNResult<SummaryOutward>> GetGSTR1Summary(APIRequestParameters apiRequestParameters)
        {
            Dictionary<string, string> dic = this.prepareEXPADictionary(apiRequestParameters);
            this.PrepareQueryString(dic);
            var info = await this.GetAsync<ResponseDataInfo>();
            var output = this.Decrypt<SummaryOutward>(info.Data);
            var model = this.BuildResult<SummaryOutward>(info, output);
            model.Data.sec_sum.RemoveAll(x => x.cpty_sum == null);
            return model;

        }

        //API call  NIL for getting  liabilities such as 'Nil Rated’, ‘Exempted’, and ‘Non GST’ supplies for a return period
        private Dictionary<string, string> prepareNILDictionary(APIRequestParameters apiRequestParameters)
        {
            if (apiRequestParameters == null || string.IsNullOrEmpty(apiRequestParameters.gstin) || string.IsNullOrEmpty(apiRequestParameters.ret_period))
            {
                throw new Exception("gstin and ret_period is required");
            }
            var dic = new Dictionary<string, string>
            {
                { "gstin", apiRequestParameters.gstin },
                { "ret_period", apiRequestParameters.ret_period },
                { "action", "NIL" }
            };
            if (!string.IsNullOrEmpty(apiRequestParameters.action_required))
            {
                dic.Add("action_required", apiRequestParameters.action_required);
            }
            if (!string.IsNullOrEmpty(apiRequestParameters.ctin))
            {
                dic.Add("ctin", apiRequestParameters.ctin);
            }
            if (!string.IsNullOrEmpty(apiRequestParameters.from_time))
            {
                if (!DateTime.TryParseExact(apiRequestParameters.from_time, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                {
                    throw new Exception("Date Should be provided in dd-MM-yyyy format only");
                }
                dic.Add("action_required", apiRequestParameters.from_time);
            }
            return dic;
        }
        public async Task<GSTNResult<NilRatedOutward>> GetNilRated(APIRequestParameters apiRequestParameters)
        {
            Dictionary<string, string> dic = this.prepareNILDictionary(apiRequestParameters);
            this.PrepareQueryString(dic);
            var info = await this.GetAsync<ResponseDataInfo>();
            var output = this.Decrypt<GSTR1Total>(info.Data);
            var model = this.BuildResult<NilRatedOutward>(info, output.nil);
            return model;

        }

        //API call  for getting tax paid details for a return period.
        public async Task<GSTNResult<List<TxpOutward>>> GetTXPD(string ret_prd)
        {
            this.PrepareQueryString(new Dictionary<string, string> {
                {
                    "gstin",
                    gstin
                },
                {
                    "action",
                    "TXP"
                },
                {
                    "ret_period",
                    ret_prd
                }
            });
            var info = await this.GetAsync<ResponseDataInfo>();
            var output = this.Decrypt<GSTR1Total>(info.Data);
            var model = this.BuildResult<List<TxpOutward>>(info, output.txpd);
            return model;

        }

       

        

    }
}
