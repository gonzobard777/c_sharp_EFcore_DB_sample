using WebApi.Controller.common;
using Application.Interfaces;
using Domain;

namespace WebApi.Controller;

public class RoleController : ListController<Role>
{
    public RoleController(IRoleService service) : base(service)
    {
    }
}