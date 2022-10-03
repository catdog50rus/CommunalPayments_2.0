using CnD.CommunalPayments.Server.Dao.Base;
using CnD.CommunalPayments.Server.Dao.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace CnD.CommunalPayments.Server.Dao.IMPL.SQL.Repositories.Base;

public abstract class DaoBase<TEntity> : IDao<TEntity> where TEntity : EntityBase, new()
{
    private readonly CommunalPaymentsDbContext _context;

    private readonly DbSet<TEntity> _dbset;

    protected virtual IQueryable<TEntity> Items => _dbset;

    public DaoBase(CommunalPaymentsDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));

        _dbset = _context.Set<TEntity>();
    }

    public virtual async Task<TEntity> CreateEntityAsync(TEntity entity, CancellationToken cancel = default)
    {
        await _context.AddAsync(entity, cancel).ConfigureAwait(false);

        await _context.SaveChangesAsync(cancel).ConfigureAwait(false);

        return await GetEntityAsync(entity.Id, cancel).ConfigureAwait(false);
    }

    public virtual async Task<bool> DeleteEntityAsync(int id, CancellationToken cancel = default)
    {
        var isItemFound = await Items.AnyAsync(x => x.Id == id, cancel).ConfigureAwait(false);

        if (isItemFound)
        {
            _context.Remove(new TEntity { Id = id });

            await _context.SaveChangesAsync(cancel).ConfigureAwait(false);

            return true;
        }

        return false;
    }

    public virtual async Task<ICollection<TEntity>> GetEntitiesAsync(CancellationToken cancel = default)
    {
        return await Items
            .AsNoTracking()
            .ToListAsync(cancel)
            .ConfigureAwait(false);
    }

    public virtual async Task<TEntity> GetEntityAsync(int id, CancellationToken cancel = default)
    {
        return await Items
            .AsNoTracking()
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync(cancel)
            .ConfigureAwait(false);
    }

    public virtual async Task<TEntity> UpdateEntityAsync(TEntity entity, CancellationToken cancel = default)
    {
        _context.Update(entity);

       await _context.SaveChangesAsync(cancel).ConfigureAwait(false);

        return await GetEntityAsync(entity.Id, cancel).ConfigureAwait(false);
    }
}