using HungryPizza.Domain.Entities;
using System.Threading.Tasks;

namespace HungryPizza.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        #region Validations
        Task<bool> IdUserExists(int idUser);
        Task<bool> EmailExists(string email);
        Task<bool> EmailExistsDifferentUser(int idUser, string email);
        #endregion

        #region CRUD
        Task<User> CreateUser(User user);
        Task UpdateUser(User user);
        Task<Customer> Authenticate(User user);
        #endregion
    }
}
