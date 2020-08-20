using HungryPizza.Domain.Entities.History;
using HungryPizza.Domain.Interfaces.Repositories;
using HungryPizza.Domain.Queries.Request;
using HungryPizza.Tests;
using HungryRequest.Domain.Handlers.Queries;
using Moq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace HungryRequest.Tests.Queries.Request
{
    public class RequestQueryTests : BaseTests
    {

        private readonly Mock<IRequestRepository> _repo;

        public RequestQueryTests()
        {
            _repo = new Mock<IRequestRepository>();
        }

        #region Query Validations
        [Fact]
        public void ErrorRequestHistoryIdCustomerNotInformed()
        {
            var query = new RequestHistoryQuery(0, _appSettings);
            var commandResult = new RequestQueryHandler(_mapper, _repo.Object)
               .Handle(query, new CancellationToken()).Result;

            Assert.True(commandResult.HasError(1009));
        }
        #endregion

        #region Repository Validations
        [Fact]
        public void ErrorRequestHistoryNotFound()
        {
            IEnumerable<RequestHistory> requestHistories = new List<RequestHistory>();
            _repo.Setup((s) => s.GetHistoryByIdCustomer(It.IsAny<int>()))
                .Returns(Task.FromResult(requestHistories));

            var query = new RequestHistoryQuery(1, _appSettings);
            var commandResult = new RequestQueryHandler(_mapper, _repo.Object)
               .Handle(query, new CancellationToken()).Result;

            Assert.True(commandResult.HasError(2012));
        }
        #endregion
    }
}
