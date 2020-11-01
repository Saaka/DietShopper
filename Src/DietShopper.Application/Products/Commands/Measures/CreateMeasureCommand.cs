using DietShopper.Application.Products.Models;
using DietShopper.Common.Requests;

namespace DietShopper.Application.Products.Commands.Measures
{
    public class CreateMeasureCommand : Request<MeasureDto>
    {
        public string Name { get; }
        public string Symbol { get; }
        public bool IsWeight { get; }
        public decimal? ValueInGrams { get; }

        public CreateMeasureCommand(string name, string symbol, bool isWeight, decimal? valueInGrams)
        {
            Name = name;
            Symbol = symbol;
            IsWeight = isWeight;
            ValueInGrams = valueInGrams;
        }
    }
}