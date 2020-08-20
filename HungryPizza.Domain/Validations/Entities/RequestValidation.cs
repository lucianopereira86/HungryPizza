using FluentValidation;
using HungryPizza.Domain.Entities;
using HungryPizza.Domain.Interfaces.Repositories;

namespace HungryPizza.Domain.Validations.Entities
{
    public class RequestValidation : AbstractValidator<Request>
    {
        private readonly IRequestRepository _repo;
        public RequestValidation(IRequestRepository repo)
        {
            _repo = repo;
        }
        public void ValidateIdRequestExists()
        {
            RuleFor(x => x.Id)
                .Cascade(CascadeMode.Stop)
                .MustAsync(async (m, c) => await _repo.IdRequestExists((int)m))
                .WithErrorCode("2008");
        }

        public void ValidateUidExists()
        {
            RuleFor(x => x.Uid)
                .Cascade(CascadeMode.Stop)
                .MustAsync(async (m, c) => await _repo.UidExists(m))
                .WithErrorCode("2009");
        }
    }
}
