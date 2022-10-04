using AutoMapper;
using CnD.CommunalPayments.Server.Dao.Entities.Models;
using CnD.CommunalPayments.Server.Domen.Core.Helpers;
using CnD.CommunalPayments.Server.Domen.Models;
using CnD.CommunalPayments.Server.Domen.Models.BaseModels;

namespace CnD.CommunalPayments.Server.Infrastructure.Mapper.Profiles;

internal class ModelEntityProfile : Profile
{
    public ModelEntityProfile()
    {
        #region Invoice

        CreateMap<Invoice, InvoiceEntity>()
            .ForPath(x => x.PeriodId, o => o.MapFrom(i => i.Period.Id.Value))
            .ForPath(x => x.Period, o => o.Ignore())
            
            .ForPath(x => x.ProviderId, o => o.MapFrom(i => i.Provider.Id.Value))
            .ForPath(x => x.Provider, o => o.Ignore())

            .ForPath(x => x.Id, o => o.MapFrom(i => i.Id.Value))
            .ForPath(x => x.Sum, o => o.MapFrom(i => i.Sum.Value))

            .ForPath(x => x.UpdatedAt, o => o.Ignore())
            .ForPath(x => x.CreatedAt, o => o.Ignore())
            //.ForPath(x => x.CreatorName, o => o.Ignore())
            //.ForPath(x => x.UpdatorName, o => o.Ignore())
            ;


        CreateMap<InvoiceEntity, Invoice>()
            .ForPath(x => x.Provider, o => o.MapFrom(i => new Provider
            {
                Id = new ModelId(i.ProviderId),
                NameProvider = new ServiceName(i.Provider.NameProvider),
                WebSite = new WebSite(i.Provider.WebSite),
            }))

            .ForPath(x => x.Period, o => o.MapFrom(i => new Period
            {
                Id = new ModelId(i.PeriodId),
                Month = EnumHelper.GetValueFromDescr<MonthName>(i.Period.Month),
                Year = i.Period.Year,
            }))

            .ForPath(x => x.Id, o => o.MapFrom(i => new ModelId(i.Id)))
            .ForPath(x => x.Sum, o => o.MapFrom(i => new Sum(i.Sum)))


            ;

        #endregion

        #region Period

        CreateMap<Period, PeriodEntity>()
            .ForPath(x => x.Id, o => o.MapFrom(i => i.Id.Value))
            .ForPath(x => x.Month, o => o.MapFrom(i => i.Month.GetShortName()))
            .ForPath(x => x.Year, o => o.MapFrom(i => i.Year))

            .ForPath(x => x.UpdatedAt, o => o.Ignore())
            .ForPath(x => x.CreatedAt, o => o.Ignore())
            //.ForPath(x => x.CreatorName, o => o.Ignore())
            //.ForPath(x => x.UpdatorName, o => o.Ignore())
            ;

        CreateMap<PeriodEntity, Period>()
            .ForPath(x => x.Id, o => o.MapFrom(i => new ModelId(i.Id)))
            .ForPath(x => x.Month, o => o.MapFrom(i => EnumHelper.GetValueFromDescr<MonthName>(i.Month)))
            .ForPath(x => x.Year, o => o.MapFrom(i => i.Year))
            ;

        #endregion

        #region Provider

        CreateMap<Provider, ProviderEntity>()
            .ForPath(x => x.Id, o => o.MapFrom(i => i.Id.Value))
            .ForPath(x => x.NameProvider, o => o.MapFrom(i => i.NameProvider.GetValue()))
            .ForPath(x => x.WebSite, o => o.MapFrom(i => i.WebSite.GetValue()))

            .ForPath(x => x.UpdatedAt, o => o.Ignore())
            .ForPath(x => x.CreatedAt, o => o.Ignore())
            //.ForPath(x => x.CreatorName, o => o.Ignore())
            //.ForPath(x => x.UpdatorName, o => o.Ignore())
            ;

        CreateMap<ProviderEntity, Provider>()
            .ForPath(x => x.Id, o => o.MapFrom(i => new ModelId(i.Id)))
            .ForPath(x => x.NameProvider, o => o.MapFrom(i => new ServiceName(i.NameProvider)))
            .ForPath(x => x.WebSite, o => o.MapFrom(i => new WebSite(i.WebSite)))
            ;

        #endregion

        #region Orders

        CreateMap<Order, OrderEntity>()
            .ForPath(x => x.Id, o => o.MapFrom(i => i.Id.Value))

            .ForPath(x => x.UpdatedAt, o => o.Ignore())
            .ForPath(x => x.CreatedAt, o => o.Ignore())
            //.ForPath(x => x.CreatorName, o => o.Ignore())
            //.ForPath(x => x.UpdatorName, o => o.Ignore())
            ;

        CreateMap<OrderEntity, Order>()
            .ForPath(x => x.Id, o => o.MapFrom(i => new ModelId(i.Id)))
            ;

        #endregion

    }
}
