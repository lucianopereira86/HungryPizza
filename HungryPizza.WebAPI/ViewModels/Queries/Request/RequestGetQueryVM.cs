using System;

namespace HungryPizza.WebAPI.ViewModels.Queries.Request
{
    public class RequestGetQueryVM
    {
        /// <summary>
        /// Date and time of creation
        /// </summary>
        public DateTime CreatedAt { get; set; }
        /// <summary>
        /// Unique identifier
        /// </summary>
        public Guid Uid { get; set; }
        /// <summary>
        /// Quantity of pizzas
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// Total to pay
        /// </summary>
        public decimal Total { get; set; }
        /// <summary>
        /// Customer Id
        /// </summary>
        public int? IdCustomer { get; set; }
        /// <summary>
        /// Customer address
        /// </summary>
        public string Address { get; set; }
    }
}
