using HungryPizza.WebAPI.ViewModels.Queries.Pizza;
using Swashbuckle.AspNetCore.Filters;

namespace HungryPizza.WebAPI.SwaggerDocs.Examples.Pizza
{
    public class PizzaGetQueryEx: IExamplesProvider<PizzaGetQueryVM>
    {
        public PizzaGetQueryVM GetExamples()
        {
            return new PizzaGetQueryVM();
        }
    }
}
