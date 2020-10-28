using System;
using System.Collections.Generic;
using DietShopper.Domain.Constants.Validation;
using DietShopper.Domain.Enums;
using DietShopper.Domain.Exceptions;

namespace DietShopper.Domain.Entities
{
    public class Measure
    {
        public int MeasureId { get; private set; }
        public Guid MeasureGuid { get; private set; }
        public string Name { get; private set; }
        public string Symbol { get; private set; }
        public bool IsWeight { get; private set; }
        public decimal? ValueInGrams { get; private set; }
        public bool IsActive { get; private set; }
        public bool IsBaseline { get; private set; }

        private readonly List<Product> _defaultProducts = new List<Product>();
        public virtual IReadOnlyCollection<Product> DefaultProducts => _defaultProducts.AsReadOnly();

        private readonly List<ProductMeasure> _productMeasures = new List<ProductMeasure>();
        public virtual IReadOnlyCollection<ProductMeasure> ProductMeasures => _productMeasures.AsReadOnly();

        private Measure() { }

        public Measure(Guid measureGuid, string name, string symbol, bool isWeight, decimal? valueInGrams)
        {
            MeasureGuid = measureGuid;
            Name = name;
            Symbol = symbol;
            IsWeight = isWeight;
            ValueInGrams = valueInGrams;
            IsActive = true;

            ValidateCreation();
        }

        public Measure Deactivate()
        {
            IsActive = false;
            return this;
        }

        private void ValidateCreation()
        {
            if (MeasureGuid.Equals(Guid.Empty))
                throw new InternalException(ErrorCode.MeasureGuidRequired);
            ValidateName();
            ValidateShortName();
            ValidateWeight();
        }

        private void ValidateWeight()
        {
            if (IsWeight)
            {
                if (ValueInGrams == null || ValueInGrams == 0)
                    throw new DomainException(ErrorCode.MeasureValueInGramsRequiredForWeightType);
            }
        }

        private void ValidateName()
        {
            if (string.IsNullOrWhiteSpace(Name))
                throw new DomainException(ErrorCode.MeasureNameRequired);
            if (Name.Length > MeasureValidationConstants.MeasureNameMaxLength)
                throw new DomainException(ErrorCode.MeasureNameTooLong);
        }

        private void ValidateShortName()
        {
            if (string.IsNullOrWhiteSpace(Symbol))
                throw new DomainException(ErrorCode.MeasureShortNameRequired);
            if (Symbol.Length > MeasureValidationConstants.MeasureSymbolMaxLength)
                throw new DomainException(ErrorCode.MeasureShortNameTooLong);
        }
    }
}