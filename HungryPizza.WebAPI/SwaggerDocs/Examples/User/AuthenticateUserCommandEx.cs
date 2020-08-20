using HungryPizza.WebAPI.ViewModels.Commands.User;
using Swashbuckle.AspNetCore.Filters;

namespace HungryPizza.WebAPI.SwaggerDocs.Examples.User
{
    public class AuthenticateUserCommandEx : IExamplesProvider<AuthenticateUserCommandVM>
    {
        public AuthenticateUserCommandVM GetExamples()
        {
            return new AuthenticateUserCommandVM
            {
                Email = "my@email.com",
                Password = "MY_NEW_PASSWORD",
            };
        }
    }
}
