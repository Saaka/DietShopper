using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using AutoMapper;
using DietShopper.Application.Models;
using DietShopper.Application.Repositories;
using DietShopper.Application.Services;
using DietShopper.Common.Requests;
using DietShopper.Domain.Entities;
using DietShopper.Domain.Enums;
using DietShopper.Domain.Exceptions;

namespace DietShopper.Application.Commands.Products.CreateProduct
{
    public class CreateProductCommandHandler : RequestHandler<CreateProductCommand, ProductDto>
    {
        private readonly IGuid _guid;
        private readonly IMapper _mapper;
        private readonly IProductsRepository _productsRepository;
        private readonly IProductCategoriesRepository _productCategoriesRepository;
        private readonly IMeasuresRepository _measuresRepository;

        public CreateProductCommandHandler(IGuid guid,
            IMapper mapper,
            IProductsRepository productsRepository,
            IProductCategoriesRepository productCategoriesRepository,
            IMeasuresRepository measuresRepository)
        {
            _guid = guid;
            _mapper = mapper;
            _productsRepository = productsRepository;
            _productCategoriesRepository = productCategoriesRepository;
            _measuresRepository = measuresRepository;
        }

        public override async Task<RequestResult<ProductDto>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var productCategoryId = await GetCategoryId(request.ProductCategoryGuid);
            var defaultMeasureId = await GetDefaultMeasure(request.ProductMeasures);
            var nutrients = CreateProductNutrients(request);

            var product = new Product(_guid.GetGuid(), request.Name, request.ShortName, request.Description, productCategoryId, defaultMeasureId)
                .SetProductNutrients(nutrients);

            await CreateProductMeasures(product, request.ProductMeasures);

            await _productsRepository.Save(product);
            return request.Success(_mapper.Map<ProductDto>(product));
        }

        private Task CreateProductMeasures(Product product, IEnumerable<CreateProductCommand.ProductMeasureData> requestProductMeasures)
        {
            throw new NotImplementedException();
        }

        private ProductNutrients CreateProductNutrients(CreateProductCommand request)
            => new ProductNutrients(_guid.GetGuid(), request.Calories, request.Carbohydrates, request.Proteins, request.Fat, request.SaturatedFat);

        private async Task<int> GetDefaultMeasure(IEnumerable<CreateProductCommand.ProductMeasureData> productMeasures)
        {
            if (!productMeasures.Any(x => x.IsDefault))
                return await _measuresRepository.GetBaselineMeasureId();

            var defaultMeasureGuid = productMeasures.First(x => x.IsDefault).MeasureGuid;
            return await _measuresRepository.GetMeasureId(defaultMeasureGuid);
        }

        private async Task<int> GetCategoryId(Guid productCategoryGuid)
        {
            var categoryId = await _productCategoriesRepository.GetCategoryId(productCategoryGuid);
            if (categoryId.Equals(default))
                throw new DomainException(ErrorCode.ProductCategoryNotExists, new {productCategoryGuid});

            return categoryId;
        }
    }
}