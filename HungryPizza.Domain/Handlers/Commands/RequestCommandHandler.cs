using AutoMapper;
using HungryPizza.Domain.Commands.Customer;
using HungryPizza.Domain.Commands.Request;
using HungryPizza.Domain.Entities;
using HungryPizza.Domain.Interfaces.Repositories;
using HungryPizza.Infra.Shared.CommandQuery;
using HungryPizza.Infra.Shared.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HungryPizza.Domain.Handlers.Commands
{
    public class RequestCommandHandler : CommandQueryHandler,
        IRequestHandler<CreateRequestCommand, ICommandQuery>
    {
        private readonly IRequestRepository _requestRepo;
        private readonly IPizzaRepository _pizzaRepo;
        private readonly ICustomerRepository _customerRepo;
        public RequestCommandHandler(IMapper m, IRequestRepository rr, IPizzaRepository rp, ICustomerRepository rc) : base(m)
        {
            _requestRepo = rr;
            _pizzaRepo = rp;
            _customerRepo = rc;
        }

        public async Task<ICommandQuery> Handle(CreateRequestCommand command, CancellationToken cancellationToken)
        {
            // VALIDATE COMMAND
            if (!command.IsValid())
                return command;

            // VALIDATE REPOSITORY
            var request = _mapper.Map<Request>(command);
            if (command.Pizzas != null)
            {
                command.Pizzas.ForEach(s =>
                    request.AddRequestPizza(new RequestPizza(0, 0, s.IdPizzaFirstHalf, s.IdPizzaSecondHalf, s.Quantity, 0, true))
                );
            }

            if (!command.IsRepositoryValid(request, _pizzaRepo, _customerRepo))
                return command;

            // CREATE REQUEST
            var newRequest = await _requestRepo.CreateRequest(request);
            command.SetData(newRequest);

            return command;
        }
    }
}
