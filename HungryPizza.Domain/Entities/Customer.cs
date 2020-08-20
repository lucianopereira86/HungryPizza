using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HungryPizza.Domain.Entities
{
    public class Customer
    {
        public Customer()
        {

        }
        public Customer(int id, int idUser, string name, string address)
        {
            Id = id;
            IdUser = idUser;
            Name = name;
            Address = address;
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }
        public int IdUser { get; private set; }
        public string Name { get; private set; }
        public string Address { get; private set; }

        //public virtual User User { get; set; }

        //public void SetUser(User user)
        //{
        //    User = user;
        //}

        public void SetIdUser(int idUser)
        {
            IdUser = idUser;
        }
    }
}
