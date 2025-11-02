using GST_API_DAL.Models;
using GST_API_Library.Models;
using GST_API_Library.Models.GSTR1;
using GST_API_Library.Models.GSTR1DTO;

namespace GST_API_Library.Services.Interfaces
{
    public interface IGstr1Service
    {
        Task<(bool IsSuccess, string Message)> SaveGSTR1Async(Gstr1Dto gstr1SaveDto);

        List<Gstr1> GetAllGstr1Data(int page, int pageSize, out int totalRecords);

        Task<(bool IsSucess, string Message)> SubmitGSTR1(int? id, string url);
        Task<(bool IsSucess, string Message)> ProceedToFile(Request request, string url);
        Task<(bool IsSucess, string Message, GetGSTR1SummaryRes? data)> GenerateEVCOTP(PanRequest request, string getSumURL);
        Task<(bool IsSucess, string Message)> GSTR1File(Gstr1Request request, string getFileURL);
        Task<(bool IsSucess, string Message)> GSTR1NilFile(Gstr1NilRequest request, string getFileURL);
    }  
}
