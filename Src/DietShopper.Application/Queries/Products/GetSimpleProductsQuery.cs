using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DietShopper.Application.Queries.Products.Models;
using DietShopper.Application.Repositories;
using DietShopper.Common.Models;
using DietShopper.Common.Requests;

namespace DietShopper.Application.Queries.Products
{
    public class GetSimpleProductsQuery : Request<PagedList<SimpleProductDto>>, IRequestWithBasicAuthorization
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }

    public class GetSimpleProductsQueryHandler : RequestHandler<GetSimpleProductsQuery, PagedList<SimpleProductDto>>
    {
        private readonly IMapper _mapper;
        private readonly IProductsRepository _productsRepository;

        public GetSimpleProductsQueryHandler(IMapper mapper, IProductsRepository productsRepository)
        {
            _mapper = mapper;
            _productsRepository = productsRepository;
        }
        public override async Task<RequestResult<PagedList<SimpleProductDto>>> Handle(GetSimpleProductsQuery request, CancellationToken cancellationToken)
        {
            var pagedList = await _productsRepository.GetSimpleProductsList(_mapper.Map<Repositories.Models.GetSimpleProductsQuery>(request));

            return request.Success(pagedList);
        }
    }
}