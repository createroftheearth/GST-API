﻿using GST_API_DAL.Models;
using GST_API_DAL.Repository.Interfaces;
using Microsoft.AspNetCore.Http;

namespace GST_API_DAL.Repository.Implementations
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context,IHttpContextAccessor accessor) : base(context,accessor)
        {
            _context = context;
        }

        public async Task<bool> IsGSTINExists(string GSTIN)
        {
            return await this.AnyAsync(user => user.GSTNNo == GSTIN);
        }
        
        public async Task<bool> IsUsernameExists(string Username)
        {
            return await this.AnyAsync(user => user.UserName == Username);
        }
        
        public async Task<bool> IsGSTNUsernameExists(string GSTNUsername)
        {
            return await this.AnyAsync(user => user.Email == GSTNUsername);
        }
    }
}
