using HungryPizza.Infra.Shared.CommandQuery;
using HungryPizza.Infra.Shared.Models;
using System;
using System.Linq.Expressions;

namespace HungryPizza.Domain.Queries.Pizza
{
    public class PizzaGetQuery : CommandQuery
    {
        public PizzaGetQuery(int? idPizza, string name, decimal price, AppSettings appSettings):base(appSettings)
        {
            IdPizza = idPizza;
            Name = name;
            Price = price;
        }

        public int? IdPizza { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public Expression<Func<Entities.Pizza, bool>> Get()
        {
            return p => (IdPizza == null || IdPizza == 0 || p.Id == IdPizza) 
                        &&
                        (string.IsNullOrEmpty(Name) || p.Name.ToLower().Contains(Name.ToLower().Trim()))
                        &&
                        (Price == 0 || p.Price == Price)
                        &&
                        p.Active;
        }
    }
}
