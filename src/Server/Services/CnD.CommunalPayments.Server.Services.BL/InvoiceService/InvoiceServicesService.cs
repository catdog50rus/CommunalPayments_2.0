using CnD.CommunalPayments.Server.DaoProviders.Base;
using CnD.CommunalPayments.Server.Domen.Models;
using CnD.CommunalPayments.Server.Services.BL.Base;
using CnD.CommunalPayments.Server.Services.BL.Interfaces;

namespace CnD.CommunalPayments.Server.Services.BL.InvoiceService;

public class InvoiceServicesService : BaseService<InvoiceServices>, IInvoiceServicesService
{
    public InvoiceServicesService(IBaseProviderService<InvoiceServices> daoProvider) : base(daoProvider)
    {
    }
}