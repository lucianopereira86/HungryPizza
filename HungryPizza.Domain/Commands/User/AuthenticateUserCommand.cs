using HungryPizza.Domain.Validations.Commands.User;
using HungryPizza.Infra.Shared.CommandQuery;
using HungryPizza.Infra.Shared.Models;

namespace HungryPizza.Domain.Commands.User
{
    public class AuthenticateUserCommand : CommandQuery
    {
        public AuthenticateUserCommand(string email, string password, 
            AppSettings appSettings) : base(appSettings)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; private set; }
        public string Password { get; private set; }
        
        public bool IsValid()
        {
            Validate(this, new AuthenticateUserCommandValidation());
            return Valid;
        }
    }
}
