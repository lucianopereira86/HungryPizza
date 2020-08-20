using System.ComponentModel.DataAnnotations;

namespace HungryPizza.WebAPI.ViewModels.Commands.Request
{
    public class RequestPizzaCommandVM
    {
        /// <summary>
        /// First half pizza Id
        /// </summary>
        [Required]
        public int IdPizzaFirstHalf { get; set; }
        /// <summary>
        /// Second half pizza Id
        /// </summary>
        [Required]
        public int IdPizzaSecondHalf { get; set; }
        /// <summary>
        /// Full pizza quantity
        /// </summary>
        [Required]
        public int Quantity { get; set; }
    }
}
