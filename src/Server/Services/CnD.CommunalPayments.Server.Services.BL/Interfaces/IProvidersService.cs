using CnD.CommunalPayments.Server.Domen.Core.Query;
using CnD.CommunalPayments.Server.Domen.Models;

namespace CnD.CommunalPayments.Server.Services.BL.Interfaces
{
    public interface IProvidersService
    {
        Task<List<Provider>> GetAllAsync(PagedListQueryParams queryParams, CancellationToken token = default);

        Task<Provider> GetEntityAsync(int id, CancellationToken token = default);

        Task<Provider> CreateEntityAsync(Provider item, CancellationToken token = default);

        Task<Provider> UpdateEntityAsync(Provider item, CancellationToken token = default);

        Task<bool> DeleteEntityAsync(int id, CancellationToken token = default);
    }
}
