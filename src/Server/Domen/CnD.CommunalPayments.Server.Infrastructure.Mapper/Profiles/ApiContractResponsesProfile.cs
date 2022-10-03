using AutoMapper;
using CnD.CommunalPayments.Contracts.Models.Invoices.Response;
using CnD.CommunalPayments.Contracts.Models.Periods.Response;
using CnD.CommunalPayments.Contracts.Models.Providers.Response;
using CnD.CommunalPayments.Server.Domen.Core.Helpers;
using CnD.CommunalPayments.Server.Domen.Models;

namespace CnD.CommunalPayments.Server.Infrastructure.Mapper.Profiles;

internal class ApiContractResponsesProfile : Profile
{
    public ApiContractResponsesProfile()
    {
        #region Invoice

        CreateMap<Invoice, CreateInvoiceResponse>()
           .ForMember(dist => dist.ProviderId,
                      opt => opt.MapFrom(i => i.Provider.Id.Value))
           .ForMember(dist => dist.PeriodId,
                      opt => opt.MapFrom(i => i.Period.Id.Value))
           .ForMember(dist => dist.Sum,
                      opt => opt.MapFrom(i => i.Sum.Value))
           .ForMember(dist => dist.Id,
                      opt => opt.MapFrom(i => i.Id.Value))
           ;

        CreateMap<Invoice, UpdateInvoiceResponse>()
           .ForMember(dist => dist.ProviderId,
                      opt => opt.MapFrom(i => i.Provider.Id.Value))
           .ForMember(dist => dist.PeriodId,
                      opt => opt.MapFrom(i => i.Period.Id.Value))
           .ForMember(dist => dist.Sum,
                      opt => opt.MapFrom(i => i.Sum.Value))
           .ForMember(dist => dist.Id,
                      opt => opt.MapFrom(i => i.Id.Value))
           ;

        CreateMap<Invoice, InvoiceResponse>()
           .ForMember(dist => dist.ProviderId,
                      opt => opt.MapFrom(i => i.Provider.Id.Value))
           .ForMember(dist => dist.PeriodId,
                      opt => opt.MapFrom(i => i.Period.Id.Value))
           .ForMember(dist => dist.Sum,
                      opt => opt.MapFrom(i => i.Sum.Value))
           .ForMember(dist => dist.Id,
                      opt => opt.MapFrom(i => i.Id.Value))
           ;

        #endregion

        #region Period

        CreateMap<Period, CreatePeriodResponse>()
           .ForMember(dist => dist.Month,
                      opt => opt.MapFrom(i => i.Month.GetShortName()))
           .ForMember(dist => dist.Id,
                      opt => opt.MapFrom(i => i.Id.Value))
           ;

        CreateMap<Period, UpdatePeriodResponse>()
           .ForMember(dist => dist.Month,
                      opt => opt.MapFrom(i => i.Month.GetShortName()))
           .ForMember(dist => dist.Id,
                      opt => opt.MapFrom(i => i.Id.Value))
           ;

        CreateMap<Period, PeriodResponse>()
           .ForMember(dist => dist.Month,
                      opt => opt.MapFrom(i => i.Month.GetShortName()))
           .ForMember(dist => dist.Id,
                      opt => opt.MapFrom(i => i.Id.Value))
           ;

        #endregion

        #region Provider

        CreateMap<Provider, ProviderResponse>()
            .ForMember(dist => dist.Id,
                       opt => opt.MapFrom(i => i.Id.GetValue()))
            .ForMember(dist => dist.NameProvider,
                       opt => opt.MapFrom(i => i.NameProvider.GetValue()))
            .ForMember(dist => dist.WebSite,
                       opt => opt.MapFrom(i => i.WebSite.GetValue()))
            ;

        CreateMap<Provider, UpdateProviderResponse>()
            .ForMember(dist => dist.Id,
                       opt => opt.MapFrom(i => i.Id.GetValue()))
            .ForMember(dist => dist.NameProvider,
                       opt => opt.MapFrom(i => i.NameProvider.GetValue()))
            .ForMember(dist => dist.WebSite,
                       opt => opt.MapFrom(i => i.WebSite.GetValue()))
            ;

        CreateMap<Provider, CreateProviderResponse>()
            .ForMember(dist => dist.Id,
                       opt => opt.MapFrom(i => i.Id.GetValue()))
            .ForMember(dist => dist.NameProvider,
                       opt => opt.MapFrom(i => i.NameProvider.GetValue()))
            .ForMember(dist => dist.WebSite,
                       opt => opt.MapFrom(i => i.WebSite.GetValue()))
            ;

        #endregion
    }
}
