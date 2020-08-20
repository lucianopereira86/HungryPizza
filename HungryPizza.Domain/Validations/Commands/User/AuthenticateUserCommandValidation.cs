using FluentValidation;
using HungryPizza.Domain.Commands.User;

namespace HungryPizza.Domain.Validations.Commands.User
{
    public class AuthenticateUserCommandValidation : AbstractValidator<AuthenticateUserCommand>
    {
        public AuthenticateUserCommandValidation()
        {
            RuleFor(x => x.Email)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithErrorCode("1002")
                .EmailAddress()
                .WithErrorCode("1003")
                .MaximumLength(100)
                .WithErrorCode("1004");

            RuleFor(x => x.Password)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithErrorCode("1005")
                .Length(4, 20)
                .WithErrorCode("1006");
        }
    }
}
