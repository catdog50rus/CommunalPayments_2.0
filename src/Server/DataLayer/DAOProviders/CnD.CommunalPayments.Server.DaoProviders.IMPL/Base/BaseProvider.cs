using AutoMapper;

namespace CnD.CommunalPayments.Server.DaoProviders.IMPL.Base;

public abstract class BaseProvider<T> : IBaseService<T> 
    where T : class, new()
{
    protected readonly IMapper _mapper;

    public BaseProvider(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<T> CreateEntityAsync(T entity, CancellationToken cancel = default)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteEntityAsync(int id, CancellationToken cancel = default)
    {
        throw new NotImplementedException();
    }

    public async Task<ICollection<T>> GetEntitiesAsync(CancellationToken cancel = default)
    {
        throw new NotImplementedException();
    }

    public async Task<T> GetEntityAsync(int id, CancellationToken cancel = default)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateEntityAsync(T entity, CancellationToken cancel = default)
    {
        throw new NotImplementedException();
    }
}
