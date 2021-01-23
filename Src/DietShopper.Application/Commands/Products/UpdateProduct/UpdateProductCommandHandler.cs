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

namespace DietShopper.Application.Commands.Products.UpdateProduct
{
    public class UpdateProductCommandHandler : RequestHandler<UpdateProductCommand, ProductDto>
    {
        private readonly IGuid _guid;
        private readonly IMapper _mapper;
        private readonly IProductsRepository _productsRepository;
        private readonly IProductCategoriesRepository _productCategoriesRepository;
        private readonly IMeasuresRepository _measuresRepository;

        public UpdateProductCommandHandler(IGuid guid, IMapper mapper, IProductsRepository productsRepository, IProductCategoriesRepository productCategoriesRepository,
            IMeasuresRepository measuresRepository)
        {
            _guid = guid;
            _mapper = mapper;
            _productsRepository = productsRepository;
            _productCategoriesRepository = productCategoriesRepository;
            _measuresRepository = measuresRepository;
        }

        public override async Task<RequestResult<ProductDto>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            await ValidateProduct(request);
            var product = await _productsRepository.GetProductEntity(request.ProductGuid);
            if (product == null)
                return request.Failure(ErrorCode.ProductNotExists, request.ProductGuid.ToString());

            product.SetName(request.Name)
                .SetShortName(request.ShortName)
                .SetDescription(request.Description);

            product.ProductNutrients
                .SetNutrientsContent(request.Calories, request.Carbohydrates, request.Proteins, request.Fat, request.SaturatedFat);

            await UpdateCategory(product, request.ProductCategoryGuid);
            await UpsertMeasures(product, request.ProductMeasures);

            return request.Success(_mapper.Map<ProductDto>(product));
        }

        private async Task UpsertMeasures(Product product, IReadOnlyCollection<UpdateProductMeasureDto> requestedMeasures)
        {
            var measures = await _measuresRepository.GetMeasures(requestedMeasures.Select(x => x.MeasureGuid));
            foreach (var measureData in requestedMeasures)
            {
                if (measureData.ProductMeasureGuid.HasValue)
                {
                    var toUpdate = product.ProductMeasures.First(x => x.ProductMeasureGuid == measureData.ProductMeasureGuid.Value);
                    toUpdate.SetValueInGrams(measureData.ValueInGrams);
                    if (measureData.IsDefault)
                        product.SetDefaultMeasure(toUpdate.Measure);
                }
                else
                {
                    var measure = measures.FirstOrDefault(x => x.MeasureGuid == measureData.MeasureGuid);
                    if (measure == null)
                        throw new InternalException(ErrorCode.MeasureNotExists, measureData.MeasureGuid.ToString());

                    var valueInGrams = measure.IsWeight ? measure.ValueInGrams ?? measureData.ValueInGrams : measureData.ValueInGrams;
                    var productMeasure = new ProductMeasure(_guid.GetGuid(), measure, valueInGrams);
                    if (measureData.IsDefault)
                        product.SetDefaultMeasure(measure);

                    product.AddProductMeasure(productMeasure);
                }
            }

            foreach (var measureToDeactivate in product.ProductMeasures
                .Where(x => x.IsActive && !requestedMeasures.Any(rm => rm.ProductMeasureGuid.HasValue && rm.ProductMeasureGuid == x.ProductMeasureGuid)).ToList())
            {
                measureToDeactivate.Deactivate();
            }
        }

        private async Task UpdateCategory(Product product, Guid productCategoryGuid)
        {
            if (product.ProductCategory.ProductCategoryGuid.Equals(productCategoryGuid)) return;

            var newProductCategory = await _productCategoriesRepository.GetCategoryId(productCategoryGuid);
            product.SetCategory(newProductCategory);
        }

        private async Task ValidateProduct(UpdateProductCommand request)
        {
            if (await _productsRepository.IsNameTaken(request.ProductGuid, request.Name))
                throw new DomainException(ErrorCode.ProductNameNotUnique, new {request.Name});
            if (!string.IsNullOrWhiteSpace(request.ShortName) && await _productsRepository.IsShortNameTaken(request.ProductGuid, request.ShortName))
                throw new DomainException(ErrorCode.ProductShortNameNotUnique, new {request.Name});
        }
    }
}