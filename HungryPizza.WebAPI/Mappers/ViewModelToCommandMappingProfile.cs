using AutoMapper;
using HungryPizza.Domain.Commands.Customer;
using HungryPizza.Domain.Commands.Request;
using HungryPizza.Domain.Commands.User;
using HungryPizza.Infra.Shared.Models;
using HungryPizza.WebAPI.ViewModels.Commands.Customer;
using HungryPizza.WebAPI.ViewModels.Commands.Request;
using HungryPizza.WebAPI.ViewModels.Commands.User;

namespace HungryPizza.WebAPI.Mappers
{
    public class ViewModelToCommandMappingProfile : Profile
    {
        public ViewModelToCommandMappingProfile(AppSettings appSettings)
        {
            #region Customer
            CreateMap<CreateCustomerCommandVM, CreateCustomerCommand>()
                 //.ConstructUsing(x => new CreateCustomerCommand(x.Name, x.Email, x.Password, x.Address, appSettings));
            .ForCtorParam("appSettings", p => p.MapFrom(f => appSettings));
            CreateMap<UpdateCustomerCommandVM, UpdateCustomerCommand>()
                 //.ConstructUsing(x => new UpdateCustomerCommand(x.IdCustomer, x.Name, x.Email, x.Password, x.Address, x.Active, appSettings));
            .ForCtorParam("appSettings", p => p.MapFrom(f => appSettings));
            #endregion

            #region User
            CreateMap<AuthenticateUserCommandVM, AuthenticateUserCommand>()
                 //.ConstructUsing(x => new AuthenticateUserCommand(x.Email, x.Password, appSettings));
            .ForCtorParam("appSettings", p => p.MapFrom(f => appSettings));
            #endregion

            #region Request
            CreateMap<RequestPizzaCommandVM, RequestPizzaCommand>();
            CreateMap<CreateRequestCommandVM, CreateRequestCommand>()
                 //.ConstructUsing(x => new CreateRequestCommand(x.Customer, x.Pizzas, appSettings));
            .ForCtorParam("appSettings", p => p.MapFrom(f => appSettings));
            #endregion
        }
    }
}
