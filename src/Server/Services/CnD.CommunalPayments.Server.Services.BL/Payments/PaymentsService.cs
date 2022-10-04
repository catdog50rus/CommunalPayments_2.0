using CnD.CommunalPayments.Server.DaoProviders.Base;
using CnD.CommunalPayments.Server.Domen.Models;
using CnD.CommunalPayments.Server.Services.BL.Base;
using CnD.CommunalPayments.Server.Services.BL.Interfaces;

namespace CnD.CommunalPayments.Server.Services.BL.Payments;

public class PaymentsService : BaseService<Payment>, IPaymentsService
{
    public PaymentsService(IBaseProviderService<Payment> daoProvider) : base(daoProvider)
    {
    }
}