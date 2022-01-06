namespace CnD.CommunalPayments.Server.Api.Definitions.Base;

internal interface IAppDefinitions
{
    void ConfigureServices(IServiceCollection services, IConfiguration configuration);

    void ConfigureApplication(IApplicationBuilder app, IWebHostEnvironment env);
}

