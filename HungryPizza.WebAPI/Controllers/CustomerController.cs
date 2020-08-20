using System.Threading.Tasks;
using AutoMapper;
using HungryPizza.Domain.Commands.Customer;
using HungryPizza.WebAPI.SwaggerDocs.Examples.Customer;
using HungryPizza.WebAPI.ViewModels.Commands.Customer;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;

namespace HungryPizza.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : BaseController
    {
        public CustomerController(IMediator mediatR, IMapper mapper): base(mediatR, mapper)
        {
        }

        /// <summary>
        /// Create customer
        /// </summary>
        [HttpPost]
        [SwaggerRequestExample(typeof(CreateCustomerCommandVM), typeof(CreateCustomerCommandEx))]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerCommandVM vm)
        {
            return await Send<CreateCustomerCommandVM, CreateCustomerCommand>(vm);
        }

        /// <summary>
        /// Update customer
        /// </summary>
        [HttpPut]
        [SwaggerRequestExample(typeof(UpdateCustomerCommandVM), typeof(UpdateCustomerCommandEx))]
        public async Task<IActionResult> UpdateCustomer([FromBody] UpdateCustomerCommandVM vm)
        {
            return await Send<UpdateCustomerCommandVM, UpdateCustomerCommand>(vm);
        }
    }
}
