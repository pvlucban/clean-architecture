using Clean_Architecture.Core.Application;
using Clean_Architecture.Core.Application.Interfaces.Repository;
using Clean_Architecture.Core.Domain;
using Clean_Architecture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class CompaniesRepository : BaseRepository<Company, Guid>, ICompaniesRepository
{
    private readonly ApplicationDBContext _applicationDBContext;
    public CompaniesRepository(ApplicationDBContext applicationDBContext) : base(applicationDBContext)
    {
        _applicationDBContext = applicationDBContext;
    }
}