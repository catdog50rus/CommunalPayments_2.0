using AutoMapper;
using CnD.CommunalPayments.Contracts.Models.Invoices.Response;
using CnD.CommunalPayments.Contracts.Models.Periods.Response;
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
                      opt => opt.MapFrom(i => i.Provider.Id))
           .ForMember(dist => dist.PeriodId,
                      opt => opt.MapFrom(i => i.Period.Id))
           ;

        CreateMap<Invoice, UpdateInvoiceResponse>()
           .ForMember(dist => dist.ProviderId,
                      opt => opt.MapFrom(i => i.Provider.Id))
           .ForMember(dist => dist.PeriodId,
                      opt => opt.MapFrom(i => i.Period.Id))
           ;

        CreateMap<Invoice, InvoiceResponse>()
           .ForMember(dist => dist.ProviderId,
                      opt => opt.MapFrom(i => i.Provider.Id))
           .ForMember(dist => dist.PeriodId,
                      opt => opt.MapFrom(i => i.Period.Id))
           ;

        #endregion

        #region Period

        CreateMap<Period, CreatePeriodResponse>()
           .ForMember(dist => dist.Month,
                      opt => opt.MapFrom(i => i.Month.GetShortName()))
           ;

        CreateMap<Period, UpdatePeriodResponse>()
           .ForMember(dist => dist.Month,
                      opt => opt.MapFrom(i => i.Month.GetShortName()))
           ;

        CreateMap<Period, PeriodResponse>()
           .ForMember(dist => dist.Month,
                      opt => opt.MapFrom(i => i.Month.GetShortName()))
           ;

        #endregion
    }
}
