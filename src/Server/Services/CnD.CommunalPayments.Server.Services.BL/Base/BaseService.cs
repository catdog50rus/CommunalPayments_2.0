using CnD.CommunalPayments.Server.DaoProviders.Base;
using CnD.CommunalPayments.Server.Domen.Core.Query;
using CnD.CommunalPayments.Server.Domen.Models.Base;

namespace CnD.CommunalPayments.Server.Services.BL.Base;

public abstract class BaseService<TModel> : IBaseService<TModel> where TModel : IDomenModel, new()
{
    private readonly IBaseProviderService<TModel> _daoProvider;

    public BaseService(IBaseProviderService<TModel> daoProvider)
    {
        _daoProvider = daoProvider ?? throw new ArgumentNullException(nameof(daoProvider));
    }

    public virtual async Task<List<TModel>> GetAllAsync(PagedListQueryParams queryParams, CancellationToken token = default)
    {
        return await _daoProvider.GetEntitiesAsync(token).ConfigureAwait(false);
    }

    public virtual async Task<TModel> GetEntityAsync(int id, CancellationToken token = default)
    {
        return await _daoProvider.GetEntityAsync(id, token).ConfigureAwait(false);
    }

    public virtual async Task<TModel> CreateEntityAsync(TModel item, CancellationToken token = default)
    {
        return await Task.Run(() => _daoProvider.CreateEntityAsync(item), token).ConfigureAwait(false);
    }

    public virtual async Task<TModel> UpdateEntityAsync(TModel item, CancellationToken token = default)
    {
        return await _daoProvider.UpdateEntityAsync(item, token).ConfigureAwait(false);
    }

    public virtual async Task<bool> DeleteEntityAsync(int id, CancellationToken token = default)
    {
        return await _daoProvider.DeleteEntityAsync(id, token).ConfigureAwait(false);
    }
}
