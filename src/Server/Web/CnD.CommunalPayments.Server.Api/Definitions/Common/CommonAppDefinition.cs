using CnD.CommunalPayments.Server.Api.Definitions.Base;
using CnD.CommunalPayments.Server.DaoProviders.Registrator;
using CnD.CommunalPayments.Server.Infrastructure.Mapper;

namespace CnD.CommunalPayments.Server.Api.Definitions.Common;

/// <summary>
/// AspNetCore common configuration
/// </summary>
public class CommonAppDefinition : AppDefinitions
{
    /// <summary>
    /// Configure application for current microservice
    /// </summary>
    /// <param name="app"></param>
    /// <param name="env"></param>
    public override void ConfigureApplication(IApplicationBuilder app, IWebHostEnvironment env)
        => app.UseHttpsRedirection();

    /// <summary>
    /// Configure services for current microservice
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddLocalization();
        services.AddHttpContextAccessor();
        services.AddResponseCaching();
        services.AddMemoryCache();
        services.AddAutoMapper();
        services.AddDaoProviders();
    }
}