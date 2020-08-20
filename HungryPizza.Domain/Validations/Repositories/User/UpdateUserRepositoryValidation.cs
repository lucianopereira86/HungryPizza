using HungryPizza.Domain.Interfaces.Repositories;
using HungryPizza.Domain.Validations.Entities;

namespace HungryPizza.Domain.Validations.Repositories.User
{
    public class UpdateUserRepositoryValidation : UserValidation
    {
        public UpdateUserRepositoryValidation(IUserRepository repo):base(repo)
        {
            ValidateIdUserExists();
            ValidateEmailNotExistsForDifferentUser();
        }
    }
}
