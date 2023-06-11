using Application.Interfaces.Infrastructure;
using Application.Interfaces;
using Domain;

namespace Application.Implementations;

public class CompanyService : BaseService<Company>, ICompanyService
{
    public CompanyService(IBaseRepository<Company> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
    {
    }
}