using HungryPizza.Domain.Entities;
using System.Threading.Tasks;

namespace HungryPizza.Domain.Interfaces.Repositories
{
    public interface ICustomerRepository: IBaseRepository<Customer>
    {
        #region Validations
        Task<bool> IdCustomerExists(int idCustomer);
        #endregion

        #region CRUD
        Task<Customer> CreateCustomer(Customer customer);
        Task<Customer> GetCustomer(int idCustomer);
        Task UpdateCustomer(Customer customer);
        #endregion
    }
}
