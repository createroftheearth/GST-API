using GST_API_DAL.Models;
using GST_API_DAL.Repository.Interfaces;

namespace GST_API_DAL.Repository.Implementations
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> IsGSTINExists(string GSTIN)
        {
            return await this.AnyAsync(user => user.GSTNNo == GSTIN);
        }
    }
}
