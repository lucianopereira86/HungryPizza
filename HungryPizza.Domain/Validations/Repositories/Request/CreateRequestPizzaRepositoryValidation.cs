using HungryPizza.Domain.Interfaces.Repositories;
using HungryPizza.Domain.Validations.Entities;

namespace HungryPizza.Domain.Validations.Repositories.Request
{
    public class CreateRequestPizzaRepositoryValidation : RequestPizzaValidation
    {
        public CreateRequestPizzaRepositoryValidation(IPizzaRepository repo):base(repo)
        {
            ValidateIdPizzaFirstHalfExists();
            ValidateIdPizzaSecondHalfExists();
        }
    }
}
