﻿using AutoMapper;
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

        #region Services

        CreateMap<Service, ServiceEntity>()
            .ForPath(x => x.Id, o => o.MapFrom(i => i.Id.Value))
            .ForPath(x => x.Name, o => o.MapFrom(i => i.Name.GetValue()))

            .ForPath(x => x.UpdatedAt, o => o.Ignore())
            .ForPath(x => x.CreatedAt, o => o.Ignore())
            //.ForPath(x => x.CreatorName, o => o.Ignore())
            //.ForPath(x => x.UpdatorName, o => o.Ignore())
            ;

        CreateMap<ServiceEntity, Service>()
            .ForPath(x => x.Id, o => o.MapFrom(i => new ModelId(i.Id)))
            .ForPath(x => x.Name, o => o.MapFrom(i => new ServiceName(i.Name)))
            ;

        #endregion

        #region InvoiceServices

        CreateMap<InvoiceServices, InvoiceServicesEntity>()
            .ForPath(x => x.InvoiceId, o => o.MapFrom(i => i.Invoice.Id.Value))
            .ForPath(x => x.Invoice, o => o.Ignore())

            .ForPath(x => x.ServiceId, o => o.MapFrom(i => i.Service.Id.Value))
            .ForPath(x => x.Service, o => o.Ignore())

            .ForPath(x => x.Id, o => o.MapFrom(i => i.Id.Value))
            .ForPath(x => x.Amount, o => o.MapFrom(i => i.Amount.Value))

            .ForPath(x => x.UpdatedAt, o => o.Ignore())
            .ForPath(x => x.CreatedAt, o => o.Ignore())
            //.ForPath(x => x.CreatorName, o => o.Ignore())
            //.ForPath(x => x.UpdatorName, o => o.Ignore())
            ;


        CreateMap<InvoiceServicesEntity, InvoiceServices>()
            .ForPath(x => x.Invoice, o => o.MapFrom(i => new Invoice
            {
                Id = new ModelId(i.InvoiceId),
                IsPaid = i.Invoice.IsPaid,
                Period = new Period()
                {
                    Id = new ModelId(i.Invoice.PeriodId),
                    Month = EnumHelper.GetValueFromDescr<MonthName>(i.Invoice.Period.Month),
                    Year = i.Invoice.Period.Year
                },
                Provider = new Provider()
                {
                    Id = new ModelId(i.Invoice.ProviderId),
                    NameProvider = new ServiceName(i.Invoice.Provider.NameProvider),
                    WebSite = new WebSite(i.Invoice.Provider.WebSite)
                },
                Sum = new Sum(i.Invoice.Sum),            
            }))

            .ForPath(x => x.Service, o => o.MapFrom(i => new Service
            {
                Id = new ModelId(i.ServiceId),
                IsCounter = i.Service.IsCounter,
                Name = new ServiceName(i.Service.Name)
            }))

            .ForPath(x => x.Id, o => o.MapFrom(i => new ModelId(i.Id)))
            .ForPath(x => x.Amount, o => o.MapFrom(i => new Amount(i.Amount)))


            ;

        #endregion

        #region Payments

        CreateMap<Payment, PaymentEntity>()
            .ForPath(x => x.InvoiceId, o => o.MapFrom(i => i.Invoice.Id.Value))
            .ForPath(x => x.Invoice, o => o.Ignore())

            .ForPath(x => x.OrderId, o => o.MapFrom(i => i.Order.Id.Value))
            .ForPath(x => x.Order, o => o.Ignore())

            .ForPath(x => x.Id, o => o.MapFrom(i => i.Id.Value))
            .ForPath(x => x.PaymentSum, o => o.MapFrom(i => i.PaymentSum.Value))
            .ForPath(x => x.DatePayment, o => o.MapFrom(i => i.DatePayment.GetValue().ToShortDateString()))

            .ForPath(x => x.UpdatedAt, o => o.Ignore())
            .ForPath(x => x.CreatedAt, o => o.Ignore())
            //.ForPath(x => x.CreatorName, o => o.Ignore())
            //.ForPath(x => x.UpdatorName, o => o.Ignore())
            ;


        CreateMap<PaymentEntity, Payment>()
            .ForPath(x => x.Invoice, o => o.MapFrom(i => new Invoice
            {
                Id = new ModelId(i.InvoiceId),
                IsPaid = i.Invoice.IsPaid,
                Period = new Period()
                {
                    Id = new ModelId(i.Invoice.PeriodId),
                    Month = EnumHelper.GetValueFromDescr<MonthName>(i.Invoice.Period.Month),
                    Year = i.Invoice.Period.Year
                },
                Provider = new Provider()
                {
                    Id = new ModelId(i.Invoice.ProviderId),
                    NameProvider = new ServiceName(i.Invoice.Provider.NameProvider),
                    WebSite = new WebSite(i.Invoice.Provider.WebSite)
                },
                Sum = new Sum(i.Invoice.Sum),
            }))

            .ForPath(x => x.Order, o => o.MapFrom(i => new Order
            {
                Id = new ModelId(i.OrderId),
                FileName = i.Order.FileName,
                OrderScreen = i.Order.OrderScreen
            }))

            .ForPath(x => x.Id, o => o.MapFrom(i => new ModelId(i.Id)))
            .ForPath(x => x.PaymentSum, o => o.MapFrom(i => new Sum(i.PaymentSum)))
            .ForPath(x => x.DatePayment, o => o.MapFrom(i => new Date(i.DatePayment)))

            ;

        #endregion

        #region ServiceCounter

        CreateMap<ServiceCounter, ServiceCounterEntity>()
            .ForPath(x => x.ServiceId, o => o.MapFrom(i => i.Service.Id.Value))
            .ForPath(x => x.Service, o => o.Ignore())

            .ForPath(x => x.Id, o => o.MapFrom(i => i.Id.Value))
            .ForPath(x => x.Value, o => o.MapFrom(i => i.Amount.Value))
            .ForPath(x => x.DateCount, o => o.MapFrom(i => i.DateCount.GetValue().ToShortDateString()))

            .ForPath(x => x.UpdatedAt, o => o.Ignore())
            .ForPath(x => x.CreatedAt, o => o.Ignore())
            //.ForPath(x => x.CreatorName, o => o.Ignore())
            //.ForPath(x => x.UpdatorName, o => o.Ignore())
            ;


        CreateMap<ServiceCounterEntity, ServiceCounter>()
            .ForPath(x => x.Service, o => o.MapFrom(i => new Service
            {
                Id = new ModelId(i.ServiceId),
                IsCounter = i.Service.IsCounter,
                Name = new ServiceName(i.Service.Name),
            }))

            .ForPath(x => x.Id, o => o.MapFrom(i => new ModelId(i.Id)))
            .ForPath(x => x.Amount, o => o.MapFrom(i => new Amount(i.Value)))
            .ForPath(x => x.DateCount, o => o.MapFrom(i => new Date(i.DateCount)))
            ;

        #endregion

    }
}
