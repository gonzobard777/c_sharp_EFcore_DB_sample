using Application.Interfaces.Infrastructure;
using Application.Interfaces.Presentation;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;
using Domain.Interfaces;

namespace Application.Implementations;

public class BaseService<T> : IBaseService<T> where T : class, IEntity
{
    protected IUnitOfWork UnitOfWork { get; }
    protected IBaseRepository<T> Repository { get; }

    protected BaseService(IBaseRepository<T> repository, IUnitOfWork unitOfWork)
    {
        Repository = repository;
        UnitOfWork = unitOfWork;
    }

    public async Task<T> Create(T model)
    {
        var entityEntry = await Repository.Create(model);
        await UnitOfWork.CommitAsync();
        return entityEntry.Entity;
    }

    public async Task<T> Read(int id) => await Read(id, EntityTracking.DisabledWithIdentityResolution);

    public async Task Update(T model)
    {
        await Read(model.Id, EntityTracking.Disabled);
        Repository.Update(model);
        await UnitOfWork.CommitAsync();
    }

    public async Task Delete(int id)
    {
        var entity = await Read(id, EntityTracking.Disabled);
        Repository.Delete(entity);
        await UnitOfWork.CommitAsync();
    }

    public virtual async Task<IEnumerable<T>> List(IListQueryParams? queryParams)
    {
        return await Repository
            .NewQuery(EntityTracking.Disabled)
            .ToListAsync();
    }


    #region Support

    private async Task<T> Read(int id, EntityTracking tracking)
    {
        var entity = await Repository.Read(id, tracking);
        if (entity is null)
            throw new Exception($"There is no entity with Id=\"{id}\"");
        return entity;
    }

    #endregion Support
}