using WebApi.Controller.common;
using Application.Interfaces;
using Domain;

namespace WebApi.Controller;

public class CompanyController : FullController<Company>
{
    public CompanyController(ICompanyService service) : base(service)
    {
    }
}