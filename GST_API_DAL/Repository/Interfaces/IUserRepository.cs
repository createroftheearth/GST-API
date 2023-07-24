using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GST_API_DAL.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> IsGSTINExists(string GSTIN);
        Task<bool> IsUsernameExists(string Username);
        Task<bool> IsGSTNUsernameExists(string GSTNUsername);
    }
}
