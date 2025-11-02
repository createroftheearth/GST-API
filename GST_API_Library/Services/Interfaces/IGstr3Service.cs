using GST_API_DAL.Models;
using GST_API_Library.Models;
using GST_API_Library.Models.GSTR1;
using GST_API_Library.Models.GSTR1DTO;
using GST_API_Library.Models.GSTR3B;
using GST_API_Library.Models.GSTR3DTO;

namespace GST_API_Library.Services.Interfaces
{
    public interface IGstr3Service
    {
        Task<(bool IsSucess, string Message, GetGSTR3BDetails data)> GetGstr3BDataByGSTIN(GSTR3BASPRequest request, string url);

        Task<(bool IsSuccess, string Message)> SaveGSTR3Async(Gstr3Dto gstr3SaveDto);
    }
}
