namespace GST_API.Services
{
    public class Constants
    {
        //public static string GSTR1_SAVE_URL = "/taxpayerapi/v2.1/returns/gstr1";
        public static string GSTR1_SAVE_URL = "/taxpayerapi/v4.0/returns/gstr1";
        public static string GSTR1_ReturnStatus_URL = "/taxpayerapi/v1.1/returns";
        public static string GSTR1_NewProceedToFile_URL = "/taxpayerapi/v1.1/returns/gstrptf";
        public static string GSTR1_V4_RETURN_URL = "/taxpayerapi/v4.0/returns/gstr1";
        public static string GSTR1_V3_RETURN_URL = "/taxpayerapi/v3.0/returns/gstr1";
        public static string GSTR2B_Get2BDetails_URL = "/taxpayerapi/v2.0/returns/gstr2b";
        public static string GSTR2B_GenOnDemand_URL = "/taxpayerapi/v4.0/returns/gstr2b";
        public static string GSTR3B_Get3B_URL = "/taxpayerapi/v6.0/returns/gstr3b";
        public static string CommomAPIDocDownload_URL = "/taxpayerapi/v1.1/document";

        public static string GSTR3B_RCM_URL = "/taxpayerapi/v6.0/returns/gstr3b";

        //Garima GSTR9
        public static string GSTR9_Get9_URL = "/taxpayerapi/v1.3/returns/gstr9";
        public static string GSTR9_GetDetails_URL = "/taxpayerapi/v2.0/returns/gstr9";
        public static string GSTR9A_URL = "/taxpayerapi/v1.1/returns/gstr9a";
        public static string GSTR9_SAVE_URL = "/taxpayerapi/v2.0/returns/gstr9";
        public static string GSTR9A_SAVE_URL = "/taxpayerapi/v1.1/returns/gstr9a";
        public static string GSTR9C_9Records_URL = "/taxpayerapi/v1.2/returns/gstr9c";
        public static string GSTR9C_GetSummary_URL = "/taxpayerapi/v2.0/returns/gstr9c";
        public static string GSTR9C_HashGenerate_URL = "/taxpayerapi/v2.0/returns/gstr9c";
        public static string GSTR9C_Save_URL = "/taxpayerapi/v2.0/returns/gstr9c";
        public static string GSTR9C_GenCerti_URL = "/taxpayerapi/v1.2/returns/gstr9c";

        //Garima Common API

        public static string CommomAPIDocStatus_URL = "/taxpayerapi/v1.1/document";
        public static string CommomAPISavePreference_URL = "/taxpayerapi/v1.0/returns";
        public static string CommomAPISignedPDF_URL = "/taxpayerapi/v0.1/gstr/signedpdf";
        public static string CommonAPISaveUserMaster_URL = "/taxpayerapi/v1.0/usermasters";
        public static string CommomAPIUploadDoc_URL = "/taxpayerapi/v1.1/document";
        public static string CommomAPINoti_URL = "/taxpayerapi/v1.0/ccapi";
        public static string CommoonAPIProceedToFile_URL = "/taxpayerapi/v1.1/returns/gstr";
        public static string CommoonAPIAddLtFeeBrk_URL = "/taxpayerapi/v1.1/returns";


        //Garima 19 March 2024

        public static string GSTR1_GetB2B_URL = "/taxpayerapi/v4.0/returns/gstr1";
        public static string GSTR1_ResetGSTR1_URL = "/taxpayerapi/v4.0/returns/gstr1";
        public static string GSTR1_Einvoice = "/taxpayerapi/v1.0/returns/einvoice";


        //Garima Public APIs 19 April 2024

        public static string Public_ViewTrack = "/commonapi/v1.0/returns";
        public static string Public_UPdatedGSTIN = "/commonapi/v1.0/tpaddtlstatus";
        public static string Public_UnregApplicants = "/commonapi/v1.0/unregistered-applicants";
        public static string Public_UnregApplicantsVali = "/commonapi/v1.0/unregistered-applicants-validation";

        //Garima GSTR1A

        public static string GSTR1A_URL = "/taxpayerapi/v1.0/returns/gstr1a";
        //public static string GSTR1A_Save_URL = "/taxpayerapi/v1.0/returns/gstr1a";
        //public static string GSTR1A_Reset_URL = "/taxpayerapi/v1.0/returns/gstr1a";
        //public static string GSTR1A_GetSmry_URL = "/taxpayerapi/v1.0/returns/gstr1a";


        //Garima GSTR-IMS

        public static string GSTRIMS_InvoiceCount_URL = "/taxpayerapi/v1.0/returns/ims";
        public static string GSTRIMS_Reset_URL = "/taxpayerapi/v1.0/returns/ims";

    }
}
