using CnD.CommunalPayments.Server.Dao.Registrator;
using CnD.CommunalPayments.Server.DaoProviders.Registrator;
using CnD.CommunalPayments.Server.Infrastructure.Mapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CnD.CommunalPayments.Server.Infrastructure.DIContainer;

public static class Registrator
{
    public static IServiceCollection AddDiContainer(this IServiceCollection services)
    {
        services.AddAutoMapper();
        services.AddDaoProviders();
        services.AddDao();

        return services;
    }
}
