using FluentValidation;
using Overstay.Application.Features.Users.Commands;
using Overstay.Application.Features.Users.Requests;

namespace Overstay.Application.Features.Users.Validators;

internal class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(user => user.Item.Email).NotEmpty().EmailAddress();
        RuleFor(user => user.Item.UserName).NotEmpty();
        RuleFor(user => user.Item.CountryId).NotEmpty();

        RuleFor(user => user.Item.Password)
            .NotEmpty()
            .MinimumLength(8)
            .Matches("[A-Z]")
            .WithMessage("Password must contain at least one uppercase letter.")
            .Matches("[a-z]")
            .WithMessage("Password must contain at least one lowercase letter.")
            .Matches("[0-9]")
            .WithMessage("Password must contain at least one digit.")
            .Matches("[^a-zA-Z0-9]")
            .WithMessage("Password must contain at least one non-alphanumeric character.");
    }
}
