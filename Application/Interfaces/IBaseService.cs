using Application.Interfaces.Presentation;

namespace Application.Interfaces;

public interface IBaseService<T> where T : class
{
    Task<T> Create(T model);
    Task<T> Read(int id);
    Task Update(T model);
    Task Delete(int id);

    Task<IEnumerable<T>> List(IListQueryParams? queryParams);
}