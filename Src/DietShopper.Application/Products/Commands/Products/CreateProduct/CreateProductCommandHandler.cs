using System.Threading;
using System.Threading.Tasks;
using DietShopper.Application.Products.Models;
using DietShopper.Common.Requests;

namespace DietShopper.Application.Products.Commands.Products.CreateProduct
{
    public class CreateProductCommandHandler : RequestHandler<CreateProductCommand, ProductDto>
    {
        public override Task<RequestResult<ProductDto>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}