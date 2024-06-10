using Clean_Architecture.Core.Domain;
using MediatR;

namespace Clean_Architecture.Core.Application.Queries;

public class GetAccountByIdQuery : IRequest<Account>
{
    public int Id { get; init; }

}
