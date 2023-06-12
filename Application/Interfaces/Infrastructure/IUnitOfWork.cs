namespace Application.Interfaces.Infrastructure;

public interface IUnitOfWork
{
    void Commit();
    Task CommitAsync();
}