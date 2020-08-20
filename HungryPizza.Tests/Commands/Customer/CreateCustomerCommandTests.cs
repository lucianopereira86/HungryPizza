using HungryPizza.Domain.Commands.Customer;
using HungryPizza.Domain.Handlers.Commands;
using HungryPizza.Domain.Interfaces.Repositories;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace HungryPizza.Tests.Commands.Customer
{
    public class CreateCustomerCommandTests : BaseTests
    {
        private readonly Mock<ICustomerRepository> _customerRepo;
        private readonly Mock<IUserRepository> _userRepo;

        public CreateCustomerCommandTests()
        {
            _customerRepo = new Mock<ICustomerRepository>();
            _userRepo = new Mock<IUserRepository>();
        }

        #region Command Validations
        [Theory]
        [InlineData(null, 1000)]
        [InlineData("ab", 1001)]
        public void ErrorCreateCustomerName(string name, int errorCode)
        {
            var command = new CreateCustomerCommand(name, null, null, null, _appSettings);
            var commandResult = new CustomerCommandHandler(_mapper, _customerRepo.Object, _userRepo.Object)
                .Handle(command, new CancellationToken()).Result;

            Assert.True(commandResult.HasError(errorCode));
        }

        [Theory]
        [InlineData(null, 1002)]
        [InlineData("ab", 1003)]
        [InlineData("abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvz@a.a", 1004)]
        public void ErrorCreateCustomerEmail(string email, int errorCode)
        {
            var command = new CreateCustomerCommand(null, email, null, null, _appSettings);
            var commandResult = new CustomerCommandHandler(_mapper, _customerRepo.Object, _userRepo.Object)
                .Handle(command, new CancellationToken()).Result;

            Assert.True(commandResult.HasError(errorCode));
        }
        [Theory]
        [InlineData(null, 1005)]
        [InlineData("abc", 1006)]
        [InlineData("abcdefghijklmnopqrstuvwxyz", 1006)]
        public void ErrorCreateCustomerPassword(string password, int errorCode)
        {
            var command = new CreateCustomerCommand(null, null, password, null, _appSettings);
            var commandResult = new CustomerCommandHandler(_mapper, _customerRepo.Object, _userRepo.Object)
                .Handle(command, new CancellationToken()).Result;

            Assert.True(commandResult.HasError(errorCode));
        }
        [Theory]
        [InlineData(null, 1007)]
        [InlineData("ab", 1008)]
        [InlineData("abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvz", 1008)]
        public void ErrorCreateCustomerAddress(string address, int errorCode)
        {
            var command = new CreateCustomerCommand(null, null, null, address, _appSettings);
            var commandResult = new CustomerCommandHandler(_mapper, _customerRepo.Object, _userRepo.Object)
                .Handle(command, new CancellationToken()).Result;

            Assert.True(commandResult.HasError(errorCode));
        }
        #endregion

        #region Repository Validations
        [Fact]
        public void ErrorCreateCustomerEmailExists()
        {
            _userRepo.Setup((s) => s.EmailExists(It.IsAny<string>())).Returns(Task.FromResult(true));

            var command = new CreateCustomerCommand("Luciano Pereira", "a@a.a", "abc123", "New York", _appSettings);
            var commandResult = new CustomerCommandHandler(_mapper, _customerRepo.Object, _userRepo.Object)
                .Handle(command, new CancellationToken()).Result;

            Assert.True(commandResult.HasError(2002));
        }
        #endregion
    }
}
