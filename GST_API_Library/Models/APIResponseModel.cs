using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GST_API_Library.Models
{



    public class ReturnStatusInfo
    {
        public string form_typ { get; set; }
        public string status_cd { get; set; }
        public string action { get; set; }
        public error_report error_report { get; set; }
    }

    public class NewProceedToFile
    {
        public string reference_id { get; set; }
        public string isSync { get; set; }
    }
    public class HeaderData
    {

        public string clientid { get; set; }
        public string client_secret { get; set; }
        [DisplayName ("ip-usr")]
        public string ip_usr { get; set; }
        public string state_cd { get; set; }
        public string gstin { get; set; }
        public string ret_period { get; set; }
        public string txn { get; set; }
        public string username { get; set; }
        public string auth_token { get; set; }
        public string rtn_typ { get; set; }
        public string userrole { get; set; }
        public string api_version { get; set; }



    }


    public class error_report
    {
        public string error_cd { get; set; }
        public string error_msg { get; set; }
    }


    public class StatusInfo
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
    public class GenerateRequestInfo
    {
        //change by amit as per version 2.2
        public string gstin { get; set; }
        public string ret_period { get; set; }
        public string isnil { get; set; }

        public string action { get; set; }
        public string hdr { get; set; }
    }
    public class RequestPTF
    {
        //change by amit as per version 2.2
        

        public string action { get; set; }
        public string data { get; set; }
        public string hmac { get; set; }
        public string hdr { get; set; }
    }
    public class GenerateResponseInfo
    {
        public string status { get; set; }
        public string trans_id { get; set; }
    }
    public class FileInfo
    {
        public string status { get; set; }
        public string ack_num { get; set; }
    }

    public class ResponseDataInfo
    {
        public string data { get; set; }
        public string status_cd { get; set; }
        public string rek { get; set; }
        public string hmac { get; set; }
        public string ack_num { get; set; }
    }

    //Created By Himanshu
    public class ResponseDataInfoGSTR1
    {
        public string ack_num { get; set; }
    }

    public class UnsignedDataInfo
    {
        public string data { get; set; }
        public string hdr { get; set; }
        public string action { get; set; }
        public string hmac { get; set; }
    }
    public class SignedDataInfo
    {
        public string data { get; set; }
        public string action { get; set; }
        public string sign { get; set; }
        public string st { get; set; }
        public string sid { get; set; }
    }
    public class GSTNResult<T>
    {
        public int HttpStatusCode { get; set; }

        public T Data { get; set; }

    }
}
