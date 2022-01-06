namespace CnD.CommunalPayments.Server.Api.Definitions.Base;

public abstract class AppDefinitions : IAppDefinitions
{
    public void ConfigureApplication(IApplicationBuilder app, IWebHostEnvironment env) { }

    public void ConfigureServices(IServiceCollection services, IConfiguration configuration) { }
}