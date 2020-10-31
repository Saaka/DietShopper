using AutoMapper;
using DietShopper.Application.Products.Commands;

namespace DietShopper.WebAPI.Controllers.Products.Models
{
    public class ProductsMapperProfile : Profile
    {
        public ProductsMapperProfile()
        {
            CreateMap<CreateProductCategoryRequest, CreateProductCategoryCommand>();
            CreateMap<RemoveProductCategoryRequest, RemoveProductCategoryCommand>();
            CreateMap<UpdateProductCategoryRequest, UpdateProductCategoryCommand>();
            CreateMap<CreateMeasureRequest, CreateMeasureCommand>();
            CreateMap<UpdateMeasureRequest, UpdateMeasureCommand>();
        }
    }
}