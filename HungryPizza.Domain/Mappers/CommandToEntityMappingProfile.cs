using AutoMapper;
using HungryPizza.Domain.Commands.Customer;
using HungryPizza.Domain.Commands.Request;
using HungryPizza.Domain.Commands.User;
using HungryPizza.Domain.Entities;
using HungryPizza.Infra.Shared.Models;

namespace HungryPizza.Domain.Mappers
{
    public class CommandToEntityMappingProfile : Profile
    {
        public CommandToEntityMappingProfile()
        {
            #region Customer
            CreateMap<CreateCustomerCommand, Customer>();
            CreateMap<CreateCustomerCommand, User>();
            //.ForMember(m => m.Name, n => n.MapFrom(f => f.Name))
            //.ForMember(m => m.Address, n => n.MapFrom(f => f.Address))
            //.ForMember(m => m.User, n => n.MapFrom(f => new User(0, f.Email, f.Password, true)));

            CreateMap<UpdateCustomerCommand, Customer>()
                .ForMember(m => m.Id, n => n.MapFrom(f => f.IdCustomer));
            CreateMap<UpdateCustomerCommand, User>();
            //.ForMember(m => m.Name, n => n.MapFrom(f => f.Name))
            //.ForMember(m => m.Address, n => n.MapFrom(f => f.Address));
            //.ForMember(m => m.User, n => n.MapFrom(f => new User(0, f.Email, f.Password, f.Active)));
            #endregion

            #region User
            CreateMap<AuthenticateUserCommand, User>();
            #endregion

            #region Request
            CreateMap<CreateRequestCommand, Request>();
            //.ForMember(m => m.Customer, n => n.MapFrom(f => new Customer(f.Customer.IdCustomer ?? 0, 0, null, f.Customer.Address)));
            #endregion
        }
    }
}
