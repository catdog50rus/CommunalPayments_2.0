using CnD.CommunalPayments.Server.Domen.Core.Query;
using CnD.CommunalPayments.Server.Domen.Models;

namespace CnD.CommunalPayments.Server.Services.BL;

public class PeriodService : IPeriodService
{
    public async Task<List<Period>> GetAllAsync(PagedListQueryParams queryParams, CancellationToken token = default)
    {
        return await Task.Run(() => new List<Period>() { new Period() }, token).ConfigureAwait(false);
    }

    public async Task<Period> GetEntityAsync(int id, CancellationToken token = default)
    {
        return await Task.Run(() => new Period(), token).ConfigureAwait(false);
    }

    public async Task<Period> CreateEntityAsync(Period item, CancellationToken token = default)
    {
        return await Task.Run(() => new Period(), token).ConfigureAwait(false);
    }

    public async Task<Period> UpdateEntityAsync(Period item, CancellationToken token = default)
    {
        return await Task.Run(() => new Period(), token).ConfigureAwait(false);
    }

    public async Task<Period> DeleteEntityAsync(int id, CancellationToken token = default)
    {
        return await Task.Run(() => new Period(), token).ConfigureAwait(false);
    }
}

public interface IPeriodService
{
    Task<List<Period>> GetAllAsync(PagedListQueryParams queryParams, CancellationToken token = default);

    Task<Period> GetEntityAsync(int id, CancellationToken token = default);

    Task<Period> CreateEntityAsync(Period item, CancellationToken token = default);

    Task<Period> UpdateEntityAsync(Period item, CancellationToken token = default);

    Task<Period> DeleteEntityAsync(int id, CancellationToken token = default);
}
