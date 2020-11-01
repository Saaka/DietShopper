using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DietShopper.Application.Models;
using DietShopper.Application.Repositories;
using DietShopper.Application.Services;
using DietShopper.Common.Requests;
using DietShopper.Domain.Entities;
using DietShopper.Domain.Enums;
using DietShopper.Domain.Exceptions;

namespace DietShopper.Application.Commands.ProductCategories.CreateProductCategory
{
    public class CreateProductCategoryCommandHandler : RequestHandler<CreateProductCategoryCommand, ProductCategoryDto>
    {
        private readonly IGuid _guid;
        private readonly IMapper _mapper;
        private readonly IProductCategoriesRepository _productCategoriesRepository;

        public CreateProductCategoryCommandHandler(
            IGuid guid,
            IMapper mapper,
            IProductCategoriesRepository productCategoriesRepository)
        {
            _guid = guid;
            _mapper = mapper;
            _productCategoriesRepository = productCategoriesRepository;
        }

        public override async Task<RequestResult<ProductCategoryDto>> Handle(
            CreateProductCategoryCommand request, CancellationToken cancellationToken)
        {
            if (await _productCategoriesRepository.IsNameTaken(request.Name))
                throw new DomainException(ErrorCode.ProductCategoryNameTaken, new {request.Name});

            var productCategory = new ProductCategory(_guid.GetGuid(), request.Name);
            await _productCategoriesRepository.Save(productCategory);

            return request.Success(_mapper.Map<ProductCategoryDto>(productCategory));
        }
    }
}