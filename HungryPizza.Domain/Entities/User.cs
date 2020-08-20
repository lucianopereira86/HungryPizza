using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HungryPizza.Domain.Entities
{
    public class User
    {
        public User()
        {

        }
        public User(int id, string email, string password, bool active)
        {
            Id = id;
            Email = email;
            Password = password;
            Active = active;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public bool Active { get; private set; }

        public void SetId(int id)
        {
            Id = id;
        }
    }
}
