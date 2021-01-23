using System;
using System.Threading.Tasks;
using DietShopper.Application.Commands.Products;
using DietShopper.Application.Models;
using DietShopper.Application.Queries.Products;
using DietShopper.Application.Queries.Products.Models;
using DietShopper.Common.Models;
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
        [HttpPost]
        [Route("update")]
        public async Task<ActionResult<ProductDto>> UpdateProduct(UpdateProductCommand request)
        {
            var result = await Mediator.Send(request);

            return GetResponse(result);
        }

        [HttpGet]
        [Route("{productGuid}")]
        public async Task<ActionResult<CompleteProductDto>> GetProduct(Guid productGuid)
        {
            var result = await Mediator.Send(new GetCompleteProductQuery {ProductGuid = productGuid});

            return GetResponse(result);
        }

        [HttpPost]
        [Route("list/simple")]
        public async Task<ActionResult<PagedList<SimpleProductDto>>> GetProducts(GetSimpleProductsQuery request)
        {
            var result = await Mediator.Send(request);
            return GetResponse(result);
        }
    }
}