using System;
using System.Collections.Generic;
using System.Linq;
using DietShopper.Domain.Constants.Validation;
using DietShopper.Domain.Enums;
using DietShopper.Domain.Exceptions;

namespace DietShopper.Domain.Entities
{
    public class Product
    {
        public int ProductId { get; private set; }
        public Guid ProductGuid { get; private set; }
        public string Name { get; private set; }
        public string ShortName { get; private set; }
        public string Description { get; private set; }
        public int ProductCategoryId { get; private set; }
        public int DefaultMeasureId { get; private set; }
        public bool IsActive { get; private set; }

        public virtual Measure DefaultMeasure { get; private set; }
        public virtual ProductNutrients ProductNutrients { get; private set; }
        public virtual ProductCategory ProductCategory { get; private set; }

        private readonly List<ProductMeasure> _productMeasures = new List<ProductMeasure>();
        public virtual IReadOnlyCollection<ProductMeasure> ProductMeasures => _productMeasures.AsReadOnly();

        private Product() { }

        public Product(Guid productGuid, string name, string shortName,
            string description, int productCategoryId, int defaultMeasureId)
        {
            ProductGuid = productGuid;
            Name = name;
            ShortName = shortName;
            Description = description;
            ProductCategoryId = productCategoryId;
            DefaultMeasureId = defaultMeasureId;
            IsActive = true;

            ValidateCreation();
        }

        public Product Deactivate()
        {
            IsActive = false;
            return this;
        }

        public Product SetName(string name)
        {
            ValidateName(name);
            
            Name = name;
            return this;
        }

        public Product SetShortName(string shortName)
        {
            ValidateShortName(shortName);

            ShortName = shortName;
            return this;
        }

        public Product SetDescription(string description)
        {
            ValidateDescription(description);

            Description = description;
            return this;
        }

        public Product AddProductMeasure(ProductMeasure productMeasure)
        {
            if (productMeasure == null)
                throw new InternalException(ErrorCode.ProductMeasureIsRequired);
            if (!productMeasure.ProductMeasureId.Equals(default) && _productMeasures.Any(x => x.ProductMeasureId == productMeasure.ProductMeasureId))
                return this;
            if (_productMeasures.Where(x => x.IsActive).Any(x => x.MeasureId == productMeasure.MeasureId))
                throw new DomainException(ErrorCode.MeasureAlreadyAddedForProduct);

            _productMeasures.Add(productMeasure);
            return this;
        }

        public Product SetProductNutrients(ProductNutrients nutrients)
        {
            if (ProductNutrients != null)
                throw new InternalException(ErrorCode.ProductNutrientsAlreadyExists);

            ProductNutrients = nutrients ?? throw new InternalException(ErrorCode.ProductNutrientsRequired);

            return this;
        }

        public Product SetCategory(int productCategoryId)
        {
            if (productCategoryId.Equals(default))
                throw new InternalException(ErrorCode.ProductCategoryRequired);

            ProductCategoryId = productCategoryId;

            return this;
        }

        public Product SetDefaultMeasure(Measure measure)
        {
            if (measure == null)
                throw new InternalException(ErrorCode.DefaultMeasureRequired);

            DefaultMeasureId = measure.MeasureId;
            DefaultMeasure = measure;

            return this;
        }

        private void ValidateCreation()
        {
            if (ProductGuid.IsEmpty())
                throw new InternalException(ErrorCode.ProductGuidRequired);

            ValidateName(Name);
            ValidateShortName(ShortName);
            ValidateDescription(Description);
            ValidateProductCategory();
            ValidateDefaultMeasure();
        }

        private void ValidateDefaultMeasure()
        {
            if (DefaultMeasureId == 0)
                throw new DomainException(ErrorCode.DefaultMeasureRequired);
        }

        private void ValidateProductCategory()
        {
            if (ProductCategoryId == 0)
                throw new DomainException(ErrorCode.ProductCategoryRequired);
        }

        private void ValidateName(string name)
        {
            if (name.IsNullOrWhiteSpace())
                throw new DomainException(ErrorCode.ProductNameRequired);
            if (name.Length > ProductValidationConstants.ProductNameMaxLength)
                throw new DomainException(ErrorCode.ProductNameTooLong);
        }

        private void ValidateShortName(string shortName)
        {
            if (!shortName.IsNullOrEmpty() && shortName.Length > ProductValidationConstants.ProductShortNameMaxLength)
                throw new DomainException(ErrorCode.ProductShortNameTooLong);
        }

        private void ValidateDescription(string description)
        {
            if (!description.IsNullOrWhiteSpace() && description.Length > ProductValidationConstants.ProductDescriptionMaxLength)
                throw new DomainException(ErrorCode.ProductDescriptionTooLong);
        }
    }
}