using System.Threading;
using System.Threading.Tasks;
using DietShopper.Application.Auth.Models;
using DietShopper.Common.Requests;

namespace DietShopper.Application.Auth.Commands.AuthorizeUserWithGoogle
{
    public class AuthorizeUserWithGoogleCommandHandler : RequestHandler<AuthorizeUserWithGoogleCommand,AuthorizationData>
    {
        public override async Task<RequestResult<AuthorizationData>> Handle(
            AuthorizeUserWithGoogleCommand request, CancellationToken cancellationToken)
        {
            return request.ReturnSuccess(new AuthorizationData());
        }
    }
}