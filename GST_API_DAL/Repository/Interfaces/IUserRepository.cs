using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GST_API_DAL.Repository.Interfaces
{
    internal interface IUserRepository
    {
        Task<bool> IsGSTINExists(string GSTIN);
    }
}
