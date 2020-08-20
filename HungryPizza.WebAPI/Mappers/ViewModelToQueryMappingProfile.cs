using AutoMapper;
using HungryPizza.Domain.Entities;
using HungryPizza.Domain.Queries.Pizza;
using HungryPizza.Domain.Queries.Request;
using HungryPizza.Infra.Shared.Models;
using HungryPizza.WebAPI.ViewModels.Queries.Pizza;
using HungryPizza.WebAPI.ViewModels.Queries.Request;

namespace HungryPizza.WebAPI.Mappers
{
    public class ViewModelToQueryMappingProfile : Profile
    {
        public ViewModelToQueryMappingProfile(AppSettings appSettings)
        {
            #region Pizza
            CreateMap<PizzaGetQueryVM, Pizza>();
            CreateMap<PizzaGetQueryVM, PizzaGetQuery>()
                //.ConstructUsing(x => new PizzaGetQuery(new Pizza(x.Id, x.Name, x.Price, true), appSettings));
            //.ForMember(m => m.Pizza, n => n.MapFrom(o => o))
            .ForCtorParam("appSettings", p => p.MapFrom(f => appSettings));
            CreateMap<RequestGetQueryVM, RequestGetQuery>()
            //.ConstructUsing(x => new RequestGetQuery(new Request(null, x.CreatedAt, x.Uid, x.IdCustomer, x.Address, true), appSettings));
            //.ForMember(m => m.Request, n => n.MapFrom(o => o))
            .ForCtorParam("appSettings", p => p.MapFrom(f => appSettings));
            CreateMap<RequestHistoryQueryVM, RequestHistoryQuery>()
            .ForCtorParam("appSettings", p => p.MapFrom(f => appSettings));
            #endregion
        }
    }
}
