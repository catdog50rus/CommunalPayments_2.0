using AutoMapper;
using CnD.CommunalPayments.Front.Infrastucture.Profiles;
using Microsoft.Extensions.DependencyInjection;

namespace CnD.CommunalPayments.Front.Infrastucture;

public static class DiRegistrator
{
    public static void AddAutoMapper(this IServiceCollection services)
    {
        var mappingConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new ResponseProfile());
        });

        mappingConfig.AssertConfigurationIsValid();

        var mapper = mappingConfig.CreateMapper();
        services.AddSingleton(mapper);
    }
}