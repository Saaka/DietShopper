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

        public Measure SetName(string value)
        {
            ValidateName(value);
            Name = value;
            return this;
        }

        public Measure SetSymbol(string value)
        {
            ValidateSymbol(value);
            Symbol = value;
            return this;
        }

        public Measure SetWeight(bool isWeight, decimal? valueInGrams)
        {
            ValidateWeight(isWeight, valueInGrams);
            IsWeight = isWeight;
            ValueInGrams = valueInGrams;
            return this;
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
            ValidateName(Name);
            ValidateSymbol(Symbol);
            ValidateWeight(IsWeight, ValueInGrams);
        }

        private void ValidateWeight(bool isWeight, decimal? valueInGrams)
        {
            if (isWeight)
            {
                if (valueInGrams == null || valueInGrams == 0)
                    throw new DomainException(ErrorCode.MeasureValueInGramsRequiredForWeightType);
            }
        }

        private void ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException(ErrorCode.MeasureNameRequired);
            if (name.Length > MeasureValidationConstants.MeasureNameMaxLength)
                throw new DomainException(ErrorCode.MeasureNameTooLong);
        }

        private void ValidateSymbol(string symbol)
        {
            if (string.IsNullOrWhiteSpace(symbol))
                throw new DomainException(ErrorCode.MeasureSymbolRequired);
            if (symbol.Length > MeasureValidationConstants.MeasureSymbolMaxLength)
                throw new DomainException(ErrorCode.MeasureSymbolTooLong);
        }
    }
}