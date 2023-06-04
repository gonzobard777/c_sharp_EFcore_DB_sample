using Persistence.Repository.common;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controller.common;
using Persistence.Interfaces;
using Domain;

namespace WebApi.Controller;

public class RoleController : BaseController
{
    private IBaseRepository Repository { get; }

    public RoleController(IBaseRepository repository)
    {
        Repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Role>>> List(ListQueryParams? queryParams)
    {
        return Ok(await Repository.List<Role>(queryParams, null));
    }
}