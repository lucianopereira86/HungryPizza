using HungryPizza.Domain.Commands.Request;
using HungryPizza.Domain.Handlers.Commands;
using HungryPizza.Domain.Interfaces.Repositories;
using Moq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace HungryPizza.Tests.Commands.User
{
    public class CreateRequestCommandTests : BaseTests
    {
        private readonly Mock<IRequestRepository> _requestRepo;
        private readonly Mock<IPizzaRepository> _pizzaRepo;
        private readonly Mock<ICustomerRepository> _customerRepo;

        public CreateRequestCommandTests()
        {
            _requestRepo = new Mock<IRequestRepository>();
            _pizzaRepo = new Mock<IPizzaRepository>();
            _customerRepo = new Mock<ICustomerRepository>();
        }

        #region Command Validations
        [Fact]
        public void ErrorCreateRequestIdUserNotInformed()
        {
            var command = new CreateRequestCommand(null, null, null, _appSettings);
            var commandResult = new RequestCommandHandler(_mapper, _requestRepo.Object, _pizzaRepo.Object, _customerRepo.Object)
                .Handle(command, new CancellationToken()).Result;

            Assert.True(commandResult.HasError(1011));
        }
        [Fact]
        public void ErrorCreateRequestAddressNotInformed()
        {
            var command = new CreateRequestCommand(null, null, null, _appSettings);
            var commandResult = new RequestCommandHandler(_mapper, _requestRepo.Object, _pizzaRepo.Object, _customerRepo.Object)
                .Handle(command, new CancellationToken()).Result;

            Assert.True(commandResult.HasError(1012));
        }
        [Theory]
        [InlineData(1013)]
        [InlineData(1014)]
        public void ErrorCreateRequestPizzasIdPizzaNotInformed(int errorCode)
        {
            var pizzas = new List<RequestPizzaCommand>();
            pizzas.Add(new RequestPizzaCommand(0, 0, 1));
            var command = new CreateRequestCommand(null, null, pizzas, _appSettings);
            var commandResult = new RequestCommandHandler(_mapper, _requestRepo.Object, _pizzaRepo.Object, _customerRepo.Object)
                .Handle(command, new CancellationToken()).Result;

            Assert.True(commandResult.HasError(errorCode));
        }
        [Fact]
        public void ErrorCreateRequestPizzasQuantityNotInformed()
        {
            var pizzas = new List<RequestPizzaCommand>();
            pizzas.Add(new RequestPizzaCommand(0, 0, 1));
            pizzas.Add(new RequestPizzaCommand(0, 0, 0));
            var command = new CreateRequestCommand(null, null, pizzas, _appSettings);
            var commandResult = new RequestCommandHandler(_mapper, _requestRepo.Object, _pizzaRepo.Object, _customerRepo.Object)
                .Handle(command, new CancellationToken()).Result;

            Assert.True(commandResult.HasError(1015));
        }
        [Theory]
        [InlineData(0, 1016)]
        [InlineData(11, 1016)]
        public void ErrorCreateRequestPizzasNotInRange(int quantity, int errorCode)
        {
            var pizzas = new List<RequestPizzaCommand>();
            for (int p = 1; p <= quantity; p++)
                pizzas.Add(new RequestPizzaCommand(0, 0, 0));
            var command = new CreateRequestCommand(null, null, pizzas, _appSettings);
            var commandResult = new RequestCommandHandler(_mapper, _requestRepo.Object, _pizzaRepo.Object, _customerRepo.Object)
                .Handle(command, new CancellationToken()).Result;

            Assert.True(commandResult.HasError(errorCode));
        }
        #endregion

        #region Repository Validations
        [Theory]
        [InlineData(2006)]
        [InlineData(2007)]
        public void ErrorCreateRequestPizzasIdPizzaNotExists(int errorCode)
        {
            _pizzaRepo.Setup((s) => s.IdPizzaExists(It.IsAny<int>())).Returns(Task.FromResult(false));

            var customer = new RequestCustomerCommand(1, "New York");
            var pizzas = new List<RequestPizzaCommand>();
            pizzas.Add(new RequestPizzaCommand(1, 1, 1));

            var command = new CreateRequestCommand(1, "New York", pizzas, _appSettings);
            var commandResult = new RequestCommandHandler(_mapper, _requestRepo.Object, _pizzaRepo.Object, _customerRepo.Object)
                .Handle(command, new CancellationToken()).Result;

            Assert.True(commandResult.HasError(errorCode));
        }
        [Fact]
        public void ErrorCreateRequestCustomerNotExists()
        {
            _customerRepo.Setup((s) => s.IdCustomerExists(It.IsAny<int>())).Returns(Task.FromResult(false));

            var customer = new RequestCustomerCommand(1, "New York");
            var pizzas = new List<RequestPizzaCommand>();
            pizzas.Add(new RequestPizzaCommand(1, 1, 1));

            var command = new CreateRequestCommand(1, "New York", pizzas, _appSettings);
            var commandResult = new RequestCommandHandler(_mapper, _requestRepo.Object, _pizzaRepo.Object, _customerRepo.Object)
                .Handle(command, new CancellationToken()).Result;

            Assert.True(commandResult.HasError(2007));
        }
        #endregion
    }
}
