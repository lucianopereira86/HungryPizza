using System.ComponentModel.DataAnnotations;

namespace HungryPizza.WebAPI.ViewModels.Commands.Customer
{
    public class CreateCustomerCommandVM
    {
        /// <summary>
        /// Customer name
        /// </summary>
        [Required]
        public string Name { get; set; }
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
        /// <summary>
        /// Customer address
        /// </summary>
        [Required]
        public string Address { get; set; }
    }
}
