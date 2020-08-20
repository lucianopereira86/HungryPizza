namespace HungryPizza.Domain.Commands.Request
{
    public class RequestCustomerCommand
    {
        public RequestCustomerCommand(int? idCustomer, string address)
        {
            IdCustomer = idCustomer;
            Address = address;
        }

        public int? IdCustomer { get; private set; }
        public string Address { get; private set; }
    }
}
