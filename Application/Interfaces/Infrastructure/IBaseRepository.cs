using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Application.Interfaces.Infrastructure;

public interface IBaseRepository<T> where T : class
{
    Task<EntityEntry<T>> Create(T model);
    Task<T?> Read(int id, EntityTracking tracking);
    EntityEntry<T> Update(T model);
    EntityEntry<T> Delete(T model);

    /*
     * Возвращает пустой IQueryable по конкретной таблице,
     * в который потом можно добавить своих фильтров.
     */
    IQueryable<T> NewQuery(EntityTracking tracking);
}