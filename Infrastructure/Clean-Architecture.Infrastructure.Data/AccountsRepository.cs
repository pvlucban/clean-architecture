using Clean_Architecture.Core.Application.Interfaces;
using Clean_Architecture.Core.Domain;

namespace Clean_Architecture.Infrastructure.Data;
public class AccountsRepository : BaseRepository<Account, int>, IAccountsRepostory
{

    private readonly ApplicationDBContext _applicationDBContext;

    public AccountsRepository(ApplicationDBContext applicationDBContext) : base(applicationDBContext)
    {
        _applicationDBContext = applicationDBContext;
    }
}