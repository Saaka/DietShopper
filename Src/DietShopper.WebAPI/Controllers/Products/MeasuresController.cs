using System.Collections.Generic;
using System.Threading.Tasks;
using DietShopper.Application.Products.Commands;
using DietShopper.Application.Products.Models;
using DietShopper.Application.Products.Queries;
using DietShopper.WebAPI.Controllers.Products.Models;
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
        public async Task<ActionResult<MeasureDto>> CreateProductCategory(CreateMeasureRequest request)
        {
            var result = await Mediator.Send(Mapper.Map<CreateMeasureCommand>(request));

            return GetResponse(result);
        }
    }
}