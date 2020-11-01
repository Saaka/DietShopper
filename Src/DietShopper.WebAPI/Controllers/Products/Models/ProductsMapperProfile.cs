using AutoMapper;
using DietShopper.Application.Products.Commands.ProductCategories;
using DietShopper.Application.Products.Commands.Measures;

namespace DietShopper.WebAPI.Controllers.Products.Models
{
    public class ProductsMapperProfile : Profile
    {
        public ProductsMapperProfile()
        {
            CreateMap<CreateProductCategoryRequest, CreateProductCategoryCommand>();
            CreateMap<UpdateProductCategoryRequest, UpdateProductCategoryCommand>();
            CreateMap<CreateMeasureRequest, CreateMeasureCommand>();
            CreateMap<UpdateMeasureRequest, UpdateMeasureCommand>();
        }
    }
}