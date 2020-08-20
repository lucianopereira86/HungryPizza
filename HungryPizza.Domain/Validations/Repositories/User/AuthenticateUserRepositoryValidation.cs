using HungryPizza.Domain.Interfaces.Repositories;
using HungryPizza.Domain.Validations.Entities;

namespace HungryPizza.Domain.Validations.Repositories.User
{
    public class AuthenticateUserRepositoryValidation : UserValidation
    {
        public AuthenticateUserRepositoryValidation(IUserRepository repo):base(repo)
        {
            ValidateEmailNotExists();
        }
    }
}
