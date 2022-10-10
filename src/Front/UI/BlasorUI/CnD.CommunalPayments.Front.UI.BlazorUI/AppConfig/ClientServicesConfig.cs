using CnD.CommunalPayments.Front.ApiClient;

namespace CnD.CommunalPayments.Front.UI.BlazorUI.AppConfig;

public static class ClientServicesConfig
{
    public static IServiceCollection AddClientServices(this IServiceCollection services)
    {
        services.AddTransient<IInvoiceClientService, InvoiceClientService>();
        services.AddTransient<IPeriodClientService, PeriodClientService>();
        services.AddTransient<IProviderClientService, ProviderClientService>();

        return services;
    }
}
