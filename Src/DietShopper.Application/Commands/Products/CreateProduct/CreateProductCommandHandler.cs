using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DietShopper.Application.Commands.Products.Models;
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
            await ValidateProduct(request);
            var productCategoryId = await GetCategoryId(request.ProductCategoryGuid);
            var defaultMeasureId = await GetDefaultMeasure(request.ProductMeasures);
            var nutrients = CreateProductNutrients(request);

            var product = new Product(_guid.GetGuid(), request.Name, request.ShortName, request.Description, productCategoryId, defaultMeasureId)
                .SetProductNutrients(nutrients);

            await CreateProductMeasures(product, request.ProductMeasures);

            await _productsRepository.Save(product);
            return request.Success(_mapper.Map<ProductDto>(product));
        }

        private async Task CreateProductMeasures(Product product, IReadOnlyCollection<CreateProductMeasureDto> requestedMeasures)
        {
            var measures = await _measuresRepository.GetMeasures(requestedMeasures.Select(x => x.MeasureGuid));
            foreach (var measureData in requestedMeasures)
            {
                var measure = measures.FirstOrDefault(x => x.MeasureGuid == measureData.MeasureGuid);
                if (measure == null)
                    throw new InternalException(ErrorCode.MeasureNotExists, measureData.MeasureGuid.ToString());

                var valueInGrams = measure.IsWeight ? measure.ValueInGrams ?? measureData.ValueInGrams : measureData.ValueInGrams;
                var productMeasure = new ProductMeasure(_guid.GetGuid(), measure, valueInGrams);

                product.AddProductMeasure(productMeasure);
            }

            if (!requestedMeasures.Any(x => x.IsDefault))
            {
                if (!product.ProductMeasures.Any(x => x.Measure.IsBaseline))
                {
                    var baselineMeasure = await _measuresRepository.GetBaselineMeasure();
                    var productMeasure = new ProductMeasure(_guid.GetGuid(), baselineMeasure, baselineMeasure.ValueInGrams.Value);
                    product.AddProductMeasure(productMeasure);
                }
            }
        }

        private ProductNutrients CreateProductNutrients(CreateProductCommand request)
            => new ProductNutrients(_guid.GetGuid(), request.Calories, request.Carbohydrates, request.Proteins, request.Fat, request.SaturatedFat);

        private async Task<int> GetDefaultMeasure(IEnumerable<CreateProductMeasureDto> productMeasures)
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

        private async Task ValidateProduct(CreateProductCommand request)
        {
            if (await _productsRepository.IsNameTaken(request.Name))
                throw new DomainException(ErrorCode.ProductNameNotUnique, new {request.Name});
            if (!string.IsNullOrWhiteSpace(request.ShortName) && await _productsRepository.IsShortNameTaken(request.ShortName))
                throw new DomainException(ErrorCode.ProductShortNameNotUnique, new {request.Name});
        }
    }
}