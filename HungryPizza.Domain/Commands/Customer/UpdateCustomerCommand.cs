using HungryPizza.Domain.Interfaces.Repositories;
using HungryPizza.Domain.Validations.Commands.Customer;
using HungryPizza.Domain.Validations.Repositories.Customer;
using HungryPizza.Domain.Validations.Repositories.User;
using HungryPizza.Infra.Shared.CommandQuery;
using HungryPizza.Infra.Shared.Models;

namespace HungryPizza.Domain.Commands.Customer
{
    public class UpdateCustomerCommand: CommandQuery
    {
        public UpdateCustomerCommand(
            int idCustomer, string name, string email, string password, string address, bool active, 
            AppSettings appSettings):base(appSettings)
        {
            IdCustomer = idCustomer;
            Name = name;
            Email = email;
            Password = password;
            Address = address;
            Active = active;
        }

        public int IdCustomer { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Address { get; private set; }
        public bool Active { get; private set; }

        public bool IsValid()
        {
            Validate(this, new UpdateCustomerCommandValidation());
            return Valid;
        }

        public bool IsRepositoryValid(Entities.Customer customer, ICustomerRepository customerRepository)
        {
            Validate(customer, new UpdateCustomerRepositoryValidation(customerRepository));
            return Valid;
        }

        public bool IsRepositoryValid(Entities.User user, IUserRepository userRepository)
        {
            Validate(user, new UpdateUserRepositoryValidation(userRepository));
            return Valid;
        }
    }
}
