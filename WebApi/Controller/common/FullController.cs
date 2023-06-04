using Persistence.Repository.common;
using Microsoft.AspNetCore.Mvc;
using Persistence.Interfaces;
using Domain.Interfaces;

namespace WebApi.Controller.common;

public abstract class FullController<T> : BaseController where T : class, IEntity
{
    protected IBaseRepository Repository { get; }

    protected FullController(IBaseRepository repository)
    {
        Repository = repository;
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody] T model)
    {
        return Ok(await Repository.Create(model));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<T>> Read(int id)
    {
        return Ok(await Repository.Read<T>(id));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<bool>> Update(int id, [FromBody] T model)
    {
        return Ok(await Repository.Update(id, model));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> Delete(int id)
    {
        return Ok(await Repository.Delete<T>(id));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<T>>> List([FromQuery] ListQueryParams queryParams)
    {
        return Ok(await Repository.List<T>(queryParams, null));
    }
}