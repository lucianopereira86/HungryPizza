using System.ComponentModel.DataAnnotations;

namespace HungryPizza.WebAPI.ViewModels.Commands.User
{
    public class AuthenticateUserCommandVM
    {
        /// <summary>
        /// User email
        /// </summary>
        [Required]
        public string Email { get; set; }
        /// <summary>
        /// User password
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}
