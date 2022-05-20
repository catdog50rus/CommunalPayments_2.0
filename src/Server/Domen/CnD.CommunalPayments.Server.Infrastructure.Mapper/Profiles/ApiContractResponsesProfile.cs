using AutoMapper;
using CnD.CommunalPayments.Contracts.Models.Invoices.Response;
using CnD.CommunalPayments.Server.Domen.Models;

namespace CnD.CommunalPayments.Server.Infrastructure.Mapper.Profiles;

internal class ApiContractResponsesProfile : Profile
{
    public ApiContractResponsesProfile()
    {
        #region Invoice

        CreateMap<Invoice, CreateInvoiceResponse>()
           .ForMember(dist => dist.ProviderId,
                      opt => opt.MapFrom(i => i.Provider.Id))
           .ForMember(dist => dist.PeriodId,
                      opt => opt.MapFrom(i => i.Period.IdKey))
           ;

        CreateMap<Invoice, UpdateInvoiceResponse>()
           .ForMember(dist => dist.ProviderId,
                      opt => opt.MapFrom(i => i.Provider.Id))
           .ForMember(dist => dist.PeriodId,
                      opt => opt.MapFrom(i => i.Period.IdKey))
           ;

        CreateMap<Invoice, InvoiceResponse>()
           .ForMember(dist => dist.ProviderId,
                      opt => opt.MapFrom(i => i.Provider.Id))
           .ForMember(dist => dist.PeriodId,
                      opt => opt.MapFrom(i => i.Period.IdKey))
           ;

        #endregion
    }
}
