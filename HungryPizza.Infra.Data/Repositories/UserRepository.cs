using HungryPizza.Domain.Entities;
using HungryPizza.Domain.Interfaces.Repositories;
using HungryPizza.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace HungryPizza.Infra.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(SQLContext ctx) : base(ctx)
        {
        }

        #region Validations
        public async Task<bool> EmailExists(string email)
        {
            return await ctx.User.AsNoTracking().AnyAsync(a => a.Email.ToUpper().Equals(email.ToUpper()));
        }

        public async Task<bool> EmailExistsDifferentUser(int idUser, string email)
        {
            return await ctx.User.AnyAsync(a => a.Id != idUser && a.Email.ToUpper().Equals(email.ToUpper()));
        }

        public async Task<bool> IdUserExists(int idUser)
        {
            return await ctx.User.AnyAsync(a => a.Id == idUser && a.Active);
        }
        #endregion

        #region CRUD
        public async Task<User> CreateUser(User user)
        {
            await ctx.User.AddAsync(user);
            await ctx.SaveChangesAsync();
            return user; 
        }

        public async Task UpdateUser(User user)
        {
            ctx.User.Update(user);
            await ctx.SaveChangesAsync();
        }

        public async Task<Customer> Authenticate(User user)
        {
            var oldUser = await ctx.Customer
                                .Join(ctx.User,
                                    a => a.IdUser,
                                    b => b.Id,
                                    (a, b) => new { a, b }
                                )
                                .AsNoTracking()
                                .Where(f =>
                                    f.b.Email.ToUpper().Equals(user.Email.ToUpper().Trim())
                                    && f.b.Password.Equals(user.Password)
                                    && f.b.Active)
                                .Select(s => s.a)
                                .FirstOrDefaultAsync();
            return oldUser;
        }
        #endregion
    }
}
