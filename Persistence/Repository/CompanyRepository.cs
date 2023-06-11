using Persistence.Repository.common;
using Domain;

namespace Persistence.Repository;

public class CompanyRepository : BaseRepository<Company>
{
    public CompanyRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}