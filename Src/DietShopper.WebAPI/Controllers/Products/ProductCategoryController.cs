using System.Collections.Generic;
using System.Threading.Tasks;
using DietShopper.Application.Products.Commands;
using DietShopper.Application.Products.Models;
using DietShopper.Application.Products.Queries;
using DietShopper.WebAPI.Controllers.Products.Models;
using Microsoft.AspNetCore.Mvc;

namespace DietShopper.WebAPI.Controllers.Products
{
    [Route("api/[controller]")]
    public class ProductCategoryController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductCategoryDto>>> GetProductCategories()
        {
            var result = await Mediator.Send(new GetProductCategoriesQuery());

            return GetResponse(result);
        }

        [HttpPut]
        public async Task<ActionResult<ProductCategoryDto>> CreateProductCategory(CreateProductCategoryRequest request)
        {
            var result = await Mediator.Send(Mapper.Map<CreateProductCategoryCommand>(request));

            return GetResponse(result);
        }
    }
}