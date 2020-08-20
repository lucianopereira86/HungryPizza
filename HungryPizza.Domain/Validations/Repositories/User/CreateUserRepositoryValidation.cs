using HungryPizza.Domain.Interfaces.Repositories;
using HungryPizza.Domain.Validations.Entities;

namespace HungryPizza.Domain.Validations.Repositories.User
{
    public class CreateUserRepositoryValidation: UserValidation
    {
        public CreateUserRepositoryValidation(IUserRepository repo):base(repo)
        {
            ValidateEmailNotExists();
        }
    }
}
