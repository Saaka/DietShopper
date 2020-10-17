using System;
using DietShopper.Domain.Enums;
using DietShopper.Domain.Exceptions;

namespace DietShopper.Domain.Entities
{
    public class ProductMeasure
    {
        public int ProductMeasureId { get; private set; }
        public Guid ProductMeasureGuid { get; private set; }
        public int ProductId { get; private set; }
        public int MeasureId { get; private set; }
        public decimal ValueInGrams { get; private set; }
        public bool IsActive { get; private set; }

        public virtual Product Product { get; private set; }
        public virtual Measure Measure { get; private set; }

        private ProductMeasure() { }

        public ProductMeasure(Guid productMeasureGuid, Product product, Measure measure, decimal valueInGrams)
        {
            ProductMeasureGuid = productMeasureGuid;
            Product = product;
            ProductId = product.ProductId;
            Measure = measure;
            MeasureId = measure.MeasureId;
            ValueInGrams = valueInGrams;
            IsActive = true;

            ValidateCreation();
        }

        public ProductMeasure SetValueInGrams(decimal valueInGrams)
        {
            ValidateValueInGrams(valueInGrams);
            
            ValueInGrams = valueInGrams;
            return this;
        }

        public ProductMeasure Deactivate()
        {
            IsActive = false;
            return this;
        }

        private void ValidateCreation()
        {
            if (ProductMeasureGuid.Equals(Guid.Empty))
                throw new InternalException(ErrorCode.ProductMeasureGuidRequired);
            if (Product == null)
                throw new InternalException(ErrorCode.ProductRequiredForProductMeasure);
            if (Measure == null)
                throw new InternalException(ErrorCode.MeasureRequiredForProductMeasure);
            
            ValidateValueInGrams(ValueInGrams);
        }

        private void ValidateValueInGrams(decimal valueInGrams)
        {
            if (valueInGrams <= 0)
                throw new DomainException(ErrorCode.WeightMustBeGreaterThanZero);
        }
    }
}