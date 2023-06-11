using Persistence.Repository.common;
using Domain;

namespace Persistence.Repository;

public class RoleRepository : BaseRepository<Role>
{
    public RoleRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}