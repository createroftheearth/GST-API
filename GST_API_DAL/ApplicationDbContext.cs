using GST_API_DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GST_API_DAL
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<Gstr1> Gstr1 { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            this.SeedRoles(builder);
        }

        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData
                (
                    new IdentityRole() { Name = "APIUser", ConcurrencyStamp = "1", NormalizedName = "APIUser" }
                );
            builder.Entity<IdentityRole>().HasData
                (
                    new IdentityRole() { Name = "PublicUser", ConcurrencyStamp = "1", NormalizedName = "PublicUser" }
                );
            builder.Entity<IdentityRole>().HasData
                (
                  new IdentityRole() { Name = "ASPUser", ConcurrencyStamp = "1", NormalizedName = "ASPUser" }
                );
        }
    }
}
