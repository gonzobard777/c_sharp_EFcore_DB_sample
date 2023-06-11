using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;

namespace WebApi.Controller.common;

public abstract class FullController<T> : BaseController where T : class
{
    protected IBaseService<T> Service { get; }

    protected FullController(IBaseService<T> service)
    {
        Service = service;
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody] T model)
    {
        return Ok(await Service.Create(model));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<T>> Read(int id)
    {
        return Ok(await Service.Read(id));
    }

    [HttpPut("{id}")]
    public async Task Update([FromBody] T model)
    {
        await Service.Update(model);
    }

    [HttpDelete("{id}")]
    public async Task Delete(int id)
    {
        await Service.Delete(id);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<T>>> List([FromQuery] ListQueryParams queryParams)
    {
        return Ok(await Service.List(queryParams));
    }
}