using HungryPizza.WebAPI.ViewModels.Commands.Customer;
using Swashbuckle.AspNetCore.Filters;

namespace HungryPizza.WebAPI.SwaggerDocs.Examples.Customer
{
    public class CreateCustomerCommandEx : IExamplesProvider<CreateCustomerCommandVM>
    {
        public CreateCustomerCommandVM GetExamples()
        {
            return new CreateCustomerCommandVM
            {
                Name = "MY NAME",
                Email = "my@email.com",
                Password = "MY_PASSWORD",
                Address = "MY ADDRESS"
            };
        }
    }
}
