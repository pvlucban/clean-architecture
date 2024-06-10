using Clean_Architecture.Core.Application.Interfaces;
using Clean_Architecture.Core.Application.Queries;
using Clean_Architecture.Core.Domain;
using MediatR;

namespace Clean_Architecture.Core.Application;

public class GetAccountByIdHandler : IRequestHandler<GetAccountByIdQuery, Account>
{
    private readonly IAccountsRepostory _accountsRepostory;

    public GetAccountByIdHandler(IAccountsRepostory accountsRepostory)
    {
        _accountsRepostory = accountsRepostory;
    }
    public async Task<Account> Handle(GetAccountByIdQuery request, CancellationToken cancellationToken)
    {
        return await _accountsRepostory.GetByIdAsync(request.Id);
    }
}
