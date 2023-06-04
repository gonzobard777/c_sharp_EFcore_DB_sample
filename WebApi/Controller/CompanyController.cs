using WebApi.Controller.common;
using Persistence.Interfaces;
using Domain;

namespace WebApi.Controller;

public class CompanyController : FullController<Company>
{
    public CompanyController(IBaseRepository repository) : base(repository)
    {
    }
}