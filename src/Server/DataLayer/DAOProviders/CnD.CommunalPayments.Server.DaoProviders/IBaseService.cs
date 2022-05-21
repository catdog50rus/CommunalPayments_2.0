namespace CnD.CommunalPayments.Server.DaoProviders;

public interface IBaseService<T> where T : class, new()
{
    Task<ICollection<T>> GetEntitiesAsync(CancellationToken cancel = default);
    Task<T> GetEntityAsync(int id, CancellationToken cancel = default);
    Task<T> CreateEntityAsync(T entity, CancellationToken cancel = default);
    Task UpdateEntityAsync(T entity, CancellationToken cancel = default);
    Task DeleteEntityAsync(int id, CancellationToken cancel = default);
}
