using HungryPizza.Domain.Interfaces.Repositories;
using HungryPizza.Domain.Validations.Commands.Request;
using HungryPizza.Domain.Validations.Repositories.Request;
using HungryPizza.Infra.Shared.CommandQuery;
using HungryPizza.Infra.Shared.Models;
using System.Collections.Generic;

namespace HungryPizza.Domain.Commands.Request
{
    public class CreateRequestCommand : CommandQuery
    {
        public CreateRequestCommand(
            int? idCustomer, string address, List<RequestPizzaCommand> pizzas,
            AppSettings appSettings) : base(appSettings)
        {
            IdCustomer = idCustomer;
            Address = address;
            Pizzas = pizzas ?? new List<RequestPizzaCommand>();
        }

        public int? IdCustomer { get; private set; }
        public string Address { get; private set; }
        public List<RequestPizzaCommand> Pizzas { get; private set; }
        public bool IsValid()
        {
            Validate(this, new CreateRequestCommandValidation());
            return Valid;
        }

        public bool IsRepositoryValid(Entities.Request request, IPizzaRepository pizzaRepository, ICustomerRepository customerRepository)
        {
            foreach (var rp in request.RequestPizzas)
            {
                Validate(rp, new CreateRequestPizzaRepositoryValidation(pizzaRepository));
                if (!Valid)
                    return false;
            }
            if (request.IdCustomer != null)
            {
                var customer = new Entities.Customer((int)request.IdCustomer, 0, null, null);
                Validate(customer, new CreateRequestCustomerRepositoryValidation(customerRepository));
            }
            return Valid;
        }
    }
}
