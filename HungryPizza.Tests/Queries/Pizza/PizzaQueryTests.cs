using HungryPizza.Domain.Handlers.Queries;
using HungryPizza.Domain.Interfaces.Repositories;
using HungryPizza.Domain.Queries.Pizza;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace HungryPizza.Tests.Queries.Pizza
{
    public class PizzaQueryTests: BaseTests
    {

        private readonly Mock<IPizzaRepository> _repo;

        public PizzaQueryTests()
        {
            _repo = new Mock<IPizzaRepository>();
        }

        #region Repository Validations
        [Fact]
        public void ErrorPizzasNotFound()
        {
            IEnumerable<Domain.Entities.Pizza> pizzas = new List<Domain.Entities.Pizza>();
            _repo.Setup((s) => s.Get(It.IsAny<Expression<Func<Domain.Entities.Pizza, bool>>>()))
                .Returns(Task.FromResult(pizzas));

            var query = new PizzaGetQuery(0, null, 0, _appSettings);
            var commandResult = new PizzaQueryHandler(_mapper, _repo.Object)
               .Handle(query, new CancellationToken()).Result;

            Assert.True(commandResult.HasError(2010));
        } 
        #endregion
    }
}
