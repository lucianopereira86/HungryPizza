using AutoMapper;
using HungryPizza.Domain.Commands.Customer;
using HungryPizza.Domain.Entities;
using HungryPizza.Domain.Interfaces.Repositories;
using HungryPizza.Infra.Shared.CommandQuery;
using HungryPizza.Infra.Shared.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HungryPizza.Domain.Handlers.Commands
{
    public class CustomerCommandHandler : CommandQueryHandler,
        IRequestHandler<CreateCustomerCommand, ICommandQuery>,
        IRequestHandler<UpdateCustomerCommand, ICommandQuery>
    {
        private readonly ICustomerRepository _customerRepo;
        private readonly IUserRepository _userRepo;
        public CustomerCommandHandler(IMapper m, ICustomerRepository cr, IUserRepository ur) : base(m)
        {
            _customerRepo = cr;
            _userRepo = ur;
        }

        public async Task<ICommandQuery> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
        {
            // VALIDATE COMMAND
            if (!command.IsValid())
                return command;

            // VALIDATE REPOSITORY
            var customer = _mapper.Map<Customer>(command);
            var user = new User(0, command.Email, command.Password, true);
            if (!command.IsRepositoryValid(user, _userRepo))
                return command;

            // CREATE CUSTOMER
            var newUser = await _userRepo.CreateUser(user);

            // CREATE CUSTOMER
            customer.SetIdUser(newUser.Id); 
            var newCustomer = await _customerRepo.CreateCustomer(customer);
            command.SetData(newCustomer);

            return command;
        }

        public async Task<ICommandQuery> Handle(UpdateCustomerCommand command, CancellationToken cancellationToken)
        {
            // VALIDATE COMMAND
            if (!command.IsValid())
                return command;

            // VALIDATE CUSTOMER ON REPOSITORY
            var customer = _mapper.Map<Customer>(command);
            if (!command.IsRepositoryValid(customer, _customerRepo))
                return command;

            // GET CUSTOMER
            var oldCustomer = await _customerRepo.GetCustomer(command.IdCustomer);
            customer.SetIdUser(oldCustomer.IdUser);

            // GET USER ID FROM CUSTOMER
            var user = _mapper.Map<User>(command);
            user.SetId(customer.IdUser);

            // VALIDATE USER ON REPOSITORY
            if (!command.IsRepositoryValid(user, _userRepo))
                return command;

            // UPDATE USER
            await _userRepo.UpdateUser(user);

            // UPDATE CUSTOMER
            await _customerRepo.UpdateCustomer(customer);

            return command;
        }
    }
}
