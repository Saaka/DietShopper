using System.Threading;
using System.Threading.Tasks;
using DietShopper.Application.Models;
using DietShopper.Application.Repositories;
using DietShopper.Common.Requests;

namespace DietShopper.Application.Commands.Products.CreateProduct
{
    public class CreateProductCommandHandler : RequestHandler<CreateProductCommand, ProductDto>
    {
        private readonly IProductCategoriesRepository _productCategoriesRepository;

        public CreateProductCommandHandler(IProductCategoriesRepository productCategoriesRepository)
        {
            _productCategoriesRepository = productCategoriesRepository;
        }
        
        public override Task<RequestResult<ProductDto>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}