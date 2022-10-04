using CnD.CommunalPayments.Server.DaoProviders.Base;
using CnD.CommunalPayments.Server.Domen.Core.Query;
using CnD.CommunalPayments.Server.Domen.Models;
using CnD.CommunalPayments.Server.Services.BL.Base;
using CnD.CommunalPayments.Server.Services.BL.Interfaces;

namespace CnD.CommunalPayments.Server.Services.BL.Orders;

public class OrdersService : BaseService<Order>, IOrdersService
{
    //private readonly IBaseProviderService<Order> _daoProvider;

    //public OrdersService(IBaseProviderService<Order> daoProvider)
    //{
    //	_daoProvider = daoProvider ?? throw new ArgumentNullException(nameof(daoProvider));
    //}

    //   public async Task<List<Order>> GetAllAsync(PagedListQueryParams queryParams, CancellationToken token = default)
    //   {
    //       return await _daoProvider.GetEntitiesAsync(token).ConfigureAwait(false);
    //   }

    //   public async Task<Order> GetEntityAsync(int id, CancellationToken token = default)
    //   {
    //       return await _daoProvider.GetEntityAsync(id, token).ConfigureAwait(false);
    //   }

    //   public async Task<Order> CreateEntityAsync(Order item, CancellationToken token = default)
    //   {
    //       return await Task.Run(() => _daoProvider.CreateEntityAsync(item), token).ConfigureAwait(false);
    //   }

    //   public async Task<Order> UpdateEntityAsync(Order item, CancellationToken token = default)
    //   {
    //       return await _daoProvider.UpdateEntityAsync(item, token).ConfigureAwait(false);
    //   }

    //   public async Task<bool> DeleteEntityAsync(int id, CancellationToken token = default)
    //   {
    //       return await _daoProvider.DeleteEntityAsync(id, token).ConfigureAwait(false);
    //   }

    public OrdersService(IBaseProviderService<Order> daoProvider) : base(daoProvider)
    {
        
    }
}
