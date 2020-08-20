namespace HungryPizza.Domain.Entities.History
{
    public class RequestHistoryPizzaInfo
    {
        public RequestHistoryPizzaInfo(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; private set; }
        public decimal Price { get; private set; }
    }
}
