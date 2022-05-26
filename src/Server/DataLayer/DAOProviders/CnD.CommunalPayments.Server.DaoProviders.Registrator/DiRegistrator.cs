using CnD.CommunalPayments.Server.DaoProviders.Base;
using CnD.CommunalPayments.Server.DaoProviders.IMPL;
using CnD.CommunalPayments.Server.Domen.Models;
using Microsoft.Extensions.DependencyInjection;

namespace CnD.CommunalPayments.Server.DaoProviders.Registrator
{
    public static class DiRegistrator
    {
        public static IServiceCollection AddDaoProviders(this IServiceCollection services) => services
            .AddScoped<IBaseProviderService<Invoice>, InvoiceDaoProvider>()
            .AddScoped<IBaseProviderService<InvoiceServices>, InvoiceServicesDaoProvider>()
            .AddScoped<IBaseProviderService<Order>, OrderDaoProvider>()
            .AddScoped<IBaseProviderService<Payment>, PaymentDaoProvider>()
            .AddScoped<IBaseProviderService<Period>, PeriodDaoProvider>()
            .AddScoped<IBaseProviderService<Provider>, ProviderDaoProvider>()
            .AddScoped<IBaseProviderService<Service>, ServiceDaoProvider>()
            .AddScoped<IBaseProviderService<ServiceCounter>, ServiceCounterDaoProvider>()
            ;
    }
}