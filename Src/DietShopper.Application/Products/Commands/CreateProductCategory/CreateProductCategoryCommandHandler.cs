using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DietShopper.Application.Products.Models;
using DietShopper.Application.Products.Repositories;
using DietShopper.Application.Services;
using DietShopper.Common.Requests;
using DietShopper.Domain.Entities;

namespace DietShopper.Application.Products.Commands.CreateProductCategory
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
            var productCategory = new ProductCategory(_guid.GetGuid(), request.Name);
            await _productCategoriesRepository.Save(productCategory);

            return request.Success(_mapper.Map<ProductCategoryDto>(productCategory));
        }
    }
}