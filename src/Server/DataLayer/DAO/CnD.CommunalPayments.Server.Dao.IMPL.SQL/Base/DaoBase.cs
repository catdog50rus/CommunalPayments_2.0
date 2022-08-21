using CnD.CommunalPayments.Server.Dao.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CnD.CommunalPayments.Server.Dao.IMPL.SQL.Base
{
    public abstract class DaoBase<TEntity> : IDao<TEntity> where TEntity : class, new()
    {
        public DaoBase()
        {
        }

        public virtual async Task<TEntity> CreateEntityAsync(TEntity entity, CancellationToken cancel = default)
        {
            return await Task.Run(() => new TEntity(), cancel).ConfigureAwait(false);
        }

        public virtual async Task<bool> DeleteEntityAsync(int id, CancellationToken cancel = default)
        {
            return await Task.Run(() => true, cancel).ConfigureAwait(false);
        }

        public virtual async Task<ICollection<TEntity>> GetEntitiesAsync(CancellationToken cancel = default)
        {
            return await Task.Run(() => new List<TEntity>(), cancel).ConfigureAwait(false);
        }

        public virtual async Task<TEntity> GetEntityAsync(int id, CancellationToken cancel = default)
        {
            return await Task.Run(() => new TEntity(), cancel).ConfigureAwait(false);
        }

        public virtual async Task<TEntity> UpdateEntityAsync(TEntity entity, CancellationToken cancel = default)
        {
            return await Task.Run(() => new TEntity(), cancel).ConfigureAwait(false);
        }
    }
}
