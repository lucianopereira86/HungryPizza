using FluentValidation;
using HungryPizza.Domain.Commands.Customer;

namespace HungryPizza.Domain.Validations.Commands.Customer
{
    public class CreateCustomerCommandValidation : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidation()
        {
            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithErrorCode("1000")
                .Length(3, 100)
                .WithErrorCode("1001");

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

            RuleFor(x => x.Address)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithErrorCode("1007")
                .Length(3, 100)
                .WithErrorCode("1008");
        }
    }
}
