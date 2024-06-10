
using FluentValidation;

namespace Clean_Architecture.Core.Domain.Models;

public record class LoginModel
{
    public string UserName { get; init; }
    public string Password { get; set; }

}

public class UserLoginDtoValidator : AbstractValidator<LoginModel>
{
    public UserLoginDtoValidator()
    {
        RuleFor(x => x.UserName).NotEmpty().WithMessage("UserName is required.");
        RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required.");
    }
}