using CnD.CommunalPayments.Front.Configure.ServerOptions;

namespace CnD.CommunalPayments.Front.UI.BlazorUI.AppConfig;

public static class OptionsConfig
{
    public static IServiceCollection AddApplicationOptions(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<ServerOptions>(configuration.GetSection(ServerOptions.SectionName));

        return services;
    }
}
