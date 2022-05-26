using AutoMapper;
using CnD.CommunalPayments.Server.Dao.Base;
using CnD.CommunalPayments.Server.Dao.Entities.Models;
using CnD.CommunalPayments.Server.DaoProviders.IMPL.Base;
using CnD.CommunalPayments.Server.Domen.Models;

namespace CnD.CommunalPayments.Server.DaoProviders.IMPL
{
    public class InvoiceDaoProvider : BaseProviderService<Invoice, InvoiceEntity>
    {
        public InvoiceDaoProvider(IMapper mapper, IDao<InvoiceEntity> dao) : base(mapper, dao)
        {

        }
    }

    public class InvoiceServicesDaoProvider : BaseProviderService<InvoiceServices, InvoiceServicesEntity>
    {
        public InvoiceServicesDaoProvider(IMapper mapper, IDao<InvoiceServicesEntity> dao) : base(mapper, dao)
        {

        }
    }

    public class OrderDaoProvider : BaseProviderService<Order, OrderEntity>
    {
        public OrderDaoProvider(IMapper mapper, IDao<OrderEntity> dao) : base(mapper, dao)
        {

        }
    }

    public class PaymentDaoProvider : BaseProviderService<Payment, PaymentEntity>
    {
        public PaymentDaoProvider(IMapper mapper, IDao<PaymentEntity> dao) : base(mapper, dao)
        {

        }
    }

    public class PeriodDaoProvider : BaseProviderService<Period, PeriodEntity>
    {
        public PeriodDaoProvider(IMapper mapper, IDao<PeriodEntity> dao) : base(mapper, dao)
        {

        }
    }

    public class ProviderDaoProvider : BaseProviderService<Provider, ProviderEntity>
    {
        public ProviderDaoProvider(IMapper mapper, IDao<ProviderEntity> dao) : base(mapper, dao)
        {

        }
    }

    public class ServiceDaoProvider : BaseProviderService<Service, ServiceEntity>
    {
        public ServiceDaoProvider(IMapper mapper, IDao<ServiceEntity> dao) : base(mapper, dao)
        {

        }
    }

    public class ServiceCounterDaoProvider : BaseProviderService<ServiceCounter, ServiceCounterEntity>
    {
        public ServiceCounterDaoProvider(IMapper mapper, IDao<ServiceCounterEntity> dao) : base(mapper, dao)
        {

        }
    }
}