using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace HungryPizza.Domain.Entities
{
    public class Request
    {
        private readonly IList<RequestPizza> _requestPizzas;
        public Request()
        {
            _requestPizzas = new List<RequestPizza>();
        }
        public Request(int id, DateTime createdAt, Guid uid, int quantity, decimal total, int? idCustomer, string address, bool active)
        {
            Id = id;
            CreatedAt = createdAt;
            Uid = uid;
            Quantity = quantity;
            Total = total;
            IdCustomer = idCustomer;
            Address = address;
            Active = active;

            _requestPizzas = new List<RequestPizza>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public Guid Uid { get; private set; }
        public int Quantity { get; private set; }
        public decimal Total { get; private set; }
        public int? IdCustomer { get; private set; }
        public string Address { get; private set; }
        public bool Active { get; private set; }

        public IList<RequestPizza> RequestPizzas { get { return _requestPizzas.ToArray(); } }
        
        public void AddRequestPizza(RequestPizza requestPizza)
        {
            _requestPizzas.Add(requestPizza);
        }

        public void AddRequestPizzaRange(List<RequestPizza> requestPizzas)
        {
            _requestPizzas.Clear();
            requestPizzas.ForEach(e => _requestPizzas.Add(e));
        }
    }
}
