using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;

namespace WebApi.Controller.common;

/*
 * Контроллер, у которого доступен только список.
 */
public class ListController<T> : BaseController where T : class
{
    protected IBaseService<T> Service { get; }

    protected ListController(IBaseService<T> service)
    {
        Service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<T>>> List([FromQuery] ListQueryParams queryParams)
    {
        return Ok(await Service.List(queryParams));
    }
}