using HungryPizza.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HungryPizza.Domain.Interfaces.Repositories
{
    public interface IPizzaRepository : IBaseRepository<Pizza>
    {
        #region Validations
        Task<bool> IdPizzaExists(int idPizza);
        #endregion

        #region CRUD
        Task<IEnumerable<Pizza>> Get(Expression<Func<Pizza, bool>> expression);
        Task<Pizza> GetPizza(int idPizza); 
        #endregion
    }
}
