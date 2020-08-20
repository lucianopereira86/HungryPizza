using System.ComponentModel.DataAnnotations;

namespace HungryPizza.WebAPI.ViewModels.Commands.Customer
{
    public class UpdateCustomerCommandVM
    {
        /// <summary>
        /// Customer Id
        /// </summary>
        public int IdCustomer { get; set; }
        /// <summary>
        /// Customer name
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Customer email
        /// </summary>
        [Required]
        public string Email { get; set; }
        /// <summary>
        /// Customer password
        /// </summary>
        [Required]
        public string Password { get; set; }
        /// <summary>
        /// Customer address
        /// </summary>
        [Required]
        public string Address { get; set; }
        /// <summary>
        /// Is customer active?
        /// </summary>
        [Required]
        public bool Active { get; set; }
    }
}
