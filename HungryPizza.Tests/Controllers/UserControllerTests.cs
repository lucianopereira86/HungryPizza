using HungryPizza.Domain.Commands.User;
using HungryPizza.Domain.Entities;
using HungryPizza.Infra.Shared.CommandQuery;
using HungryPizza.Infra.Shared.Interfaces;
using HungryPizza.WebAPI.Controllers;
using HungryPizza.WebAPI.SwaggerDocs.Examples.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace HungryPizza.Tests.Controllers
{
    public class UserControllerTests : BaseTests
    {
        [Fact]
        public void SuccessAuthenticateUser()
        {
            var vm = new AuthenticateUserCommandEx().GetExamples();

            #region MOCKS RESULT
            ICommandQuery commandQuery = new CommandQuery(_appSettings);
            var customer = new Customer(1, 1, "MY NAME", "MY ADDRESS");
            //customer.SetUser(new User(1, vm.Email, vm.Password, true));
            commandQuery.SetData(customer);
            #endregion

            #region MOCKS REQUEST
            var mediator = new Mock<IMediator>();
            mediator.Setup(s =>
                s.Send(It.IsAny<AuthenticateUserCommand>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(commandQuery)); 
            #endregion

            var result = new UserController(mediator.Object, _mapper).AuthenticateUser(vm);
            Assert.IsType<OkObjectResult>(result.Result);
        }
    }
}
