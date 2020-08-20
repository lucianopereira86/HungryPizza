using HungryPizza.WebAPI.ViewModels.Commands.Request;
using Swashbuckle.AspNetCore.Filters;
using System.Collections.Generic;

namespace HungryPizza.WebAPI.SwaggerDocs.Examples.Request
{
    public class CreateRequestCommandEx : IExamplesProvider<CreateRequestCommandVM>
    {
        public CreateRequestCommandVM GetExamples()
        {
            var pizzas = new List<RequestPizzaCommandVM>
            {
                new RequestPizzaCommandVM { IdPizzaFirstHalf = 1, IdPizzaSecondHalf = 2, Quantity = 1 },
                new RequestPizzaCommandVM { IdPizzaFirstHalf = 3, IdPizzaSecondHalf = 7, Quantity = 1 },
                new RequestPizzaCommandVM { IdPizzaFirstHalf = 5, IdPizzaSecondHalf = 4, Quantity = 3 },
            };
            return new CreateRequestCommandVM
            {
                Address = "MY ADDRESS",
                Pizzas = pizzas
            };
        }
    }
}
