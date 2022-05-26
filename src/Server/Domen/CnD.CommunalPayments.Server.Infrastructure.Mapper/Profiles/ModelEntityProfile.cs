using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CnD.CommunalPayments.Contracts.Models.Invoices.Request;
using CnD.CommunalPayments.Contracts.Models.Periods.Request;
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
            .ForPath(x => x.Period.Id, o => o.MapFrom(i => i.Period.Id))
            .ForPath(x => x.Period.Month, o => o.MapFrom(i => i.Period.Month))
            .ForPath(x => x.Period.Year, o => o.MapFrom(i => i.Period.Year))

            .ForPath(x => x.ProviderId, o => o.MapFrom(i => i.Provider.Id))
            .ForPath(x => x.Provider.Id, o => o.MapFrom(i => i.Provider.Id))
            .ForPath(x => x.Provider.NameProvider, o => o.MapFrom(i => i.Provider.NameProvider))
            .ForPath(x => x.Provider.WebSite, o => o.MapFrom(i => i.Provider.WebSite))
            ;


        CreateMap<InvoiceEntity, Invoice>()
            .ForPath(x => x.Provider.Id, o => o.MapFrom(i => i.ProviderId))
            .ForPath(x => x.Provider.NameProvider, o => o.MapFrom(i => i.Provider.NameProvider))
            .ForPath(x => x.Provider.WebSite, o => o.MapFrom(i => i.Provider.WebSite))

            .ForPath(x => x.Period.Id, o => o.MapFrom(i => i.PeriodId))
            .ForPath(x => x.Period.Month, o => o.MapFrom(i => i.Period.Month))
            .ForPath(x => x.Period.Year, o => o.MapFrom(i => i.Period.Year))
            ;

        #endregion
    }
}
