using CnD.CommunalPayments.Server.Domen.Models.Base;

namespace CnD.CommunalPayments.Server.DaoProviders.Base;

public interface IBaseProviderService<T> where T : IDomenModel, new()
{
    Task<List<T>> GetEntitiesAsync(CancellationToken cancel = default);

    Task<T> GetEntityAsync(int id, CancellationToken cancel = default);

    Task<T> CreateEntityAsync(T item, CancellationToken cancel = default);

    Task<T> UpdateEntityAsync(T item, CancellationToken cancel = default);

    Task<bool> DeleteEntityAsync(int id, CancellationToken cancel = default);
}