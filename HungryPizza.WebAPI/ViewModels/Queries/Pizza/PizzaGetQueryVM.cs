namespace HungryPizza.WebAPI.ViewModels.Queries.Pizza
{
    public class PizzaGetQueryVM
    {
        /// <summary>
        /// Pizza Id
        /// </summary>
        public int? IdPizza { get; set; }
        /// <summary>
        /// Pizza name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Pizza price
        /// </summary>
        public decimal Price { get; set; }
    }
}
