using AutoMapper;
using HungryPizza.Domain.Interfaces.Repositories;
using HungryPizza.Domain.Queries.Pizza;
using HungryPizza.Infra.Shared.CommandQuery;
using HungryPizza.Infra.Shared.Interfaces;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HungryPizza.Domain.Handlers.Queries
{
    public class PizzaQueryHandler: CommandQueryHandler,
        IRequestHandler<PizzaGetQuery, ICommandQuery>
    {
        private readonly IPizzaRepository _repo;

        public PizzaQueryHandler(IMapper m, IPizzaRepository repo):base(m)
        {
            _repo = repo;
        }

        public async Task<ICommandQuery> Handle(PizzaGetQuery query, CancellationToken cancellationToken)
        {
            var pizzas = await _repo.Get(query.Get());
            if (pizzas.ToList().Count == 0)
            {
                query.AddError(2010);
            }
            else
            {
                query.SetData(pizzas);
            }
            return query;
        }
    }
}
