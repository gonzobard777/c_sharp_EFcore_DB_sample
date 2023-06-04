using Microsoft.EntityFrameworkCore;
using Persistence.Repository.common;

namespace Persistence.Repository;

public class UserRepository : BaseRepository
{
    public UserRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public override async Task<IEnumerable<T>> List<T>(ListQueryParams? queryParams, IQueryable<T>? _)
    {
        var query = DbContext.Users
            .Include(user => user.Company)
            .AsQueryable();

        if (queryParams?.CompanyId != null)
            query = query.Where(user => user.CompanyId == queryParams.CompanyId);

        if (queryParams?.Search != null)
        {
            var search = queryParams.Search.ToLower();
            query = query.Where(user =>
                user.Name.ToLower().Contains(search) ||
                user.Surname.ToLower().Contains(search)
            );
        }

        return (IEnumerable<T>)await base.List(queryParams, query);
    }
}