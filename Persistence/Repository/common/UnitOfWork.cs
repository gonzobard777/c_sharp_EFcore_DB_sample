using Application.Interfaces;

namespace Persistence.Repository.common;

public class UnitOfWork : IUnitOfWork
{
    private AppDbContext DbContext { get; }

    public UnitOfWork(AppDbContext dbContext) =>
        DbContext = dbContext;

    public void Commit() =>
        DbContext.SaveChanges();

    public async Task CommitAsync() =>
        await DbContext.SaveChangesAsync();
}