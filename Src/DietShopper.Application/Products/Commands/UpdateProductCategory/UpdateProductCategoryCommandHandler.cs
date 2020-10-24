using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DietShopper.Application.Products.Models;
using DietShopper.Application.Products.Repositories;
using DietShopper.Application.Services;
using DietShopper.Common.Requests;
using DietShopper.Domain.Entities;
using DietShopper.Domain.Enums;
using DietShopper.Domain.Exceptions;

namespace DietShopper.Application.Products.Commands.UpdateProductCategory
{
    public class UpdateProductCategoryCommandHandler: RequestHandler<UpdateProductCategoryCommand, ProductCategoryDto>
    {
        private readonly IGuid _guid;
        private readonly IMapper _mapper;
        private readonly IProductCategoriesRepository _productCategoriesRepository;

        public UpdateProductCategoryCommandHandler(
            IGuid guid,
            IMapper mapper,
            IProductCategoriesRepository productCategoriesRepository)
        {
            _guid = guid;
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