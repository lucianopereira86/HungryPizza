using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HungryPizza.Domain.Entities
{
    public class Pizza
    {
        public Pizza(int id, string name, decimal price, bool active)
        {
            Id = id;
            Name = name;
            Price = price;
            Active = active;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public bool Active { get; private set; }
    }
}
