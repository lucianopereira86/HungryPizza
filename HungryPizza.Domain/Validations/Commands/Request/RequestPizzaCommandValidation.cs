using FluentValidation;
using HungryPizza.Domain.Commands.Request;

namespace HungryPizza.Domain.Validations.Commands.Request
{
    public class RequestPizzaCommandValidation : AbstractValidator<RequestPizzaCommand>
    {
        public RequestPizzaCommandValidation()
        {
            RuleFor(x => x.IdPizzaFirstHalf)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0)
                .WithErrorCode("1013");

            RuleFor(x => x.IdPizzaSecondHalf)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0)
                .WithErrorCode("1014");

            RuleFor(x => x.Quantity)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0)
                .WithErrorCode("1015");
        }
    }
}
