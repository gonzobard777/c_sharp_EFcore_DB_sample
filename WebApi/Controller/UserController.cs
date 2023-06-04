using WebApi.Controller.common;
using Persistence.Repository;
using Domain;

namespace WebApi.Controller;

public class UserController : FullController<User>
{
    public UserController(UserRepository repository) : base(repository)
    {
    }
}