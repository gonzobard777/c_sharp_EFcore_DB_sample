using Application.Interfaces.Infrastructure;
using Application.Interfaces;
using Domain;

namespace Application.Implementations;

public class RoleService : BaseService<Role>, IRoleService
{
    public RoleService(IBaseRepository<Role> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
    {
    }
}