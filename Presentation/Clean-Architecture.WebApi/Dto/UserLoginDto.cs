using FluentValidation;
namespace Clean_Architecture.WepApi.Dto;

public record class UserLoginDto
{
    public string UserName { get; init; }
    public string Password { get; init; }
}

public class UserLoginDtoValidator : AbstractValidator<UserLoginDto>
{
    public UserLoginDtoValidator()
    {
        RuleFor(x => x.UserName).NotEmpty().WithMessage("UserName is required.");
        RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required.");
    }
}