using FluentValidation;
using HungryPizza.Domain.Entities;
using HungryPizza.Domain.Interfaces.Repositories;

namespace HungryPizza.Domain.Validations.Entities
{
    public class RequestPizzaValidation : AbstractValidator<RequestPizza>
    {
        private readonly IPizzaRepository _repo;
        public RequestPizzaValidation(IPizzaRepository repo)
        {
            _repo = repo;
        }
        public void ValidateIdPizzaFirstHalfExists()
        {
            RuleFor(x => x.IdPizzaFirstHalf)
                .Cascade(CascadeMode.Stop)
                .MustAsync(async (m, c) => await _repo.IdPizzaExists(m))
                .WithErrorCode("2006");
        }

        public void ValidateIdPizzaSecondHalfExists()
        {
            RuleFor(x => x.IdPizzaSecondHalf)
                .Cascade(CascadeMode.Stop)
                .MustAsync(async (m, c) => await _repo.IdPizzaExists(m))
                .WithErrorCode("2007");
        }
    }
}
