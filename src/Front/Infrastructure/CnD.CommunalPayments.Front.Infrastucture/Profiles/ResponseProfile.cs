using AutoMapper;
using CnD.CommunalPayments.Contracts.Models.Invoices.Response;
using CnD.CommunalPayments.Contracts.Models.Periods.Response;
using CnD.CommunalPayments.Contracts.Models.Providers.Response;
using CnD.CommunalPayments.Front.ViewModels;
using CnD.CommunalPayments.Front.ViewModels.Invoices;
using CnD.CommunalPayments.Front.ViewModels.Periods;
using CnD.CommunalPayments.Front.ViewModels.Providers;

namespace CnD.CommunalPayments.Front.Infrastucture.Profiles;

public class ResponseProfile : Profile
{
	public ResponseProfile()
	{
		CreateMap<InvoiceResponse, Invoice>()
            .ForMember(m => m.Id, o => o.MapFrom(x => new ModelId(x.Id)))
            .ForMember(m => m.PeriodId, o => o.MapFrom(x => new ModelId(x.PeriodId)))
            .ForMember(m => m.ProviderId, o => o.MapFrom(x => new ModelId(x.ProviderId)))
            ;

        CreateMap<CreateInvoiceResponse, Invoice>()
            .ForMember(m => m.Id, o => o.MapFrom(x => new ModelId(x.Id)))
            .ForMember(m => m.PeriodId, o => o.MapFrom(x => new ModelId(x.PeriodId)))
            .ForMember(m => m.ProviderId, o => o.MapFrom(x => new ModelId(x.ProviderId)))
            ;



        CreateMap<PeriodResponse, Period>()
			.ForMember(m => m.Id, o => o.MapFrom(x => new ModelId(x.Id)));

        CreateMap<ProviderResponse, Provider>()
            .ForMember(m => m.Id, o => o.MapFrom(x => new ModelId(x.Id)));
    }
}