using AutoMapper;
using DietShopper.Application.Services;
using DietShopper.Common.Requests;
using DietShopper.WebAPI.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace DietShopper.WebAPI.Controllers
{
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        private IMediator _mediator;
        private IMapper _mapper;
        private IGuid _guid;
        protected IMediator Mediator 
            => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        protected IMapper Mapper 
            => _mapper ??= HttpContext.RequestServices.GetService<IMapper>();
        protected IGuid GuidProvider 
            => _guid ??= HttpContext.RequestServices.GetService<IGuid>();
        

        protected ActionResult<TResponseType> GetResponse<TResponseType>(RequestResult<TResponseType> result)
        {
            if (result.IsSuccess)
                return Ok(result.Data);
            else
                return BadRequest(new ErrorResponse(result.Error, result.ErrorDetails?.ToString()));
        }
    }
}