using FluentValidation;
using HungryPizza.Domain.Interfaces.Repositories;

namespace HungryPizza.Domain.Validations.Commands.Customer
{
    public class CustomerValidation : AbstractValidator<Domain.Entities.Customer>
    {
        private readonly ICustomerRepository _repo;
        public CustomerValidation(ICustomerRepository repo)
        {
            _repo = repo;
        }

        public void ValidateIdCustomerExists()
        {
            RuleFor(x => x.Id)
                .Cascade(CascadeMode.Stop)
                .MustAsync(async (a, c) => await _repo.IdCustomerExists((int)a))
                .When(w => w.Id > 0)
                .WithErrorCode("2005");
        }
    }
}
