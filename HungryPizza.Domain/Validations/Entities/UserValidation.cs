using FluentValidation;
using HungryPizza.Domain.Entities;
using HungryPizza.Domain.Interfaces.Repositories;

namespace HungryPizza.Domain.Validations.Entities
{
    public class UserValidation: AbstractValidator<User>
    {
        private readonly IUserRepository _repo;
        public UserValidation(IUserRepository repo)
        {
            _repo = repo;
        }
        public void ValidateIdUserExists()
        {
            RuleFor(u => (int) u.Id)
                .Cascade(CascadeMode.Stop)
                .MustAsync(async(m, c) => await _repo.IdUserExists(m))
                .WithErrorCode("2000");
        }
        public void ValidateEmailExists()
        {
            RuleFor(u => u.Email)
                .Cascade(CascadeMode.Stop)
                .MustAsync(async (m, c) => await _repo.EmailExists(m))
                .WithErrorCode("2001");
        }
        public void ValidateEmailNotExists()
        {
            RuleFor(u => u.Email)
                .Cascade(CascadeMode.Stop)
                .MustAsync(async (m, c) => !await _repo.EmailExists(m))
                .WithErrorCode("2002");
        }
        public void ValidateEmailNotExistsForDifferentUser()
        {
            RuleFor(u => u.Email)
                .Cascade(CascadeMode.Stop)
                .MustAsync(async (a, b, c) => !await _repo.EmailExistsDifferentUser((int)a.Id, b))
                .WithErrorCode("2003");
        }
    }
}
