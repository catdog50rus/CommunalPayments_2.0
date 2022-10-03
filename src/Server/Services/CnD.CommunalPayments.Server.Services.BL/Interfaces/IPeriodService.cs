using CnD.CommunalPayments.Server.Domen.Core.Query;
using CnD.CommunalPayments.Server.Domen.Models;

namespace CnD.CommunalPayments.Server.Services.BL.Interfaces;

public interface IPeriodService
{
    Task<List<Period>> GetAllAsync(PagedListQueryParams queryParams, CancellationToken token = default);

    Task<Period> GetEntityAsync(int id, CancellationToken token = default);

    Task<Period> CreateEntityAsync(Period item, CancellationToken token = default);

    Task<Period> UpdateEntityAsync(Period item, CancellationToken token = default);

    Task<bool> DeleteEntityAsync(int id, CancellationToken token = default);
}
