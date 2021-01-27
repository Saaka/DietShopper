using System;
using DietShopper.Application.Models;
using DietShopper.Common.Requests;

namespace DietShopper.Application.Commands.Measures
{
    public class UpdateMeasureCommand : Request<MeasureDto>, IRequestWithAdminAuthorization
    {
        public Guid MeasureGuid { get; set;}
        public string Name { get; set;}
        public string Symbol { get; set;}
        public bool IsWeight { get; set; }
        public decimal? ValueInGrams { get; set; }
    }
}