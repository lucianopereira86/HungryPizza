using FluentValidation;
using HungryPizza.Domain.Queries.Request;

namespace HungryPizza.Domain.Validations.Queries.History
{
    public class RequestHistoryQueryValidation : AbstractValidator<RequestHistoryQuery>
    {
        public RequestHistoryQueryValidation()
        {
            RuleFor(x => x.IdCustomer)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0)
                .WithErrorCode("1009");
        }
    }
}
