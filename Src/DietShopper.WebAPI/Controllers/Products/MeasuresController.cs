using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DietShopper.Application.Commands.Measures;
using DietShopper.Application.Models;
using DietShopper.Application.Queries.Measures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DietShopper.WebAPI.Controllers.Products
{
    [Authorize]
    public class MeasuresController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MeasureDto>>> GetMeasures()
        {
            var result = await Mediator.Send(new GetMeasuresQuery());

            return GetResponse(result);
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<MeasureDto>> CreateMeasure(CreateMeasureCommand request)
        {
            var result = await Mediator.Send(request);

            return GetResponse(result);
        }

        [HttpPost]
        [Route("update")]
        public async Task<ActionResult<MeasureDto>> UpdateMeasure(UpdateMeasureCommand request)
        {
            var result = await Mediator.Send(request);

            return GetResponse(result);
        }

        [HttpDelete]
        [Route("{measureGuid}")]
        public async Task<ActionResult<Guid>> UpdateMeasure(Guid measureGuid)
        {
            var result = await Mediator.Send(new RemoveMeasureCommand {MeasureGuid = measureGuid});
            
            return GetResponse(result);
        }
    }
}