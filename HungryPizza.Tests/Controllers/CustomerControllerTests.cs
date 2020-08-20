using HungryPizza.Domain.Commands.Customer;
using HungryPizza.Domain.Entities;
using HungryPizza.Infra.Shared.CommandQuery;
using HungryPizza.Infra.Shared.Interfaces;
using HungryPizza.WebAPI.Controllers;
using HungryPizza.WebAPI.SwaggerDocs.Examples.Customer;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace HungryPizza.Tests.Controllers
{
    public class CustomerControllerTests : BaseTests
    {
        [Fact]
        public void SuccessCreateCustomer()
        {
            var vm = new CreateCustomerCommandEx().GetExamples();

            #region MOCKS RESULT
            ICommandQuery commandQuery = new CommandQuery(_appSettings);
            var customer = new Customer(1, 1, vm.Name, vm.Address);
            //customer.SetUser(new User(1, vm.Email, vm.Password, true));
            commandQuery.SetData(customer);
            #endregion

            #region MOCKS REQUEST
            var mediator = new Mock<IMediator>();
            mediator.Setup(s =>
                s.Send(It.IsAny<CreateCustomerCommand>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(commandQuery)); 
            #endregion

            var result = new CustomerController(mediator.Object, _mapper).CreateCustomer(vm);
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void SuccessUpdateCustomer()
        {
            var vm = new UpdateCustomerCommandEx().GetExamples();

            #region MOCKS RESULT
            ICommandQuery commandQuery = new CommandQuery(_appSettings);
            #endregion

            #region MOCKS REQUEST
            var mediator = new Mock<IMediator>();
            mediator.Setup(s =>
                s.Send(It.IsAny<UpdateCustomerCommand>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(commandQuery));
            #endregion

            var result = new CustomerController(mediator.Object, _mapper).UpdateCustomer(vm);
            Assert.IsType<OkObjectResult>(result.Result);
        }
    }
}
