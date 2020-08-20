using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HungryPizza.Domain.Entities
{
    public class RequestPizza
    {
        public RequestPizza(int id, int idRequest, int idPizzaFirstHalf, int idPizzaSecondHalf, int quantity, decimal total, bool active)
        {
            Id = id;
            IdRequest = idRequest;
            IdPizzaFirstHalf = idPizzaFirstHalf;
            IdPizzaSecondHalf = idPizzaSecondHalf;
            Quantity = quantity;
            Total = total;
            Active = active;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }
        public int IdRequest { get; private set; }
        public int IdPizzaFirstHalf { get; private set; }
        public int IdPizzaSecondHalf { get; private set; }
        public int Quantity { get; private set; }
        public decimal Total { get; private set; }
        public bool Active { get; private set; }

        //public virtual Request Request { get; private set; }
        //public virtual Pizza Pizza { get; private set; }

        public void SetTotal(decimal total)
        {
            Total = total;
        }

        //public void SetRequest(Request request)
        //{
        //    Request = request;
        //}

        //public void SetPizza(Pizza pizza)
        //{
        //    Pizza = pizza;
        //}
    }
}
