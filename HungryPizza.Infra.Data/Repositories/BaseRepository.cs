using HungryPizza.Domain.Interfaces.Repositories;
using HungryPizza.Infra.Data.Context;

namespace HungryPizza.Infra.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {

        protected SQLContext ctx;

        public BaseRepository(SQLContext ctx)
        {
            this.ctx = ctx;
        }
    }
}
