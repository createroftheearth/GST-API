using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GST_API_DAL;
using GST_API_DAL.Models;
using GST_API_Library.Models.GSTR1DTO;
using Microsoft.EntityFrameworkCore;

namespace GST_API_Library.Services
{
    public interface IGstr1Service
    {
        Task<(bool IsSuccess, string Message)> SaveGSTR1Async(Gstr1Dto gstr1SaveDto);

        List<Gstr1> GetAllGstr1Data(int page, int pageSize, out int totalRecords);

        Task<(bool IsSucess, string Message)> SubmitGSTR1(int id, string url);
        Task<(bool IsSucess, string Message)> ProceedToFile(int id, string url);
    }
}
