using System.Collections.Generic;

namespace HungryPizza.WebAPI.ViewModels.Commands.Request
{
    public class CreateRequestCommandVM
    {
        /// <summary>
        /// Customer Id
        /// </summary>
        public int? IdCustomer { get; set; }
        /// <summary>
        /// Customer Address
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// List of pizzas
        /// </summary>
        public List<RequestPizzaCommandVM> Pizzas { get; set; }
    }
}
