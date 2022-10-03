using CnD.CommunalPayments.Server.DaoProviders.Base;
using CnD.CommunalPayments.Server.Domen.Core.Query;
using CnD.CommunalPayments.Server.Domen.Models;
using CnD.CommunalPayments.Server.Services.BL.Interfaces;

namespace CnD.CommunalPayments.Server.Services.BL.Periods;

public class PeriodService : IPeriodService
{
    private readonly IBaseProviderService<Period> _daoProvider;

    public PeriodService(IBaseProviderService<Period> daoProvider)
    {
        _daoProvider = daoProvider ?? throw new ArgumentNullException(nameof(daoProvider));
    }

    public async Task<List<Period>> GetAllAsync(PagedListQueryParams queryParams, CancellationToken token = default)
    {
        return await _daoProvider.GetEntitiesAsync(token).ConfigureAwait(false);
    }

    public async Task<Period> GetEntityAsync(int id, CancellationToken token = default)
    {
        return await _daoProvider.GetEntityAsync(id, token).ConfigureAwait(false);
    }

    public async Task<Period> CreateEntityAsync(Period item, CancellationToken token = default)
    {
        return await Task.Run(() => _daoProvider.CreateEntityAsync(item), token).ConfigureAwait(false);
    }

    public async Task<Period> UpdateEntityAsync(Period item, CancellationToken token = default)
    {
        return await _daoProvider.UpdateEntityAsync(item, token).ConfigureAwait(false);
    }

    public async Task<bool> DeleteEntityAsync(int id, CancellationToken token = default)
    {
        return await _daoProvider.DeleteEntityAsync(id, token).ConfigureAwait(false);
    }
}
