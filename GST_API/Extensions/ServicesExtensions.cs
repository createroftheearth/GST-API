using GST_API.Middlewares;
using GST_API_DAL.Repository.Implementations;
using GST_API_DAL.Repository.Interfaces;

namespace GST_API.Extensions
{
    public static class ServicesExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
        }

        public static void AddServices(this IServiceCollection services)
        {
        }
    }
}
