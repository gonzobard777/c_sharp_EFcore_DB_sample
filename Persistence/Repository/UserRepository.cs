using Persistence.Repository.common;
using Domain;

namespace Persistence.Repository;

public class UserRepository : BaseRepository<User>
{
    public UserRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}