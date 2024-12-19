using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GST_API_Library.Models
{
    public class ReturnStatusInfo : BaseErrorData
    {
        public string form_typ { get; set; }
        public string status_cd { get; set; }
        public string action { get; set; }
        public error_report error_report { get; set; }
    }

    public class NewProceedToFile : BaseErrorData
    {
        public string reference_id { get; set; }
        public string isSync { get; set; }
    }

    public class ProceedToFileGSTR1A : BaseErrorData
    {
        public string reference_id { get; set; }
    }

    public class ProceedToFile : BaseErrorData
    {
        public string reference_id { get; set; }
        public string isSync { get; set; }
    }

    public class HeaderData
    {

        public string clientid { get; set; }
        [JsonProperty (PropertyName = "ip-usr")]
        public string ip_usr { get; set; }
        [JsonProperty(PropertyName = "state-cd")]
        public string state_cd { get; set; }
        public string gstin { get; set; }
        public string ret_period { get; set; }
        public string txn { get; set; }
        public string username { get; set; }
        [JsonProperty(PropertyName = "auth-token")]
        public string auth_token { get; set; }
        public string rtn_typ { get; set; }
        public string userrole { get; set; }
        public string api_version { get; set; }
    }

    public class HeaderData1
    {

        public string clientid { get; set; }
        [JsonProperty(PropertyName = "ip-usr")]
        public string ip_usr { get; set; }
        [JsonProperty(PropertyName = "state-cd")]
        public string state_cd { get; set; }
        public string gstin { get; set; }
        public string ret_period { get; set; }
        public string txn { get; set; }
        public string username { get; set; }
        [JsonProperty(PropertyName = "auth-token")]
        public string auth_token { get; set; }
        public string rtn_typ { get; set; }
        public string userrole { get; set; }
        public string api_version { get; set; }
        public string form_typ { get; set; }


    }


    public class error_report
    {
        public string error_cd { get; set; }
        public string error_msg { get; set; }
    }


    public class StatusInfo : BaseErrorData
    {
        public string status_cd { get; set; }
        public string errorCd { get; set; }
        public string error_msg { get; set; }
        public string error_report { get; set; }
    }
    public class SaveInfo
    {
        public string trans_id { get; set; }
        public string reference_id { get; set; }
    }
    public class GenerateRequestInfo : BaseErrorData
    {
        //change by amit as per version 2.2
        public string gstin { get; set; }
        public string ret_period { get; set; }
        public string isnil { get; set; }
    }

    public class GenerateRequestInfo1
    {
        public string gstin { get; set; }
        public string ret_period { get; set; }
    }
    public class RequestPTF : BaseErrorData
    {
        //change by amit as per version 2.2
        

        public string action { get; set; }
        public string data { get; set; }
        public string hmac { get; set; }
        public string hdr { get; set; }
    }
    public class GenerateResponseInfo : BaseErrorData
    {
        public string status { get; set; }
        public string trans_id { get; set; }
    }
    public class FileInfo : BaseErrorData
    {
        public string status { get; set; }
        public string ack_num { get; set; }
    }

    public class ResponseDataInfo :BaseErrorData
    {
        public string data { get; set; }
        public string status_cd { get; set; }
        public string rek { get; set; }
        public string hmac { get; set; }
        public string ack_num { get; set; }
    }

    public class BaseErrorData
    {
        public ErrorData? error { get; set; }
    }

    public class ErrorData
    {
        public string message { get; set; }
        public string error_cd { get; set; }
    }

    //Created By Himanshu
    public class ResponseDataInfoGSTR1
    {
        public string ack_num { get; set; }
    }

    public class UnsignedDataInfo
    {
        public string data { get; set; }
        public HeaderData hdr { get; set; }
        public string action { get; set; }
        public string hmac { get; set; }
    }

    public class UnsignedDataInfo2
    {
        public string data { get; set; }
        public HeaderData1 hdr { get; set; }
        public string action { get; set; }
        public string hmac { get; set; }
    }

    public class UnsignedDataInfo1
    {
        public string data { get; set; }
        //public HeaderData hdr { get; set; }
        //public string action { get; set; }

    }
    public class SignedDataInfo
    {
        public string action { get; set; }
        public string data { get; set; }
        public string sign { get; set; }
        public string st { get; set; }
        public string sid { get; set; }
        //public HeaderData hdr { get; set; }
        //public string hmac { get; set; }
    }
    public class GSTNResult<T>: BaseErrorData
    {
        public int HttpStatusCode { get; set; }

        public T Data { get; set; }

    }

    public class GSTNResult1<T>
    {
        public T Data { get; set; }

    }

    //Garima
    public class GSTR9CHashGenerate
    {
        public string hash { get; set; }
    }

    //Garima Common API
    public class SavePreference : BaseErrorData
    {
        public string status_cd { get; set; }
    }

    public class UploadDocumentResp
    {
        public string doc_id { get; set; }
    }
    public class UploadDocumentResponse
    {
        public string doc_id { get; set; }
    }

    public class SavePreferenceResponse
    {
        public string status_cd { get; set; }
    }

    public class CreateNotificationResponse
    {
        public string notify_id { get; set; }
    }

    public class DeleteNotiByIDsResponse
    {
        public string status_cd { get; set; }
    }

    public class Gen2BonDemandResp
    {
        public string reference_id { get; set; }

    }

    public class GSTRIMS_Reset_Response
    {
        public string reference_id { get; set; }
    }
}
