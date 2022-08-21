using AutoMapper;
using CnD.CommunalPayments.Server.Dao.Entities.Models;
using CnD.CommunalPayments.Server.Domen.Core.Helpers;
using CnD.CommunalPayments.Server.Domen.Models;

namespace CnD.CommunalPayments.Server.Infrastructure.Mapper.Profiles;

internal class ModelEntityProfile : Profile
{
    public ModelEntityProfile()
    {
        #region Invoice

        CreateMap<Invoice, InvoiceEntity>()
            .ForPath(x => x.PeriodId, o => o.MapFrom(i => i.Period.Id))
            .ForPath(x => x.Period, o => o.MapFrom(i => new PeriodEntity
            {
                Id = i.Period.Id,
                Month = i.Period.Month.GetShortName(),
                Year = i.Period.Year,
            }))
 
            .ForPath(x => x.ProviderId, o => o.MapFrom(i => i.Provider.Id))
            .ForPath(x => x.Provider, o => o.MapFrom(i => new ProviderEntity 
            {
                Id = i.Provider.Id,
                NameProvider = i.Provider.NameProvider,
                WebSite = i.Provider.WebSite,
            }))

            .ForPath(x=>x.UpdatedAt, o=>o.Ignore())
            .ForPath(x => x.CreatedAt, o => o.Ignore())
            .ForPath(x => x.CreatorName, o => o.Ignore())
            .ForPath(x => x.UpdatorName, o => o.Ignore())
            ;


        CreateMap<InvoiceEntity, Invoice>()
            .ForPath(x => x.Provider, o => o.MapFrom(i => new Provider
            {
                Id = i.Provider.Id,
                NameProvider = i.Provider.NameProvider,
                WebSite = i.Provider.WebSite,
            }))
 
            .ForPath(x => x.Period, o => o.MapFrom(i => new Period
            {
                Id = i.Period.Id,
                Month = EnumHelper.GetValueFromDescr<PeriodsName>(i.Period.Month),
                Year = i.Period.Year,
            }))

            ;

        #endregion
    }
}
