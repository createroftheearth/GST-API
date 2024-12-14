using AutoMapper;
using GST_API_DAL.Models;

namespace GST_API
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RegistrationModel, User>();
            CreateMap<User, RegistrationModel>();
            CreateMap<PublicRegistrationModel, User>();
            CreateMap<User, PublicRegistrationModel>();
        }
    }
}
