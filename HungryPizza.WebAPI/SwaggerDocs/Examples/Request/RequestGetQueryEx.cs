using HungryPizza.WebAPI.ViewModels.Queries.Request;
using Swashbuckle.AspNetCore.Filters;

namespace HungryPizza.WebAPI.SwaggerDocs.Examples.Request
{
    public class RequestGetQueryEx : IExamplesProvider<RequestGetQueryVM>
    {
        public RequestGetQueryVM GetExamples()
        {
            return new RequestGetQueryVM();
        }
    }
}
