using Microsoft.EntityFrameworkCore;
using Persistence.Interfaces;
using Domain.Interfaces;

namespace Persistence.Repository.common;

/*
 * Репозиторий, реализующий базовые операции:
 *   - Create
 *   - Read
 *   - Update
 *   - Delete
 *   - List
 */
public class BaseRepository : IBaseRepository
{
    protected AppDbContext DbContext { get; }

    public BaseRepository(AppDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public async Task<int> Create<T>(T model) where T : class, IEntity
    {
        var entityEntry = await DbContext.Set<T>().AddAsync(model);
        await SaveChangesAsync();
        return entityEntry.Entity.Id;
    }

    public Task<T?> Read<T>(int id) where T : class, IEntity
    {
        return GetNoTrackingEntity<T>(id);
    }

    public async Task<bool> Update<T>(int id, T model) where T : class, IEntity
    {
        var entity = await GetNoTrackingEntity<T>(id);
        if (entity is null)
            return false;
        model.Id = id;
        DbContext.Set<T>().Update(model);
        await SaveChangesAsync();
        return true;
    }

    public async Task<bool> Delete<T>(int id) where T : class, IEntity
    {
        var entity = await GetTrackingEntity<T>(id);
        if (entity is null)
            return false;
        DbContext.Set<T>().Remove(entity);
        await SaveChangesAsync();
        return true;
    }

    public virtual async Task<IEnumerable<T>> List<T>(ListQueryParams? queryParams, IQueryable<T>? query) where T : class, IEntity
    {
        query ??= DbContext.Set<T>();
        // здесь можно добавить к запросу что-то общее для всех
        return await query.ToListAsync();
    }


    #region Support

    private async Task SaveChangesAsync() => await DbContext.SaveChangesAsync();

    private async Task<T?> GetTrackingEntity<T>(int id) where T : class, IEntity
    {
        return id > 0
            ? await DbContext.Set<T>().FirstOrDefaultAsync(entity => entity.Id == id)
            : null;
    }

    private async Task<T?> GetNoTrackingEntity<T>(int id) where T : class, IEntity
    {
        return id > 0
            ? await DbContext.Set<T>()
                .AsNoTracking()
                .FirstOrDefaultAsync(entity => entity.Id == id)
            : null;
    }

    #endregion Support
}