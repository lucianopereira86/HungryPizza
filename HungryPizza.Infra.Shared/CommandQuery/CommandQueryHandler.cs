using AutoMapper;

namespace HungryPizza.Infra.Shared.CommandQuery
{
    public class CommandQueryHandler
    {
        public readonly IMapper _mapper;
        public CommandQueryHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}
