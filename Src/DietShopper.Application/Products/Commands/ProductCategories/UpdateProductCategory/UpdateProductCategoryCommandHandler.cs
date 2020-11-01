using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DietShopper.Application.Products.Models;
using DietShopper.Application.Products.Repositories;
using DietShopper.Common.Requests;
using DietShopper.Domain.Enums;
using DietShopper.Domain.Exceptions;

namespace DietShopper.Application.Products.Commands.ProductCategories.UpdateProductCategory
{
    public class UpdateProductCategoryCommandHandler : RequestHandler<UpdateProductCategoryCommand, ProductCategoryDto>
    {
        private readonly IMapper _mapper;
        private readonly IProductCategoriesRepository _productCategoriesRepository;

        public UpdateProductCategoryCommandHandler(IMapper mapper,
            IProductCategoriesRepository productCategoriesRepository)
        {
            _mapper = mapper;
            _productCategoriesRepository = productCategoriesRepository;
        }

        public override async Task<RequestResult<ProductCategoryDto>> Handle(
            UpdateProductCategoryCommand request, CancellationToken cancellationToken)
        {
            if (await _productCategoriesRepository.IsNameTaken(request.ProductCategoryGuid, request.Name))
                throw new DomainException(ErrorCode.ProductCategoryNameTaken, new {request.Name});

            var productCategory = await _productCategoriesRepository.GetProductCategory(request.ProductCategoryGuid);
            productCategory.SetName(request.Name);

            await _productCategoriesRepository.Save(productCategory);

            return request.Success(_mapper.Map<ProductCategoryDto>(productCategory));
        }
    }
}