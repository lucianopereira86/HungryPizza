using System.Threading.Tasks;
using AutoMapper;
using HungryPizza.Domain.Queries.Pizza;
using HungryPizza.WebAPI.SwaggerDocs.Examples.Pizza;
using HungryPizza.WebAPI.ViewModels.Queries.Pizza;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;

namespace HungryPizza.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PizzaController : BaseController
    {
        public PizzaController(IMediator m, IMapper mp) : base(m, mp)
        {
        }

        /// <summary>
        /// Get list of pizzas by filter
        /// </summary>
        /// <param name="vm" cref="PizzaGetQueryVM"></param>
        /// <returns></returns>
        [HttpGet]
        [SwaggerRequestExample(typeof(PizzaGetQueryVM), typeof(PizzaGetQueryEx))]
        public async Task<IActionResult> GetPizza([FromQuery] PizzaGetQueryVM vm)
        {
            return await Send<PizzaGetQueryVM, PizzaGetQuery>(vm);
        }
    }
}
