using AutoMapper;
using CnD.CommunalPayments.Server.Infrastructure.Mapper.Profiles;
using Microsoft.Extensions.DependencyInjection;

namespace CnD.CommunalPayments.Server.Infrastructure.Mapper
{
    public static class DiRegistrator
    {
        public static void AddAutoMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ApiContractRequestsProfile());
                mc.AddProfile(new ApiContractResponsesProfile());
            });

            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}