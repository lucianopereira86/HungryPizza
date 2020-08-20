namespace HungryPizza.Infra.Shared.Models
{
    public class Error
    {
        public Error(int code, string message)
        {
            Code = code;
            Message = message;
        }

        public int Code { get; private set; }
        public string Message { get; private set; }
    }
}
