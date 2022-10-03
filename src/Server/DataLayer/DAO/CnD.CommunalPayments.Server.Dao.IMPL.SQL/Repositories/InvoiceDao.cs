using CnD.CommunalPayments.Server.Dao.Entities.Models;
using CnD.CommunalPayments.Server.Dao.IMPL.SQL.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace CnD.CommunalPayments.Server.Dao.IMPL.SQL.Repositories;

public class InvoiceDao : DaoBase<InvoiceEntity>
{
    public InvoiceDao(CommunalPaymentsDbContext context) : base(context)
    {
        
    }

    public override async Task<InvoiceEntity> GetEntityAsync(int id, CancellationToken cancel = default)
    {
        return await Items
            .AsNoTracking()
            .Include(x => x.Period)
            .Include(x => x.Provider)
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync(cancel)
            .ConfigureAwait(false);
    }

    public override async Task<ICollection<InvoiceEntity>> GetEntitiesAsync(CancellationToken cancel = default)
    {
        return await Items
            .AsNoTracking()
            .Include(x => x.Period)
            .Include(x => x.Provider)
            .ToListAsync(cancel)
            .ConfigureAwait(false);
    }
}

public class InvoiceServicesDao : DaoBase<InvoiceServicesEntity>
{
    public InvoiceServicesDao(CommunalPaymentsDbContext context) : base(context)
    {
    }
}

public class OrderDao : DaoBase<OrderEntity>
{
    public OrderDao(CommunalPaymentsDbContext context) : base(context)
    {
    }
}

public class PaymentDao : DaoBase<PaymentEntity>
{
    public PaymentDao(CommunalPaymentsDbContext context) : base(context)
    {
    }
}

public class PeriodDao : DaoBase<PeriodEntity>
{
    public PeriodDao(CommunalPaymentsDbContext context) : base(context)
    {
    }

    public override async Task<bool> DeleteEntityAsync(int id, CancellationToken cancel = default)
    {
        return await Task.Run(() => false);
    }
}

public class ProviderDao : DaoBase<ProviderEntity>
{
    public ProviderDao(CommunalPaymentsDbContext context) : base(context)
    {
    }

    public override async Task<bool> DeleteEntityAsync(int id, CancellationToken cancel = default)
    {
        return await Task.Run(() => false);
    }
}


public class ServiceCounterDao : DaoBase<ServiceCounterEntity>
{
    public ServiceCounterDao(CommunalPaymentsDbContext context) : base(context)
    {
    }
}

public class ServicesDao : DaoBase<ServiceEntity>
{
    public ServicesDao(CommunalPaymentsDbContext context) : base(context)
    {
    }
}