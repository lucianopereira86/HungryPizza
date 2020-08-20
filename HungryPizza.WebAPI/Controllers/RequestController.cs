using System.Threading.Tasks;
using AutoMapper;
using HungryPizza.Domain.Commands.Request;
using HungryPizza.Domain.Queries.Request;
using HungryPizza.WebAPI.SwaggerDocs.Examples.Request;
using HungryPizza.WebAPI.ViewModels.Commands.Request;
using HungryPizza.WebAPI.ViewModels.Queries.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;

namespace HungryPizza.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RequestController : BaseController
    {
        public RequestController(IMediator m, IMapper mp) : base(m, mp)
        {
        }

        /// <summary>
        /// Create request
        /// </summary>
        /// <param name="vm" cref="CreateRequestCommandVM"></param>
        /// <returns></returns>
        [HttpPost]
        [SwaggerRequestExample(typeof(CreateRequestCommandVM), typeof(CreateRequestCommandEx))]
        public async Task<IActionResult> CreateRequest([FromBody] CreateRequestCommandVM vm)
        {
            return await Send<CreateRequestCommandVM, CreateRequestCommand>(vm);
        }

        /// <summary>
        /// Get list of requests by filter
        /// </summary>
        /// <param name="vm" cref="CreateRequestCommandVM"></param>
        /// <returns></returns>
        [HttpGet]
        [SwaggerRequestExample(typeof(RequestGetQueryVM), typeof(RequestGetQueryEx))]
        public async Task<IActionResult> GetRequest([FromQuery] RequestGetQueryVM vm)
        {
            return await Send<RequestGetQueryVM, RequestGetQuery>(vm);
        }

        /// <summary>
        /// Get list of request history by customer Id
        /// </summary>
        /// <param name="idCustomer" cref="int"></param>
        /// <returns></returns>
        [HttpGet("{idCustomer}")]
        [SwaggerRequestExample(typeof(RequestGetQueryVM), typeof(RequestGetQueryEx))]
        public async Task<IActionResult> GetHistory([FromRoute] int idCustomer)
        {
            var vm = new RequestHistoryQueryVM { IdCustomer = idCustomer };
            return await Send<RequestHistoryQueryVM, RequestHistoryQuery>(vm);
        }
    }
}
