using Application.Interfaces.Infrastructure;
using Application.Interfaces.Presentation;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;
using Domain;

namespace Application.Implementations;

public class UserService : BaseService<User>, IUserService
{
    public UserService(IBaseRepository<User> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
    {
    }

    public new async Task<IEnumerable<User>> List(IListQueryParams? queryParams)
    {
        var query = Repository
            .NewQuery(EntityTracking.DisabledWithIdentityResolution)
            .Include(user => user.Company)
            .AsQueryable();

        if (queryParams?.CompanyId is not null)
            query = query.Where(user => user.CompanyId == queryParams.CompanyId);

        if (queryParams?.Search is not null)
        {
            var search = queryParams.Search.ToLower();
            query = query.Where(user =>
                user.Name.ToLower().Contains(search) ||
                user.Surname.ToLower().Contains(search)
            );
        }

        return await query.ToListAsync();
    }
}