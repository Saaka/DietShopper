using System;
using System.Threading;
using System.Threading.Tasks;
using DietShopper.Application.Models;
using DietShopper.Application.Queries.Products.Models;
using DietShopper.Application.Repositories;
using DietShopper.Common.Requests;
using DietShopper.Domain.Enums;
using FluentValidation;

namespace DietShopper.Application.Queries.Products
{
    public class GetCompleteProductQuery : Request<CompleteProductDto>, IRequestWithBasicAuthorization
    {
        public Guid ProductGuid { get; set; }
    }

    public class GetCompleteProductQueryHandler : RequestHandler<GetCompleteProductQuery, CompleteProductDto>
    {
        private readonly IProductsRepository _productsRepository;

        public GetCompleteProductQueryHandler(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public override async Task<RequestResult<CompleteProductDto>> Handle(GetCompleteProductQuery request, CancellationToken cancellationToken)
        {
            var productData = await _productsRepository.GetCompleteProduct(request.ProductGuid);
            return productData == null 
                ? request.Failure(ErrorCode.ProductNotExists, request.ProductGuid.ToString()) 
                : request.Success(productData);
        }
    }

    public class GetCompleteProductQueryValidator : AbstractValidator<GetCompleteProductQuery>
    {
        public GetCompleteProductQueryValidator()
        {
            RuleFor(x => x.ProductGuid)
                .NotEmpty()
                .WithMessageCode(ErrorCode.ProductGuidRequired);
        }
    }
}