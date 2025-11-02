
using GST_API_DAL.Models;
using GST_API_DAL.Repository.Interfaces;
using Microsoft.AspNetCore.Http;

namespace GST_API_DAL.Repository.Implementations
{
    public class GSTR3Repository : BaseRepository<Gstr3>, IGSTR3Repository
    {
        private readonly ApplicationDbContext _context;
        public GSTR3Repository(ApplicationDbContext context, IHttpContextAccessor accessor) : base(context, accessor)
        {
            _context = context;
        }
    }
}
