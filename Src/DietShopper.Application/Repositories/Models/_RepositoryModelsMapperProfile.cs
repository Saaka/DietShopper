using AutoMapper;
using DietShopper.Application.Queries.Products;

namespace DietShopper.Application.Repositories.Models
{
    public class RepositoryModelsMapperProfile : Profile
    {
        public RepositoryModelsMapperProfile()
        {
            CreateMap<GetSimpleProductsQuery, GetSimpleProductsQueryModel>();
        }
    }
}