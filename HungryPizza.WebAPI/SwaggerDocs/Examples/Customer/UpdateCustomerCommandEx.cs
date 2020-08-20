using HungryPizza.WebAPI.ViewModels.Commands.Customer;
using Swashbuckle.AspNetCore.Filters;

namespace HungryPizza.WebAPI.SwaggerDocs.Examples.Customer
{
    public class UpdateCustomerCommandEx : IExamplesProvider<UpdateCustomerCommandVM>
    {
        public UpdateCustomerCommandVM GetExamples()
        {
            return new UpdateCustomerCommandVM
            {
                IdCustomer = 1,
                Name = "MY NEW NAME",
                Email = "my@email.com",
                Password = "MY_NEW_PASSWORD",
                Address = "MY NEW ADDRESS",
                Active = true
            };
        }
    }
}
