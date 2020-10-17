using AutoMapper;
using DietShopper.Application.Products.Models;
using DietShopper.Domain.Entities;

namespace DietShopper.Application.Products
{
    public class ProductsMapperProfile : Profile
    {
        public ProductsMapperProfile()
        {
            CreateMap<ProductCategory, ProductCategoryDto>();
        }
    }
}