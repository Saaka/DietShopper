using System.Threading.Tasks;
using DietShopper.Application.Commands.Products;
using DietShopper.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DietShopper.WebAPI.Controllers.Products
{
    [Authorize]
    public class ProductsController : BaseApiController
    {
        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<ProductDto>> CreateProduct(CreateProductCommand request)
        {
            var result = await Mediator.Send(request);

            return GetResponse(result);
        }
    }
}