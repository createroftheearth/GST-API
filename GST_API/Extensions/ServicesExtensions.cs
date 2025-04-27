using GST_API.Middlewares;
using GST_API.Services;
using GST_API_DAL.Repository.Implementations;
using GST_API_DAL.Repository.Interfaces;
using GST_API_Library.Services;
using GST_API_Library.Services.Implementation;
using GST_API_Library.Services.Interfaces;

namespace GST_API.Extensions
{
    public static class ServicesExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IGSTR1Repository, GSTR1Repository>();
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<TokenService,TokenService>();
            services.AddScoped<EncryptionUtils,EncryptionUtils>();
            services.AddScoped<EncryptDecryptService, EncryptDecryptService>();
            services.AddScoped<IGstr1Service, Gstr1Service>();
        }
    }
}
