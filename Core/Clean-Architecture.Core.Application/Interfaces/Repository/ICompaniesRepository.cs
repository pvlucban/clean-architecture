using Clean_Architecture.Core.Application.Interfaces.Repository;
using Clean_Architecture.Core.Domain;

namespace Clean_Architecture.Core.Application;

public interface ICompaniesRepository : IRepository<Company, Guid>
{

}
