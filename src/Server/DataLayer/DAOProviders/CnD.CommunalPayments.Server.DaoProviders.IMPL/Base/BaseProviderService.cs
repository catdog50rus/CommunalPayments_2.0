using AutoMapper;
using CnD.CommunalPayments.Server.Dao.Base;
using CnD.CommunalPayments.Server.DaoProviders.Base;

namespace CnD.CommunalPayments.Server.DaoProviders.IMPL.Base;

public abstract class BaseProviderService<T, TEntity> : IBaseProviderService<T> 
    where T : class, new()
    where TEntity : class, new()
{
    protected readonly IMapper _mapper;
    private readonly IDao<TEntity> _dao;

    public BaseProviderService(IMapper mapper, IDao<TEntity> dao)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _dao = dao ?? throw new ArgumentNullException(nameof(dao));
    }

    public virtual async Task<ICollection<T>> GetEntitiesAsync(CancellationToken cancel = default)
    {
        var entityList = await _dao.GetEntitiesAsync(cancel).ConfigureAwait(false);

        if (entityList is null || !entityList.Any())
            return new List<T>();

        var itemList = _mapper.Map<List<T>>(entityList);

        return itemList;
    }

    public virtual async Task<T> GetEntityAsync(int id, CancellationToken cancel = default)
    {
        var entity = await _dao.GetEntityAsync(id, cancel).ConfigureAwait(false);

        if (entity is null)
            return new T();

        var item = _mapper.Map<T>(entity);

        return item;
    }

    public virtual async Task<T> CreateEntityAsync(T item, CancellationToken cancel = default)
    {
        var entity = _mapper.Map<TEntity>(item);

        var newEntity = await _dao.CreateEntityAsync(entity, cancel).ConfigureAwait(false);

        if  (newEntity is null)
            return item;

        var newItem = _mapper.Map<T>(newEntity);

        return newItem;
    }

    public virtual async Task<T> UpdateEntityAsync(T item, CancellationToken cancel = default)
    {
        var entity = _mapper.Map<TEntity>(item);

        var newEntity = await _dao.UpdateEntityAsync(entity, cancel).ConfigureAwait(false);

        if (newEntity is null)
            return item;

        var newItem = _mapper.Map<T>(newEntity);

        return newItem;
    }

    public virtual async Task<bool> DeleteEntityAsync(int id, CancellationToken cancel = default)
    {
        return await _dao.DeleteEntityAsync(id, cancel).ConfigureAwait(false);
    }
}