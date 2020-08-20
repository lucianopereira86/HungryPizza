using HungryPizza.Domain.Validations.Queries.History;
using HungryPizza.Infra.Shared.CommandQuery;
using HungryPizza.Infra.Shared.Models;

namespace HungryPizza.Domain.Queries.Request
{
    public class RequestHistoryQuery : CommandQuery
    {
        public RequestHistoryQuery(
            int idCustomer,
            AppSettings appSettings) : base(appSettings)
        {
            IdCustomer = idCustomer;
        }
        public int IdCustomer { get; private set; }
        public bool IsValid()
        {
            Validate(this, new RequestHistoryQueryValidation());
            return Valid;
        }
    }
}
