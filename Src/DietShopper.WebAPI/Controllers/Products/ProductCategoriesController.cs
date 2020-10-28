using System;
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
    public class ProductCategoriesController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductCategoryDto>>> GetProductCategories()
        {
            var result = await Mediator.Send(new GetProductCategoriesQuery());

            return GetResponse(result);
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<ProductCategoryDto>> CreateProductCategory(CreateProductCategoryRequest request)
        {
            var result = await Mediator.Send(Mapper.Map<CreateProductCategoryCommand>(request));

            return GetResponse(result);
        }

        [HttpPost]
        [Route("update")]
        public async Task<ActionResult<ProductCategoryDto>> UpdateProductCategory(UpdateProductCategoryRequest request)
        {
            var result = await Mediator.Send(Mapper.Map<UpdateProductCategoryCommand>(request));

            return GetResponse(result);
        }

        [HttpDelete]
        [Route("{productCategoryGuid}")]
        public async Task<ActionResult<Guid>> RemoveProductCategory(Guid productCategoryGuid)
        {
            var result = await Mediator.Send(new RemoveProductCategoryCommand(productCategoryGuid));

            return GetResponse(result);
        }
    }
}