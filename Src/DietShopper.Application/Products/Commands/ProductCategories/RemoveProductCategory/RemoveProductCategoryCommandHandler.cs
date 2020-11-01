using System;
using System.Threading;
using System.Threading.Tasks;
using DietShopper.Application.Products.Repositories;
using DietShopper.Common.Requests;

namespace DietShopper.Application.Products.Commands.ProductCategories.RemoveProductCategory
{
    public class RemoveProductCategoryCommandHandler : RequestHandler<RemoveProductCategoryCommand, Guid>
    {
        private readonly IProductCategoriesRepository _productCategoriesRepository;

        public RemoveProductCategoryCommandHandler(IProductCategoriesRepository productCategoriesRepository)
        {
            _productCategoriesRepository = productCategoriesRepository;
        }
        
        public override async Task<RequestResult<Guid>> Handle(RemoveProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _productCategoriesRepository.GetProductCategory(request.ProductCategoryGuid);
            category.Deactivate();
            await _productCategoriesRepository.Save(category);

            return request.Success();
        }
    }
}