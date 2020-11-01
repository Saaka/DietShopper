using AutoMapper;
using DietShopper.Application.Commands.Measures;
using DietShopper.Application.Commands.ProductCategories;

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