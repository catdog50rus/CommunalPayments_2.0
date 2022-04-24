namespace CnD.CommunalPayments.Server.Api.Definitions.Base;

public abstract class AppDefinitions : IAppDefinitions
{
    public virtual void ConfigureApplication(IApplicationBuilder app, IWebHostEnvironment env) { }

    public virtual void ConfigureServices(IServiceCollection services, IConfiguration configuration) { }
}