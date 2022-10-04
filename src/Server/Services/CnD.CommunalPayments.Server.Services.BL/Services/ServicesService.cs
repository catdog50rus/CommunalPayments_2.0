using CnD.CommunalPayments.Server.DaoProviders.Base;
using CnD.CommunalPayments.Server.Domen.Models;
using CnD.CommunalPayments.Server.Services.BL.Base;
using CnD.CommunalPayments.Server.Services.BL.Interfaces;

namespace CnD.CommunalPayments.Server.Services.BL.Services;

public class ServicesService : BaseService<Service>, IServicesService
{
    public ServicesService(IBaseProviderService<Service> daoProvider) : base(daoProvider)
    {
    }
}