using System.Threading;
using System.Threading.Tasks;
using DietShopper.Application.Models;
using DietShopper.Common.Requests;

namespace DietShopper.Application.Commands.Products.UpdateProduct
{
    public class UpdateProductCommandHandler: RequestHandler<UpdateProductCommand, ProductDto>
    {
        public override async Task<RequestResult<ProductDto>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}