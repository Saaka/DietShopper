using System.Collections.Generic;
using System.Threading.Tasks;
using DietShopper.Application.Products.Models;
using DietShopper.Application.Products.Queries;
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
    }
}