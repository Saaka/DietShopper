using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DietShopper.Application.Models;
using DietShopper.Application.Repositories;
using DietShopper.Common.Requests;

namespace DietShopper.Application.Queries.ProductCategories
{
    public class GetProductCategoriesQuery : Request<IEnumerable<ProductCategoryDto>> { }

    public class GetProductCategoriesQueryHandler : RequestHandler<GetProductCategoriesQuery, IEnumerable<ProductCategoryDto>>
    {
        private readonly IMapper _mapper;
        private readonly IProductCategoriesRepository _productCategoriesRepository;

        public GetProductCategoriesQueryHandler(
            IMapper mapper,
            IProductCategoriesRepository productCategoriesRepository)
        {
            _mapper = mapper;
            _productCategoriesRepository = productCategoriesRepository;
        }
        public override async Task<RequestResult<IEnumerable<ProductCategoryDto>>> Handle(
            GetProductCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _productCategoriesRepository.GetActiveProductCategories();
            
            return request.Success(_mapper.Map<IEnumerable<ProductCategoryDto>>(categories));
        }
    }
}