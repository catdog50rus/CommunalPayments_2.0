using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CnD.CommunalPayments.Server.Dao.Base;

public interface IDao<TEntity> where TEntity : class, new()
{
    Task<ICollection<TEntity>> GetEntitiesAsync(CancellationToken cancel = default);

    Task<TEntity> GetEntityAsync(int id, CancellationToken cancel = default);

    Task<TEntity> CreateEntityAsync(TEntity entity, CancellationToken cancel = default);

    Task<TEntity> UpdateEntityAsync(TEntity entity, CancellationToken cancel = default);

    Task<bool> DeleteEntityAsync(int id, CancellationToken cancel = default);
}