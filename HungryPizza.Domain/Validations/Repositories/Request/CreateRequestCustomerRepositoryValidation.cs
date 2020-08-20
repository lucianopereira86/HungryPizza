using HungryPizza.Domain.Interfaces.Repositories;
using HungryPizza.Domain.Validations.Commands.Customer;

namespace HungryPizza.Domain.Validations.Repositories.Request
{
    public class CreateRequestCustomerRepositoryValidation : CustomerValidation
    {
        public CreateRequestCustomerRepositoryValidation(ICustomerRepository repo):base(repo)
        {
            ValidateIdCustomerExists();
        }
    }
}
