using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GST_API_Library.Models.GSTR1DTO;

namespace GST_API_Library.Services
{
    public interface IGstr1Service
    {
        Task<(bool IsSuccess, string Message)> SaveGSTR1Async(Gstr1Dto gstr1SaveDto);
    }
}
