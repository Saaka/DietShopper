using System.Threading;
using System.Threading.Tasks;
using DietShopper.Application.Auth.Models;
using DietShopper.Application.Auth.Services;
using DietShopper.Common.Requests;

namespace DietShopper.Application.Auth.Commands.AuthorizeUserWithGoogle
{
    public class AuthorizeUserWithGoogleCommandHandler : RequestHandler<AuthorizeUserWithGoogleCommand,AuthorizationData>
    {
        private readonly IGoogleAuthorizationClient _googleAuthorizationClient;

        public AuthorizeUserWithGoogleCommandHandler(IGoogleAuthorizationClient googleAuthorizationClient)
        {
            _googleAuthorizationClient = googleAuthorizationClient;
        }
        
        public override async Task<RequestResult<AuthorizationData>> Handle(
            AuthorizeUserWithGoogleCommand request, CancellationToken cancellationToken)
        {
            var user = await _googleAuthorizationClient.AuthorizeWithGoogleToken(request.GoogleToken);
            
            return request.Success(user);
        }
    }
}