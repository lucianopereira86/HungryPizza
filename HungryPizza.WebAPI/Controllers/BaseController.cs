using AutoMapper;
using HungryPizza.Infra.Shared.CommandQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HungryPizza.WebAPI.Controllers
{
    public class BaseController : ControllerBase
    {
        private readonly IMediator _mediatR;
        private readonly IMapper _mapper;
        public BaseController(IMediator mediatR, IMapper mapper)
        {
            _mediatR = mediatR;
            _mapper = mapper;
        }
        /// <summary>
        /// Send request from viewmodel and returns the result
        /// </summary>
        /// <typeparam name="TViewModel"></typeparam>
        /// <typeparam name="TCommandQuery"></typeparam>
        /// <param name="vm"></param>
        /// <returns></returns>
        protected async Task<IActionResult> Send<TViewModel, TCommandQuery>(TViewModel vm) where TCommandQuery : CommandQuery
        {
            try
            {
                var request = _mapper.Map<TCommandQuery>(vm);
                var result = (CommandQuery)await _mediatR.Send(request, new CancellationToken());
                if (!result.Valid)
                    return BadRequest(result.Errors);
                return Ok(result.Data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Send request and returns the result
        /// </summary>
        /// <typeparam name="ICommandQuery"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        protected async Task<IActionResult> Send<ICommandQuery>(ICommandQuery request)
        {
            try
            {
                var result = (CommandQuery)await _mediatR.Send(request, new CancellationToken());
                if (!result.Valid)
                    return BadRequest(result.Errors);
                return Ok(result.Data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
