using AutoMapper;
using CnD.CommunalPayments.Contracts.Models.Invoices.Request;
using CnD.CommunalPayments.Server.Domen.Models;

namespace CnD.CommunalPayments.Server.Infrastructure.Mapper.Profiles;

internal class ApiContractRequestsProfile : Profile
{
    public ApiContractRequestsProfile()
    {
        #region Invoice

        CreateMap<CreateInvoiceRequest, Invoice>()
            .ForPath(x => x.Provider.Id, o => o.MapFrom(i => i.ProviderId))
            .ForPath(x => x.Period.IdKey, o => o.MapFrom(i => i.PeriodId));

        CreateMap<UpdateInvoiceRequest, Invoice>()
            .ForPath(x => x.Provider.Id, o => o.MapFrom(i => i.ProviderId))
            .ForPath(x => x.Period.IdKey, o => o.MapFrom(i => i.PeriodId));

        #endregion
    }
}
