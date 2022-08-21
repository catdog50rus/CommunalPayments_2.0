using CnD.CommunalPayments.Server.Dao.Base;
using CnD.CommunalPayments.Server.Dao.Entities.Models;
using CnD.CommunalPayments.Server.Dao.IMPL.SQL;
using Microsoft.Extensions.DependencyInjection;

namespace CnD.CommunalPayments.Server.Dao.Registrator;

public static class DiDaoRegistrator
{
    public static IServiceCollection AddDao(this IServiceCollection services) => services
        .AddScoped<IDao<InvoiceEntity>, InvoiceDao>()
        .AddScoped<IDao<InvoiceServicesEntity>, InvoiceServicesDao>()
        .AddScoped<IDao<OrderEntity>, OrderDao>()
        .AddScoped<IDao<PaymentEntity>, PaymentDao>()
        .AddScoped<IDao<PeriodEntity>, PeriodDao>()
        .AddScoped<IDao<ProviderEntity>, ProviderDao>()
        .AddScoped<IDao<ServiceEntity>, ServicesDao>()
        .AddScoped<IDao<ServiceCounterEntity>, ServiceCounterDao>()
        ;
}