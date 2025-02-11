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

        Task<List<Gstr1>> GetAllGstr1DataAsync();
    }
}
