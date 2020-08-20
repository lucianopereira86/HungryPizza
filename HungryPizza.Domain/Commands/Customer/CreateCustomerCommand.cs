using HungryPizza.Domain.Interfaces.Repositories;
using HungryPizza.Domain.Validations.Commands.Customer;
using HungryPizza.Domain.Validations.Repositories.User;
using HungryPizza.Infra.Shared.CommandQuery;
using HungryPizza.Infra.Shared.Models;

namespace HungryPizza.Domain.Commands.Customer
{
    public class CreateCustomerCommand : CommandQuery
    {
        public CreateCustomerCommand(string name, string email, string password, string address, 
            AppSettings appSettings) : base(appSettings)
        {
            Name = name;
            Email = email;
            Password = password;
            Address = address;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Address { get; private set; }

        public bool IsValid()
        {
            Validate(this, new CreateCustomerCommandValidation());
            return Valid;
        }

        public bool IsRepositoryValid(Entities.User user, IUserRepository userRepository)
        {
            Validate(user, new CreateUserRepositoryValidation(userRepository));
            return Valid;
        }
    }
}
