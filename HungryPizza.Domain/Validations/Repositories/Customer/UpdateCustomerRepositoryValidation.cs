using HungryPizza.Domain.Interfaces.Repositories;
using HungryPizza.Domain.Validations.Commands.Customer;

namespace HungryPizza.Domain.Validations.Repositories.Customer
{
    public class UpdateCustomerRepositoryValidation : CustomerValidation
    {
        public UpdateCustomerRepositoryValidation(ICustomerRepository repo):base(repo)
        {
            ValidateIdCustomerExists();
        }
    }
}
