using System.Threading.Tasks;
using AutoMapper;
using HungryPizza.Domain.Commands.User;
using HungryPizza.WebAPI.SwaggerDocs.Examples.User;
using HungryPizza.WebAPI.ViewModels.Commands.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;

namespace HungryPizza.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : BaseController
    {
        public UserController(IMediator mediatR, IMapper mapper) : base(mediatR, mapper)
        {
        }

        /// <summary>
        /// Authenticate user
        /// </summary>
        /// <param name="vm" cref="AuthenticateUserCommandVM"></param>
        /// <returns></returns>
        [HttpPost]
        [SwaggerRequestExample(typeof(AuthenticateUserCommandVM), typeof(AuthenticateUserCommandEx))]
        public async Task<IActionResult> AuthenticateUser([FromBody] AuthenticateUserCommandVM vm)
        {
            return await Send<AuthenticateUserCommandVM, AuthenticateUserCommand>(vm);
        }
    }
}
