using AutoMapper;
using CnD.CommunalPayments.Contracts.Models.Invoices.Request;
using CnD.CommunalPayments.Contracts.Models.Periods.Request;
using CnD.CommunalPayments.Contracts.Models.Providers.Request;
using CnD.CommunalPayments.Server.Domen.Core.Helpers;
using CnD.CommunalPayments.Server.Domen.Models;
using CnD.CommunalPayments.Server.Domen.Models.BaseModels;

namespace CnD.CommunalPayments.Server.Infrastructure.Mapper.Profiles;

internal class ApiContractRequestsProfile : Profile
{
    public ApiContractRequestsProfile()
    {
        #region Invoice

        CreateMap<CreateInvoiceRequest, Invoice>()
            .ForPath(x => x.Provider, o => o.MapFrom(i => new Provider { Id = new ModelId(i.ProviderId) }))

            .ForPath(x => x.Period, o => o.MapFrom(i => new Period { Id = new ModelId(i.PeriodId) }))

            .ForPath(x => x.Id, o => o.Ignore())
            ;

        CreateMap<UpdateInvoiceRequest, Invoice>()
            .ForPath(x => x.Provider, o => o.MapFrom(i => new Provider { Id = new ModelId(i.ProviderId) }))

            .ForPath(x => x.Period, o => o.MapFrom(i => new Period { Id = new ModelId(i.PeriodId) }))
            ;

        #endregion

        #region Period

        CreateMap<CreatePeriodRequest, Period>()
            .ForMember(x => x.Month, o => o.MapFrom(x => EnumHelper.GetValueFromDescr<MonthName>(x.Month)))
            .ForPath(x => x.Id, o => o.Ignore())
            ;

        CreateMap<UpdatePeriodRequest, Period>()
            .ForMember(x => x.Month, o => o.MapFrom(x => EnumHelper.GetValueFromDescr<MonthName>(x.Month)));

        #endregion

        #region Providers

        CreateMap<CreateProviderRequest, Provider>()
            .ForMember(x => x.NameProvider, o => o.MapFrom(x => new ServiceName(x.NameProvider)))
            .ForMember(x => x.WebSite, o => o.MapFrom(x => new WebSite(x.WebSite)))
            .ForPath(x => x.Id, o => o.Ignore())
            ;

        CreateMap<UpdateProviderRequest, Provider>()
            .ForMember(x => x.Id, o => o.MapFrom(x => new ModelId(x.Id)))
            .ForMember(x => x.NameProvider, o => o.MapFrom(x => new ServiceName(x.NameProvider)))
            .ForMember(x => x.WebSite, o => o.MapFrom(x => new WebSite(x.WebSite)))
            ;

        #endregion
    }

}