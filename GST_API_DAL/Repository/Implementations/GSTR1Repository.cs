
using GST_API_DAL.Models;
using GST_API_DAL.Repository.Interfaces;
using Microsoft.AspNetCore.Http;

namespace GST_API_DAL.Repository.Implementations
{
    public class GSTR1Repository : BaseRepository<Gstr1>, IGSTR1Repository
    {
        private readonly ApplicationDbContext _context;
        public GSTR1Repository(ApplicationDbContext context, IHttpContextAccessor accessor) : base(context, accessor)
        {
            _context = context;
        }
    }
}
