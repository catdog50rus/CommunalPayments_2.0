using CnD.CommunalPayments.Server.DaoProviders.Base;
using CnD.CommunalPayments.Server.Domen.Models;
using CnD.CommunalPayments.Server.Services.BL.Base;
using CnD.CommunalPayments.Server.Services.BL.Interfaces;

namespace CnD.CommunalPayments.Server.Services.BL.ServiceCounters;

public class ServiceCountersService : BaseService<ServiceCounter>, IServiceCountersService
{
    public ServiceCountersService(IBaseProviderService<ServiceCounter> daoProvider) : base(daoProvider)
    {
    }
}
