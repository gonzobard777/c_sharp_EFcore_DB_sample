using Persistence.Repository.common;
using Domain.Interfaces;

namespace Persistence.Interfaces;

/*
 * Использование патерна репозиторий:
 *   https://youtu.be/aNKRdtDBH08?t=457
 */
public interface IBaseRepository
{
    Task<int> Create<T>(T model) where T : class, IEntity;

    Task<T?> Read<T>(int id) where T : class, IEntity;

    Task<bool> Update<T>(int id, T model) where T : class, IEntity;

    Task<bool> Delete<T>(int id) where T : class, IEntity;

    Task<IEnumerable<T>> List<T>(ListQueryParams? queryParams, IQueryable<T>? query) where T : class, IEntity;
}