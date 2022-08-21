using AutoMapper;
using CnD.CommunalPayments.Contracts.Models.Invoices.Request;
using CnD.CommunalPayments.Contracts.Models.Periods.Request;
using CnD.CommunalPayments.Server.Domen.Core.Helpers;
using CnD.CommunalPayments.Server.Domen.Models;

namespace CnD.CommunalPayments.Server.Infrastructure.Mapper.Profiles;

internal class ApiContractRequestsProfile : Profile
{
    public ApiContractRequestsProfile()
    {
        #region Invoice

        CreateMap<CreateInvoiceRequest, Invoice>()
            .ForPath(x => x.Provider, o => o.MapFrom(i => new Provider { Id = i.ProviderId }))

            .ForPath(x => x.Period, o => o.MapFrom(i => new Period { Id = i.PeriodId }))

            .ForPath(x => x.Id, o => o.Ignore())
            ;

        CreateMap<UpdateInvoiceRequest, Invoice>()
             .ForPath(x => x.Provider, o => o.MapFrom(i => new Provider { Id = i.ProviderId }))

            .ForPath(x => x.Period, o => o.MapFrom(i => new Period { Id = i.PeriodId }))
            ;

        #endregion

        #region Period

        CreateMap<CreatePeriodRequest, Period>()
            .ForMember(x => x.Month, o => o.MapFrom(x => EnumHelper.GetValueFromDescr<PeriodsName>(x.Month)))
            .ForPath(x => x.Id, o => o.Ignore())
            ;

        CreateMap<UpdatePeriodRequest, Period>()
            .ForMember(x => x.Month, o => o.MapFrom(x => EnumHelper.GetValueFromDescr<PeriodsName>(x.Month)));

        #endregion
    }

}