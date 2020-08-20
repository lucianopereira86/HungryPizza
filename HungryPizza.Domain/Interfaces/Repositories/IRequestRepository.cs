using HungryPizza.Domain.Entities;
using HungryPizza.Domain.Entities.History;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HungryPizza.Domain.Interfaces.Repositories
{
    public interface IRequestRepository : IBaseRepository<Request>
    {
        #region Validations
        Task<bool> IdRequestExists(int idRequest);
        Task<bool> UidExists(Guid uid);
        #endregion

        #region CRUD
        Task<Request> CreateRequest(Request request);
        Task<IEnumerable<Request>> Get(Expression<Func<Request, bool>> expression);
        Task<IEnumerable<RequestHistory>> GetHistoryByIdCustomer(int idCustomer);
        #endregion
    }
}
