using System;
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

        public virtual Measure DefaultMeasure { get; private set; }
        public virtual ProductCategory ProductCategory { get; private set; }

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

            ValidateCreation();
        }

        public Product SetCategory(ProductCategory category)
        {
            if (category == null)
                throw new InternalException(ErrorCode.ProductCategoryRequired);

            ProductCategoryId = category.ProductCategoryId;
            ProductCategory = category;

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
            if (ProductGuid.Equals(Guid.Empty))
                throw new InternalException(ErrorCode.ProductGuidRequired);

            ValidateName();
            ValidateShortName();
            ValidateDescription();
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

        private void ValidateName()
        {
            if (string.IsNullOrWhiteSpace(Name))
                throw new DomainException(ErrorCode.ProductNameRequired);
            if (Name.Length > ProductValidationConstants.ProductNameMaxLength)
                throw new DomainException(ErrorCode.ProductNameTooLong);
        }

        private void ValidateShortName()
        {
            if (string.IsNullOrWhiteSpace(ShortName))
                throw new DomainException(ErrorCode.ProductShortNameRequired);
            if (ShortName.Length > ProductValidationConstants.ProductShortNameMaxLength)
                throw new DomainException(ErrorCode.ProductShortNameTooLong);
        }

        private void ValidateDescription()
        {
            if (Description.Length > ProductValidationConstants.ProductDescriptionMaxLength)
                throw new DomainException(ErrorCode.ProductDescriptionTooLong);
        }
    }
}