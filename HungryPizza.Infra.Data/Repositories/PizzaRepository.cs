using HungryPizza.Domain.Entities;
using HungryPizza.Domain.Interfaces.Repositories;
using HungryPizza.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HungryPizza.Infra.Data.Repositories
{
    public class PizzaRepository : BaseRepository<Pizza>, IPizzaRepository
    {
        public PizzaRepository(SQLContext ctx) : base(ctx)
        {
        }

        #region Validations
        public async Task<bool> IdPizzaExists(int idPizza)
        {
            return await ctx.Pizza.AnyAsync(a => a.Id == idPizza && a.Active);
        }
        #endregion

        #region CRUD

        public async Task<IEnumerable<Pizza>> Get(Expression<Func<Pizza, bool>> expression)
        {
            return await ctx.Pizza.AsNoTracking().Where(expression).OrderBy(o => o.Id).ToListAsync();
        }

        public async Task<Pizza> GetPizza(int idPizza)
        {
            return await ctx.Pizza.AsNoTracking().FirstOrDefaultAsync(f => f.Id == idPizza && f.Active);
        }
        #endregion
    }
}
