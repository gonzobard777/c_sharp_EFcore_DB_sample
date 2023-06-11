using WebApi.Controller.common;
using Application.Interfaces;
using Domain;

namespace WebApi.Controller;

public class UserController : FullController<User>
{
    public UserController(IUserService service) : base(service)
    {
    }
}