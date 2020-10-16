using System;
using System.Collections.Generic;
using DietShopper.Domain.Constants.Validation;
using DietShopper.Domain.Enums;
using DietShopper.Domain.Exceptions;

namespace DietShopper.Domain.Entities
{
    public class Measure
    {
        public int MeasureId { get; set; }
        public Guid MeasureGuid { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public bool IsWeight { get; set; }
        public decimal? ValueInGrams { get; set; }

        private readonly List<Product> _defaultProducts = new List<Product>();
        public virtual IReadOnlyCollection<Product> DefaultProducts => _defaultProducts.AsReadOnly();

        private Measure() { }

        public Measure(Guid measureGuid, string name, string shortName, bool isWeight, decimal? valueInGrams)
        {
            MeasureGuid = measureGuid;
            Name = name;
            ShortName = shortName;
            IsWeight = isWeight;
            ValueInGrams = valueInGrams;

            ValidateCreation();
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
                if(ValueInGrams == null || ValueInGrams == 0)
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
            if (string.IsNullOrWhiteSpace(ShortName))
                throw new DomainException(ErrorCode.MeasureShortNameRequired);
            if (ShortName.Length > MeasureValidationConstants.MeasureShortNameMaxLength)
                throw new DomainException(ErrorCode.MeasureShortNameTooLong);
        }
    }
}