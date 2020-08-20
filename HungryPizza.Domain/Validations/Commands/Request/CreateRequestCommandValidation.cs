using FluentValidation;
using HungryPizza.Domain.Commands.Request;
using System.Linq;

namespace HungryPizza.Domain.Validations.Commands.Request
{
    public class CreateRequestCommandValidation : AbstractValidator<CreateRequestCommand>
    {
        public CreateRequestCommandValidation()
        {
            //RuleFor(x => x.Customer)
            //    .Cascade(CascadeMode.Stop)
            //    .NotNull()
            //    .WithErrorCode("1010")
            //    .SetValidator(new RequestCustomerCommandValidation());
            RuleFor(x => x.IdCustomer)
                .Cascade(CascadeMode.Stop)
                .Must(m => m != null && m > 0)
                .When(w => string.IsNullOrEmpty(w.Address))
                .WithErrorCode("1011");

            RuleFor(x => x.Address)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .When(w => w.IdCustomer == null || w.IdCustomer == 0)
                .WithErrorCode("1012");

            RuleFor(x => x.Pizzas)
                .Cascade(CascadeMode.Stop)
                .Must(m => m.Sum(s => s.Quantity) >= 1 && m.Sum(s => s.Quantity) <= 10)
                .When(w => w != null)
                .WithErrorCode("1016")
                .ForEach(e => e.SetValidator(new RequestPizzaCommandValidation()));
        }
    }
}
