namespace HungryPizza.Domain.Entities.History
{
    public class RequestHistoryPizza
    {
        public RequestHistoryPizza(RequestHistoryPizzaInfo firstHalfPizza, RequestHistoryPizzaInfo secondHalfPizza, int quantity, decimal total)
        {
            FirstHalfPizza = firstHalfPizza;
            SecondHalfPizza = secondHalfPizza;
            Quantity = quantity;
            Total = total;
        }

        public RequestHistoryPizzaInfo FirstHalfPizza { get; private set; }
        public RequestHistoryPizzaInfo SecondHalfPizza { get; private set; }
        public int Quantity { get; private set; }
        public decimal Total { get; private set; }
    }
}
