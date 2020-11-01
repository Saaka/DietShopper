using System;
using DietShopper.Application.Models;
using DietShopper.Common.Requests;

namespace DietShopper.Application.Commands.Measures
{
    public class UpdateMeasureCommand : Request<MeasureDto>
    {
        public Guid MeasureGuid { get; }
        public string Name { get; }
        public string Symbol { get; }
        public bool IsWeight { get; }
        public decimal? ValueInGrams { get; }

        public UpdateMeasureCommand(Guid measureGuid, string name, string symbol, bool isWeight, decimal? valueInGrams)
        {
            MeasureGuid = measureGuid;
            Name = name;
            Symbol = symbol;
            IsWeight = isWeight;
            ValueInGrams = valueInGrams;
        }
    }
}