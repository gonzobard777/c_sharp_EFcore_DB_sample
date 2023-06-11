using Domain.Interfaces;

namespace Application.Interfaces.Infrastructure;

/*
 * Create, Update, Delete - сразу применяет изменения в БД.
 * List запрашивает все сущности из таблицы.
 */
public interface ISimpleRepository
{
    Task<int> Create<T>(T model) where T : class, IEntity;

    Task<T?> Read<T>(int id) where T : class, IEntity;

    Task<bool> Update<T>(int id, T model) where T : class, IEntity;

    Task<bool> Delete<T>(int id) where T : class, IEntity;

    Task<IEnumerable<T>> List<T>() where T : class, IEntity;
}