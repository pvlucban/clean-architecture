using Clean_Architecture.Core.Application.Interfaces.Repository;
using Clean_Architecture.Core.Domain;

namespace Clean_Architecture.Core.Application.Interfaces;
public interface IAccountsRepostory : IRepository<Account, int>
{
}