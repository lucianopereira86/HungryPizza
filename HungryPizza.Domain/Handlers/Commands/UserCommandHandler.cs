using AutoMapper;
using HungryPizza.Domain.Commands.User;
using HungryPizza.Domain.Entities;
using HungryPizza.Domain.Interfaces.Repositories;
using HungryPizza.Infra.Shared.CommandQuery;
using HungryPizza.Infra.Shared.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HungryPizza.Domain.Handlers.Commands
{
    public class UserCommandHandler : CommandQueryHandler,
        IRequestHandler<AuthenticateUserCommand, ICommandQuery>
    {
        private readonly IUserRepository _userRepo;
        public UserCommandHandler(IMapper m, IUserRepository ur) : base(m)
        {
            _userRepo = ur;
        }

        public async Task<ICommandQuery> Handle(AuthenticateUserCommand command, CancellationToken cancellationToken)
        {
            // VALIDATE COMMAND
            if (!command.IsValid())
                return command;

            // AUTHENTICATE
            var user = _mapper.Map<User>(command);
            var customer = await _userRepo.Authenticate(user);
            if (customer == null)
            {
                command.AddError(2004);
            }
            else
            {
                command.SetData(customer);
            }
            return command;
        }
    }
}
