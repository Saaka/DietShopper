using AutoMapper;
using DietShopper.Domain.Entities;

namespace DietShopper.Application.Models
{
    public class ApplicationModulesMapperProfile : Profile
    {
        public ApplicationModulesMapperProfile()
        {
            CreateMap<ProductCategory, ProductCategoryDto>();
            CreateMap<Measure, MeasureDto>();
            CreateMap<Product, ProductDto>();
        }
    }
}