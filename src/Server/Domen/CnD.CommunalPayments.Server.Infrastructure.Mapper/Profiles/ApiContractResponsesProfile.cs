using AutoMapper;
using CnD.CommunalPayments.Contracts.Models.Invoices.Response;
using CnD.CommunalPayments.Contracts.Models.InvoiceServices.Response;
using CnD.CommunalPayments.Contracts.Models.Orders.Response;
using CnD.CommunalPayments.Contracts.Models.Payments.Response;
using CnD.CommunalPayments.Contracts.Models.Periods.Response;
using CnD.CommunalPayments.Contracts.Models.Providers.Response;
using CnD.CommunalPayments.Contracts.Models.ServiceCounters.Response;
using CnD.CommunalPayments.Contracts.Models.Services.Response;
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

        #region Orders

        CreateMap<Order, OrderResponse>()
            .ForMember(dist => dist.Id,
                       opt => opt.MapFrom(i => i.Id.GetValue()))
            ;

        CreateMap<Order, UpdateOrderResponse>()
            .ForMember(dist => dist.Id,
                       opt => opt.MapFrom(i => i.Id.GetValue()))
            ;

        CreateMap<Order, CreateOrderResponse>()
            .ForMember(dist => dist.Id,
                       opt => opt.MapFrom(i => i.Id.GetValue()))
            ;

        #endregion

        #region Services

        CreateMap<Service, ServiceResponse>()
            .ForMember(dist => dist.Id,
                       opt => opt.MapFrom(i => i.Id.GetValue()))
            .ForMember(dist => dist.Name,
                       opt => opt.MapFrom(i => i.Name.GetValue()))
            ;

        CreateMap<Service, UpdateServiceResponse>()
            .ForMember(dist => dist.Id,
                       opt => opt.MapFrom(i => i.Id.GetValue()))
            .ForMember(dist => dist.Name,
                       opt => opt.MapFrom(i => i.Name.GetValue()))
            ;

        CreateMap<Service, CreateServiceResponse>()
            .ForMember(dist => dist.Id,
                       opt => opt.MapFrom(i => i.Id.GetValue()))
            .ForMember(dist => dist.Name,
                       opt => opt.MapFrom(i => i.Name.GetValue()))
            ;

        #endregion

        #region InvoiceServices

        CreateMap<InvoiceServices, CreateInvoiceServicesResponse>()
           .ForMember(dist => dist.ServiceId,
                      opt => opt.MapFrom(i => i.Service.Id.Value))
           .ForMember(dist => dist.InvoiceId,
                      opt => opt.MapFrom(i => i.Invoice.Id.Value))
           .ForMember(dist => dist.Amount,
                      opt => opt.MapFrom(i => i.Amount.Value))
           .ForMember(dist => dist.Id,
                      opt => opt.MapFrom(i => i.Id.Value))
           ;

        CreateMap<InvoiceServices, UpdateInvoiceServicesResponse>()
           .ForMember(dist => dist.ServiceId,
                      opt => opt.MapFrom(i => i.Service.Id.Value))
           .ForMember(dist => dist.InvoiceId,
                      opt => opt.MapFrom(i => i.Invoice.Id.Value))
           .ForMember(dist => dist.Amount,
                      opt => opt.MapFrom(i => i.Amount.Value))
           .ForMember(dist => dist.Id,
                      opt => opt.MapFrom(i => i.Id.Value))
           ;

        CreateMap<InvoiceServices, InvoiceServicesResponse>()
           .ForMember(dist => dist.ServiceId,
                      opt => opt.MapFrom(i => i.Service.Id.Value))
           .ForMember(dist => dist.InvoiceId,
                      opt => opt.MapFrom(i => i.Invoice.Id.Value))
           .ForMember(dist => dist.Amount,
                      opt => opt.MapFrom(i => i.Amount.Value))
           .ForMember(dist => dist.Id,
                      opt => opt.MapFrom(i => i.Id.Value))
           ;

        #endregion

        #region Payments

        CreateMap<Payment, CreatePaymentResponse>()
           .ForMember(dist => dist.InvoiceId,
                      opt => opt.MapFrom(i => i.Invoice.Id.Value))
           .ForMember(dist => dist.OrderId,
                      opt => opt.MapFrom(i => i.Order.Id.Value))
           .ForMember(dist => dist.PaymentSum,
                      opt => opt.MapFrom(i => i.PaymentSum.Value))
           .ForMember(dist => dist.Id,
                      opt => opt.MapFrom(i => i.Id.Value))
           .ForMember(dist => dist.DatePayment,
                      opt => opt.MapFrom(i => i.DatePayment.GetValue().ToShortDateString()))
           ;

        CreateMap<Payment, UpdatePaymentResponse>()
           .ForMember(dist => dist.InvoiceId,
                      opt => opt.MapFrom(i => i.Invoice.Id.Value))
           .ForMember(dist => dist.OrderId,
                      opt => opt.MapFrom(i => i.Order.Id.Value))
           .ForMember(dist => dist.PaymentSum,
                      opt => opt.MapFrom(i => i.PaymentSum.Value))
           .ForMember(dist => dist.Id,
                      opt => opt.MapFrom(i => i.Id.Value))
           .ForMember(dist => dist.DatePayment,
                      opt => opt.MapFrom(i => i.DatePayment.GetValue().ToShortDateString()))
           ;

        CreateMap<Payment, PaymentResponse>()
           .ForMember(dist => dist.InvoiceId,
                      opt => opt.MapFrom(i => i.Invoice.Id.Value))
           .ForMember(dist => dist.OrderId,
                      opt => opt.MapFrom(i => i.Order.Id.Value))
           .ForMember(dist => dist.PaymentSum,
                      opt => opt.MapFrom(i => i.PaymentSum.Value))
           .ForMember(dist => dist.Id,
                      opt => opt.MapFrom(i => i.Id.Value))
           .ForMember(dist => dist.DatePayment,
                      opt => opt.MapFrom(i => i.DatePayment.GetValue().ToShortDateString()))
           ;

        #endregion

        #region ServiceCounters

        CreateMap<ServiceCounter, CreateServiceCounterResponse>()
           .ForMember(dist => dist.Amount,
                      opt => opt.MapFrom(i => i.Amount.Value))
           .ForMember(dist => dist.ServiceId,
                      opt => opt.MapFrom(i => i.Service.Id.Value))
           .ForMember(dist => dist.Id,
                      opt => opt.MapFrom(i => i.Id.Value))
           .ForMember(dist => dist.DateCount,
                      opt => opt.MapFrom(i => i.DateCount.GetValue().ToShortDateString()))
           ;

        CreateMap<ServiceCounter, UpdateServiceCounterResponse>()
           .ForMember(dist => dist.Amount,
                      opt => opt.MapFrom(i => i.Amount.Value))
           .ForMember(dist => dist.ServiceId,
                      opt => opt.MapFrom(i => i.Service.Id.Value))
           .ForMember(dist => dist.Id,
                      opt => opt.MapFrom(i => i.Id.Value))
           .ForMember(dist => dist.DateCount,
                      opt => opt.MapFrom(i => i.DateCount.GetValue().ToShortDateString()))
           ;

        CreateMap<ServiceCounter, ServiceCounterResponse>()
           .ForMember(dist => dist.Amount,
                      opt => opt.MapFrom(i => i.Amount.Value))
           .ForMember(dist => dist.ServiceId,
                      opt => opt.MapFrom(i => i.Service.Id.Value))
           .ForMember(dist => dist.Id,
                      opt => opt.MapFrom(i => i.Id.Value))
           .ForMember(dist => dist.DateCount,
                      opt => opt.MapFrom(i => i.DateCount.GetValue().ToShortDateString()))
           ;

        #endregion
    }
}
