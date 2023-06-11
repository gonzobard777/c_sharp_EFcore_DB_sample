using Microsoft.EntityFrameworkCore.ChangeTracking;
using Application.Interfaces.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Domain.Interfaces;

namespace Persistence.Repository.common;

public class BaseRepository<T> : IBaseRepository<T> where T : class, IEntity
{
    private DbSet<T> DbSet { get; }

    public BaseRepository(AppDbContext dbContext)
    {
        DbSet = dbContext.Set<T>();
    }

    public async Task<EntityEntry<T>> Create(T model) => await DbSet.AddAsync(model);

    public async Task<T?> Read(int id, EntityTracking tracking) =>
        id > 0
            ? await NewQuery(tracking).FirstOrDefaultAsync(entity => entity.Id == id)
            : null;

    public EntityEntry<T> Update(T model) => DbSet.Update(model);

    public EntityEntry<T> Delete(T model) => DbSet.Remove(model);

    public IQueryable<T> NewQuery(EntityTracking tracking)
    {
        switch (tracking)
        {
            case EntityTracking.Disabled:
                return DbSet.AsNoTracking();
            case EntityTracking.DisabledWithIdentityResolution:
                return DbSet.AsNoTrackingWithIdentityResolution();
            default:
                return DbSet.AsQueryable();
        }
    }
}