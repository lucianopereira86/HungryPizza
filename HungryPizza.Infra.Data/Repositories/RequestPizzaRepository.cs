using HungryPizza.Domain.Entities;
using HungryPizza.Domain.Interfaces.Repositories;
using HungryPizza.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HungryPizza.Infra.Data.Repositories
{
    public class RequestPizzaRepository : BaseRepository<RequestPizza>, IRequestPizzaRepository
    {
        public RequestPizzaRepository(SQLContext ctx) : base(ctx)
        {
        }

        #region Validations
        public async Task<bool> IdPizzaExists(int idPizza)
        {
            return await ctx.Pizza.AnyAsync(a => a.Id == idPizza && a.Active);
        }
        #endregion
    }
}
